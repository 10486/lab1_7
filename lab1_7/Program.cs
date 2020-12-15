using Lib;
using System;
using System.Collections.Generic;

namespace lab1_7
{
    class Program
    {
        static void Main(string[] args)
        {
            StudGroup group = new StudGroup
            {
                new List<Student>
                {
                    new Student("ABC",DateTime.Now,"8-800-555-35-35"),
                    new Student("BCA",DateTime.Now.AddDays(-2),"9-800-555-35-35"),
                    new Student("CBA",DateTime.Now.AddDays(-15),"10-800-555-35-35"),
                    new Student("BAC",DateTime.Now.AddDays(-152),"11-800-555-35-35"),
                    new Student("CAB",DateTime.Now.AddDays(-900),"12-800-555-35-35"),
                }
            };
            string phone = "11-800-555-35-35";
            Console.WriteLine("До сортировки\n");
            Console.WriteLine(group);
            group.Sort();
            Console.WriteLine("---------------------------");
            Console.WriteLine("После сортировки\n");
            Console.WriteLine(group);
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Ищем ученика с телефоном: {phone}\n");
            var tmp = group.Search(phone, "Phone");
            Console.WriteLine(tmp);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Удалили его\n");
            group.Remove(tmp);
            Console.WriteLine(group);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Проверяем еще разок его наличие\n");
            tmp = group.Search("11-800-555-35-35", "Phone");
            Console.WriteLine(tmp is null ? "не найдено" : "найден");


        }
    }
}
