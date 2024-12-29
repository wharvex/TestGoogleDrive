using System.ComponentModel.DataAnnotations;

namespace TestGoogleDrive.Models;

public class TestRun
{
    [Key]
    public int Id { get; set; }
    public bool IsDriveLetter { get; set; }
    [UIHint("_TestRunAttrBoolTemplatePartial")]
    public bool IsMirrored { get; set; }
    public bool AppearsExactlyOnce { get; set; }
    public bool NotUnderPlainDrives { get; set; }
    public bool OpensMyDriveDirectly { get; set; }
}
