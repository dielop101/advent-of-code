using Helpers;

namespace _2022.Day2;
public static class LogicPart2
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

        return WinScore(myChoice) + TransformChoiceToScore(opponentChoice, myChoice);
    }

    private static int WinScore(string myChoice)
    {
        switch (myChoice)
        {
            case "X":   //need lose
                return 0;
            case "Y":  //need draw
                return 3;
            case "Z":  //need win
                return 6;
            default:
                throw new Exception("no match");
        }
    }

    private static int TransformChoiceToScore(string opponentChoice, string myChoice)
    {
        var myWinScore = WinScore(myChoice);
        if (IsRock(opponentChoice))
        {
            switch (myWinScore)
            {
                case 0: //loose
                    return 3;   //scissor
                case 3: //draw
                    return 1;   //rock
                case 6: //win
                    return 2;   //paper
            }
        }
        else if (IsPaper(opponentChoice))
        {
            switch (myWinScore)
            {
                case 0: //loose
                    return 1; //rock
                case 3: //draw
                    return 2;   //paper
                case 6: //win
                    return 3; //scissor
            }
        }
        else if (IsScissor(opponentChoice))
        {
            switch (myWinScore)
            {
                case 0: //loose
                    return 2;   //paper
                case 3: //draw
                    return 3; //scissor
                case 6: //win
                    return 1; //rock
            }
        }

        throw new Exception("no match");
    }

    private static bool IsRock(string value)
    {
        return value.Equals("A");
    }
    private static bool IsPaper(string value)
    {
        return value.Equals("B");
    }
    private static bool IsScissor(string value)
    {
        return value.Equals("C");
    }
}
