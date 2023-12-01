using _2022.Day6;
using FluentAssertions;

namespace TemplateTest;

public class LogicTests
{
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Part(string message, int positionExpected)
    {
        var position = Logic.GetIndex(message, 4);
        position.Should().Be(positionExpected);
    }

    [TestCase("abcd", true)]
    [TestCase("abdd", false)]
    public void ContainsUniqueChars(string input, bool resultExpected)
    {
        var result = Logic.ContainsUniqueChars(input);
        result.Should().Be(resultExpected);
    }

    [TestCase("abcde", 0, "abcd")]
    [TestCase("abcde", 1, "bcde")]
    public void MoveNext(string input, int index, string subStringExpected)
    {
        var subString = Logic.MoveNext(input, index, 4);
        subString.Should().Be(subStringExpected);
    }
}