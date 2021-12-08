using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using pharma.Models;

namespace pharma.Controllers
{
    public class UserController : DBController
    {
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            if (email == "admin@gmail.com" && password == "iamadmin")
            {
                return RedirectToAction("AdminPage", "Admin");
            }
            List<User> users = ShowUsers();
            User user = users.Find(p => p.Email == email && p.Password == password);
            if (user == null) return Content("Ви ввели неправильну пошту або пароль.");
            return RedirectToAction("CreateOrder", "Tovar", user);
        }
        [HttpPost]
        public IActionResult SignUp(string name, string lastname, string phone, string email, string password)
        {
            string MyConnection2 = "server=localhost;user=root;password=password;database=pharmacy;";
            string Query = $"insert into pharmacy.Клієнт(Імя, Прізвище, Номер_телефону, Електронна_пошта, Пароль)" +
                $"values('{name}', '{lastname}', '{phone}', '{email}', '{password}')";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
            return RedirectToAction("Index", "Home");
        }
    }
}
