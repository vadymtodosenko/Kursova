using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using pharma.Models;

namespace pharma.Controllers
{
    public class TovarController : DBController
    {
        private readonly ILogger<HomeController> _logger;

        public TovarController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Shop(int Category)
        {
            List<Category> categories = ShowCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            if (Category != 0)
            {
                return View(ShowTovars().Where(s => s.Category == categories[Category - 1].Name).ToList());
            }
            return View(ShowTovars());
        }
        public IActionResult Find(string name)
        {
            List<Tovar> find = ShowTovars();
            Tovar tovar = find.Find(p => p.Name == name);
            if (tovar == null) return RedirectToAction("Shop");
            return View("OneTovar", tovar);
        }
        public IActionResult OneTovar(int id)
        {
            List<Tovar> find = ShowTovars();
            Tovar tovar = find.Find(p => p.Id == id);
            return View(tovar);
        }
        public IActionResult Checkout(int id, int Count)
        {
            List<Tovar> find = ShowTovars();
            Tovar tovar = find.Find(p => p.Id == id);
            if (Count != 0 ) ViewBag.Count = Count;

            return View(tovar);
        }
        public IActionResult CreateOrder(User user)
        {
            List<Tovar> tovars = ShowTovars();
            List<Pharmacy> pharmacies = ShowPharmacies();
            List<Payment> payments = ShowPayments();
            ViewBag.Tovars = new SelectList(tovars, "Id", "Name");
            ViewBag.Pharmacies = new SelectList(pharmacies, "Id", "Address");
            ViewBag.Payments = new SelectList(payments, "Id", "Type");
            return View(user);
        }
        public IActionResult NewOrder(int id)
        {
            List<User> users = ShowUsers();
            User user = users.Find(p => p.Id == id);
            List<Tovar> tovars = ShowTovars();
            List<Pharmacy> pharmacies = ShowPharmacies();
            List<Payment> payments = ShowPayments();
            List<Receipt> receipts = ShowReceipts();
            ViewBag.Tovars = new SelectList(tovars, "Id", "Name");
            ViewBag.Pharmacies = new SelectList(pharmacies, "Id", "Address");
            ViewBag.Payments = new SelectList(payments, "Id", "Type");
            return View(user);
        }
        [HttpPost]
        public IActionResult NewOrder(int id, int Tovar, int Pharmacy, int Payment)
        {
            List<Tovar> tovars = ShowTovars();
            Tovar tovar = tovars.Find(p => p.Id == Tovar);
            List<Receipt> receipts = ShowReceipts();
            int IdOrder = receipts.TakeWhile((x, i) => x.Id == i + 1).LastOrDefault()?.Id + 1 ?? 1;
            string MyConnection2 = "server=localhost;user=root;password=password;database=pharmacy;";
            string Query = $"insert into pharmacy.Чек(Вартість_замовлення, Оплата_idОплата, Час_оформлення) " +
                $"values('{tovar.Price}', '{Payment}', '{DateTime.Now.ToString("yyyy'-'MM'-'dd hh:mm:ss")}'); " +
                $"insert into pharmacy.Замовлення(idАптека, Товар_idТовар, Клієнт_idКлієнт, Чек_idЧек) " +
                $"values({Pharmacy}, {Tovar}, {id}, {IdOrder})";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
            return RedirectToAction("Thankyou");
        }
        public IActionResult Thankyou()
        {
            return View();
        }
    }
}
