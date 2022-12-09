using Day9.model;
using Helpers;

namespace Day9;

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

        return RemoveRepeatedCoordinates(allPoints[allPoints.Count - 1].Coordinates).Count;
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
                if (previousPoint is null || Math.Abs(previousPoint.CurrentY - point.CurrentY) > 1)
                {
                    point.CurrentY = coordinates.y > 0 ? point.CurrentY + 1 : point.CurrentY - 1;
                    //point.CurrentX = previousPoint?.CurrentX ?? point.CurrentX;
                    if (previousPoint is not null && Math.Abs(previousPoint.CurrentX - point.CurrentX) > 1)
                    {
                        var isSum = point.CurrentX < previousPoint.CurrentX;
                        point.CurrentX = isSum ? point.CurrentX + 1 : point.CurrentX - 1;
                    }
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
                if (previousPoint is null || Math.Abs(previousPoint.CurrentX - point.CurrentX) > 1)
                {
                    point.CurrentX = coordinates.x > 0 ? point.CurrentX + 1 : point.CurrentX - 1;
                    //point.CurrentY = previousPoint?.CurrentY ?? point.CurrentY;
                    if (previousPoint is not null && Math.Abs(previousPoint.CurrentY - point.CurrentY) > 1)
                    {
                        var isSum = point.CurrentY < previousPoint.CurrentY;
                        point.CurrentY = isSum ? point.CurrentY + 1 : point.CurrentY - 1;
                    }
                    point.Coordinates.Add((point.CurrentX, point.CurrentY));
                }

                previousPoint = point;
            }
            movements++;
        }
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
}
