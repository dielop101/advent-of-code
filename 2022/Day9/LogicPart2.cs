﻿using Day9.model;
using Helpers;

namespace _2022.Day9;

public static class LogicPart2
{
    public static int Part2(string filepath)
    {
        var lines = ReadFile.Lines(filepath);

        var allPoints = new List<Point>
        {
            new Point("H"),
            new Point("1"),
            new Point("2"),
            new Point("3"),
            new Point("4"),
            new Point("5"),
            new Point("6"),
            new Point("7"),
            new Point("8"),
            new Point("9"),
        };

        foreach (var instruction in lines)
        {
            Movements(allPoints, instruction);
        }
        var clean = RemoveRepeatedCoordinates(allPoints[allPoints.Count - 1].Coordinates);
        return clean.Count;
    }

    public static List<(int x, int y)> RemoveRepeatedCoordinates(IEnumerable<(int x, int y)> coordinates)
    {
        return coordinates
            .ToList()
            .Distinct()
            .ToList();
    }

    public static void Movements(List<Point> points, string instruction)
    {
        var coordinates = ConvertInstructionToCoordinates(instruction);

        int movements = 1;
        while (Math.Abs(coordinates.y) >= movements)
        {
            Point? previousPoint = null;
            foreach (var point in points)
            {
                if (previousPoint is null)
                {
                    //head
                    point.CurrentY = coordinates.y > 0 ? point.CurrentY + 1 : point.CurrentY - 1;
                    point.Coordinates.Add((point.CurrentX, point.CurrentY));
                }
                else if (Math.Abs(previousPoint.CurrentY - point.CurrentY) > 1 ||
                    Math.Abs(previousPoint.CurrentX - point.CurrentX) > 1)
                {
                    //tails
                    var (x, y) = NewPoint((previousPoint.CurrentX, previousPoint.CurrentY), (point.CurrentX, point.CurrentY));

                    point.CurrentX = x;
                    point.CurrentY = y;
                    point.Coordinates.Add((point.CurrentX, point.CurrentY));
                }

                previousPoint = point;
            }
            movements++;
        }

        movements = 1;
        while (Math.Abs(coordinates.x) >= movements)
        {
            Point? previousPoint = null;
            foreach (var point in points)
            {
                if (previousPoint is null)
                {
                    //head
                    point.CurrentX = coordinates.x > 0 ? point.CurrentX + 1 : point.CurrentX - 1;
                    point.Coordinates.Add((point.CurrentX, point.CurrentY));
                }
                else if (Math.Abs(previousPoint.CurrentY - point.CurrentY) > 1 ||
                    Math.Abs(previousPoint.CurrentX - point.CurrentX) > 1)
                {
                    var (x, y) = NewPoint((previousPoint.CurrentX, previousPoint.CurrentY), (point.CurrentX, point.CurrentY));

                    point.CurrentX = x;
                    point.CurrentY = y;
                    point.Coordinates.Add((point.CurrentX, point.CurrentY));
                }

                previousPoint = point;
            }

            //PrintPoints(points);
            movements++;
        }
    }

    public static (int x, int y) NewPoint((int x, int y) beforePoint, (int x, int y) currentPoint)
    {
        int x, y;
        if (beforePoint.x > currentPoint.x)
        {
            x = currentPoint.x + 1;
        }
        else if (beforePoint.x < currentPoint.x)
        {
            x = currentPoint.x - 1;
        }
        else
        {
            x = currentPoint.x;
        }

        if (beforePoint.y > currentPoint.y)
        {
            y = currentPoint.y + 1;
        }
        else if (beforePoint.y < currentPoint.y)
        {
            y = currentPoint.y - 1;
        }
        else
        {
            y = currentPoint.y;
        }

        return (x, y);
    }

    public static (int x, int y) ConvertInstructionToCoordinates(string instruction)
    {
        var instructionSplitted = instruction.Split(' ');
        return instructionSplitted[0] switch
        {
            "U" => (0, int.Parse(instructionSplitted[1])),
            "D" => (0, -int.Parse(instructionSplitted[1])),
            "R" => (int.Parse(instructionSplitted[1]), 0),
            "L" => (-int.Parse(instructionSplitted[1]), 0),
            _ => throw new Exception("Cannot convert instruction to coordinates"),
        };
    }

    private static void PrintPoints(List<Point> points)
    {
        string[][] map = new string[][]
        {
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
        new string[] { ".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},

        };

        foreach (var point in points)
        {
            if (map[point.CurrentY + 10][point.CurrentX + 10] == ".")
                map[point.CurrentY + 10][point.CurrentX + 10] = point.Name;
        }

        foreach (var array in map.Reverse())
        {
            foreach (var item in array)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
