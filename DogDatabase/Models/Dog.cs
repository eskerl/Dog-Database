using System.Text.Json;

namespace DogDatabase.Models
{
    public class Dog
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Birthday { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Dog>(this);
    }
}
