using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace PrettyGood.Util
{
	public static class Web
	{
		public static bool PageExist(string url)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			//request.ReadWriteTimeout = 1000;
			request.AllowAutoRedirect = true;

			// execute the request
			try
			{
				using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
				{
					// we will read data via the response stream
					using (Stream s = response.GetResponseStream())
					{
						return true;
					}
				}
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					return false;
				}
				else throw ex;
			}
		}

		public static bool IsUrl(string text)
		{
			Uri.IsWellFormedUriString(text, UriKind.Absolute);
			return true;
		}

		public static string FetchString(string url, ref Encoding enc)
		{
			// used to build entire input
			StringBuilder sb = new StringBuilder();
			string tempString = null;
			int count = 0;

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.ReadWriteTimeout = 1000;

			// execute the request
			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			{
				// we will read data via the response stream
				using (Stream resStream = response.GetResponseStream())
				{
					byte[] buf = new byte[8192];
					do
					{
						count = resStream.Read(buf, 0, buf.Length);

						if (count != 0)
						{
							string name = response.CharacterSet;
							if (false == string.IsNullOrEmpty(name)) enc = Encoding.GetEncoding(response.CharacterSet);
							tempString = enc.GetString(buf, 0, count);
							//Encoding.ASCII.GetString(buf, 0, count);
							sb.Append(tempString);
						}
					}
					while (count > 0);
				}
			}

			return sb.ToString();
		}

		public static void OpenUrl(string url)
		{
			Process.Start(url);
		}

		public static void DownloadFile(string url, string target)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.ReadWriteTimeout = 1000;

			// execute the request
			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			{
				// we will read data via the response stream
				using (Stream resStream = response.GetResponseStream())
				{
					using (FileStream fs = File.Open(target, FileMode.Create))
					{
						byte[] buf = new byte[8192];
						int count = 0;
						do
						{
							count = resStream.Read(buf, 0, buf.Length);

							if (count != 0)
							{
								fs.Write(buf, 0, count);
							}
						}
						while (count > 0);
					}
				}
			}
		}
	}
}