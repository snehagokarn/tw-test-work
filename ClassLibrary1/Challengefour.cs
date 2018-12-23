using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ChallengefourInput
    {
        public Tool[] tools { get; set; }
        public int maximumWeight { get; set; }
    }

    public class Tool
    {
        public string name { get; set; }
        public int weight { get; set; }
        public int value { get; set; }
        public int? originalWeight { get; set; }
        public int? originalValue { get; set; }
    }

    public class ChallengefourOutput
    {
        public string[] toolsToTakeSorted { get; set; }
    }
}
