namespace AdventOfCode2024.Day4;

internal static class Solution
{
    public static void Run()
    {
        List<string> ws = new List<string>();
        using (var stream = File.OpenRead(Path.Combine("Day4", "input.txt")))
        using (var reader = new StreamReader(stream))
        {
            var line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                ws.Add(line);
            }
        }

        var xmas_count = 0;
        var x_mas_count = 0;

        for (int i = 0; i < ws.Count; i++)
        {
            for (int j = 0; j < ws[i].Length; j++)
            {
                if (ws[i][j] == 'X')
                {
                    xmas_count += GetXMASCount(ws, i, j);
                }

                if (ws[i][j] == 'A')
                {
                    x_mas_count += ValidateX_MAS(ws, i, j) ? 1 : 0;
                }
            }
        }

        Console.WriteLine($"XMAS: {xmas_count}");
        Console.WriteLine($"X-MAS: {x_mas_count}");
    }

    private static int GetXMASCount(List<string> ws, int i, int j)
    {
        var count = 0;

        try { count += ws[i][j] == 'X' && ws[i + 1][j] == 'M' && ws[i + 2][j] == 'A' && ws[i + 3][j] == 'S' ? 1 : 0; } catch { }
        try { count += ws[i][j] == 'X' && ws[i - 1][j] == 'M' && ws[i - 2][j] == 'A' && ws[i - 3][j] == 'S' ? 1 : 0; } catch { }
        try { count += ws[i][j] == 'X' && ws[i][j - 1] == 'M' && ws[i][j - 2] == 'A' && ws[i][j - 3] == 'S' ? 1 : 0; } catch { }
        try { count += ws[i][j] == 'X' && ws[i][j + 1] == 'M' && ws[i][j + 2] == 'A' && ws[i][j + 3] == 'S' ? 1 : 0; } catch { }
        try { count += ws[i][j] == 'X' && ws[i + 1][j + 1] == 'M' && ws[i + 2][j + 2] == 'A' && ws[i + 3][j + 3] == 'S' ? 1 : 0; } catch { }
        try { count += ws[i][j] == 'X' && ws[i + 1][j - 1] == 'M' && ws[i + 2][j - 2] == 'A' && ws[i + 3][j - 3] == 'S' ? 1 : 0; } catch { }
        try { count += ws[i][j] == 'X' && ws[i - 1][j + 1] == 'M' && ws[i - 2][j + 2] == 'A' && ws[i - 3][j + 3] == 'S' ? 1 : 0; } catch { }
        try { count += ws[i][j] == 'X' && ws[i - 1][j - 1] == 'M' && ws[i - 2][j - 2] == 'A' && ws[i - 3][j - 3] == 'S' ? 1 : 0; } catch { }

        return count;
    }

    private static bool ValidateX_MAS(List<string> ws, int i, int j)
    {
        try
        {
            return
                ((ws[i+1][j-1] == 'M' && ws[i-1][j+1] == 'S') || (ws[i+1][j-1] == 'S' && ws[i-1][j+1] == 'M')) &&
                ((ws[i-1][j-1] == 'M' && ws[i+1][j+1] == 'S') || (ws[i-1][j-1] == 'S' && ws[i+1][j+1] == 'M'))
                ? true : false;
        }
        catch { return false; }
    }
}
