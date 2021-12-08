using System;
using System.ComponentModel.DataAnnotations;
namespace pharma.Models
{
    public class Producer
    {
        public int Id { get; set; }
        [Display(Name = "Виробник")]
        public string Name { get; set; }
    }
}
