using FitApp.DL.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.DL.Controller
{   
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        public User User { get; }

        public UserController(string userName, Gender gender, DateTime birthDate, double weight, double height)
        {
            gender = new Male();
            User user = new User(userName, gender, birthDate, weight, height);

            User = user ?? throw new ArgumentNullException("Ошибка в инициализации пользователя",nameof(user));
        }
        
        /// <summary>
        /// Сохранение данных пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

        public UserController()
        {
            var formatter = new BinaryFormatter();
            
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is User user)
                {
                    User = user;
                } 
            }
        }

    }
}
