using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.DL.Other
{
    static class GetAge
    {
        static public int GetCurrentAge(DateTime birthDate)
        {
            DateTime nowDate = DateTime.Today;
            int age = nowDate.Year - birthDate.Year;
            if (birthDate > nowDate.AddYears(-age)) { age--; }
            return age;
        }
    }
}
