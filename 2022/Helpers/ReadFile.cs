namespace Helpers;

public static class ReadFile
{
    public static ICollection<string> Lines(string filepath)
    {

        var allText = File.ReadAllText(filepath);

        return allText.Split("\r\n");
    }
}
