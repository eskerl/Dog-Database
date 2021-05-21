using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogWebApp.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [StringLength(16)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public List<Dog> Dogs { get; set; }
    }
}
