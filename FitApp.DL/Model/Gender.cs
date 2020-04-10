using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.DL.Model
{
     class Gender
     {
       protected string GenderName { get; set; }

        
     }

    class Male : Gender
    {
        Male()
        {
            GenderName = "Male";
        }
    }

    class Female : Gender
    {
        Female()
        {
            GenderName = "Female";
        }
    }
}
