using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab04WebAPI.Models
{


    public class Hospitalmedicines
    {
        [Key]
        [DisplayName("MedicineId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineId { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Manufactorer")]

        public string Manufactorer { get; set; }

        [DisplayName("Price")]
        public double Price { get; set; }

    }
    
}
