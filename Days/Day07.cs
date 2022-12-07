namespace AoC2022.Days;

internal static class Day07
{
    public static async Task<List<string>> PrepareData()
        => (await File.ReadAllTextAsync("./Data/Day07.txt"))
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

    public async static Task<ITuple> PartOneAndTwo() => (await PartOne(), await PartTwo());

    async static Task<int> PartOne() => DirectorySizes(await PrepareData()).Where(size => size <= 100000).Sum();
    async static Task<int> PartTwo()
    {
        var sizes = DirectorySizes(await PrepareData());
        return sizes.Where(size => size + (70000000 - sizes.Max()) >= 30000000).Min();
    }
    public static List<int> DirectorySizes(List<string> listOfCommands)
    {
        var path = new Stack<string>();
        var sizes = new Dictionary<string, int>();

        listOfCommands.ForEach(input =>
        {
            var cmd = input.Split(' ');
            if (cmd is ["$", "cd", ".."])
                path.Pop();
            else if (cmd is ["$", "cd", var dirName])
                path.Push(string.Join("", path) + dirName);
            else if (cmd is ["$", "ls"] or ["dir", ..])
                return;
            else if (cmd is [var fileSize, ..])
                foreach (var dir in path)
                    sizes[dir] = sizes.GetValueOrDefault(dir) + int.Parse(fileSize);
        });

        return sizes.Values.ToList();
    }

}



