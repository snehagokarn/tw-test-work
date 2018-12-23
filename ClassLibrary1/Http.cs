using System;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public class Http
    {
        public const string InputUrl = "https://http-hunt.thoughtworks-labs.net/challenge/input";
        public const string OutputUrl = "https://http-hunt.thoughtworks-labs.net/challenge/output";
        public static string Get(string url)
        {
            WebRequest req = System.Net.WebRequest.Create(url);
            req.ContentType = "application/json";
            req.Headers.Add("userId", "RhcycwZag");
            WebResponse resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            
            return sr.ReadToEnd().Trim();
        }

        public static string Post(string url, string body)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Headers.Add("userId", "RhcycwZag");
            http.Method = "POST";
            string parsedContent = body;
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();

            return content;
        }
    }
}
