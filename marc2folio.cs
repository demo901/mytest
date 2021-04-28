using System;
using System.Text;

using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mytest
{
	class marc2folio
    {
		public char SUB_FIELD_SPLIT_CHAR { get; set; }//子字段分隔符		
		public string curEncoding { get; set; }//默认编码
		public bool Only_Digital_Field { get; set; }//只提取数字开头的字段
		public string req_UserAgent { get; set; }
		public string req_Accept { get; set; }

		public marc2folio()
		{
			curEncoding = "UTF-8";
			SUB_FIELD_SPLIT_CHAR = (char)0x1f;
			req_UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
			req_Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
		}
		//解析Json格式的数据
        public void get_data_from_json(string jsonText,out string code, out string message, out string success,
			out string folio_id, out string rawContent, out string marcContent)
		{
			JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);

			code = jo["code"].ToString();
			message = jo["message"].ToString();
			success = jo["success"].ToString();
			folio_id = jo["data"]["id"].ToString();
			rawContent = jo["data"]["rawContent"].ToString();
			marcContent = jo["data"]["marcContent"].ToString();
		}
		
		public string fetch_json_from_folio(string recordID)
		{
			HttpWebRequest request = null;
			string jsonText = "";
			if (Folio_Config_Info.Folio_data_get_url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
			{
				request = WebRequest.Create(Folio_Config_Info.Folio_data_get_url + recordID) as HttpWebRequest;
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
				request.ProtocolVersion = HttpVersion.Version11;         // 这里设置了协议类型。
				ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;// SecurityProtocolType.Tls1.2; 
				ServicePointManager.CheckCertificateRevocationList = true;
				ServicePointManager.DefaultConnectionLimit = 100;
				ServicePointManager.Expect100Continue = false;
			}
			else
			{
				request = (HttpWebRequest)WebRequest.Create(Folio_Config_Info.Folio_data_get_url + recordID);
			}

			request.Method = "GET";
			request.UserAgent = req_UserAgent;
			request.Accept = req_Accept;
			request.KeepAlive = true;
			request.Headers["x-okapi-tenant"] = Folio_Config_Info.Folio_tenant;
			request.Headers["x-okapi-token"] = Folio_Config_Info.Folio_token;
			try
			{
				var response = (HttpWebResponse)request.GetResponse();  //获取响应，即发送请求
				Stream responseStream = response.GetResponseStream();
				var streamReader = new StreamReader(responseStream, Encoding.UTF8);
				jsonText = streamReader.ReadToEnd();

				streamReader.Close();
				if (response != null)
					response.Close();
				if (request != null)
					request.Abort();
			}
			catch(Exception ex)
            {
				ex.ToString();
            }
			return jsonText;
		}
		public string marc2json_for_folio(string cur_id, string cur_instanceId, string marc)
		{
			string result = null;

			Encoding _encoding = Encoding.GetEncoding(curEncoding);
			var rex = new Regex(@"^\d+$");

			int MarcTextLength = Convert.ToInt32(marc.Substring(0, 5));//MARC记录文本总长度,00931
			int Data_base_addr = Convert.ToInt32(marc.Substring(12, 5));//数据字段区起始地址,00253
			int Fields_count = (Data_base_addr - 24) / 12;//字段个数,19
			string str_directory = marc.Substring(24, Data_base_addr - 24 - 1);//地址目次区字符串
			string str_data = marc.Substring(Data_base_addr);//数据字段区字符串
			byte[] str_bytes = _encoding.GetBytes(str_data);

			/* 构建json字符串 */
			string json_out_1 = "{";
			json_out_1 += "\"id\" : \"" + cur_id + "\",";
			json_out_1 += "\"instanceId\" : \"" + cur_instanceId + "\",";
			json_out_1 += "\"rawContent\" : \"";

			/* 转换marc中的不可见字符 */
			string marc_data = marc;
			marc_data = marc_data.Replace("\x1e", "\\u001e").Replace("\x1f", "\\u001f").Replace("\x1d", "\\u001d");
			json_out_1 += marc_data;

			json_out_1 += "\",";
			json_out_1 += "\"marcContent\" : {";
			json_out_1 += "\"fields\": [";

			string json_out_2 = "";
			try
			{
				for (int i = 0; i < Fields_count; i++)
				{
					string _dir = str_directory.Substring(i * 12, 12);
					if (Only_Digital_Field.Equals(true) && !rex.IsMatch(_dir.Substring(0, 3)))//跳过非数字的字段
						continue;

					int _Len = int.Parse(_dir.Substring(3, 4));
					int _Pos = int.Parse(_dir.Substring(7, 5));
					string _data = _encoding.GetString(str_bytes, _Pos, _Len);

					json_out_2 += "{\"" + _dir.Substring(0, 3) + "\": ";

					if (_dir.Substring(0, 2).Equals("00"))
					{
						json_out_2 += "\"" + _data + "\"";
						json_out_2 += "},";
						continue;
					}
					json_out_2 += "{\"ind1\": \"" + _data.Substring(0, 1) + "\", \"ind2\": \"" + _data.Substring(0, 1) + "\", \"subfields\": [";
					string[] arr = _data.Split(SUB_FIELD_SPLIT_CHAR);
					int arr_count = arr.Length;
					for (int j = 1; j < arr_count; j = j + 1)
					{
						json_out_2 += "{\"" + arr[j].Substring(0, 1) + "\":\"" + arr[j].Substring(1) + "\"},";
					}
					json_out_2 = json_out_2.Substring(0, json_out_2.Length - 1);
					json_out_2 += "]}";
					json_out_2 += "},";
				}
				json_out_2 = json_out_2.Substring(0, json_out_2.Length - 1) + "],";
				json_out_2 += "\"leader\": \"" + marc_data.Substring(0, 24) + "\"}}";

				result = json_out_1 + Regex.Replace(json_out_2, @"[\u0001-\u001F]", ""); //替换所有不可见字符为空
			}
			catch (Exception ex)
			{
				result = "MARC数据转换JSON格式出现错误: " + ex.ToString();
			}
			return result;
		}
		//更新远程服务器记录
		public string update_folio(string jsonData)
		{
			HttpWebRequest request = null;
			string result = null;

			if (Folio_Config_Info.Folio_data_update_url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
			{
				request = WebRequest.Create(Folio_Config_Info.Folio_data_update_url) as HttpWebRequest;
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
				request.ProtocolVersion = HttpVersion.Version11;
				ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
				request.KeepAlive = true;
				ServicePointManager.CheckCertificateRevocationList = true;
				ServicePointManager.DefaultConnectionLimit = 100;
				ServicePointManager.Expect100Continue = false;
			}
			else
			{
				request = (HttpWebRequest)WebRequest.Create(Folio_Config_Info.Folio_data_update_url);
			}

			request.Method = "PUT";
			request.ContentType = "application/json";
			request.Headers.Add("x-okapi-tenant", Folio_Config_Info.Folio_tenant);//加tenant
			request.Headers.Add("x-okapi-token", Folio_Config_Info.Folio_token);//加token
			request.Referer = null;
			request.AllowAutoRedirect = true;
			request.UserAgent = req_UserAgent;
			request.Accept = "*/*";

			using (Stream newStream = request.GetRequestStream())
			{
				byte[] data = Encoding.UTF8.GetBytes(jsonData);
				newStream.Write(data, 0, data.Length);
				newStream.Flush();
				newStream.Close();
			}

			HttpWebResponse response = null;
			try
			{
				response = (HttpWebResponse)request.GetResponse();
			}
			catch (WebException ex)
			{
				response = (HttpWebResponse)ex.Response;
			}

			if (Convert.ToInt32(response.StatusCode) == 200)
			{
				Stream myResponseStream = response.GetResponseStream();
				string encoding = response.ContentEncoding;
				if (encoding == null || encoding.Length < 1)
				{
					encoding = curEncoding;
				}
				using (var myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding(encoding)))
				{
					result = myStreamReader.ReadToEnd();
				}
				myResponseStream.Close();
			}
			else
			{
				result = response.StatusDescription;
			}
			response.Close();

			return result;
		}
		//获取token
		public void token_fetch()
		{
			string param = "{\"username\":\"" + Folio_Config_Info.Folio_uname 
				+ "\",\"password\":\"" + Folio_Config_Info.Folio_upass 
				+ "\",\"tenant\":\"" + Folio_Config_Info.Folio_tenant + "\"}";
			HttpWebRequest request = null;
			if (Folio_Config_Info.Folio_token_url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
			{
				request = WebRequest.Create(Folio_Config_Info.Folio_token_url) as HttpWebRequest;
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
				request.ProtocolVersion = HttpVersion.Version11;         // 这里设置了协议类型。
				ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;// SecurityProtocolType.Tls1.2; 
				request.KeepAlive = false;
				ServicePointManager.CheckCertificateRevocationList = true;
				ServicePointManager.DefaultConnectionLimit = 100;
				ServicePointManager.Expect100Continue = false;
			}
			else
			{
				request = (HttpWebRequest)WebRequest.Create(Folio_Config_Info.Folio_token_url);
			}

			request.Method = "POST";
			request.ContentType = "application/json";
			request.Headers.Add("x-okapi-tenant", Folio_Config_Info.Folio_tenant);
			request.Referer = null;
			request.AllowAutoRedirect = true;
			request.UserAgent = req_UserAgent;
			request.Accept = "*/*";

			byte[] data = Encoding.ASCII.GetBytes(param);
			Stream newStream = request.GetRequestStream();
			newStream.Write(data, 0, data.Length);
			newStream.Close();

			Folio_Config_Info.Folio_token = "";
			try
			{
				var response = (HttpWebResponse)request.GetResponse();
				for (int i = 0; i < response.Headers.Keys.Count; i++)
				{
					if (response.Headers.Keys[i].Trim().Equals("x-okapi-token"))
					{
						Folio_Config_Info.Folio_token = response.Headers.Get(i);
						break;
					}
				}
			}
			catch(Exception ex)
            {
				ex.ToString();
            }
		}
		bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			return true; //总是接受  
		}
		
		//使用GET请求获取任务列表
		public string task_fetch(string status,int pagenum,int pagesize)
		{
			HttpWebRequest request = null;
			string url = Folio_Config_Info.Folio_task_url + "?status=" + status + "&pageSize=" + pagesize + "&pageNum=" + pagenum;
			Console.WriteLine(url);
			if (Folio_Config_Info.Folio_task_url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
			{
				request = WebRequest.Create(url) as HttpWebRequest;
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
				request.ProtocolVersion = HttpVersion.Version11;         // 这里设置了协议类型。
				ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;// SecurityProtocolType.Tls1.2; 
				ServicePointManager.CheckCertificateRevocationList = true;
				ServicePointManager.DefaultConnectionLimit = 100;
				ServicePointManager.Expect100Continue = false;
			}
			else
			{
				request = (HttpWebRequest)WebRequest.Create(url);
			}

			request.Method = "GET";
			request.UserAgent = req_UserAgent;
			request.Accept = req_Accept;
			request.KeepAlive = true;
			request.Headers["x-okapi-tenant"] = Folio_Config_Info.Folio_tenant;
			request.Headers["x-okapi-token"] = Folio_Config_Info.Folio_token;

			string res = "";

			try
			{
				var response = (HttpWebResponse)request.GetResponse();
				Stream responseStream = response.GetResponseStream();
				var streamReader = new StreamReader(responseStream, Encoding.UTF8);
				res = streamReader.ReadToEnd();

				streamReader.Close();
				if (response != null)
					response.Close();
				if (request != null)
					request.Abort();
			}catch(Exception ex)
            {
				ex.ToString();
            }
			return res;
		}

		//根据instanceID获取图片列表
		public string image_fetch(string instanceID)
		{
			HttpWebRequest request = null;
			string url = Folio_Config_Info.Folio_image_url + "?instanceId=" + instanceID;
			if (Folio_Config_Info.Folio_image_url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
			{
				request = WebRequest.Create(url) as HttpWebRequest;
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
				request.ProtocolVersion = HttpVersion.Version11;
				ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
				ServicePointManager.CheckCertificateRevocationList = true;
				ServicePointManager.DefaultConnectionLimit = 100;
				ServicePointManager.Expect100Continue = false;
			}
			else
			{
				request = (HttpWebRequest)WebRequest.Create(url);
			}

			request.Method = "GET";
			request.UserAgent = req_UserAgent;
			request.Accept = req_Accept;
			request.KeepAlive = true;
			request.ContentType = "application/json";
			request.Headers["x-okapi-tenant"] = Folio_Config_Info.Folio_tenant;
			request.Headers["x-okapi-token"] = Folio_Config_Info.Folio_token;

			string res = "";
			try
			{
				var response = (HttpWebResponse)request.GetResponse();
				Stream responseStream = response.GetResponseStream();
				var streamReader = new StreamReader(responseStream, Encoding.UTF8);
				res = streamReader.ReadToEnd();

				streamReader.Close();
				if (response != null)
					response.Close();
				if (request != null)
					request.Abort();
			}catch(Exception ex)
            {
				ex.ToString();
            }
			return res;
		}
	}
}
