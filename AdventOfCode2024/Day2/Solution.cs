namespace AdventOfCode2024.Day2;

internal static class Solution
{
    public static void Run()
    {
        var safe = 0;

        using (var stream = File.OpenRead(Path.Combine("Day2", "input.txt")))
        using (var reader = new StreamReader(stream))
        {
            var line = string.Empty;

            while ((line = reader.ReadLine()) != null)
            {
                var items = line.Split(" ");

                var list = items.Select(x => int.Parse(x.Trim())).ToList();

                if (test(list))
                {
                    safe++;
                }
                else
                {
                    Console.WriteLine($"Fail\t{line}");
                }
            }
        }
        Console.WriteLine($"Safe: {safe}");
    }

    private static bool test(List<int> sequence, int? skip = null)
    {
        var list = sequence.ToList();

        if (skip.HasValue)
            list.RemoveAt(skip.Value);

        var valid = 0;
        var comparison = list[0] > list[1] ? '>' : '<';
        for (var i = 1; i < list.Count; i++)
        {
            var diff = Math.Abs(list[i - 1] - list[i]);
            if (compare(list[i - 1], list[i], comparison) && diff >= 1 && diff <= 3)
                valid++;
        }

        if (valid == list.Count() - 1)
            return true;

        if (!skip.HasValue)
            for (var i = 0; i < list.Count; i++)
                if (test(list, i))
                    return true;

        return false;
    }

    private static bool compare(int a, int b, char comparison)
    {
        if (comparison == '<')
            return a < b;
        else if (comparison == '>')
            return a > b;
        else return false;
    }
}
