using Microsoft.EntityFrameworkCore;
using NullForgivingOperator.Entities;
using System;

namespace NullableReferences
{
    class Program
    {
        static void Main()
        {
            InMemory();
            DisplayText(null);
            UsingDB();
        }

        static void UsingDB()
        {
            CarContext.Populate();

            using CarContext context = new CarContext();

            DisplayDriver(context);
            DisplayAll(context);
        }

        private static void DisplayAll(CarContext context)
        {
            var cars = context.Cars.Include(c => c.Engine).Include(c => c.Driver!.Licence);

            foreach (var car in cars)
                Console.WriteLine($"{car.Driver?.Name ?? "No one"} drives a {car.Model} with a {car.Engine.Capacity}cc engine on a {car.Driver?.Licence.Description ?? "Non-existant"} licence");
        }

        private static void DisplayDriver(CarContext context)
        {
            var cars = context.Cars.Include(c => c.Driver);

            foreach (var car in cars)
                Console.WriteLine($"{car.Driver?.Name ?? "No one"} drives a {car.Model}.");
        }

        private static void InMemory()
        {
            MotorCar car = new MotorCar(new Person("Jenson"),
                                        new Engine { Capacity = 1600 });

            Console.WriteLine(car);
        }

        private static void DisplayText (string? text)
        {
            if (!string.IsNullOrEmpty(text))
                Console.WriteLine($"The the text is {text.ToUpper()}");
            else
                Console.WriteLine("String is empty or null.");
        }
    }
}
