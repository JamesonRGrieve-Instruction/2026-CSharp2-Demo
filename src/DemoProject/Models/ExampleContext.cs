using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models;

public partial class ExampleContext : DbContext
{
    public ExampleContext()
    {
    }

    public ExampleContext(DbContextOptions<ExampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EfmigrationsLock> EfmigrationsLocks { get; set; }

    public virtual DbSet<ExampleParent> ExampleParents { get; set; }

    public virtual DbSet<ExampleTable> ExampleTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=example.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EfmigrationsLock>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<ExampleTable>(entity =>
        {
            entity.HasOne(d => d.Parent).WithMany(p => p.ExampleTables).OnDelete(DeleteBehavior.Restrict);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
