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
        var orderArray1 = list1.OrderBy(x => x).ToArray();
        var orderArray2 = list2.OrderBy(x => x).ToArray();

        var total = 0;
        for (int i = 0; i < orderArray1.Length; i++)
        {
            total += Math.Abs(orderArray1[i] - orderArray2[i]);
        }

        return total;
    }

    public static int CalculateSimilarity(List<int> list1, List<int> list2)
    {
        var total = 0;
        foreach (var item1 in list1)
        {
            var repeated = 0;
            foreach (var item2 in list2)
            {
                if (item2 == item1)
                    repeated++;
            }
            total += item1 * repeated;
        }

        return total;
    }
}
