using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models;

[Table("classroom")]
public partial class Classroom
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("room_number")]
    public int RoomNumber { get; set; }

    [InverseProperty("Class")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
