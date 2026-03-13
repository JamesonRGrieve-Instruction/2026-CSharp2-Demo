using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models
{
    [Table("example_parent")]
    public partial class ExampleParent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [InverseProperty(nameof(ExampleTable.ExampleParent))]
        public virtual List<ExampleTable>? ExampleTables { get; set; }
    }
}