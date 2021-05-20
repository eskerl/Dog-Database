using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace DogDatabase.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Birthday { get; set; }

        [Range(0, 30)]
        public short Age { get; set; }

        [Range(0.0, 350.0)]
        public float Weight { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Dog>(this);
    }
}
