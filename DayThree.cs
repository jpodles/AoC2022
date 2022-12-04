using System.Runtime.CompilerServices;

namespace AoC2022
{
    internal class DayThree : IAocResults
    {
        public static async Task<ITuple> PartOneAndTwo() => (await PartOne(), await PartTwo());

        async static Task<int> PartOne() => (await File.ReadAllLinesAsync("./Data/DayThree.txt"))
            .Select(line => (First: line.Take(line.Length / 2), Second: line.TakeLast(line.Length / 2)))
            .Select(group => group.First.Intersect(group.Second).Single())
            .Select(GetPriority)
            .Sum();

        async static Task<int> PartTwo() => (await File.ReadAllLinesAsync("./Data/DayThree.txt"))
            .Chunk(3)
            .Select(group => group[0].Intersect(group[1]).Intersect(group[2]).Single())
            .Select(GetPriority)
            .Sum();

        static int GetPriority(char item) => char.IsLower(item) ? item - 96 : item - 38;
    }
}