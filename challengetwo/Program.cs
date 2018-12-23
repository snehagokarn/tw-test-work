using System;
using System.Text;
using System.Net;
using System.IO;
using ClassLibrary1;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace challengetwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = string.Empty;
            var sampleInput = JsonConvert.DeserializeObject<ChallengetwoInput>(Get("https://http-hunt.thoughtworks-labs.net/challenge/input"));
            var hiddenTools = sampleInput.tools;
            var toolsFound = new List<string>();
            foreach (var tool in hiddenTools)
            {
                var toolIndex = new List<int>();
                var distinct = sampleInput.hiddenTools.ToCharArray();
                foreach (var item in tool.ToCharArray())
                {
                    var exists = distinct.Contains(item);
                    if (exists)
                    {
                        toolIndex.Add(item);
                    }
                }

                if (toolIndex.Count() == tool.ToCharArray().Length)
                {
                    toolsFound.Add(tool);
                }
            }

            //toolsFound.Add("rope");
            //toolsFound.Add("flare");
            //toolsFound.Add("crowbar");
            //toolsFound.Add("chocolate");

            var sampleOutput = new ChallengetwoOutput() { toolsFound = toolsFound.ToArray() };
            var outputFromChallenge = HttpPost("https://http-hunt.thoughtworks-labs.net/challenge/output", JsonConvert.SerializeObject(sampleOutput));
            Console.WriteLine(outputFromChallenge);
            Console.Read();
        }

        private static string Get(string url)
        {
            WebRequest req = System.Net.WebRequest.Create(url);
            req.ContentType = "application/json";
            req.Headers.Add("userId", "RhcycwZag");
            WebResponse resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public static string HttpPost(string url, string body)
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
