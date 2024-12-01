using Helpers;

namespace Day01;

public static class Logic
{
    public static int CalculatePath(string path, bool part1)
    {
        var lines = ReadFile.Lines(path);

        var list1 = new List<int>();
        var list2 = new List<int>();

        foreach (var line in lines)
        {
            list1.Add(int.Parse(line.Split("   ")[0]));
            list2.Add(int.Parse(line.Split("   ")[1]));
        }

        return part1 ? CalculatePath(list1, list2) : CalculateSimilarity(list1, list2);
    }

    public static int CalculatePath(List<int> list1, List<int> list2)
    {
        return list1.OrderBy(x => x)
                       .Zip(list2.OrderBy(x => x), (a, b) => Math.Abs(a - b))
                       .Sum();
    }

    public static int CalculateSimilarity(List<int> list1, List<int> list2)
    {
        return list1.Sum(x => list2.Count(y => y == x) * x);
    }
}
