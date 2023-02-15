using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //DoMain();
            DoMainAsync();
        }

        static void DoMain()
        {
            // Добавление пользователей
            InsertUsers();

            // Получение пользователей из БД и вывод их данных на консоль
            Console.WriteLine("Данные после добавления:");
            PrintUsers(SelectUsers());

            // Обновление данных пользователей и вывод на консоль
            UpdateUsers();
            Console.WriteLine("\nДанные после редактирования:");
            PrintUsers(SelectUsers());

            // Обновление данных пользователей и вывод на консоль
            DeleteUsers();
            Console.WriteLine("\nДанные после удаления:");
            PrintUsers(SelectUsers());
        }

        static void DoMainAsync()
        {
            // Добавление пользователей
            InsertUsersAsync();

            // Получение пользователей из БД и вывод их данных на консоль
            Console.WriteLine("Данные после добавления:");
            PrintUsers(SelectUsersAsync().Result);

            // Обновление данных пользователей и вывод на консоль
            UpdateUsersAsync();
            Console.WriteLine("\nДанные после редактирования:");
            PrintUsers(SelectUsersAsync().Result);

            // Обновление данных пользователей и вывод на консоль
            DeleteUsersAsync();
            Console.WriteLine("\nДанные после удаления:");
            PrintUsers(SelectUsersAsync().Result);
        }

        static void PrintUsers(IEnumerable<User> users)
        {
            foreach (User user in users)
            {
                Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
            }
        }

        static void InsertUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User tom = new User { Name = "Tom", Age = 33 };
                User alice = new User { Name = "Alice", Age = 26 };

                db.Users.Add(tom);
                db.Users.Add(alice);

                db.SaveChanges();
            }
        }

        static async void InsertUsersAsync()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User tom = new User { Name = "Tom", Age = 33 };
                User alice = new User { Name = "Alice", Age = 26 };

                await db.Users.AddRangeAsync(tom, alice);

                await db.SaveChangesAsync();
            }
        }

        static List<User> SelectUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Users.ToList();
            }
        }

        static async Task<List<User>> SelectUsersAsync()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return await db.Users.ToListAsync();
            }
        }

        static void UpdateUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;

                    db.SaveChanges();
                }
            }
        }

        static async void UpdateUsersAsync()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = await db.Users.FirstOrDefaultAsync();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;

                    await db.SaveChangesAsync();
                }
            }
        }

        static void DeleteUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    db.Users.Remove(user);

                    db.SaveChanges();
                }
            }
        }

        static async void DeleteUsersAsync()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = await db.Users.FirstOrDefaultAsync();
                if (user != null)
                {
                    db.Users.Remove(user);

                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
