namespace ServerMonitorCLI.Services;

public class CpuService
{
    public async Task<double> GetCpuUsageAsync()
    {
        var first = ReadCpuStats();

        await Task.Delay(1000);

        var second = ReadCpuStats();

        var totalDiff = second.Total - first.Total;
        var idleDiff = second.Idle - first.Idle;

        return (double)(totalDiff - idleDiff)
               / totalDiff * 100;
    }

    private (long Total, long Idle) ReadCpuStats()
    {
        var line = File.ReadLines("/proc/stat")
                       .First();

        var parts = line.Split(' ',
            StringSplitOptions.RemoveEmptyEntries);

        var values = parts.Skip(1)
                          .Select(long.Parse)
                          .ToArray();

        var idle = values[3];

        var total = values.Sum();

        return (total, idle);
    }
}