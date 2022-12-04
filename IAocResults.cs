using System.Runtime.CompilerServices;

namespace AoC2022;

internal interface IAocResults
{
    static int Day { get; set; } = 1;
    static async Task<IEnumerable<Result>> RunAndGetResults(Func<Task<ITuple>> func)
    {
       
        ITuple result = await func();
        var resultList = new List<Result>();
        for (int i = 0; i < result.Length; i++)
        {
            var part = i + 1;
            var r = (int)(result[i] ?? 0);
            resultList.Add(new Result(Day, part, r));
        }
        Day++;
        return resultList;
    }
}
