using ServerMonitorCLI.Models;

namespace ServerMonitorCLI.Reports;

public class ReportGenerator
{
    public void Generate(ServerInfo serverInfo)
    {
        Directory.CreateDirectory("reports");

        var fileName =
            $"reports/report-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.txt";

        var content = $"""
SERVER REPORT

Generated At: {DateTime.Now}

CPU Usage  : {serverInfo.CpuUsage:F2}%
RAM Usage  : {serverInfo.MemoryUsage:F2}%
Disk Usage : {serverInfo.DiskUsage:F2}%
Uptime     : {serverInfo.Uptime}
""";

        File.WriteAllText(fileName, content);

        Console.WriteLine($"Report saved: {fileName}");
    }
}