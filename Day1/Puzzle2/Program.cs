var increasedCount = 0;

var measurementsQueue = new Queue<int>();

foreach (var line in File.ReadLines(@"input.txt"))
{
    var currentValue = int.Parse(line.Trim());

    measurementsQueue.Enqueue(currentValue);
    
    if (measurementsQueue.Count == 4)
    {
        var segmentA = new ArraySegment<int>(measurementsQueue.ToArray(), 0, 3);
        var segmentB = new ArraySegment<int>(measurementsQueue.ToArray(), 1, 3);
        
        if ( segmentA.Sum() < segmentB.Sum())
        {
            increasedCount++;
        }
        
        measurementsQueue.Dequeue();
    }
}

Console.WriteLine($"Measurements larger than previous {increasedCount}");
Console.ReadKey();
