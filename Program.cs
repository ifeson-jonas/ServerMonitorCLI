using ServerMonitorCLI.Models;
using ServerMonitorCLI.Services;
using ServerMonitorCLI.Utils;
using ServerMonitorCLI.Reports;

var reportMode = args.Contains("--report");
var watchMode = args.Contains("--watch");

var cpuService = new CpuService();
var memoryService = new MemoryService();
var diskService = new DiskService();
var uptimeService = new UptimeService();
var helpMode = args.Contains("--help");

if (watchMode)
{
    while (true)
    {
        var serverInfo = new ServerInfo
        {
            CpuUsage = await cpuService.GetCpuUsageAsync(),
            MemoryUsage = memoryService.GetMemoryUsagePercentage(),
            DiskUsage = diskService.GetDiskUsage(),
            Uptime = uptimeService.GetUptime()
        };

        Console.Clear();

        ConsoleFormatter.PrintServerInfo(serverInfo);

        await Task.Delay(2000);
    }
}
else
{
    var serverInfo = new ServerInfo
    {
        CpuUsage = await cpuService.GetCpuUsageAsync(),
        MemoryUsage = memoryService.GetMemoryUsagePercentage(),
        DiskUsage = diskService.GetDiskUsage(),
        Uptime = uptimeService.GetUptime()
    };

    ConsoleFormatter.PrintServerInfo(serverInfo);

    if (reportMode)
    {
        var reportGenerator = new ReportGenerator();
        reportGenerator.Generate(serverInfo);
    }
}

if (helpMode)
{
    Console.WriteLine("Usage:");
    Console.WriteLine("--report   Generate a report");
    Console.WriteLine("--watch    Watch server resources");
    Console.WriteLine("--help     Show this help message");
}