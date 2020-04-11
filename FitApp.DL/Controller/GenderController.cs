using FitApp.DL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.DL.Controller
{
        public class GenderController
         {
        static public Gender GetGender(string genderName)
        {
            switch (genderName)
            {
                case "Male": return new Male();

                case "Female":return new Female();

                default:
                    {
                        Console.WriteLine("Произошла ошибка в выборе пола");
                        return null;
                        
                    }
                        
            }
        }
    }
}
