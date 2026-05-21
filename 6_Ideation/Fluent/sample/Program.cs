

using System;

namespace Alis.Core.Aspect.Fluent.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            Car sampleCar = Car
                .Create()
                .WithName("Ferrari")
                .WithModel("F8")
                .WithColor("Red")
                .Build();

            Car quickStartCar = QuickStartScenario.CreateSportsCar();

            Console.WriteLine($"Car Name: {sampleCar.Name}");
            Console.WriteLine($"Car Model: {sampleCar.Model}");
            Console.WriteLine($"Car Color: {sampleCar.Color}");
            Console.WriteLine($"Quick Start Car: {quickStartCar.Name} / {quickStartCar.Model} / {quickStartCar.Color}");
        }
    }
}
