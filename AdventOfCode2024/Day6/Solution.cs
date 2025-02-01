namespace AdventOfCode2024.Day6;

internal static class Solution
{
    public static void Run()
    {
        int x = -1, y = -1;
        var direction = Direction.up;
        List<List<char>> map = new List<List<char>>();
        using (var stream = File.OpenRead(Path.Combine("Day6", "input.txt")))
        using (var reader = new StreamReader(stream))
        {
            var line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                map.Add(new List<char>(line));

                if (line.Contains('^'))
                {
                    (x, y) = (line.IndexOf('^'), map.Count() - 1);
                    map[y][x] = 'X';
                }
            }
        }

        Console.WriteLine((x, y));

        while (true)
        {
            if(direction == Direction.up)
            {
                if (y == 0)
                    break;
                else if (map[y - 1][x] == '#')
                    direction = Direction.right;
                else
                    y--;
                map[y][x] = 'X';
            }
            else if (direction == Direction.down)
            {
                if (map.Count() - 1 == y)
                    break;
                else if (map[y + 1][x] == '#')
                    direction = Direction.left;
                else
                    y++;
                map[y][x] = 'X';
            }
            else if (direction == Direction.left)
            {
                if (x == 0)
                    break;
                else if (map[y][x - 1] == '#')
                    direction = Direction.up;
                else
                    x--;
                map[y][x] = 'X';
            }
            else if (direction == Direction.right)
            {
                if (map[y].Count() - 1 == x)
                    break;
                else if (map[y][x + 1] == '#')
                    direction = Direction.down;
                else
                    x++;
                map[y][x] = 'X';
            }
        }

        map.Select((line, i) => $"{i.ToString().PadLeft(3, '0')} {string.Join("", line)}").ToList().ForEach(Console.WriteLine);
        Console.WriteLine(map.Sum(line => line.Count(character => character == 'X')));
    }
}

public enum Direction
{
    up, down, left, right
}
