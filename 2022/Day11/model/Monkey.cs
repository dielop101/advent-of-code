namespace Day11.model;

public class Monkey
{
    private readonly bool _handicapWorryLevel;
    public Monkey(string id, string items, string operation, string test, string monkeyTrue, string monkeyFalse, bool handicapWorryLevel)
    {
        Id = short.Parse(id.Replace(":", "").Last().ToString());
        Items = items.Replace("Starting items: ", "").Split(',').Select(double.Parse).ToList();
        Operation = operation;
        DivisibleBy = short.Parse(test.Split(' ').Last());
        MonkeyTrueId = short.Parse(monkeyTrue.Split(' ').Last());
        MonkeyFalseId = short.Parse(monkeyFalse.Split(' ').Last());
        _handicapWorryLevel = handicapWorryLevel;
    }

    public short Id { get; init; }
    public short DivisibleBy { get; init; }
    public List<double> Items { get; set; }
    public string Operation { get; set; } = null!;
    public short MonkeyTrueId { get; set; }
    public short MonkeyFalseId { get; set; }
    public double InspectsItems { get; set; }

    public void AddItem(double item)
    {
        Items.Add(item);
    }

    public void DoAction(List<Monkey> monkeys)
    {
        foreach (var item in Items)
        {
            InspectsItems++;
            var newItem = DoOperation(item);

            var mod = newItem % DivisibleBy;
            if (_handicapWorryLevel)
                newItem = Math.Floor(newItem / 3);
            else
            {
                var divisorLimit = monkeys.Aggregate(1, (c, m) => c * m.DivisibleBy);
                newItem %= divisorLimit;
            }

            if (newItem % DivisibleBy == 0)
            {
                monkeys.Single(x => x.Id == MonkeyTrueId).AddItem(newItem);
            }
            else
            {
                monkeys.Single(x => x.Id == MonkeyFalseId).AddItem(newItem);
            }
        }

        Items.Clear();
    }

    public double DoOperation(double oldItem)
    {
        var splitOperation = Operation.Split("= ");
        var operation = splitOperation[1].Split(' ');
        var firstItem = operation[0];
        var op = operation[1];
        var secondItem = operation[2];

        var transformFirstItem = firstItem == "old" ? oldItem : double.Parse(firstItem);
        var transformSecondItem = secondItem == "old" ? oldItem : double.Parse(secondItem);

        if (op == "+")
        {
            return transformFirstItem + transformSecondItem;
        }
        else if (op == "-")
        {
            return transformFirstItem - transformSecondItem;
        }
        else if (op == "*")
        {
            return transformFirstItem * transformSecondItem;
        }

        throw new Exception("operation not found");
    }
}
