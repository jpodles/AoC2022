var input = File.ReadAllText("./Data/Day06.txt");

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

Console.WriteLine(packetMarkerEndIdx);
Console.WriteLine(messageMarkerEndIdx);
