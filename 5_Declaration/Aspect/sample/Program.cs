

using System.Threading;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Sample.Fluent;
using Alis.Core.Aspect.Time;

namespace Alis.Core.Aspect.Sample
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
            Logger.Info("--------------------------");
            Logger.Info("Fluent sample");
            Logger.Info("--------------------------\n");

            Car sampleCar = Car
                .Create()
                .WithName("Ferrari")
                .WithModel("F8")
                .WithColor("Red")
                .Build();

            Logger.Info($"Car: Name={sampleCar.Name} Model={sampleCar.Model} Color={sampleCar.Color}");

            Logger.Info("--------------------------");
            Logger.Info("Data sample");
            Logger.Info("--------------------------\n");


            Logger.Info("--------------------------");
            Logger.Info("Math sample");
            Logger.Info("--------------------------\n");

            Logger.Info(new Vector2F(3.0f, 2.0f).ToString());

            Logger.Info("--------------------------");
            Logger.Info("Time sample");
            Logger.Info("--------------------------\n");
            Clock clock = new Clock();
            clock.Start();

            int i = 0;
            while (i < 1000)
            {
                Thread.Sleep(1);
                i++;
            }

            clock.Stop();
            Logger.Info($"Elapsed time: {clock.ElapsedMilliseconds} ms");

            Logger.Info("--------------------------");
            Logger.Info("Memory sample");
            Logger.Info("--------------------------\n");

            Logger.Info("--------------------------");
            Logger.Info("Logging sample");
            Logger.Info("--------------------------\n");

            Logger.Trace("Sample");

            Logger.Log("Sample");
            Logger.Info("Sample");


            Logger.Warning("Sample");
            Logger.Error("Sample");
        }
    }
}