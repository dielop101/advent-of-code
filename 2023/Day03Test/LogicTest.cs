namespace _2023.Day03;

public class LogicTest
{
    [Test]
    public void Example()
    {
        var sumEngineSchematic = Logic.SumEngineSchematic(@"data\example.txt");

        sumEngineSchematic.Should().Be(4361);
    }
}