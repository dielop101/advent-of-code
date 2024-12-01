
using Helpers;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _2023.Day03;

public static class Logic
{
    private static List<(int y, int x)> _mapSymbols = new();

    public static int SumEngineSchematic(string filepath)
    {
        var lines = ReadFile.Lines(filepath).ToArray();
        var result = 0;

        FillMapSymbols(lines);

        var numberString = string.Empty;
        for (int y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                var @char = line[x].ToString();
                if (int.TryParse(@char, out _))
                {
                    numberString += @char;
                }
                else if (!string.IsNullOrEmpty(numberString))
                {
                    //number completed. Check if it has symbols around it
                    var xRealPosition = x - 1;
                    result += CheckPosition(numberString, y, xRealPosition);

                    //restart number
                    numberString = string.Empty;
                }
            }
        }

        return result;
    }

    private static int CheckPosition(string numberString, int y, int finalX)
    {
        var finalNumber = int.Parse(numberString);
        var initX = finalX - numberString.Length + 1;

        //check left
        if (_mapSymbols.Contains((y, initX - 1)))
        {
            return finalNumber;
        }
        //check right
        if (_mapSymbols.Contains((y, finalX + 1)))
        {
            return finalNumber;
        }

        //initX - 1 y finalX + 1 para coger el las diagonales
        for (int i = initX - 1; i <= finalX + 1; i++)
        {
            //check above
            if (_mapSymbols.Contains((y - 1, i)))
            {
                return finalNumber;
            }
            //check below
            if (_mapSymbols.Contains((y + 1, i)))
            {
                return finalNumber;
            }
        }

        return 0;
    }

    private static void FillMapSymbols(string[] lines)
    {
        for (int y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                var @char = line[x].ToString();
                if (!int.TryParse(@char, out _) && @char != ".")
                {
                    _mapSymbols.Add((y, x));
                }
            }
        }
    }
}
