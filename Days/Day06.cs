using AoC2022;

using System.Runtime.CompilerServices;

internal class Day06 : IAocResults
{

    public async static Task<ITuple> PartOneAndTwo()
    {
        var input = await File.ReadAllTextAsync("./Data/Day06.txt");

        var packetMarkerEndIdx = 0;
        var messageMarkerEndIdx = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i..].Take(4).Distinct().Count() == 4)
            {
                packetMarkerEndIdx = i + 4;

                for (int j = i; j < input.Length; j++)
                {
                    if (input[j..].Take(14).Distinct().Count() == 14)
                    {
                        messageMarkerEndIdx = j + 14;
                        break;
                    }
                }
                break;
            }
        }

        return (packetMarkerEndIdx, messageMarkerEndIdx);

    }
}
