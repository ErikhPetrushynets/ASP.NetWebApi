using Lab04WebAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab04WebAPI.ViewModels
{
    public class HospitaldoctorViewModel
    {
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "The First Name field is required.")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required.")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "The Phone Number field is required.")]
        public string PhoneNumber { get; set; }

    }
}
