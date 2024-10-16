namespace AdventOfCode2023Blazor.Components.Services.Tasks.Day2
{
    public class CubeConundrumPart1
    {
        private Dictionary<int, List<KeyValuePair<string, int>>> dictionary { get; set; }
        public CubeConundrumPart1(Dictionary<int, List<KeyValuePair<string, int>>> inputDictionary)
        {
            dictionary = inputDictionary;
        }

        public string Result()
        {
            int sum = dictionary.Select(line =>
            {
                return line.Value.Any(pair => ComparePairs(pair.Key, pair.Value)) ? 0 : line.Key;
            })
            .Sum();

            return sum.ToString();
        }

        public bool ComparePairs(string colour, int count) =>
            colour switch
            {
                "red" => count > 12,
                "green" => count > 13,
                "blue" => count > 14,
                _ => false
            };

    }
}
