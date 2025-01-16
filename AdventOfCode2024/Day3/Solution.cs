using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day3;

internal static class Solution
{
    public static void Run()
    {
        var input = string.Empty;
        using (var stream = File.OpenRead(Path.Combine("Day3", "input.txt")))
        using (var reader = new StreamReader(stream))
        {
            var line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                input += line;
            }
        }

        var sum = 0;

        var regex = new Regex(@"(mul\(\d+,\d+\))|(do\(\))|(don't\(\))");

        MatchCollection matches = regex.Matches(input);

        var disabled = false;
        foreach (Match match in matches)
        {
            if (match.Value.Equals("do()"))
            {
                disabled = false;
                continue;
            }
            if (match.Value.Equals("don't()"))
            {
                disabled = true;
                continue;
            }
            else if (!disabled)
            {
                var values = match.Value.Replace("mul(", string.Empty).Replace(")", string.Empty).Split(',');
                var numbers = values.Select(value => int.Parse(value)).ToList();

                var result = 1;
                foreach (var number in numbers)
                {
                    result *= number;
                }

                sum += result;
            }
        }

        Console.WriteLine(sum);
    }
}
