using ServerMonitorCLI.Models;

namespace ServerMonitorCLI.Utils;

public static class ConsoleFormatter
{
    public static void PrintServerInfo(ServerInfo serverInfo)
    {
        Console.WriteLine("=================================");
        Console.WriteLine("         SERVER MONITOR");
        Console.WriteLine("=================================");
        Console.WriteLine();

        Console.WriteLine($"CPU Usage  : {serverInfo.CpuUsage:F2}%");
        Console.WriteLine($"RAM Usage  : {serverInfo.MemoryUsage:F2}%");
        Console.WriteLine($"Disk Usage : {serverInfo.DiskUsage:F2}%");
        Console.WriteLine($"Uptime     : {serverInfo.Uptime}");

        Console.WriteLine();
        Console.WriteLine("=================================");
    }
}