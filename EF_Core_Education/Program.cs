using System;
using System.Linq;

namespace EF_Core_Education
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User tom = new User { Name = "Tom", Age = 33 };
                User alice = new User { Name = "Alice", Age = 26 };

                db.Add(tom);
                db.Add(alice);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены!");

                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User user in users)
                {
                    Console.WriteLine($"{user.Id}. {user.Name} - {user.Age}");
                }
            }
        }
    }
}
