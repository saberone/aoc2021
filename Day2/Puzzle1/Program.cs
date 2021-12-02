using System.Text.RegularExpressions;
using Puzzle1;

int horizontalPosition = 0;
int depth = 0;

foreach (var line in File.ReadLines(@"input.txt"))
{
   var submarineCommand = ParseLineToCommand(line);

   switch (submarineCommand.CommandType)
   { 
       case CommandType.None:
           break;
       case CommandType.Forward:
           horizontalPosition += submarineCommand.Value;
           break;
       case CommandType.Down:
           depth += submarineCommand.Value;
           break;
       case CommandType.Up:
           depth -= submarineCommand.Value;
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