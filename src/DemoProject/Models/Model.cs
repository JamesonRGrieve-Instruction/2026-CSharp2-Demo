using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models
{
    [Table("model")]
    public partial class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }
        [Column("name")]

        public string Name { get; set; }

        [Column("manufacturer_id")]
        public int ManufacturerID { get; set; }

        [ForeignKey(nameof(ManufacturerID))]
        [InverseProperty(nameof(Manufacturer.Models))]
        public virtual Manufacturer? Manufacturer { get; set; }

        [InverseProperty(nameof(Vehicle.Model))]
        public virtual List<Vehicle>? Vehicles { get; set; }
    }
}