using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models;

[Table("vehicle")]
public partial class Vehicle
{
    [Key]
    [Column("vin")]
    public string Vin { get; set; } = null!;

    [Column("odometer")]
    public int Odometer { get; set; }

    [Column("model_id")]
    public int ModelId { get; set; }

    [ForeignKey("ModelId")]
    [InverseProperty("Vehicles")]
    public virtual Model Model { get; set; } = null!;
}
