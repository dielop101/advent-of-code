using _2022.Day1;

//part1
var elf = Logic.GetElfWithMostCalories(@"data\input.txt");
Console.WriteLine(elf);

//part2
elf = Logic.GetTotalSumOfCaloriesForThreTopElfs(@"data\input.txt");
Console.WriteLine(elf);