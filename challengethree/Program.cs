using System;
using System.Text;
using System.Net;
using System.IO;
using ClassLibrary1;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace challengethree
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = string.Empty;
            var sampleInput = JsonConvert.DeserializeObject<ChallengeThreeInput>(Http.Get(Http.InputUrl));
            var toolUsage = sampleInput.toolUsage;
            var sortedToolsTime = toolUsage.
                GroupBy(t => t.name, t => t, (key, g) =>
                new ToolsSorted()
                {
                    name = key,
                    timeUsedInMinutes = g.Sum(z => (z.useEndTime - z.useStartTime).TotalMinutes)
                })
                    .OrderByDescending(x => x.timeUsedInMinutes).ToList();


            var sampleOutput = new ChallengeThreeOutput() { toolsSortedOnUsage = sortedToolsTime };
            var outputFromChallenge = Http.Post(Http.OutputUrl, JsonConvert.SerializeObject(sampleOutput));
            Console.WriteLine(outputFromChallenge);
            Console.Read();
        }
    }
}
