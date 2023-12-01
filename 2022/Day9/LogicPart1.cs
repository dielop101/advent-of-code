using Day9.model;
using Helpers;

namespace _2022.Day9;

public static class LogicPart1
{
    public static int Part1(string filepath)
    {
        var lines = ReadFile.Lines(filepath);

        var allPoints = new List<Point>
        {
            new Point("H"),
            new Point("T")
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
                if (previousPoint is null)
                {
                    //head
                    point.CurrentY = coordinates.y > 0 ? point.CurrentY + 1 : point.CurrentY - 1;
                    point.Coordinates.Add((point.CurrentX, point.CurrentY));
                }
                else if (Math.Abs(previousPoint.CurrentY - point.CurrentY) > 1)
                {
                    //tails
                    var beforePreviousPoint = previousPoint.Coordinates[previousPoint.Coordinates.Count - 2];
                    point.CurrentY = beforePreviousPoint.y;
                    point.CurrentX = beforePreviousPoint.x;
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
                else if (Math.Abs(previousPoint.CurrentX - point.CurrentX) > 1)
                {
                    //tails
                    var beforePreviousPoint = previousPoint.Coordinates[previousPoint.Coordinates.Count - 2];
                    point.CurrentY = beforePreviousPoint.y;
                    point.CurrentX = beforePreviousPoint.x;
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
