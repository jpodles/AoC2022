using Spectre.Console;

using System.Runtime.CompilerServices;

namespace AoC2022;

internal class Day04 : IAocResults
{
    public static async Task<ITuple> PartOneAndTwo() => (await PartOne(), await PartTwo());
    static async Task<int> PartOne() => (await PrepareData())
        .Where(x => ContainsInList(x.Item1, x.Item2) || ContainsInList(x.Item2, x.Item1))
        .ToList().Count;

    static async Task<int> PartTwo() => (await PrepareData())
        .Where(x => x.Item1.Intersect(x.Item2).Any())
        .ToList().Count;

    async static Task<IEnumerable<(List<int>, List<int>)>> PrepareData() 
        => (await File.ReadAllLinesAsync("./Data/Day04.txt"))
        .Select(line => line.Split(",") switch { var arr => (First: PopulateList(arr[0]), Second: PopulateList(arr[1])) });

    static bool ContainsInList(IEnumerable<int> first, IEnumerable<int> second) 
        => !first.Except(second).Any();

    static List<int> PopulateList(string s)
    {
        var list = s.Split('-').Select(int.Parse).ToArray();
        return Enumerable.Range(list[0], list[1] - list[0] + 1).ToList();
    }

}
