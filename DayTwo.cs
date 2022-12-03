using System.Runtime.CompilerServices;

namespace AoC2022;

internal class DayTwo : IAocResults
{
    public static async Task<ITuple> PartOneAndTwo()
    {
        var partOneResult = 0;
        var partTwoResult = 0;

        await foreach (var line in File.ReadLinesAsync("./Data/DayTwo.txt"))
        {
            var (oponent, player) = line.Split(" ") switch { var a => (a[0], a[1]) };

            var playerShape = GetShape(player);
            var oponentShape = GetShape(oponent);

            partOneResult += GetMatchResult(playerShape, oponentShape);

            var designetedPlayerShape = DesignatePlayerShape(player, oponentShape);
            partTwoResult += GetMatchResult(designetedPlayerShape, oponentShape);
        }

        return (partOneResult, partTwoResult);
    }


    static int GetMatchResult(Shape playerShape, Shape oponentShape) 
        => (int)playerShape + playerShape switch
    {
        Shape.Rock => GetResult(oponentShape, Shape.Scissors, Shape.Paper),
        Shape.Paper => GetResult(oponentShape, Shape.Rock, Shape.Scissors),
        Shape.Scissors => GetResult(oponentShape, Shape.Paper, Shape.Rock),
        _ => throw new NotImplementedException()
    };

    static int GetResult(Shape oponentShape, Shape winningForPlayer, Shape losingForPlayer)
    {
        if (oponentShape == winningForPlayer) 
            return (int)MatchResult.Win;
        if (oponentShape == losingForPlayer) 
            return (int)MatchResult.Lose;
        return (int)MatchResult.Draw;
    }


    static Shape GetShape(string letter) => letter switch
    {
        "A" or "X" => Shape.Rock,
        "B" or "Y" => Shape.Paper,
        "C" or "Z" => Shape.Scissors,
        _ => throw new NotImplementedException(),
    };

    static Shape DesignatePlayerShape(string playerString, Shape oponentShape) => (playerString, oponentShape) switch
    {
        ("X", Shape.Rock) => Shape.Scissors,
        ("X", Shape.Paper) => Shape.Rock,
        ("X", Shape.Scissors) => Shape.Paper,
        ("Z", Shape.Rock) => Shape.Paper,
        ("Z", Shape.Paper) => Shape.Scissors,
        ("Z", Shape.Scissors) => Shape.Rock,
        ("Y", _) => oponentShape,
        _ => throw new NotImplementedException(),
    };


    enum Shape
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3,
    }

    enum MatchResult
    {
        Lose = 0,
        Draw = 3,
        Win = 6
    }

}

