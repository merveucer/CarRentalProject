﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            BrandTest();
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand { Id = 4, Name = "Marka 4" };

            Console.WriteLine("--- GetAll ---");
            foreach (Brand b in brandManager.GetAll())
            {
                Console.WriteLine(b.Id + " " + b.Name);
            }

            Console.WriteLine("--- GetById ---");
            Console.WriteLine(brandManager.GetById(1).Id + " " + brandManager.GetById(1).Name);

            Console.WriteLine("--- Add ---");
            brandManager.Add(brand);
            foreach (Brand b in brandManager.GetAll())
            {
                Console.WriteLine(b.Id + " " + b.Name);
            }

            Console.WriteLine("--- Update ---");
            brand.Name = "Marka 5";
            brandManager.Update(brand);
            foreach (Brand b in brandManager.GetAll())
            {
                Console.WriteLine(b.Id + " " + b.Name);
            }

            Console.WriteLine("--- Delete ---");
            brandManager.Delete(brand);
            foreach (Brand b in brandManager.GetAll())
            {
                Console.WriteLine(b.Id + " " + b.Name);
            }
        }

            private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car { Id = 6, BrandId = 3, ColorId = 3, DailyPrice = 600, Description = "", Name="C 666", ModelYear = 2022 };

            Console.WriteLine("--- GetAll ---");
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }

            Console.WriteLine("--- GetAllByBrandId ---");
            foreach (Car c in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }

            Console.WriteLine("--- GetAllByColorId ---");
            foreach (Car c in carManager.GetAllByColorId(1))
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }

            Console.WriteLine("--- GetById ---");
            Console.WriteLine(carManager.GetById(1).Id + " " + carManager.GetById(1).DailyPrice);

            Console.WriteLine("--- Add ---");
            carManager.Add(car);
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }

            Console.WriteLine("--- Update ---");
            car.DailyPrice = 700;
            carManager.Update(car);
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }

            Console.WriteLine("--- Delete ---");
            carManager.Delete(car);
            foreach (Car c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + " " + c.DailyPrice);
            }

            Console.WriteLine("--- Failed Add Operation ---");
            carManager.Add(new Car { Id = 6, BrandId = 3, ColorId = 3, DailyPrice = 600, Description = "", Name = "C", ModelYear = 2022 });
        }
    }
}
