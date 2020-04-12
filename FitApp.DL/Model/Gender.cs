using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.DL.Model
{
     [Serializable]
       public class Gender
       {
       protected string GenderName { get; set; }
       }
    
    [Serializable]
    public class Male : Gender
    {
        public Male()
        {
            GenderName = "Male";
        }
    }

    [Serializable]
    public class Female : Gender
    {
        public Female()
        {
            GenderName = "Female";
        }
    }
}
