using System.ComponentModel.DataAnnotations;

namespace TestGoogleDrive.Models;

public class TestRun
{
    [Key]
    public int Id { get; set; }
    [UIHint("_BoolTextTemplatePartial")]
    public bool IsDriveLetter { get; set; }
    [UIHint("_BoolTextTemplatePartial")]
    public bool IsMirrored { get; set; }
    [UIHint("_BoolIconTemplatePartial")]
    public bool AppearsExactlyOnce { get; set; }
    [UIHint("_BoolIconTemplatePartial")]
    public bool NotUnderPlainDrives { get; set; }
    [UIHint("_BoolIconTemplatePartial")]
    public bool OpensMyDriveDirectly { get; set; }
}
