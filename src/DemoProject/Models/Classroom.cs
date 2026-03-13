using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models
{
    [Table("example_parent")]
    public partial class ClassRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("room_number")]
        public int RoomNumber { get; set; }


        [InverseProperty(nameof(Student.ClassRoom))]
        public virtual List<Student>? Students { get; set; }
    }
}