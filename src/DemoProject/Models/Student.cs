using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models;

[Table("student")]
public partial class Student
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("class_id")]
    public int ClassId { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; } = null!;
    [Column("middle_name")]
    public string MiddleName { get; set; } = null!;

    [Column("last_name")]
    public string LastName { get; set; } = null!;

    [ForeignKey("ClassId")]
    [InverseProperty("Students")]
    public virtual Classroom Class { get; set; } = null!;
}
