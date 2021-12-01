// See https://aka.ms/new-console-template for more information


int? previousValue = null;
var increasedCount = 0;

foreach (string line in File.ReadLines(@"input.txt"))
{
    int currentValue = int.Parse(line.Trim());
    Console.Write($"{currentValue}: ");
    if (currentValue > previousValue)
    {
        Console.WriteLine($"increased");
        increasedCount++;
    } else if (currentValue < previousValue)
    {
        Console.WriteLine($"decreased");
    }
    previousValue = currentValue;
}
Console.WriteLine($"Measurements larger than previous {increasedCount}");
Console.ReadKey();