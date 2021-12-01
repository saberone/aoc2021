int? previousValue = null;
var increasedCount = 0;

foreach (var line in File.ReadLines(@"input.txt"))
{
    var currentValue = int.Parse(line.Trim());

    Console.WriteLine(previousValue == null
        ? $"{currentValue}: (N/A)"
        : $"{currentValue}: ({(currentValue > previousValue ? "increased" : "decreased")})");

    if (currentValue > previousValue)
    {
        increasedCount++;
    } 
    previousValue = currentValue;
}
Console.WriteLine($"Measurements larger than previous {increasedCount}");
Console.ReadKey();