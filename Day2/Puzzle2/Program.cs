using System.Text.RegularExpressions;
using Puzzle2;

int horizontalPosition = 0;
int depth = 0;
int aim = 0;

foreach (var line in File.ReadLines(@"input.txt"))
{
    var submarineCommand = ParseLineToCommand(line);

    switch (submarineCommand.CommandType)
    { 
        case CommandType.None:
            break;
        case CommandType.Forward:
            horizontalPosition += submarineCommand.Value;
            depth += aim * submarineCommand.Value;
            break;
        case CommandType.Down:
            aim += submarineCommand.Value;
            break;
        case CommandType.Up:
            aim -= submarineCommand.Value;
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
}

Console.WriteLine($"Horizontal position: {horizontalPosition} Depth: {depth}");
Console.WriteLine($"Solution: {horizontalPosition * depth}");

SubmarineCommand ParseLineToCommand(string line)
{
    const string pattern = @"(\w+)\s(\d+)";
    var match =  Regex.Matches(line, pattern, RegexOptions.None).FirstOrDefault();

    var commandType = match?.Groups[1].Value switch
    {
        "forward" => CommandType.Forward,
        "down" => CommandType.Down,
        "up" => CommandType.Up,
        _ => CommandType.None
    };

    return new SubmarineCommand(commandType, int.Parse(match?.Groups[2].Value!));
}