using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestGoogleDrive.Models;

public enum StreamLoc
{
    Folder,
    DriveLetter,
}

public enum Syncing
{
    Stream,
    Mirror,
}

public class Config
{
    [Key]
    public int Id { get; set; }

    [DisplayName("Streaming Location")]
    public StreamLoc StreamLoc { get; set; }

    [DisplayName("Syncing Options")]
    public Syncing Syncing { get; set; }

    public string Name => "Syncing " + Syncing + " with StreamLoc " + StreamLoc;
}
