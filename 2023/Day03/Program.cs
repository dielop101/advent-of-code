using _2023.Day03;

var sumEngineSchematic = Logic.SumEngineSchematic(@"data\input.txt");

//1.127.521 too high. Result = 527446
Console.WriteLine($"Result: {sumEngineSchematic}");


//using Helpers;

//const char empty = '.', gearIndicator = '*';
//var lines = ReadFile.Lines(@"data\input.txt").ToArray();
//int lineLen = lines[0].Length;
//Dictionary<(int x, int y), char> map = new();
//List<(int x, int y, int len, int val)> numbers = new();
//HashSet<(int x, int y)> justSpecial = new();
//Dictionary<(int x, int y), List<(int x, int y, int len, int val)>> gearTouches = new();
//Func<char, bool> isDigit = (val) => val >= '0' && val <= '9';
//string rowRaw;
//char val;
//int len;
//bool recording = false, ended = false;
//for (int row = 0, rMax = lines.Length; row < rMax; ++row)
//{
//    recording = false;
//    rowRaw = lines[row];
//    for (int col = 0, cMax = rowRaw.Length; col < cMax; ++col)
//    {
//        val = rowRaw[col];
//        if (isDigit(val))
//        {
//            map.Add((col, row), val);
//            if (!recording)
//            {
//                recording = true;
//                ended = false;
//                for (int sub = col + 1; sub < cMax; ++sub)
//                {
//                    val = rowRaw[sub];
//                    if (!isDigit(val))
//                    {
//                        ended = true;
//                        len = sub - col;
//                        numbers.Add((col, row, len, int.Parse(rowRaw.Substring(col, len))));
//                        break;
//                    }
//                }
//                if (!ended)
//                {
//                    len = cMax - col;
//                    numbers.Add((col, row, len, int.Parse(rowRaw.Substring(col))));
//                }
//            }
//        }
//        else if (val != empty)
//        {
//            recording = false;
//            justSpecial.Add((col, row));
//            map.Add((col, row), val);
//        }
//        else
//        {
//            recording = false;
//        }
//    }
//}
//Func<(int x, int y, int len, int val), bool> isTouchingSpecial = (t) => {
//    bool touching = false;
//    (int x, int y) topLeft = (t.x - 1, t.y - 1), bottomRight = (t.x + t.len, t.y + 1);
//    var matches = justSpecial.Where(x => x.x <= bottomRight.x && x.y <= bottomRight.y && x.x >= topLeft.x && x.y >= topLeft.y).ToList();
//    touching = matches.Any();
//    if (touching)
//    {
//        (int x, int y) point;
//        foreach (var match in matches)
//        {
//            point = (match.x, match.y);
//            if (map[point] == gearIndicator)
//            {
//                if (!gearTouches.TryGetValue(point, out var existingMatches))
//                {
//                    existingMatches = new();
//                    gearTouches.Add(point, existingMatches);
//                }
//                existingMatches.Add(t);
//            }
//        }
//    }
//    return touching;
//};
//long sum = 0L;
//foreach (var num in numbers)
//{
//    if (isTouchingSpecial(num)) sum += num.val;
//}
//Console.WriteLine($"Part 1: {sum}");
//var gears = justSpecial.Where(x => map[(x.x, x.y)] == gearIndicator).ToArray();
//var gearsWithExactly2Matches = gearTouches.Where(x => x.Value.Count == 2).ToArray();
//var ratios = gearsWithExactly2Matches.Sum(x => (long)x.Value[0].val * (long)x.Value[1].val);
//Console.WriteLine($"We have {gears.Length} gear indicators, {gearsWithExactly2Matches.Length} of them have exactly 2 matches. Answer: {ratios}");