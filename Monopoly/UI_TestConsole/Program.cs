﻿    using Logic.DataProcess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_TestConsole.Models;

namespace UI_TestConsole
{
    class Program
    {
        Repository r;
        static void Main(string[] args)
        {           
            Program p = new Program();                            
            Console.ReadKey();
        }

        public User UserSeeder(string _name)
        {
            var result = new User(_name);
            result.positionChanged += postionHadler;
            result.isOnPrisonChanged += isInPriosnHandler;
            return result;
        }

        /// <summary>
        /// Этот констурктор - тестовая точка входа
        /// </summary>
        public Program()
        {
            //Новый репозиторий
            r = Repository.getInstance();

            //Этот кусок будет вызывать новую viewModel для определения количества пользователей
            r.Session.Users = new List<User>
            {
                UserSeeder("John"),
                UserSeeder("Andrew"),
                UserSeeder("Bob"),
                UserSeeder("Max")
            };

            foreach (var item in r.Session.Users)
            {
                r.NewMove(item);
            }   
        }

        void postionHadler(User user)
        {
            Console.WriteLine("{0} Совершил ход. Новая позиция - {1}",user.Name, user.Position);
        }

        void isInPriosnHandler(bool state)
        {
            if (state)
            {
                Console.WriteLine("В тюрьме");
            }
        }
    }  
        
}
