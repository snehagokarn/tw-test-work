using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ChallengeThreeInput
    {
        public List<ToolUsage> toolUsage { get; set; }
    }

    public class ChallengeThreeOutput
    {
        public List<ToolsSorted> toolsSortedOnUsage { get; set; }
    }

    public class ToolUsage {
        public string name { get; set; }
        public DateTime useStartTime { get; set; }
        public DateTime useEndTime { get; set; }

    }

    public class ToolsSorted {

        public string name { get; set; }
        public double timeUsedInMinutes { get; set; }
    }
}
