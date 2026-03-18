using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Models;

[Table("example_table")]
[Index("ParentId", Name = "IX_example_table_parent_id")]
public partial class ExampleTable
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("parent_id")]
    public int ParentId { get; set; }

    [ForeignKey("ParentId")]
    [InverseProperty("ExampleTables")]
    public virtual ExampleParent Parent { get; set; } = null!;
}
