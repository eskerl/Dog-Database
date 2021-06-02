using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogWebApp.Dtos
{
    public class DogDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Breed { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        [Range(0, 30)]
        public short? Age { get; set; }


        [Range(0.0, 350.0)]
        public float? Weight { get; set; }
    }
}
