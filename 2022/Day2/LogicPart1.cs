using Helpers;

namespace _2022.Day2;
public static class LogicPart1
{
    public static int TotalScore(string filepath)
    {
        var lines = ReadFile.Lines(filepath);

        var finalScore = 0;
        foreach (var round in lines)
        {
            finalScore += Round(round);
        }

        return finalScore;
    }

    public static int Round(string round)
    {
        var selections = round.Split(" ");
        var opponentChoice = selections.First();
        var myChoice = selections.Last();

        return TransformChoiceToScore(myChoice) + WinScore(opponentChoice, myChoice);
    }

    private static int WinScore(string opponentChoice, string myChoice)
    {
        //draw
        if ((IsRock(opponentChoice) && IsRock(myChoice)) ||
            (IsPaper(opponentChoice) && IsPaper(myChoice)) ||
             (IsScissor(opponentChoice) && IsScissor(myChoice)))
        {
            return 3;
        }

        //win
        if ((IsRock(opponentChoice) && IsPaper(myChoice)) ||
            (IsPaper(opponentChoice) && IsScissor(myChoice)) ||
            (IsScissor(opponentChoice) && IsRock(myChoice)))
        {
            return 6;
        }

        //lose
        if ((IsRock(opponentChoice) && IsScissor(myChoice)) ||
            (IsPaper(opponentChoice) && IsRock(myChoice)) ||
            (IsScissor(opponentChoice) && IsPaper(myChoice)))
        {
            return 0;
        }

        throw new Exception("no match");
    }

    private static int TransformChoiceToScore(string choice)
    {
        switch (choice)
        {
            case "X":
                return 1;
            case "Y":
                return 2;
            case "Z":
                return 3;
            default:
                throw new Exception("no match");
        }

    }

    private static bool IsRock(string value)
    {
        return value.Equals("A") || value.Equals("X");
    }
    private static bool IsPaper(string value)
    {
        return value.Equals("B") || value.Equals("Y");
    }
    private static bool IsScissor(string value)
    {
        return value.Equals("C") || value.Equals("Z");
    }
}
