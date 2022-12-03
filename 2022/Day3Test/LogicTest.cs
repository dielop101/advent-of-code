using Day3;
using FluentAssertions;

namespace TemplateTest;

public class LogicTest
{
    [TestCase("vJrwpWtwJgWrhcsFMMfFFhFp", "vJrwpWtwJgWr", "hcsFMMfFFhFp")]
    [TestCase("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL")]
    public void SplitString(string assert, string comp1, string comp2)
    {
        (string compartiment1, string compartiment2) = Logic.GetCompartiments(assert);

        compartiment1.Should().Be(comp1);
        compartiment2.Should().Be(comp2);
    }

    [TestCase("vJrwpWtwJgWr", "hcsFMMfFFhFp", 'p')]
    [TestCase("jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL", 'L')]
    public void TakeRepeatedLetter(string comp1, string comp2, char letter)
    {
        var result = Logic.TakeRepeatedLetter(comp1, comp2);

        result.Should().Be(letter);
    }

    [TestCase('p', 16)]
    [TestCase('L', 38)]
    [TestCase('P', 42)]
    public void TransformLetterToValue(char letter, int value)
    {
        var result = Logic.TransformLetterToValue(letter);

        result.Should().Be(value);
    }

    [Test]
    public void Part1Test()
    {
        var result = Logic.Part1(@"data\example.txt");

        result.Should().Be(157);
    }
}