namespace ServerMonitorCLI.Services;

public class UptimeService
{
    public string GetUptime()
    {
        var content = File.ReadAllText("/proc/uptime");

        var seconds =
            double.Parse(content.Split(' ')[0]);

        var time =
            TimeSpan.FromSeconds(seconds);

        return $"{time.Days}d {time.Hours}h {time.Minutes}m";
    }
}