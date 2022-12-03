using System.Runtime.CompilerServices;

namespace AoC2022
{
    internal class DayThree : IAocResults
    {
        public static async Task<ITuple> PartOneAndTwo() => (await PartOne(), await PartTwo());

        async static Task<int> PartOne()
        {
            var result = 0;
            await foreach (var line in File.ReadLinesAsync("./Data/DayThree.txt"))
            {
                var firstRucksack = line.Take(line.Length / 2).ToArray();
                var secondRucksack = line.TakeLast(line.Length / 2).ToArray();

                result += GetValue(firstRucksack.Intersect(secondRucksack).Select(x => x).First());
            }
            return result;
        }

        async static Task<int> PartTwo()
        {
            var groupCount = 0;
            var listOfGroups = new List<List<List<char>>>();
            var groupList = new List<List<char>>();
            await foreach (var line in File.ReadLinesAsync("./Data/DayThree.txt"))
            {
                groupList.Add(line.ToList());
                groupCount++;

                if (groupCount == 3)
                {
                    listOfGroups.Add(groupList);
                    groupList = new List<List<char>>();
                    groupCount = 0;
                }
            }

            var results = new List<HashSet<char>>();
            listOfGroups.ForEach(list =>
            {
                var intersection = list
                   .Skip(1)
                   .Aggregate(
                       new HashSet<char>(list.First()),
                       (a, b) => { a.IntersectWith(b); return a; }
                   );

                results.Add(intersection);
            });
            return results.Select(x => GetValue(x.First())).Sum();
        }

        static int GetValue(char item) => char.IsLower(item) ? item - 96 : item - 38;
    }
}