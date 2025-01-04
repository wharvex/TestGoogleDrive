using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestGoogleDrive.Models;

namespace TestGoogleDrive.Data;

public class TestGoogleDriveContext : DbContext
{
    public TestGoogleDriveContext(DbContextOptions<TestGoogleDriveContext> options)
        : base(options) { }

    public DbSet<TestRun> TestRun { get; set; } = default!;
    public DbSet<Commit> Commit { get; set; } = default!;

    public DbSet<ConfigPath> ConfigPath { get; set; } = default!;

    public DbSet<Config> Config { get; set; } = default!;
}
