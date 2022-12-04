using AoC2022;

using System.Net.WebSockets;

var results = new List<Result>()
    .Concat(await IAocResults.RunAndGetResults(DayOne.PartOneAndTwo))
    .Concat(await IAocResults.RunAndGetResults(DayTwo.PartOneAndTwo))
    .Concat(await IAocResults.RunAndGetResults(DayThree.PartOneAndTwo));

//TODO: Spectre.Console table

Console.WriteLine((await DayFour.PartOneAndTwo())[1]);