using System.Runtime.CompilerServices;

namespace AoC2022.Days;

internal class Day01 : IAocResults
{

    public static async Task<ITuple> PartOneAndTwo()
    {
        var acc = 0;
        var calories = new List<int>();

        await foreach (var line in File.ReadLinesAsync("./Data/Day01.txt"))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                calories.Add(acc);
                acc = 0;
                continue;
            }

            acc += int.Parse(line);
        }

        var maxCalories = calories.Max();
        var totlaCaloriesOfThreeElves = calories.OrderDescending().Take(3).Sum();

        return (maxCalories, totlaCaloriesOfThreeElves);
    }
}
