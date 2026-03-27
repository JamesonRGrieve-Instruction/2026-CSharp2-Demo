using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models;

public partial class CarsContext : DbContext
{
    public CarsContext()
    {
    }

    public CarsContext(DbContextOptions<CarsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=database.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasData([
                new Manufacturer() {
                                Id = -1,
                                Name = "Toyota"
                            },
                            new Manufacturer() {
                                Id = -2,
                                Name = "Mitsubishi"
                            }
            ]);
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Models).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasData([
        new Model() {
                        Id = -1,
                        Name = "Supra",
                        ManufacturerId = -1,
                    },
                    new Model() {
                        Id = -2,
                        Name = "Soarer",
                        ManufacturerId = -1,
                    },
                    new Model() {
                        Id = -3,
                        Name = "3000GT",
                        ManufacturerId = -2,
                    },
                    new Model() {
                        Id = -4,
                        Name = "Eclipse",
                        ManufacturerId = -2
                    }
    ]);

        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasOne(d => d.Model).WithMany(p => p.Vehicles).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasData([
                    new Vehicle()
                    {
                        Vin = "VIN00000000000001",
                        ModelId = -1, // Supra
                        Odometer = 100

                    },
                    new Vehicle()
                    {
                        Vin = "VIN00000000000002",
                        ModelId = -2, // Soarer
                        Odometer = 100
                    },
                    new Vehicle()
                    {
                        Vin = "VIN00000000000003",
                        ModelId = -3, // 3000GT
                        Odometer = 100

                    },
                    new Vehicle()
                    {
                        Vin = "VIN00000000000004",
                        ModelId = -4, // Eclipse
                        Odometer = 100

                    }]);

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
