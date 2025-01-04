using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestGoogleDrive.Models;

public class ConfigPath
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Path { get; set; } = string.Empty;

    [ForeignKey("Config")]
    [DisplayName("Config")]
    public int ConfigId { get; set; }

    [MaxLength(100)]
    public string ConfigName { get; set; } = "??";
}
