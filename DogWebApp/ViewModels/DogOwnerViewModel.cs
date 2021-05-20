using DogWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogWebApp.ViewModels
{
    public class DogOwnerViewModel
    {
        public List<Dog> Dogs { get; set; }
        public Owner Owner { get; set; }
    }
}
