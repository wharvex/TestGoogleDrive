namespace TestGoogleDrive.Models;

public class TestRun
{
    public int Id { get; set; }
    public bool IsDriveLetter { get; set; }
    public bool IsMirrored { get; set; }
    public bool AppearsExactlyOnce { get; set; }
    public bool NotUnderPlainDrives { get; set; }
    public bool OpensMyDriveDirectly { get; set; }
}