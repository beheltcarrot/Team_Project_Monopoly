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
            //result.isOnPrisonChanged += isInPriosnHandler;
            result.moneyChanged += MoneyChangedHandler;
            return result;
        }

        /// <summary>
        /// Этот констурктор - тестовая точка входа
        /// </summary>
        public Program()
        {
            //Новый репозиторий
            r = Repository.getInstance();
            r.BuyRepo += BuyHandler;
            //r.BuybackFromPrisonRepo += (user) =>
            //{
            //    return Boolean.Parse(Console.ReadLine());
            //};
            r.BuybackFromPrisonRepo += BuyBackFromPrisonHandler;
            //r.BuyRepo += BuyHandler;
            //Этот кусок будет вызывать новую viewModel для определения количества пользователей
            r.Session.Users = new List<User>
            {
                UserSeeder("John"),
                UserSeeder("Andrew"),
                UserSeeder("Bob"),
                UserSeeder("Max")
            };
            int count = 0;
            while (true)
            {
                if (count == 4)
                    count = 0;
                r.NewMove(r.Session.Users[count]);
                count++;
            }  
        }

        void postionHadler(User user)
        {
            Console.WriteLine("{0} Совершил ход. Новая позиция - {1}",user.Name, user.Position);
        }

        void MoneyChangedHandler(User user)
        {
            Console.WriteLine($"{user.Name} новое количество денег - {user.Money}");
        }

        void isInPriosnHandler(User user)
        {
            //if (state) //rinat
            //{
            //    Console.WriteLine("В тюрьме");
            //}
            Console.WriteLine($"{user.Name}, вы в тюрьме");
            
        }
        bool BuyBackFromPrisonHandler(User user)
        {
            Console.WriteLine($"{user.Name}, купите выход из тюрьмы за 50?");
            return Boolean.Parse(Console.ReadLine());
        }
        bool BuyHandler(User user)
        {
            Console.WriteLine("Будете покупать?");
            return Boolean.Parse(Console.ReadLine());
        }
    }  
        
}
