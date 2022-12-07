namespace Day7.models;
public class Command
{
    public Command(string name, string? args)
    {
        Name = name;
        Args = args;
    }

    public string Name { get; set; }
    public string? Args { get; set; }
}
