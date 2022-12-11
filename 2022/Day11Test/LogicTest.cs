using Day11;
using FluentAssertions;

namespace Day11Test;
public class LogicTest
{
    [Test]
    public void Part1()
    {
        var total = Logic.Part1(@"data\example.txt", 20);
        total.Should().Be(10605);
    }

    [Test]
    public void DoRounds()
    {
        var monkeys = Logic.DoRounds(@"data\example.txt", 20);
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
    public void InitMonkeys()
    {
        var monkeys = Logic.InitMonkeys(@"data\example.txt");
        monkeys.Should().HaveCount(4);
    }
}
