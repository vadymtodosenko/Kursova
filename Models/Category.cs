using System;
using System.ComponentModel.DataAnnotations;
namespace pharma.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Категорія")]
        public string Name { get; set; }
    }
}
