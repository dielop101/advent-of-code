using Helpers;

namespace Day9;

public static class LogicPart1
{
    public static int Part1(string filepath)
    {
        var lines = ReadFile.Lines(filepath);
        var headPosition = (0, 0);
        var tailPosition = (0, 0);

        var allPaths = new List<(int, int)>
        {
            headPosition
        };

        foreach (var instruction in lines)
        {
            var isSameStartPosition = headPosition == tailPosition;
            var path = Movements(headPosition, instruction).ToList();
            var previousHead = headPosition;
            headPosition = path.Last();

            if (!isSameStartPosition)
            {
                path = FilterPathDependsOnTail(path, tailPosition, previousHead).ToList();
            }

            if (path.Count > 0)
            {
                if (isSameStartPosition)
                {
                    path.RemoveAt(path.Count - 1);
                }

                if (path.Count > 0)
                {
                    tailPosition = path[path.Count - 1];
                    allPaths.AddRange(path);
                }
            }
        }

        return RemoveRepeatedCoordinates(allPaths).Count;
    }

    public static IEnumerable<(int x, int y)> FilterPathDependsOnTail(List<(int x, int y)> path, (int x, int y) tailPosition, (int x, int y) headPosition)
    {
        (int x, int y) previousPossiblePath = headPosition;
        var index = 0;
        foreach (var possiblePath in path)
        {
            if (Math.Abs(possiblePath.x - tailPosition.x) > 1)
            {
                yield return previousPossiblePath;
            }
            else if (Math.Abs(possiblePath.y - tailPosition.y) > 1)
            {
                yield return previousPossiblePath;
            }

            previousPossiblePath = possiblePath;
            index++;
        }
    }

    public static List<(int x, int y)> RemoveRepeatedCoordinates(IEnumerable<(int x, int y)> coordinates)
    {
        return coordinates
            .ToList()
            .Distinct()
            .ToList();
    }

    public static IEnumerable<(int x, int y)> Movements((int x, int y) currentPosition, string instruction)
    {
        var coordinates = ConvertInstructionToCoordinates(instruction);

        int movements = 1;
        while (Math.Abs(coordinates.y) >= movements)
        {
            yield return (currentPosition.x, coordinates.y > 0 ? currentPosition.y + movements : currentPosition.y - movements);
            movements++;
        }

        movements = 1;
        while (Math.Abs(coordinates.x) >= movements)
        {
            yield return (coordinates.x > 0 ? currentPosition.x + movements : currentPosition.x - movements, currentPosition.y);
            movements++;
        }
    }

    public static (int x, int y) ConvertInstructionToCoordinates(string instruction)
    {
        var instructionSplitted = instruction.Split(' ');
        switch (instructionSplitted[0])
        {
            case "U":
                return (0, int.Parse(instructionSplitted[1]));
            case "D":
                return (0, -int.Parse(instructionSplitted[1]));
            case "R":
                return (int.Parse(instructionSplitted[1]), 0);
            case "L":
                return (-int.Parse(instructionSplitted[1]), 0);
            default:
                throw new Exception("Cannot convert instruction to coordinates");
        }
    }
}
