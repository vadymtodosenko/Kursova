using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using pharma.Models;

namespace pharma.Controllers
{
    public class AdminController : DBController
    {
        public IActionResult AdminPage()
        {
            return View();
        }
        public IActionResult Pharmacies()
        {
            return View(ShowPharmacies());
        }

        public IActionResult Tovars()
        {
            return View(ShowTovars());
        }
        [HttpGet]
        public IActionResult CreatePharmacy()
        {
            Pharmacy pharmacy = new Pharmacy();
            List<Pharmacy> pharmacies = ShowPharmacies();
            List<City> cities = ShowCities();
            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            pharmacy.Id = pharmacies.TakeWhile((x, i) => x.Id == i + 1).LastOrDefault()?.Id + 1 ?? 1;
            return View(pharmacy);
        }
        [HttpPost]
        public IActionResult CreatePharmacy(string Address, int City)
        {
            string MyConnection2 = "server=localhost;user=root;password=password;database=pharmacy;";
            string Query = $"insert into pharmacy.Аптека(Адреса, idМісто) " +
                $"values('{Address}', '{City}')";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
            return RedirectToAction("Pharmacies");
        }

        [HttpGet]
        public IActionResult EditPharmacy(int? id)
        {
            Pharmacy pharmacy = new Pharmacy();
            List<Pharmacy> pharmacies = ShowPharmacies();
            List<City> cities = ShowCities();
            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            pharmacy = pharmacies.Find(p => p.Id == id);
            return View(pharmacy);
        }
        [HttpPost]
        public IActionResult EditPharmacy(int Id, string Address, int City)
        {
            string MyConnection2 = "server=localhost;user=root;password=password;database=pharmacy;";
            string Query = $"update pharmacy.Аптека " +
                $"set Адреса = '{Address}', idМісто = '{City}' where idАптека = '{Id}'";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
            return RedirectToAction("Pharmacies");
        }
        [HttpGet]
        public IActionResult DeletePharmacy(int? id)
        {
            Pharmacy pharmacy = new Pharmacy();
            List<Pharmacy> pharmacies = ShowPharmacies();
            pharmacy = pharmacies.Find(p => p.Id == id);
            if (pharmacy == null) return RedirectToAction("HandleError");
            return View(pharmacy);
        }
        [HttpPost]
        public IActionResult DeletePharmacy(int? id, int city)
        {
            string MyConnection2 = "server=localhost;user=root;password=password;database=pharmacy;";
            string Query = $"delete from pharmacy.Аптека " +
                $"where idАптека = '{id}'; " +
                $"ALTER TABLE pharmacy.Аптека AUTO_INCREMENT = { id }; ";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
            return RedirectToAction("Pharmacies");
        }
        [HttpGet]
        public IActionResult CreateTovar()
        {
            Tovar tovar = new Tovar();
            List<Tovar> tovars = ShowTovars();
            List<Category> categories = ShowCategories();
            List<Producer> producers = ShowProducers();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ViewBag.Producers = new SelectList(producers, "Id", "Name");
            tovar.Id = tovars.Last().Id + 1;
            return View(tovar);
        }
        [HttpPost]
        public IActionResult CreateTovar(int Id, string Name, int Price, string Instruction, string Image, int Producer, int Category)
        {
            string MyConnection2 = "server=localhost;user=root;password=password;database=pharmacy;";
            string Query = $"insert into pharmacy.Товар(Назва_товару, Ціна, Інструкція, idВиробник, Зображення) " +
                $"values ('{Name}', '{Price}', '{Instruction}', '{Producer}', '{Image}');" +
                $"insert into pharmacy.Товар_has_Категорія(Товар_idТовар, Категорія_idКатегорія) " +
                $"values ('{Id}', '{Category}')";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
            return RedirectToAction("Tovars");
        }
        [HttpGet]
        public IActionResult EditTovar(int? Id)
        {
            Tovar tovar = new Tovar();
            List<Tovar> tovars = ShowTovars();
            List<Category> categories = ShowCategories();
            List<Producer> producers = ShowProducers();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ViewBag.Producers = new SelectList(producers, "Id", "Name");
            tovar = tovars.Find(p => p.Id == Id);
            return View(tovar);
        }
        [HttpPost]
        public IActionResult EditTovar(int Id, string Name, int Price, string Instruction, string Image, int Producer)
        {
            string MyConnection2 = "server=localhost;user=root;password=password;database=pharmacy;";
            string Query = $"update pharmacy.Товар " +
                $"set Назва_товару = '{Name}', Ціна = '{Price}', Інструкція = '{Instruction}', idВиробник = '{Producer}', Зображення = '{Image}' " +
                $"where idТовар = '{Id}'";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
            return RedirectToAction("Tovars");
        }
        [HttpGet]
        public IActionResult DeleteTovar(int? Id)
        {
            Tovar tovar = new Tovar();
            List<Tovar> tovars = ShowTovars();
            tovar = tovars.Find(p => p.Id == Id);
            if (tovar == null) return RedirectToAction("HandleError");
            return View(tovar);
        }
        [HttpPost]
        public IActionResult DeleteTovar(int? Id, int Category)
        {
            string MyConnection2 = "server=localhost;user=root;password=password;database=pharmacy;";
            string Query = $"delete from pharmacy.Товар_has_Категорія " +
                $"where Товар_idТовар = '{Id}'; " +
                $"delete from pharmacy.Товар " +
                $"where idТовар = '{Id}'; " +
                $"ALTER TABLE pharmacy.Товар AUTO_INCREMENT = {Id}; ";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
            return RedirectToAction("Tovars");
        }
    }
}
