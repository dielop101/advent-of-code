
using Helpers;

namespace _2023.Day02;

public static class Logic
{
    public static int SumPossibleGames(string filepath, (int r, int g, int b) maxBag)
    {
        var lines = ReadFile.Lines(filepath);
        var result = 0;
        foreach (var line in lines) 
        {
            var splitLine = line.Split(": ");
            var gameId = int.Parse(splitLine[0].Replace("Game ", ""));

            var items = splitLine[1].Split("; ");

            var isPossible = true;
            foreach (var item in items)
            {
                if (IsImpossible(item, maxBag))
                {
                    isPossible = false;
                    break;
                }    
            }

            if (isPossible)
            {
                result += gameId;
            }
        }
        return result;
    }

    public static int MultiplyMaxCubes(string filepath)
    {
        var lines = ReadFile.Lines(filepath);
        var result = 0;
        foreach (var line in lines)
        {
            var splitLine = line.Split(": ");
            var items = splitLine[1].Split("; ");

            (int r, int g, int b) maxRGB = (0, 0, 0);
            foreach (var item in items)
            {
                UpdateMaxItem(item, ref maxRGB);
            }

            result += maxRGB.r * maxRGB.g * maxRGB.b;
        }
        return result;
    }

    private static bool IsImpossible(string item, (int r, int g, int b) maxBag)
    {
        var (r, g, b) = GetRGB(item);
        return maxBag.r < r || maxBag.g < g || maxBag.b < b;
    }

    private static void UpdateMaxItem(string item, ref (int r, int g, int b) maxRGB)
    {
        var (r, g, b) = GetRGB(item);
        if (r > maxRGB.r) maxRGB.r = r;
        if (g > maxRGB.g) maxRGB.g = g;
        if (b > maxRGB.b) maxRGB.b = b;
    }

    private static (int r, int g, int b) GetRGB(string item)
    {
        var r = 0;
        var g = 0;
        var b = 0;
        var splitRGB = item.Split(", ");
        foreach (var rgb in splitRGB)
        {
            if (rgb.Contains("red"))
            {
                r = int.Parse(rgb.Split(" ")[0]);
            }
            else if (rgb.Contains("green"))
            {
                g = int.Parse(rgb.Split(" ")[0]);
            }
            else if (rgb.Contains("blue"))
            {
                b = int.Parse(rgb.Split(" ")[0]);
            }
        }

        return (r, g, b);
    }
}
