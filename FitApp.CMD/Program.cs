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
            

            UserController userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Gender gender;
                DateTime birthDate;
                double weight;
                double height;

                //Определение пола
                Console.WriteLine("Введите пол");
                gender = GenderController.GetGender();

               // Определение даты
                birthDate = GetDate();

                weight = DoubleParse("Вес");

                height = DoubleParse("Рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);


            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести прием пищи");
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E){
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"/t{item.Key} - {item.Value}");
                }
            }
        }

        private static DateTime GetDate()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату рождения в формате дд.мм.гггг");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Дата некорректна");
                }
            }

            return birthDate;
        }


        private static double DoubleParse(string numberString)
        {
            Console.WriteLine(numberString);
            double number;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out number))
                {

                    return number;
                }
                else
                {
                    Console.WriteLine("Некорректное число");
                }
            }
        }


        private static (Food Food,double Weight) EnterEating()
        {
            Console.WriteLine("Введите имя продукта");
            var food = Console.ReadLine();
            double calories = DoubleParse("Калории");
            double prot = DoubleParse("Белка");
            double fats = DoubleParse("Жиры");
            double hydr = DoubleParse("Углеводы");
            
            double weight = DoubleParse("Введите вес порции");
            

            return (Food: new Food(food,calories,prot,fats,hydr), Weight: weight);
        }
    }
}
