using AoC2022;

var results = new List<Result>()
    .Concat(await IAocResults.RunAndGetResults(DayOne.PartOneAndTwo))
    .Concat(await IAocResults.RunAndGetResults(DayTwo.PartOneAndTwo))
    .Concat(await IAocResults.RunAndGetResults(DayThree.PartOneAndTwo));


//TODO: Spectre.Console table