namespace Puzzle1;
public enum CommandType
{
    None,
    Forward,
    Down,
    Up
}

public readonly record struct SubmarineCommand(CommandType CommandType, int Value);