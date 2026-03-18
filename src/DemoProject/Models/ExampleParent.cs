using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models;

[Table("example_parent")]
public partial class ExampleParent
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [InverseProperty("Parent")]
    public virtual ICollection<ExampleTable> ExampleTables { get; set; } = new List<ExampleTable>();
}
