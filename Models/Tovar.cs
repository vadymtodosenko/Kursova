using System;
using System.ComponentModel.DataAnnotations;
namespace pharma.Models
{
    public class Tovar
    {
        public int Id { get; set; }
        [Display(Name = "Назва товару")]
        public string Name { get; set; }
        [Display(Name = "Ціна")]
        public int Price { get; set; }
        [Display(Name = "Інструкція")]
        public string Instruction { get; set; }
        [Display(Name = "Виробник")]
        public string Producer { get; set; }
        public string Image { get; set; }
        [Display(Name = "Категорія")]
        public string Category { get; set; }
    }
}
