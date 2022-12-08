using Helpers;

namespace Day8;

public static class LogicPart2
{
    public static double Part2(string filepath)
    {
        var lines = ReadFile.Lines(filepath);
        var matrix = BuildMatrix(lines);
        var numOfTrees = 0;
        for (var y = 0; y < matrix.Length; y++)
        {
            var row = matrix[y];
            for (int x = 0; x < row.Length; x++)
            {
                var candidate = TotalOfTrees(matrix, x, y);
                if (candidate > numOfTrees)
                    numOfTrees = candidate;
            }
        }

        return numOfTrees;
    }

    public static short[][] BuildMatrix(ICollection<string> lines)
    {
        var listOfLines = new List<short[]>();
        foreach (var line in lines)
        {
            listOfLines.Add(ConvertLineToString(line));
        }

        return listOfLines.ToArray();
    }

    public static int TotalOfTrees(short[][] matrix, int x, int y)
    {
        return NumOfTreesVisibleTop(matrix, x, y) * NumOfTreesVisibleBottom(matrix, x, y)
           * NumOfTreesVisibleLeft(matrix, x, y) * NumOfTreesVisibleRight(matrix, x, y);
    }

    public static int NumOfTreesVisibleTop(short[][] matrix, int x, int y)
    {
        var myTreeSize = matrix[y][x];

        int position = 1;
        while (matrix.Length > position)
        {
            if (y - position < 0)
                return position - 1;

            var top = matrix[y - position][x];
            if (myTreeSize <= top)
            {
                return position;
            }
            position++;
        }

        return position - 1;
    }

    public static int NumOfTreesVisibleBottom(short[][] matrix, int x, int y)
    {
        var myTreeSize = matrix[y][x];

        int position = 1;
        while (matrix.Length > position)
        {
            if (y + position > matrix.Length - 1)
                return position - 1;

            var bottom = matrix[y + position][x];
            if (myTreeSize <= bottom)
            {
                return position;
            }
            position++;
        }

        return position - 1;
    }

    public static int NumOfTreesVisibleLeft(short[][] matrix, int x, int y)
    {
        var myTreeSize = matrix[y][x];

        int position = 1;
        while (matrix[0].Length > position)
        {
            if (x - position < 0)
                return position - 1;

            var left = matrix[y][x - position];
            if (myTreeSize <= left)
            {
                return position;
            }
            position++;
        }

        return position - 1;
    }

    public static int NumOfTreesVisibleRight(short[][] matrix, int x, int y)
    {
        var myTreeSize = matrix[y][x];

        int position = 1;
        while (matrix[0].Length > position)
        {
            if (x + position > matrix[0].Length - 1)
                return position - 1;

            var right = matrix[y][x + position];
            if (myTreeSize <= right)
            {
                return position;
            }
            position++;
        }

        return position - 1;
    }

    public static short[] ConvertLineToString(string line)
    {
        return line.Select(c => short.Parse(c.ToString())).ToArray();
    }
}
