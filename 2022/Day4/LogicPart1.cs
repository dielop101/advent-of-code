using Helpers;

namespace Day4;
public static class LogicPart1
{
    public static int Part1(string filepath)
    {
        var lines = ReadFile.Lines(filepath);

        var result = 0;
        foreach (var sections in lines)
        {
            var listSections = sections.Split(',');
            result += FullyContains(listSections[0], listSections[1]) ? 1 : 0;
        }

        return result;
    }

    public static bool FullyContains(string section1, string section2)
    {
        var listSection1 = TakeAllNumbersBetweenRange(section1);
        var listSection2 = TakeAllNumbersBetweenRange(section2);

        if (listSection2.Count > listSection1.Count)
        {
            return listSection1.All(x => listSection2.Contains(x));
        }

        return listSection2.All(x => listSection1.Contains(x));
    }

    public static List<int> TakeAllNumbersBetweenRange(string section)
    {
        var listSection = section.Split('-').Select(x => int.Parse(x));
        var firstSection = listSection.First();
        var lastSection = listSection.Last();
        var count = lastSection - firstSection + 1;
        return Enumerable.Range(firstSection, count).ToList();
    }
}
