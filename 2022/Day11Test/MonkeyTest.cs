using Day11.model;
using FluentAssertions;

namespace Day11Test;

public class MonkeyTest
{
    [Test]
    public void DoAction()
    {
        var monkey0 = new Monkey("Monkey 0:", "Starting items: 79, 98", "Operation: new = old * 19", "Test: divisible by 23",
            "If true: throw to monkey 2",
            "If false: throw to monkey 1");

        var monkey1 = new Monkey("Monkey 1:", "Starting items: 5, 6", "", "Test: divisible by 23",
            "If true: throw to monkey 1",
            "If false: throw to monkey 2");

        var allMonkeys = new List<Monkey>
        {
            monkey0,
            monkey1
        };

        monkey0.DoAction(allMonkeys);
        monkey0.Items.Should().HaveCount(0);
        monkey1.Items.Should().HaveCount(4);
        monkey1.Items[2].Should().Be(500);
        monkey1.Items[3].Should().Be(620);
    }

    [TestCase("new = old * 19", 1, 19)]
    [TestCase("new = old + 19", 0, 19)]
    [TestCase("new = old - 19", 0, -19)]
    [TestCase("new = old * old", 5, 25)]
    [TestCase("new = old / 3", 1501, 500)]
    public void DoOperation(string instruction, int old, int resultExpected)
    {
        var monkey = new Monkey("Monkey 0:", "Starting items: 79, 98", instruction, "Test: divisible by 23",
            "If true: throw to monkey 2",
            "If false: throw to monkey 3");

        var result = monkey.DoOperation(old);

        result.Should().Be(resultExpected);
    }

    [Test]
    public void MonkeyBuildData()
    {
        var monkey = new Monkey("Monkey 1:",
            "Starting items: 79, 98",
            "Operation: new = old * 19", 
            "Test: divisible by 23", 
            "If true: throw to monkey 2",
            "If false: throw to monkey 3");

        monkey.Id.Should().Be(1);
        monkey.MonkeyTrueId.Should().Be(2);
        monkey.MonkeyFalseId.Should().Be(3);
        monkey.DivisibleBy.Should().Be(23);
        monkey.Items.Should().HaveCount(2);
        monkey.Items[0].Should().Be(79);
        monkey.Items[1].Should().Be(98);
    }
}