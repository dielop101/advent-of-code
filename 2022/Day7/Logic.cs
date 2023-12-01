using Day7.models;
using Helpers;
using OneOf;
using Directory = Day7.models.Directory;

namespace _2022.Day7;

public static class Logic
{
    public static double Part1(string filepath)
    {
        var lines = ReadFile.Lines(filepath);
        var structure = CreateStructure(lines);

        const double maxSize = 100000;
        return structure
            .GetDirectories()
            .Where(x => x.TotalSize() <= maxSize)
            .Sum(x => x.TotalSize());
    }

    public static double Part2(string filepath)
    {
        var lines = ReadFile.Lines(filepath);
        var structure = CreateStructure(lines);
        var spaceNeeded = SpaceNeeded(structure);

        var candidateDirectories = structure.GetDirectories()
            .Where(x => x.TotalSize() >= spaceNeeded)
            .OrderBy(x => x.TotalSize());

        return candidateDirectories
            .First()
            .TotalSize();
    }

    public static double SpaceNeeded(Directory root)
    {
        const double diskSpace = 70000000;
        const double spaceRequested = 30000000;
        var freeSpace = Math.Abs(root.TotalSize() - diskSpace);
        return spaceRequested - freeSpace;
    }

    public static Directory CreateStructure(ICollection<string> instructions)
    {
        Directory currentDirectory = new Directory("");
        Directory root = new Directory("");

        foreach (var instruction in instructions)
        {
            var oneof = ConvertInstruction(instruction);
            if (oneof.IsT0)
            {
                if (oneof.AsT0.Name.Equals("cd"))
                {
                    if (oneof.AsT0.Args!.Equals("/"))
                    {
                        currentDirectory = new Directory(oneof.AsT0.Args);
                        root = currentDirectory;
                    }
                    else if (oneof.AsT0.Args!.Equals(".."))
                    {
                        currentDirectory = currentDirectory!.ParentDirectory!;
                    }
                    else
                    {
                        currentDirectory = currentDirectory!.Directories.Single(x => x.Name.Equals(oneof.AsT0.Args));
                    }
                }
            }
            else if (oneof.IsT1)
            {
                var dir = oneof.AsT1;
                dir.ParentDirectory = currentDirectory;
                currentDirectory!.Directories.Add(dir);
            }
            else if (oneof.IsT2)
            {
                currentDirectory!.Size += oneof.AsT2;
            }
        }

        return root;
    }

    public static OneOf<Command, Directory, double> ConvertInstruction(string instruction)
    {
        var strings = instruction.Split(" ");

        if (instruction.StartsWith('$'))
        {
            return new Command(strings[1], strings.Length > 2 ? strings[2] : null);
        }
        if (instruction.StartsWith("dir"))
        {
            return new Directory(strings[1]);
        }

        return double.Parse(strings[0]);
    }
}
