using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models;

[Table("model")]
public partial class Model
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("manufacturer_id")]
    public int ManufacturerId { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [ForeignKey("ManufacturerId")]
    [InverseProperty("Models")]
    public virtual Manufacturer Manufacturer { get; set; } = null!;

    [InverseProperty("Model")]
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
