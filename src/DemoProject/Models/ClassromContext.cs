using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models;

public partial class ClassromContext : DbContext
{
    public ClassromContext()
    {
    }

    public ClassromContext(DbContextOptions<ClassromContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=database.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasData([
                new Classroom() {
                    Id = -1,
                    RoomNumber = 101,
                }
            ]);
        });
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasOne(d => d.Class).WithMany(p => p.Students).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasData([
            new Student() {
                    Id = -1,
                    ClassId = -1,
                    FirstName = "John",
                    MiddleName = "Bob",
                    LastName = "Doe"
                }
            ]);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
