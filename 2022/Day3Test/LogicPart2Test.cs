using _2022.Day3;
using FluentAssertions;

namespace TemplateTest;

public class LogicPart2Test
{
    [TestCase("abc", "zza", "tag", 'a')]
    [TestCase("vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg", 'r')]
    [TestCase("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw", 'Z')]
    public void TakeRepeatedLetter(string rackpack1, string rackpack2, string rackpack3, char letter)
    {
        var result = LogicPart2.TakeRepeatedLetter(rackpack1, rackpack2, rackpack3);

        result.Should().Be(letter);
    }

    [Test]
    public void Part2()
    {
        var result = LogicPart2.Part2(@"data\example.txt");

        result.Should().Be(70);
    }
}