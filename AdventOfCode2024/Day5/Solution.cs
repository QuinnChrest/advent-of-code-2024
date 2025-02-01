namespace AdventOfCode2024.Day5;

internal static class Solution
{
    public static void Run()
    {
        Dictionary<int,List<int>> rules = new Dictionary<int,List<int>>();
        List<List<int>> lines = new List<List<int>>();
        using (var stream = File.OpenRead(Path.Combine("Day5", "input.txt")))
        using (var reader = new StreamReader(stream))
        {
            var line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains('|'))
                {
                    var rule = line.Split('|').Select(x => int.Parse(x)).ToArray();

                    if (!rules.ContainsKey(rule[0]))
                        rules.Add(rule[0], new List<int>());

                    rules[rule[0]].Add(rule[1]);
                }
                else if (line.Contains(','))
                {
                    lines.Add(line.Split(',').Select(x => int.Parse(x)).ToList());
                }
            }
        }

        var sum = 0;

        // loop through lists of manual pages
        for (var i = 0; i < lines.Count(); i++)
        {
            var line = lines[i];
            var valid = false;
            var log = string.Join(',', line);

            // loop through each page of a manual starting with index 1 since there is nothing in front of index 0
            for (var j = 1; j < line.Count(); j++)
            {
                // if there is a rule for this page number and one of the rules applies to the items before this one then move page
                if (rules.ContainsKey(line[j]) && line.GetRange(0, j).Intersect(rules[line[j]]).Any())
                {
                    // find target index to move invalid page to
                    valid = true;
                    var target = -1;
                    for (int h = j - 1; h >= 0; h--)
                        if (rules[line[j]].Contains(line[h]))
                            target = h;
                    line = MoveToIndex(line, j, target);
                }
            }

            if (valid)
            {
                log += $" => {string.Join(',', line)}";
                Console.WriteLine(log);
                sum += line[line.Count() / 2];
            }
        }

        Console.WriteLine($"Sum: {sum}");
    }

    private static List<int> MoveToIndex(List<int> list, int index, int target)
    {
        var item = list[index];
        list.RemoveAt(index);
        list.Insert(target, item);

        return list;
    }
}
