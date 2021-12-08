using System;
using System.ComponentModel.DataAnnotations;
namespace pharma.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Ім'я")]
        public string Name { get; set; }
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }
        [Display(Name = "Номер телефону")]
        public string Phone { get; set; }
        [Display(Name = "Пароль")]
        public string Password { get; set; }

    }
}
