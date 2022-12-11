using Day11;

var total = Logic.Part1(@"data\input.txt", 20, true);
Console.WriteLine(total);

//part2
//14394120588 too high
total = Logic.Part1(@"data\input.txt", 10000, false);
Console.WriteLine(total);