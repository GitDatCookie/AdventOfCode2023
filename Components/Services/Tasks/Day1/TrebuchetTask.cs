using AdventOfCode2023Blazor.Components.Models;
using System.Globalization;

namespace AdventOfCode2023Blazor.Components.Services.Tasks.Day1
{
    public class TrebuchetTask : BaseCodingTask
    {
        public TrebuchetTask(TaskModel taskModel) : base(taskModel) { }

        enum EDigits
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9
        }

        public override string SolveTask()
        {
            var eDigits = Enum.GetValues(typeof(EDigits))
            .Cast<EDigits>()
            .ToDictionary(word => word.ToString().ToLower(), word => (int)word);

            result = firstPart 
                ? new TrebuchetPart1(preProcessedLines).Result() 
                : new TrebuchetPart2(preProcessedLines, eDigits).Result();

            return result;
        }
    }
}
