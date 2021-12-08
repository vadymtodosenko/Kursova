using System;
using System.ComponentModel.DataAnnotations;
namespace pharma.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        [Display(Name = "Вартість замовлення")]
        public int Price { get; set; }
        [Display(Name = "Оплата")]
        public string Payment { get; set; }
        [Display(Name = "Час оформлення")]
        public DateTime Time { get; set; }
    }
}
