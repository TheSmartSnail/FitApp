using System;
using FitApp.DL;
using FitApp.DL.Controller;
using FitApp.DL.Model;

namespace FitApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение FitApp");
            Console.WriteLine("Name");
            string name = Console.ReadLine();

            Console.WriteLine("Gender");
            Gender gender = GenderController.GetGender(Console.ReadLine());

            Console.WriteLine("Birth Date");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Weigth");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Height");
            double height = Convert.ToDouble(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}
