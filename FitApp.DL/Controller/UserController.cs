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
    [Serializable]
    public class UserController:ControllerBase
    {
        private const string USER_FILE_NAME = "users.dat";
        public List<User> Users{get;}
        
        public User CurrentUser { get; }
        
        public bool IsNewUser { get; } = false;


        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Ошибка в инициализации имени", nameof(userName));
            }
            //Считывание списка пользователей из файлы users.dat
            Users = GetUserData();


            //Проверка на наличие текущего пользователя в списке пользователей 
            //и его последующие занасение в него
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <returns></returns>
        private List<User> GetUserData()
        {
            return Load<List<User>>(USER_FILE_NAME) ?? new List<User>();

        }
        
        /// <summary>
        /// Установка данных для новыйх пользователей
        /// </summary>
        /// <param name="gender"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public void SetNewUserData(Gender gender, DateTime birthDate, double weight=1, double height=1)
        {
            CurrentUser.Gender = gender;
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

        }

        /// <summary>
        /// Сохранение данных пользователя
        /// </summary>
        public void Save()
        {
            Save(USER_FILE_NAME, Users);
            
        }

        

    }

     
}
