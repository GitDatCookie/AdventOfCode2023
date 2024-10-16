using AdventOfCode2023Blazor.Components.Models;
using AdventOfCode2023Blazor.Components.Services.Tasks.Day1;

namespace AdventOfCode2023Blazor.Components.Services.Tasks.Day2
{
    public class CubeConundrumTask : BaseCodingTask
    {
        public CubeConundrumTask(TaskModel taskModel) : base(taskModel) { }

        public override string SolveTask()
        {
            result = firstPart
                ? new CubeConundrumPart1(PreProcessData()).Result()
                : new CubeConundrumPart2(PreProcessData()).Result();

            return result;
        }

        private Dictionary<int, List<KeyValuePair<string, int>>> PreProcessData()
        {
            var linesDictionary = preProcessedLines.Select(line =>
            {
                int.TryParse(line.Split(": ")[0].Split(' ')[1], out int gameID);

                var sets = line.Split(":")[1]
                    .Split(';')
                    .SelectMany(set => set.Split(',')
                        .Select(pair =>
                        {
                            var parts = pair.Split(' ');
                            return new KeyValuePair<string, int>(parts[2], int.Parse(parts[1]));
                        }))
                        .ToList();
                return new { gameID, sets };
            }).ToDictionary(x => x.gameID, x => x.sets);

            return linesDictionary;
        }
    }
}

