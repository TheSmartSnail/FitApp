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
            if (userController.IsNewUser)
            {
                Gender gender;
                DateTime birthDate;
                double weight;
                double height;

                //Определение пола
                Console.WriteLine("Введите пол");
                gender = GetGender();

               // Определение даты
                birthDate = GetDate();

                Console.WriteLine("Введите вес");
                weight = DoubleParse(Console.ReadLine());

                Console.WriteLine("Введите рост");
                height = DoubleParse(Console.ReadLine());

                userController.SetNewUserData(gender, birthDate, weight, height);
            }



            Console.WriteLine(userController.CurrentUser);
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
            double number;
            while (true)
            {
                if (double.TryParse(numberString, out number))
                {

                    return number;
                }
                else
                {
                    Console.WriteLine("Дата некорректна");
                }
            }
        }


        static private Gender GetGender()
        {
            string genderName;
            
            while (true)
            {
                genderName = Console.ReadLine();
                switch (genderName)
                {
                    case "Male": return new Male();

                    case "Female": return new Female();

                    default:
                        {
                            Console.WriteLine("Произошла ошибка в выборе пола");
                        }
                        break;
                }
            }
        }
    }
}
