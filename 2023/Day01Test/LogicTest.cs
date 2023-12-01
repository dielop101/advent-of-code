using Helpers;

namespace Day01;

public class LogicTest
{
    [Test]
    public void Example()
    {
        var sumCalibratedValues = Logic.SumCalibratedValues(@"data\example.txt");

        sumCalibratedValues.Should().Be(142);
    }
    [Test]
    public void Example2()
    {
        var sumCalibratedValues = Logic.SumCalibratedValues(@"data\example2.txt");

        sumCalibratedValues.Should().Be(281);
    }
}