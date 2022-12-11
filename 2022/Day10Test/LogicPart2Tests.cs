using Day10;
using FluentAssertions;

namespace Day10Test;

public class LogicPart2Tests
{
    [Test]
    public void Part2()
    {
        var result = LogicPart2.Part2(@"data\example.txt");
        result[0][0].Should().Be(true);
        result[0][1].Should().Be(true);
        result[0][2].Should().Be(false);
        result[0][3].Should().Be(false);
        result[0][4].Should().Be(true);
        result[0][5].Should().Be(true);
        result[0][6].Should().Be(false);
        result[0][7].Should().Be(false);
        result[0][8].Should().Be(true);
        result[0][9].Should().Be(true);
        result[0][10].Should().Be(false);
        result[0][11].Should().Be(false);
        result[0][12].Should().Be(true);
        result[0][13].Should().Be(true);
        result[0][14].Should().Be(false);
        result[0][15].Should().Be(false);
        result[0][16].Should().Be(true);
        result[0][17].Should().Be(true);
        result[0][18].Should().Be(false);
        result[0][19].Should().Be(false);
        result[0][20].Should().Be(true);
        result[0][21].Should().Be(true);
        result[0][22].Should().Be(false);
        result[0][23].Should().Be(false);
        result[0][24].Should().Be(true);
        result[0][25].Should().Be(true);
        result[0][26].Should().Be(false);
        result[0][27].Should().Be(false);
        result[0][28].Should().Be(true);
        result[0][29].Should().Be(true);
        result[0][30].Should().Be(false);
        result[0][31].Should().Be(false);
        result[0][32].Should().Be(true);
        result[0][33].Should().Be(true);
        result[0][34].Should().Be(false);
        result[0][35].Should().Be(false);
        result[0][36].Should().Be(true);
        result[0][37].Should().Be(true);
        result[0][38].Should().Be(false);
        result[0][39].Should().Be(false);

        result[1][0].Should().Be(true);
        result[1][1].Should().Be(true);
        result[1][2].Should().Be(true);
        result[1][3].Should().Be(false);
        result[1][4].Should().Be(false);
        result[1][5].Should().Be(false);
        result[1][6].Should().Be(true);
        result[1][7].Should().Be(true);
        result[1][8].Should().Be(true);
        result[1][9].Should().Be(false);
        result[1][10].Should().Be(false);
        result[1][11].Should().Be(false);
    }

    [Test]
    public void BuildCRT()
    {
        var result = LogicPart2.BuildCRT(40,6);
        result.Length.Should().Be(6);
        result[0].Length.Should().Be(40);
    }

    [TestCase(0, 1, 0, true)]
    [TestCase(1, 3, 1, false)]
    public void PrintPixel(int cycle, int valuex, int y, bool result)
    {
        var crt = LogicPart2.BuildCRT(40, 6);
        LogicPart2.PrintPixel(crt, cycle, valuex, y);
        crt[y][cycle].Should().Be(result);
    }
}