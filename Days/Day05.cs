using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AoC2022.Days;

internal partial class Day05 : IAocResults
{
    public static List<Stack<char>> stacks = new();

    public async static Task<ITuple> PartOneAndTwo() => (await Move(CrateMover9000), await Move(CrateMover9001));
    public static async Task<string> Move(Action<int, int, int> crateMover)
    {
        var input = await File.ReadAllTextAsync("./Data/Day05.txt");

        var stackInput = input.Split(Environment.NewLine + Environment.NewLine)
            .First().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var instructionInput = input.Split(Environment.NewLine + Environment.NewLine)
            .Last().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var numOfCrates = stackInput.Last().Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        for (var i = 0; i < numOfCrates; i++)
            stacks.Add(new Stack<char>());


        foreach (var level in stackInput.SkipLast(1).Reverse())
        {
            for (var i = 0; i < numOfCrates; i++)
            {
                var crate = level[4 * i + 1];
                if (crate != ' ')
                {
                    stacks[i].Push(crate);
                }
            }
        }

        var result = new List<char>();
        foreach (var line in instructionInput)
        {
            var match = InstructionRegex().Match(line);
            var amount = int.Parse(match.Groups[1].Value);
            var from = int.Parse(match.Groups[2].Value) - 1;
            var to = int.Parse(match.Groups[3].Value) - 1;
            crateMover(amount, from, to);
        }

        foreach (var stack in stacks)
        {
            if (stack.Count == 0)
                continue;
            result.Add(stack.Peek());
        }

        return new string(result.ToArray());
    }

    public static void CrateMover9000(int amount, int from, int to)
    {
        for (int i = 0; i < amount; i++)
        {
            stacks[to].Push(stacks[from].Pop());

        }
    }

    public static void CrateMover9001(int amount, int from, int to)
    {
        var temp = new Stack<char>();
        for (int i = 0; i < amount; i++)
        {
            temp.Push(stacks[from].Pop());
        }

        for (int i = 0; i < amount; i++)
        {
            stacks[to].Push(temp.Pop());
        }
    }




    [GeneratedRegex("move (.*) from (.*) to (.*)")]
    private static partial Regex InstructionRegex();
}
