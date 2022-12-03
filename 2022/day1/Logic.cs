using Helpers;

namespace Day1;
public static class Logic
{
    public static int GetElfWithMostCalories(string filepath)
    {
        var lines = ReadFile.Lines(filepath);

        var elfWithMostCalories = 0;
        var currentElfWithCalories = 0;
        foreach (var calories in lines)
        {
            if (string.IsNullOrEmpty(calories))
            {
                if (currentElfWithCalories > elfWithMostCalories)
                    elfWithMostCalories = currentElfWithCalories;

                currentElfWithCalories = 0;
            }
            else
            {
                currentElfWithCalories += int.Parse(calories);
            }
        }

        return elfWithMostCalories;
    }

    public static int GetTotalSumOfCaloriesForThreTopElfs(string filepath)
    {
        var lines = ReadFile.Lines(filepath);

        var listOfCalories = new List<int>();
        var currentElfWithCalories = 0;
        foreach (var calories in lines)
        {
            if (string.IsNullOrEmpty(calories))
            {
                listOfCalories.Add(currentElfWithCalories);
                currentElfWithCalories = 0;
            }
            else
            {
                currentElfWithCalories += int.Parse(calories);
            }
        }

        if (currentElfWithCalories > 0)
            listOfCalories.Add(currentElfWithCalories);

        return listOfCalories.OrderByDescending(x => x).Take(3).Sum();
    }
}