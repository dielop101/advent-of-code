using Day11;
using FluentAssertions;

namespace Day11Test;
public class LogicTest
{
    [TestCase(20, true, 10605)]
    [TestCase(10000, false, 2713310158)]
    public void Part1(int rounds, bool handicap, double result)
    {
        var total = Logic.Part1(@"data\example.txt", rounds, handicap);
        total.Should().Be(result);
    }

    [Test]
    public void DoRounds()
    {
        var monkeys = Logic.DoRounds(@"data\example.txt", 20, true);
        monkeys[0].Items.Should().HaveCount(5);
        monkeys[1].Items.Should().HaveCount(5);
        monkeys[2].Items.Should().HaveCount(0);
        monkeys[3].Items.Should().HaveCount(0);

        monkeys[0].Items[0].Should().Be(10);
        monkeys[0].Items[1].Should().Be(12);
        monkeys[0].Items[2].Should().Be(14);
        monkeys[0].Items[3].Should().Be(26);
        monkeys[0].Items[4].Should().Be(34);

        monkeys[1].Items[0].Should().Be(245);
        monkeys[1].Items[1].Should().Be(93);
        monkeys[1].Items[2].Should().Be(53);
        monkeys[1].Items[3].Should().Be(199);
        monkeys[1].Items[4].Should().Be(115);
    }

    [Test]
    public void DoRoundsPart2()
    {
        var monkeys = Logic.DoRounds(@"data\example.txt", 1, false);
        monkeys[0].InspectsItems.Should().Be(2);
        monkeys[1].InspectsItems.Should().Be(4);
        monkeys[2].InspectsItems.Should().Be(3);
        monkeys[3].InspectsItems.Should().Be(6);

        monkeys = Logic.DoRounds(@"data\example.txt", 20, false);
        monkeys[0].InspectsItems.Should().Be(99);
        monkeys[1].InspectsItems.Should().Be(97);
        monkeys[2].InspectsItems.Should().Be(8);
        monkeys[3].InspectsItems.Should().Be(103);

        //monkeys = Logic.DoRounds(@"data\example.txt", 1000, false);
        //monkeys[0].InspectsItems.Should().Be(5204);
        //monkeys[1].InspectsItems.Should().Be(4792);
        //monkeys[2].InspectsItems.Should().Be(199);
        //monkeys[3].InspectsItems.Should().Be(5192);
    }

    [Test]
    public void InitMonkeys()
    {
        var monkeys = Logic.InitMonkeys(@"data\example.txt", true);
        monkeys.Should().HaveCount(4);
    }
}
