using System;
using System.ComponentModel.DataAnnotations;
namespace pharma.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Display(Name = "Аптека")]
        public Pharmacy pharmacy { get; set; }
        [Display(Name = "Товар")]
        public Tovar tovar { get; set; }
        [Display(Name = "Клієнт")]
        public User user { get; set; }
        [Display(Name = "Чек")]
        public Receipt receipt { get; set; }
    }
}
