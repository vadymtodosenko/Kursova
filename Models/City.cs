using System;
using System.ComponentModel.DataAnnotations;
namespace pharma.Models
{
    public class City
    {
        public int Id { get; set; }
        [Display(Name = "Місто")]
        public string Name { get; set; }
    }
}
