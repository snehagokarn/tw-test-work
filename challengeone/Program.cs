using System;
using System.Text;
using System.Net;
using System.IO;
using ClassLibrary1;
using Newtonsoft.Json;

namespace challengeone
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = string.Empty;
            var sampleInput = JsonConvert.DeserializeObject<Input>(Http.Get(Http.InputUrl));
            int key = Convert.ToInt32(sampleInput.key);
            byte[] asciiBytes = Encoding.ASCII.GetBytes(sampleInput.encryptedMessage);

            foreach (var item in asciiBytes)
            {
                var itemProcessed = item - key;

                if (itemProcessed >= 65 && itemProcessed <= 90)
                {
                    var outputString = Convert.ToChar(itemProcessed);
                    output = output + outputString;
                }
                else if (itemProcessed < 65 && !(item >= 32 && item < 65))
                {
                    var remainder = itemProcessed % key;
                    var tooSmall = Convert.ToChar((90 - (key - (item - 65)) + 1));
                    output = output + tooSmall;
                }
                else
                {
                    output = output + Convert.ToChar(item);
                }
            }

            var sampleOutput =  new Output() { message = output };
            var outputFromChallenge = Http.Post(Http.OutputUrl, JsonConvert.SerializeObject(sampleOutput));
            Console.WriteLine(outputFromChallenge);
            Console.Read();
        }
    }
}
