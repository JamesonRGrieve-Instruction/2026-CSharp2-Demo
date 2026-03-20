using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models
{
    [Table("vehicle")]
    public partial class Vehicle
    {
        [Key]
        [Column("vin")]
        public string VIN { get; set; }

        [Column("model_year")]
        public int ModelYear { get; set; }

        [Column("colour")]
        public string Colour { get; set; }

        [Column("model_id")]
        public int ModelID { get; set; }

        [ForeignKey(nameof(ModelID))]
        [InverseProperty(nameof(Model.Vehicles))]
        public virtual Model? Model { get; set; }
    }
}