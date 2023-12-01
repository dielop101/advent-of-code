namespace Helpers;

public static class ReadFile
{
    public static ICollection<string> Lines(string filepath)
    {
        return File.ReadAllLines(filepath);
    }

    public static ICollection<ICollection<string>> LinesGroupBy(string filepath, int groupBy)
    {
        var allText = File.ReadAllLines(filepath);
        int count = 0;
        var result = new List<ICollection<string>>();
        var subCollection = new List<string>();
        foreach (var line in allText)
        {
            if (count == groupBy)
            {
                result.Add(subCollection);
                count = 0;
                subCollection = new List<string>();
            }

            subCollection.Add(line);
            count++;
        }

        if (subCollection.Count > 0)
        {
            result.Add(subCollection);
        }

        return result;
    }

    public static ICollection<ICollection<string>> LinesGroupedBySpace(string filepath)
    {
        var allText = File.ReadAllLines(filepath);
        var result = new List<ICollection<string>>();
        var subCollection = new List<string>();

        foreach (var line in allText)
        {
            if (string.IsNullOrEmpty(line))
            {
                result.Add(subCollection);
                subCollection = new List<string>();
            }
            else
            {
                subCollection.Add(line);
            }
        }

        if (subCollection.Count > 0)
        {
            result.Add(subCollection);
        }

        return result;
    }
}
