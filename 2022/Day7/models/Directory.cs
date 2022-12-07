namespace Day7.models;

public class Directory
{
    public Directory(string name)
    {
        Name = name;
    }
    public string Name { get; set; }

    public ICollection<Directory> Directories { get; set; } = new List<Directory>();

    public double Size { get; set; }

    public Directory? ParentDirectory { get; set; }

    internal void Select()
    {
        throw new NotImplementedException();
    }

    private double? _size;
    public double TotalSize()
    {
        if (_size is null)
        {
            _size = Size + GetDirectories().Select(d => d.Size).Sum();
        }

        return _size.Value;
    }

    private List<Directory> _directories = null!;
    public ICollection<Directory> GetDirectories()
    {
        if (_directories is null)
        {
            _directories = new List<Directory>();
            _directories.AddRange(Directories);
            foreach (var dir in Directories)
            {
                _directories.AddRange(dir.GetDirectories());
            }

        }
        return _directories;
    }
}
