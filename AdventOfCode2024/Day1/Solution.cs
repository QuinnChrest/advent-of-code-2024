namespace AdventOfCode2024.Day1;

internal static class Solution
{
    public static void Run()
    {
        var a = new List<int>();
        var b = new List<int>();

        using (var stream = File.OpenRead(Path.Combine("Day1", "input.txt")))
        using (var reader = new StreamReader(stream))
        {
            var line = string.Empty;

            while ((line = reader.ReadLine()) != null)
            {
                var items = line.Split("   ");

                a.Add(int.Parse(items[0]));
                b.Add(int.Parse(items[1]));
            }
        }

        a.Sort();
        b.Sort();

        var distance = 0;
        for (int i = 0; i < a.Count; i++)
        {
            distance += Math.Abs(a[i] - b[i]);
        }

        Console.WriteLine($"Distance: {distance}");

        var b_dictionary = new Dictionary<int, int>();
        for (int i = 0; i < b.Count; i++)
        {
            if (b_dictionary.ContainsKey(b[i]))
            {
                b_dictionary[b[i]]++;
            }
            else
            {
                b_dictionary.Add(b[i], 1);
            }
        }

        var similarity = 0;
        foreach (var item in a)
        {
            if(b_dictionary.ContainsKey(item))
                similarity += item * b_dictionary[item];
        }

        Console.WriteLine($"Similarity: {similarity}");
    }
}
