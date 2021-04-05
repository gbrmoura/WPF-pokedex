using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Linq;

namespace pokedex.Utils
{
    class HttpRequest {
        public static CookieContainer cookies;
        static HttpRequest() {
            cookies = new CookieContainer();
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
        }
        public void SetCookie(string url, string cookiename, string cookievalue) {
            Uri target = new Uri(url);
            cookies.Add(new Cookie(cookiename, cookievalue) { Domain = target.Host });
        }

        public static string HttpPostRequest(string url, Dictionary<string, string> postParameters) {
            string postData = "";

            foreach (string key in postParameters.Keys) {
                if (key == "tags") {
                    string tags = postParameters[key];
                    string[] words = tags.Split(';');

                    foreach (var word in words) {
                        postData += "tags="
                        + Uri.EscapeDataString(word) + "&";
                    } 
                } else {
                    postData += key + "=" + Uri.EscapeDataString(postParameters[key]) + "&";
                }
            }

            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            myHttpWebRequest.Method = "POST";
            myHttpWebRequest.CookieContainer = cookies;

            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] data = utf8.GetBytes(postData);

            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            myHttpWebRequest.ContentLength = data.Length;
            myHttpWebRequest.UserAgent = @"Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.1667.0 Safari/537.36";
            myHttpWebRequest.KeepAlive = true;
            myHttpWebRequest.AllowAutoRedirect = true;
            Stream requestStream = myHttpWebRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            Stream responseStream = myHttpWebResponse.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            responseStream.Close();

            myHttpWebResponse.Close();

            return pageContent;
        }

        public static string HttpGetRequest(string url) {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            myHttpWebRequest.Method = "GET";
            myHttpWebRequest.CookieContainer = cookies;
            myHttpWebRequest.UserAgent = @"Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.1667.0 Safari/537.36";
            myHttpWebRequest.AllowAutoRedirect = true;

            var response = (HttpWebResponse)myHttpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream())) {
                return streamReader.ReadToEnd();
            }
        }

        public static bool HttpGetDownload(string url, string arquivo) {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            myHttpWebRequest.Method = "GET";
            myHttpWebRequest.CookieContainer = cookies;
            myHttpWebRequest.UserAgent = @"Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.1667.0 Safari/537.36";
            myHttpWebRequest.AllowAutoRedirect = true;

            var response = (HttpWebResponse)myHttpWebRequest.GetResponse();
            using (Stream stream = response.GetResponseStream()) {
                using (FileStream fs = File.Create(arquivo)) {
                    stream.CopyTo(fs);
                }
            }
            return true;
        }
        public static void HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc) {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            wr.CookieContainer = cookies;
            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys) {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0) {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
            } catch (Exception ex) {

                if (wresp != null) {
                    wresp.Close();
                    wresp = null;
                }
            } finally {
                wr = null;
            }
        }

        public static void LimpaCookies(string url) {
            if (cookies != null) {
                cookies.GetCookies(new Uri(url))
                           .Cast<Cookie>()
                           .ToList()
                           .ForEach(c => c.Expired = true);
            }
        }
    }
}
