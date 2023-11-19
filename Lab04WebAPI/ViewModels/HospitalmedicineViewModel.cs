using Lab04WebAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab04WebAPI.ViewModels
{
    public class HospitalmedicineViewModel
    {
        public int MedicineId { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Manufactorer field is required.")]
        public string Manufactorer { get; set; }

        [GreaterThanZero(ErrorMessage = "The Price must be greater than 0.")]
        public double Price { get; set; }

    }
}
