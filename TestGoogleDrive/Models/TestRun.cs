using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestGoogleDrive.Models;

public class TestRun
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Commit")]
    [DisplayName("Commit")]
    public int CommitId { get; set; }

    [MaxLength(100)]
    public string CommitName { get; set; } = "??";

    [ForeignKey("Config")]
    [DisplayName("Config")]
    public int ConfigId { get; set; }

    [MaxLength(100)]
    public string ConfigName { get; set; } = "??";

    [UIHint("_BoolIconTemplatePartial")]
    [DisplayName("Appears exactly once under 'Cloud Drives'")]
    public bool AppearsExactlyOnce { get; set; }

    [UIHint("_BoolIconTemplatePartial")]
    [DisplayName("Does not appear under plain 'Drives' in sidebar or home")]
    public bool NotUnderPlainDrives { get; set; }

    [UIHint("_BoolIconTemplatePartial")]
    [DisplayName("Opens 'My Drive' directly")]
    public bool OpensMyDriveDirectly { get; set; }
}
