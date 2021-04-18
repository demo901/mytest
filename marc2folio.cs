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
	public class json_Record
    {
		public string id { get; set; }
		public string snapshotId { get; set; }
		public string matchedProfileId { get; set; }
		public string matchedId { get; set; }
		public string generation { get; set; }
		public string recordType { get; set; }
		public string deleted { get; set; }
		public string order { get; set; }
		public string externalIdsHolder { get; set; }
		public string instanceId { get; set; }
		public string additionalInfo { get; set; }
		public string metadata { get; set; }

		public string rawRecord { get; set; }
		public string rawRecordId { get; set; }
		public string rawRecordContent { get; set; }

		public string parsedRecord { get; set; }
		public string parsedRecordId { get; set; }
		public string parsedRecordContent { get; set; }

		public string errorRecord { get; set; }
	}
	class marc2folio
    {
		public char SUB_FIELD_SPLIT_CHAR { get; set; }//子字段分隔符		
		public string curEncoding { get; set; }//默认编码
		public bool Only_Digital_Field { get; set; }//只提取数字开头的字段

		public string req_UserAgent { get; set; }
		public string req_Accept { get; set; }

		public string url_token { get; set; }
		public string url_record { get; set; }
		public string url_record_catalog { get; set; }
		public string url_record_image { get; set; }
		public string cur_Tenant { get; set; }
		public string cur_Token { get; set; }
		public string user_name { get; set; }
		public string user_pass { get; set; }
		public string jsonText { get; set; }
		public string dcmarcText { get; set; }

		public json_Record json_record = new json_Record();


		public marc2folio(string uname, string upass, string tenant, string token, string url,
			string url_catalog,string url_image)
		{
			curEncoding = "UTF-8";
			SUB_FIELD_SPLIT_CHAR = (char)0x1f;
			req_UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
			req_Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";

			user_name = uname;
			user_pass = upass;
			cur_Tenant = tenant;
			url_token = token;
			url_record = url;
			url_record_catalog = url_catalog;
			url_record_image = url_image;
		}

		public void json_data_process()
		{
			JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);

			json_record.id = jo["id"].ToString();
			json_record.snapshotId = jo["snapshotId"].ToString();
			try
			{
				json_record.matchedProfileId = jo["matchedProfileId"].ToString();
			}
			catch (Exception e1) { e1.ToString(); }

			json_record.matchedId = jo["matchedId"].ToString();
			json_record.generation = jo["generation"].ToString();
			json_record.recordType = jo["recordType"].ToString();
			json_record.deleted = jo["deleted"].ToString();
			try
			{
				json_record.order = jo["order"].ToString();
			}catch(Exception e1) { e1.ToString(); }

			json_record.externalIdsHolder = jo["externalIdsHolder"].ToString();
			json_record.instanceId = jo["externalIdsHolder"]["instanceId"].ToString();
			try
			{
				json_record.additionalInfo = jo["additionalInfo"].ToString();
				json_record.metadata = jo["metadata"].ToString();
			}catch(Exception e1) { e1.ToString(); }

			json_record.rawRecord = jo["rawRecord"].ToString();
			json_record.rawRecordId = jo["rawRecord"]["id"].ToString();
			json_record.rawRecordContent = jo["rawRecord"]["content"].ToString();

			json_record.parsedRecord = jo["parsedRecord"].ToString();
			json_record.parsedRecordId = jo["parsedRecord"]["id"].ToString();
			json_record.parsedRecordContent = jo["parsedRecord"]["content"].ToString();
			try
			{
				json_record.errorRecord = jo["errorRecord"].ToString();
			}catch(Exception e1) { e1.ToString(); }
		}

		/*
		 * 将标准MARC转换为丹诚格式
		 */
		public void marc2dc()
        {
			Encoding _encoding = Encoding.GetEncoding(curEncoding);
			var rex = new Regex(@"^\d+$");

			int MarcTextLength = Convert.ToInt32(json_record.rawRecordContent.Substring(0, 5));//MARC记录文本总长度,00931
			int Data_base_addr = Convert.ToInt32(json_record.rawRecordContent.Substring(12, 5));//数据字段区起始地址,00253
			int Fields_count = (Data_base_addr - 24) / 12;//字段个数,19
			string str_directory = json_record.rawRecordContent.Substring(24, Data_base_addr - 24 - 1);//地址目次区字符串
			string str_data = json_record.rawRecordContent.Substring(Data_base_addr);//数据字段区字符串
			byte[] str_bytes = _encoding.GetBytes(str_data);

			dcmarcText = json_record.rawRecordContent.Substring(0,24);
			for (int i = 0; i < Fields_count; i++)
			{
				string _dir = str_directory.Substring(i * 12, 12);
				if (Only_Digital_Field.Equals(true) && !rex.IsMatch(_dir.Substring(0, 3)))//跳过非数字的字段
					continue;

				int _Len = int.Parse(_dir.Substring(3, 4));
				int _Pos = int.Parse(_dir.Substring(7, 5));

				dcmarcText += _dir.Substring(0, 3) + _encoding.GetString(str_bytes, _Pos, _Len);
			}
		}

		/*
		 * 将丹诚格式转换为标准MARC
		 */
		public string dc2marc(string dcmarc)
        {
			string leader = dcmarc.Substring(0, 24);
			string[] arr = dcmarc.Substring(24).Split((char)0x1E);
			string tag = "000";
			string fld = "";
			int len = 0;
			int base_addr = 0;
			string _dir = "";
			string _data = "";

			try
			{
				for (int i = 0; i < arr.Length; i++)
				{
					tag = arr[i].Substring(0, 3);
					fld = arr[i].Substring(3);
					len = Encoding.UTF8.GetBytes(fld).Length + 1;

					_dir += tag + len.ToString().PadLeft(4, '0') + base_addr.ToString().PadLeft(5, '0');
					base_addr += len;
					_data += fld + (char)0x1e;
				}
			}catch(Exception ex) { ex.ToString(); }

			return leader + _dir + (char)0x1e + _data;
		}

		/*
		 * 将标准MARC转换为JSON格式
		 */
		public string marc2json(string marc)
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
			json_out_1 += "\"id\" : \"" + json_record.id + "\",";
			json_out_1 += "\"snapshotId\" : \"" + json_record.snapshotId + "\",";
			json_out_1 += "\"matchedProfileId\" : null,";
			json_out_1 += "\"matchedId\" : \"" + json_record.matchedId + "\",";
			json_out_1 += "\"generation\" : 0,";
			json_out_1 += "\"recordType\" : \"MARC\",";
			json_out_1 += "\"deleted\" : \"false\",";
			json_out_1 += "\"order\" : null,";
			json_out_1 += "\"externalIdsHolder\" : {\"instanceId\": \"" + json_record.instanceId + "\"},";
			json_out_1 += "\"additionalInfo\" : null,";
			json_out_1 += "\"metadata\" : null,";
			json_out_1 += "\"rawRecord\" : {";
			json_out_1 += "\"id\": \"" + json_record.rawRecordId + "\",";
			json_out_1 += "\"content\": \"";

			/* 转换marc中的不可见字符 */
			string marc_data = marc;
			marc_data = marc_data.Replace("\x1e", "\\u001e").Replace("\x1f", "\\u001f").Replace("\x1d", "\\u001d");
			json_out_1 += marc_data;

			json_out_1 += "\"},";
			json_out_1 += "\"parsedRecord\" : {";
			json_out_1 += "\"id\": \"" + json_record.parsedRecordId + "\",";
			json_out_1 += "\"content\": {";
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
					{//00开头的字段没有指示符？
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
				json_out_2 += "\"leader\": \"" + marc_data.Substring(0, 24) + "\"}},";
				json_out_2 += "\"errorRecord\" : null}";

				result = json_out_1 + Regex.Replace(json_out_2, @"[\u0001-\u001F]", ""); //替换所有不可见字符为空
			}
			catch (Exception ex)
			{
				result = "MARC数据转换JSON格式出现错误: " + ex.ToString();
			}
			return result;
		}
		public void data_fetch(string recordID)
		{
			HttpWebRequest request = null;
			if (url_record.StartsWith("https", StringComparison.OrdinalIgnoreCase))
			{
				request = WebRequest.Create(url_record + "/" + recordID) as HttpWebRequest;
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
				request.ProtocolVersion = HttpVersion.Version11;         // 这里设置了协议类型。
				ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;// SecurityProtocolType.Tls1.2; 
				ServicePointManager.CheckCertificateRevocationList = true;
				ServicePointManager.DefaultConnectionLimit = 100;
				ServicePointManager.Expect100Continue = false;
			}
			else
			{
				request = (HttpWebRequest)WebRequest.Create(url_record + "/" + recordID);
			}

			request.Method = "GET";
			request.UserAgent = req_UserAgent;
			request.Accept = req_Accept;
			request.KeepAlive = true;
			request.Headers["x-okapi-tenant"] = cur_Tenant;
			request.Headers["x-okapi-token"] = cur_Token;

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
		public string data_post(string postData)
		{
			HttpWebRequest request = null;
			string result = null;

			if (url_record.StartsWith("https", StringComparison.OrdinalIgnoreCase))
			{
				request = WebRequest.Create(url_record) as HttpWebRequest;
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
				request.ProtocolVersion = HttpVersion.Version11;         // 这里设置了协议类型。
				ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;// SecurityProtocolType.Tls1.2; 
				request.KeepAlive = true;
				ServicePointManager.CheckCertificateRevocationList = true;
				ServicePointManager.DefaultConnectionLimit = 100;
				ServicePointManager.Expect100Continue = false;
			}
			else
			{
				request = (HttpWebRequest)WebRequest.Create(url_record);
			}

			request.Method = "POST";
			request.ContentType = "application/json";
			request.Headers.Add("x-okapi-tenant", cur_Tenant);//加tenant
			request.Headers.Add("x-okapi-token", cur_Token);//加token

			request.Referer = null;
			request.AllowAutoRedirect = true;
			request.UserAgent = req_UserAgent;
			request.Accept = "*/*";

			using (Stream newStream = request.GetRequestStream())
			{
				byte[] data = Encoding.UTF8.GetBytes(postData);
				newStream.Write(data, 0, data.Length);
				newStream.Flush();
				newStream.Close();
			}

			//获取网页响应结果
			HttpWebResponse response = null;
			try
			{
				response = (HttpWebResponse)request.GetResponse();
			}
			catch (WebException ex)
			{
				response = (HttpWebResponse)ex.Response;
			}

			if (Convert.ToInt32(response.StatusCode) == 201)
			{//服务器返回正确值
				Stream myResponseStream = response.GetResponseStream();
				string encoding = response.ContentEncoding;
				if (encoding == null || encoding.Length < 1)
				{
					encoding = curEncoding; //默认编码 
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
		public void token_fetch()
		{
			string param = "{\"username\":\"" + user_name + "\",\"password\":\"" + user_pass + "\",\"tenant\":\"" + cur_Tenant + "\"}";
			HttpWebRequest request = null;
			if (url_token.StartsWith("https", StringComparison.OrdinalIgnoreCase))
			{
				request = WebRequest.Create(url_token) as HttpWebRequest;
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
				request = (HttpWebRequest)WebRequest.Create(url_token);
			}

			request.Method = "POST";    //使用post方式发送数据
			request.ContentType = "application/json";
			request.Headers.Add("x-okapi-tenant", cur_Tenant);

			request.Referer = null;
			request.AllowAutoRedirect = true;
			request.UserAgent = req_UserAgent;
			request.Accept = "*/*";

			byte[] data = Encoding.ASCII.GetBytes(param);
			Stream newStream = request.GetRequestStream();
			newStream.Write(data, 0, data.Length);
			newStream.Close();

			//获取网页响应结果
			cur_Token = "";
			try
			{
				var response = (HttpWebResponse)request.GetResponse();
				for (int i = 0; i < response.Headers.Keys.Count; i++)
				{
					if (response.Headers.Keys[i].Trim().Equals("x-okapi-token"))
					{
						cur_Token = response.Headers.Get(i);
						break;
					}
				}
			}
			catch(Exception ex)
            {
				ex.ToString();
				cur_Token = "";
            }
		}
		bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			return true; //总是接受  
		}

		public string catalog_fetch(string status,int pagenum,int pagesize)
		{
			HttpWebRequest request = null;
			string url = url_record_catalog + "?status=" + status + "&pageNum=" + pagenum + "&pageSize=" + pagesize;
			if (url_record_catalog.StartsWith("https", StringComparison.OrdinalIgnoreCase))
			{
				request = WebRequest.Create(url_record_catalog) as HttpWebRequest;
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
				request.ProtocolVersion = HttpVersion.Version11;         // 这里设置了协议类型。
				ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;// SecurityProtocolType.Tls1.2; 
				ServicePointManager.CheckCertificateRevocationList = true;
				ServicePointManager.DefaultConnectionLimit = 100;
				ServicePointManager.Expect100Continue = false;
			}
			else
			{
				request = (HttpWebRequest)WebRequest.Create(url_record_catalog);
			}

			request.Method = "GET";
			request.UserAgent = req_UserAgent;
			request.Accept = req_Accept;
			request.KeepAlive = true;
			request.ContentType = "application/json";
			request.Headers["x-okapi-tenant"] = cur_Tenant;
			request.Headers["x-okapi-token"] = cur_Token;

			var response = (HttpWebResponse)request.GetResponse();  //获取响应，即发送请求
			Stream responseStream = response.GetResponseStream();
			var streamReader = new StreamReader(responseStream, Encoding.UTF8);
			string res = streamReader.ReadToEnd();

			streamReader.Close();
			if (response != null)
				response.Close();
			if (request != null)
				request.Abort();

			return res;
		}
	}
}
