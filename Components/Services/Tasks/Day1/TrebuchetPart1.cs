namespace AdventOfCode2023Blazor.Components.Services.Tasks.Day1
{
    public class TrebuchetPart1
    {
        private string[] lines{ get; set; }
        public TrebuchetPart1(string[] inputLines)
        {
            lines = inputLines;
        }

        public string Result()
        {
            int sum = lines
            .Select(line =>
            {
                var digits = line
                .Where(char.IsDigit)
                .Select(d => (int)char.GetNumericValue(d))
                .ToList();

                return digits.Count > 0 ? int.Parse($"{digits[0]}{digits[digits.Count - 1]}") : 0;
            })
            .Sum();

            return sum.ToString();
        }
    }
}

