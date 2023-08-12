﻿using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using System;
using System.Linq;

namespace ConsoleApp1
{
    static class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> dataService = new GenericDataService<User>(new SimpleTraderDbContextFactory());
            Console.WriteLine(dataService.GetAll().Result.Count());
            Console.ReadKey();
        }
    }
}
