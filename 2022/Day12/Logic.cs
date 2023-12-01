using Helpers;

namespace _2022.Day12;

public static class Logic
{
    public static char START = 'S';
    public static char END = 'E';

    public static int Part1(string filepath)
    {
        var matrix = CreateMatrix(filepath);
        var starterPoint = FindStartPoint(matrix);

        var result = Recursive(matrix, starterPoint, Position.Undefined);

        if (result.EndsWith(END))
            return result.Length;
        return 0;
    }

    public static string Recursive(char[][] matrix, (int x, int y) currentPosition, Position lastPosition)
    {
        var currentChar = matrix[currentPosition.y][currentPosition.x];

        var topChar = GetTop(matrix, currentPosition);
        var bottomChar = GetBottom(matrix, currentPosition);
        var leftChar = GetLeft(matrix, currentPosition);
        var rightChar = GetRight(matrix, currentPosition);

        if (lastPosition != Position.Bottom && IsPossiblePath(currentChar, topChar))
        {
            return topChar + Recursive(matrix, (currentPosition.x, currentPosition.y - 1), Position.Top);
        }

        if (lastPosition != Position.Top && IsPossiblePath(currentChar, bottomChar))
        {
            return bottomChar + Recursive(matrix, (currentPosition.x, currentPosition.y + 1), Position.Bottom);
        }

        if (lastPosition != Position.Right && IsPossiblePath(currentChar, leftChar))
        {
            return leftChar + Recursive(matrix, (currentPosition.x - 1, currentPosition.y), Position.Left);
        }

        if (lastPosition != Position.Left && IsPossiblePath(currentChar, rightChar))
        {
            return rightChar + Recursive(matrix, (currentPosition.x + 1, currentPosition.y), Position.Right);
        }

        return string.Empty;
    }

    public static char[][] CreateMatrix(string filepath)
    {
        var lines = ReadFile.Lines(filepath).ToArray();
        var result = new List<char[]>();
        foreach (var line in lines)
        {
            result.Add(line.ToCharArray());
        }

        return result.ToArray();
    }

    public static (int x, int y) FindStartPoint(char[][] matrix)
    {
        for (int y = 0; y < matrix.Length; y++)
        {
            for (int x = 0; x < matrix[y].Length; x++)
            {
                if (matrix[y][x].Equals(START))
                    return (x, y);
            }
        }

        throw new Exception("Starter point not found");
    }

    public static bool IsPossiblePath(char currentPath, char? nextPath)
    {
        if (currentPath == START)
        {
            return nextPath.HasValue && nextPath.Value == 'a';
        }

        return nextPath.HasValue && (currentPath == nextPath || currentPath + 1 == nextPath);
    }

    public static char? GetTop(char[][] matrix, (int x, int y) position)
    {
        return (position.y - 1) < 0 ? null : matrix[position.y - 1][position.x];
    }

    public static char? GetBottom(char[][] matrix, (int x, int y) position)
    {
        return (position.y + 1 > matrix.Length - 1) ? null : matrix[position.y + 1][position.x];
    }

    public static char? GetLeft(char[][] matrix, (int x, int y) position)
    {
        return (position.x - 1 < 0) ? null : matrix[position.y][position.x - 1];
    }

    public static char? GetRight(char[][] matrix, (int x, int y) position)
    {
        return (position.x + 1 > matrix[0].Length - 1) ? null : matrix[position.y][position.x + 1];
    }
}

public enum Position
{
    Undefined,
    Top,
    Bottom,
    Left,
    Right
}