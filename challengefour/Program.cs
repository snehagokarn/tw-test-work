using ClassLibrary1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace challengefour
{
    class Program
    {
        static void Main(string[] args)
        {
            var sampleInput = JsonConvert.DeserializeObject<ChallengefourInput>(Http.Get(Http.OutputUrl));
            var tools = sampleInput.tools.OrderBy(x => x.weight).ToArray();

            var maxWeight = sampleInput.maximumWeight;
            var sortedTools = new List<Tool>();

            foreach (var tool in tools)
            {
                for (int i = 0; i <= tools.Length; i++)
                {
                    //This is for adding individually
                    if (i < tools.Length && tools[i].weight != tool.weight)
                    {
                        var nextWeight = tools[i].weight + tool.weight;
                        var nextValue = tools[i].value + tool.value;

                        if (nextWeight <= maxWeight)
                        {
                            sortedTools.Add(new Tool() { name = tool.name, weight = nextWeight, value = nextValue, originalValue = tool.value, originalWeight = tool.weight });
                        }
                    }
                    //This is for a recursive add
                    var value = 0;
                    var perfectWeight = Recursive(tool, tools, i, out value);
                    if (perfectWeight <= maxWeight)
                    {
                        sortedTools.Add(new Tool() { name = tool.name, weight = perfectWeight, value = value, originalValue = tool.value, originalWeight = tool.weight });
                    }
                }
            }

            var sortedToolsTime = sortedTools
                .OrderByDescending(x => x.originalValue)
                .GroupBy(t => new { t.weight, t.value }, t => t)
                .Select(g => new
                {
                    tools = g.ToList(),
                    value = g.Max(p => p.value)
                }).OrderByDescending(x => x.value).First().tools.Select(x => x.name).Distinct()
                .ToArray();

            var sampleOutput = new ChallengefourOutput() { toolsToTakeSorted = sortedToolsTime };
            var outputFromChallenge = Http.Post(Http.OutputUrl, JsonConvert.SerializeObject(sampleOutput));
            Console.WriteLine(outputFromChallenge);
            Console.Read();
        }

        private static int Recursive(Tool tool, Tool[] tools, int numberofLoops, out int summedValue)
        {
            var perfectWeight = tool.weight;
            summedValue = tool.value;
            for (int i = 0; i < numberofLoops; i++)
            {
                if (tool.weight != tools[i].weight)
                {
                    perfectWeight = perfectWeight + tools[i].weight;
                    summedValue = summedValue + tools[i].value;
                }
            }

            return perfectWeight;
        }
    }
}
