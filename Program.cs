using ServerMonitorCLI.Models;
using ServerMonitorCLI.Services;
using ServerMonitorCLI.Utils;

var cpuService = new CpuService();
var memoryService = new MemoryService();
var diskService = new DiskService();
var uptimeService = new UptimeService();

var serverInfo = new ServerInfo
{
    CpuUsage = await cpuService.GetCpuUsageAsync(),
    MemoryUsage = memoryService.GetMemoryUsagePercentage(),
    DiskUsage = diskService.GetDiskUsage(),
    Uptime = uptimeService.GetUptime()
};

ConsoleFormatter.PrintServerInfo(serverInfo);