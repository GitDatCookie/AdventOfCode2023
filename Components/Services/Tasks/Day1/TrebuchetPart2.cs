namespace AdventOfCode2023Blazor.Components.Services.Tasks.Day1
{
    public class TrebuchetPart2
    {
        private string[] lines { get; set; }
        private Dictionary<string, int>? eDigits { get; set; }

        public TrebuchetPart2(string[] inputLines, Dictionary<string, int>? enumDictionary)
        {
            lines = inputLines;
            eDigits= enumDictionary;
        }

        public string Result()
        {
            int sum = lines.Select(line =>
            {
                var digits = line
                    .Select((character, index) =>
                    {
                        if (char.IsDigit(character))
                            return (int)char.GetNumericValue(character);

                        var wordDigit = eDigits.Keys
                        .FirstOrDefault(word => line.Substring(index).StartsWith(word));

                        return wordDigit != null ? eDigits[wordDigit] : (int?)null;
                    })
                    .Where(digit => digit.HasValue)
                    .Select(digit => digit.Value)
                    .ToList();

                return digits.Count > 0
                ? int.Parse($"{digits[0]}{digits[digits.Count - 1]}")
                : 0;
            })
            .Sum();

            return sum.ToString();
        }
    }
}
