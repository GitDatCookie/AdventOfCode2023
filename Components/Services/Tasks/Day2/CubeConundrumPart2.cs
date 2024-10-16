namespace AdventOfCode2023Blazor.Components.Services.Tasks.Day2
{
    public class CubeConundrumPart2
    {
        private Dictionary<int, List<KeyValuePair<string, int>>> dictionary { get; set; }
        public CubeConundrumPart2(Dictionary<int, List<KeyValuePair<string, int>>> inputDictionary)
        {
            dictionary = inputDictionary;
        }

        public string Result()
        {
            int sum = dictionary.Select(line =>
            {
                return MultiplyMinimumPairs(line.Value);
            })
            .Sum();

            return sum.ToString();
        }

        public int MultiplyMinimumPairs(List<KeyValuePair<string, int>> inputPairs)
        {
            var minimumCount = inputPairs
                .GroupBy(pair => pair.Key)
                .Select(group => group.Max(pair => pair.Value))
                .ToArray();

            return minimumCount.Aggregate(1, (accumulation, multiplier) => accumulation * multiplier);
        }
    }
}
