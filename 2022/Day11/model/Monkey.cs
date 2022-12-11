namespace Day11.model;

public class Monkey
{
    public Monkey(string id, string items, string operation, string test, string monkeyTrue, string monkeyFalse)
    {
        Id = short.Parse(id.Replace(":", "").Last().ToString());
        Items = items.Replace("Starting items: ", "").Split(',').Select(int.Parse).ToList();
        Operation = operation;
        DivisibleBy = short.Parse(test.Split(' ').Last());
        MonkeyTrueId = short.Parse(monkeyTrue.Split(' ').Last());
        MonkeyFalseId = short.Parse(monkeyFalse.Split(' ').Last());
    }

    public short Id { get; init; }
    public short DivisibleBy { get; init; }
    public List<int> Items { get; set; }
    public string Operation { get; set; } = null!;
    public short MonkeyTrueId { get; set; }
    public short MonkeyFalseId { get; set; }
    public int InspectsItems { get; set; }

    public void AddItem(int item)
    {
        Items.Add(item);
    }

    public void DoAction(List<Monkey> monkeys)
    {
        foreach (var item in Items)
        {
            InspectsItems++;
            var newItem = DoOperation(item);
            newItem = newItem / 3;  //reduce worry level

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

    public int DoOperation(int oldItem)
    {
        var splitOperation = Operation.Split("= ");
        var operation = splitOperation[1].Split(' ');
        var firstItem = operation[0];
        var op = operation[1];
        var secondItem = operation[2];

        var transformFirstItem = firstItem == "old" ? oldItem : int.Parse(firstItem);
        var transformSecondItem = secondItem == "old" ? oldItem : int.Parse(secondItem);

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
        else if (op == "/")
        {
            return transformFirstItem / transformSecondItem;
        }

        throw new Exception("operation not found");
    }
}
