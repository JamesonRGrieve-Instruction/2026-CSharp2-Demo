using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models
{
    [Table("example_table")]
    public partial class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("parent_id")]
        public int ClassRoomID { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }


        [ForeignKey(nameof(ClassRoomID))]
        [InverseProperty(nameof(ClassRoom.Students))]
        public virtual ClassRoom? ClassRoom { get; set; }
    }
}