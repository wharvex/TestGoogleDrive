using System.ComponentModel.DataAnnotations;

namespace TestGoogleDrive.Models;

public class Commit
{
    [Key]
    public int Id { get; set; }
    public string SourceCommit { get; set; } = string.Empty;
    public string ForkCommit { get; set; } = string.Empty;
    public string Name => ForkCommit + " on " + SourceCommit;
}
