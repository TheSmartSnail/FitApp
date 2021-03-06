﻿using FitApp.DL.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.DL.Model
{
    [Serializable]
    public class User
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get {return GetAge.GetCurrentAge(BirthDate); } }
        

        
        public User (
            string name,
            Gender gender,
            DateTime birthDate,
            double weght,
            double height
            )
        {
            #region Отлов исключений
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(("Имя не корректно"), nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException(("Пол не корректен"), nameof(name));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate > DateTime.Now)
            {
                throw new ArgumentNullException(("Дата рождения не корретна"), nameof(name));
            }

            if (weght <= 0)
            {
                throw new ArgumentNullException(("Вес должен быть положительным"), nameof(name));
            }

            if (height <= 0)
            {
                throw new ArgumentNullException(("Рост должен быть положительным"), nameof(name));
            }
            #endregion
            
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Height = height;
            Weight = weght;
        }

        public User(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }

    }

    
}
