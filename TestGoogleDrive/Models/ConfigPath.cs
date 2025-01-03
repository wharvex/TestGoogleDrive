using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestGoogleDrive.Models;

public class ConfigPath
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Path { get; set; } = string.Empty;

    [DisplayName("Streaming Location")]
    public StreamLoc StreamLoc { get; set; }

    [DisplayName("Syncing Options")]
    public Syncing Syncing { get; set; }
}
