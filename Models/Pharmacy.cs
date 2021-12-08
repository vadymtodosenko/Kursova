using System;
using System.ComponentModel.DataAnnotations;
namespace pharma.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }
        [Display(Name = "Адреса")]
        public string Address { get; set; }
        [Display(Name = "Місто")]
        public string City { get; set; }
    }
}
