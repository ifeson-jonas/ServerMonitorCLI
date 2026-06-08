namespace ServerMonitorCLI.Services;

public class DiskService
{
    public double GetDiskUsage()
    {
        var drive = DriveInfo.GetDrives()
            .FirstOrDefault(d => d.Name == "/");

        if (drive is null)
        {
            Console.WriteLine("Root drive not found.");
            return 0;
        }

        return ((double)(drive.TotalSize - drive.AvailableFreeSpace)
            / drive.TotalSize) * 100;
    }
}