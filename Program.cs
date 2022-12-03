

using AoC2022;

var dayOne = await IAocResults.RunAndGetResults(DayOne.PartOneAndTwo);
var dayTwo = await IAocResults.RunAndGetResults(DayTwo.PartOneAndTwo);


var results = new List<Result>()
    .Concat(await IAocResults.RunAndGetResults(DayOne.PartOneAndTwo))
    .Concat(await IAocResults.RunAndGetResults(DayTwo.PartOneAndTwo));

