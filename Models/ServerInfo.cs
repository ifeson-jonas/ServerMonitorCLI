namespace ServerMonitorCLI.Models;

public class ServerInfo
{
    public double CpuUsage { get; set; }

    public double MemoryUsage { get; set; }

    public double DiskUsage { get; set; }

    public string Uptime { get; set; } = string.Empty;
}