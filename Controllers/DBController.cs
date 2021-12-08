using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using pharma.Models;

namespace pharma.Controllers
{
    public class DBController : Controller
    {
        public static string connectionString = "server=localhost;user=root;password=password;database=pharmacy;";
        MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
        public List<Pharmacy> ShowPharmacies()
        {
            var sql = "SELECT idАптека, Адреса, Місто FROM Аптека " +
                "join Місто on Аптека.idМісто = Місто.idМісто;";
            MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
            List<Pharmacy> pharmacies = new List<Pharmacy>();
            try
            {
                mySqlConnection.Open();
                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    pharmacies.Add(new Pharmacy { Id = (int)rdr["idАптека"], Address = (string)rdr["Адреса"], City = (string)rdr["Місто"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            return pharmacies.OrderBy(p => p.Id).ToList();
        }
        public List<User> ShowUsers()
        {
            var sql = "SELECT * FROM pharmacy.Клієнт;";
            MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
            List<User> users = new List<User>();
            try
            {
                mySqlConnection.Open();
                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    users.Add(new User { Id = (int)rdr["idКлієнт"], Name = (string)rdr["Імя"], LastName = (string)rdr["Прізвище"], Phone = (string)rdr["Номер_телефону"], Email = (string)rdr["Електронна_пошта"], Password = (string)rdr["Пароль"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            return users.OrderBy(p => p.Id).ToList();
        }
        public List<Payment> ShowPayments()
        {
            var sql = "SELECT * FROM pharmacy.Оплата;";
            MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
            List<Payment> payments = new List<Payment>();
            try
            {
                mySqlConnection.Open();
                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    payments.Add(new Payment { Id = (int)rdr["idОплата"], Type = (string)rdr["Вид_оплати"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            return payments.OrderBy(p => p.Id).ToList();
        }
        public List<Receipt> ShowReceipts()
        {
            var sql = "SELECT * FROM pharmacy.Чек " +
                "join pharmacy.Оплата on Чек.Оплата_idОплата = Оплата.idОплата; ";
            MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
            List<Receipt> receipts = new List<Receipt>();
            try
            {
                mySqlConnection.Open();
                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    receipts.Add(new Receipt { Id = (int)rdr["idЧек"], Price = (int)rdr["Вартість_замовлення"], Payment = (string)rdr["Вид_оплати"], Time = (DateTime)rdr["Час_оформлення"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            return receipts.OrderBy(p => p.Id).ToList();
        }
        public List<Tovar> ShowTovars()
        {
            var sql = "SELECT idТовар, Назва_товару, Ціна, Інструкція, Назва_виробник, Зображення, Назва_категорія FROM pharmacy.Товар_has_Категорія " +
                "join pharmacy.Товар on Товар.idТовар = Товар_has_Категорія.Товар_idТовар " +
                "join pharmacy.Категорія on pharmacy.Категорія.idКатегорія = Товар_has_Категорія.Категорія_idКатегорія " +
                "join pharmacy.Виробник on pharmacy.Виробник.idВиробник = pharmacy.Товар.idВиробник; ";
            MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
            List<Tovar> tovars = new List<Tovar>();
            try
            {
                mySqlConnection.Open();
                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    tovars.Add(new Tovar { Id = (int)rdr["idТовар"], Name = (string)rdr["Назва_товару"], Price = (int)rdr["Ціна"], Instruction = (string)rdr["Інструкція"], Producer = (string)rdr["Назва_виробник"], Image = (string)rdr["Зображення"], Category = (string)rdr["Назва_категорія"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            return tovars.OrderBy(p => p.Id).ToList();
        }
        public List<Category> ShowCategories()
        {
            var sql = "SELECT * FROM pharmacy.Категорія;";
            MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
            List<Category> categories = new List<Category>();
            try
            {
                mySqlConnection.Open();
                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    categories.Add(new Category { Id = (int)rdr["idКатегорія"], Name = (string)rdr["Назва_категорія"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            return categories.OrderBy(p => p.Id).ToList();
        }
        public List<City> ShowCities()
        {
            var sql = "SELECT * FROM pharmacy.Місто;";
            MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
            List<City> cities = new List<City>();
            try
            {
                mySqlConnection.Open();
                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    cities.Add(new City { Id = (int)rdr["idМісто"], Name = (string)rdr["Місто"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            return cities.OrderBy(p => p.Id).ToList();
        }
        public List<Producer> ShowProducers()
        {
            var sql = "SELECT * FROM pharmacy.Виробник;";
            MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
            List<Producer> producers = new List<Producer>();
            try
            {
                mySqlConnection.Open();
                MySqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    producers.Add(new Producer { Id = (int)rdr["idВиробник"], Name = (string)rdr["Назва_виробник"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            return producers.OrderBy(p => p.Id).ToList();
        }
    }
}

