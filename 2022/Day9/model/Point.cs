namespace Day9.model;
public class Point
{
    public Point(string name)
    {
        Name = name;
        Coordinates.Add((0,0));
    }
    public string Name { get; set; }
    public int CurrentX { get; set; }
    public int CurrentY { get; set; }
    public List<(int x, int y)> Coordinates { get; set; } = new List<(int x, int y)> ();
}
