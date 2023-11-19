using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab04WebAPI.Models
{
    public class Hospitaldoctors
    {
        [Key]
        [DisplayName("DoctorId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }

        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [DisplayName("LastName")]

        public string LastName { get; set; }

        [DisplayName("PhoneNumber")]
        public string PhoneNumber { get; set; }

    }
}
