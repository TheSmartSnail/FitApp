using FitApp.DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.DL.Controller
{
    public static class GenderController
    {
        public static Gender GetGender()
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
