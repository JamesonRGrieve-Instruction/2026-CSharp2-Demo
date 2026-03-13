using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models
{
    [Table("example_table")]
    public partial class ExampleTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("parent_id")]
        public int ParentID { get; set; }

        [ForeignKey(nameof(ParentID))]
        [InverseProperty(nameof(ExampleParent.ExampleTables))]
        public virtual ExampleParent? ExampleParent { get; set; }
    }
}