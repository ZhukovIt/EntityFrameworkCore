using EF_Core_Education;
using System;
using System.Linq;

namespace DbFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (helloappContext db = new helloappContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Users u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }
    }
}
