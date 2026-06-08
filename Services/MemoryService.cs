namespace ServerMonitorCLI.Services;

public class MemoryService
{
    public double GetMemoryUsagePercentage()
    {
        var lines = File.ReadAllLines("/proc/meminfo");

        var total = ExtractValue(lines, "MemTotal");
        var available = ExtractValue(lines, "MemAvailable");

        return ((double)(total - available) / total) * 100;
    }

    private long ExtractValue(string[] lines, string key)
    {
        var line = lines.First(x => x.StartsWith(key));

        return long.Parse(
            line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]
        );
    }
}