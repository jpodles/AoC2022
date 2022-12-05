using AoC2022;
using AoC2022.Days;

using Spectre.Console;

var results = new List<Result>()
    .Concat(await IAocResults.RunAndGetResults(Day01.PartOneAndTwo))
    .Concat(await IAocResults.RunAndGetResults(Day02.PartOneAndTwo))
    .Concat(await IAocResults.RunAndGetResults(Day03.PartOneAndTwo))
    .Concat(await IAocResults.RunAndGetResults(Day04.PartOneAndTwo))
    .Concat(await IAocResults.RunAndGetResults(Day05.PartOneAndTwo));



var table = new Table();
var centered = (string name) => new TableColumn(name).Centered();

table
    .AddColumn(centered("DAY"))
    .AddColumn(centered("PART"))
    .AddColumn(centered("RESULT"));


results.ToList().ForEach(row => table.AddRow(row.Day.ToString(), row.Part.ToString(), row.Value.ToString() ?? 0.ToString()));


AnsiConsole.Write(table);
