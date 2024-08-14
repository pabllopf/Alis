// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Aspect.Memory.Exceptions;
using Alis.Core.Aspect.Sample.Data;
using Alis.Core.Aspect.Sample.Fluent;
using Alis.Core.Aspect.Thread;
using Alis.Core.Aspect.Time;

namespace Alis.Core.Aspect.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Gets or sets the value of the non zero value
        /// </summary>
        [IsNotZero] private static int _nonZeroValue;
        
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            // SAMPLE ASPECT FLUENT 
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
            
            // SAMPLE ASPECT DATA
            Logger.Info("--------------------------");
            Logger.Info("Data sample");
            Logger.Info("--------------------------\n");
            
            Music musicInfo2 = new Music
            {
                Name = "Prince Charming",
                Artist = "Metallica",
                Genre = "Rock and Metal",
                Album = "Reload"
            };
            
            // This will produce a JSON String
            string serialized2 = JsonSerializer.Serialize(musicInfo2);
            
            Logger.Info(serialized2);
            
            // This will produce a copy of the instance you created earlier
            JsonSerializer.Deserialize<Music>(serialized2);
            
            Logger.Info("deserialized 2");
            
            // SAMPLE ASPECT MATH
            Logger.Info("--------------------------");
            Logger.Info("Math sample");
            Logger.Info("--------------------------\n");
            
            Logger.Info(new Vector2(3.0f, 2.0f).ToString());
            Logger.Info(new Vector2(3.0f, 2.0f).ToString("F2", CultureInfo.InvariantCulture));
            
            // SAMPLE ASPECT TIME
            Logger.Info("--------------------------");
            Logger.Info("Time sample");
            Logger.Info("--------------------------\n");
            Clock clock = new Clock();
            clock.Start();
            
            // Create a new TimeConfiguration instance
            TimeConfiguration timeConfig = new TimeConfiguration();
            
            // Create a new TimeManager instance
            TimeManager timeManager = new TimeManager();
            
            int i = 0;
            while (i < 1000)
            {
                System.Threading.Thread.Sleep(1);
                i++;
            }
            
            // Stop the clock and print the elapsed time
            clock.Stop();
            Logger.Info($"Elapsed time: {clock.ElapsedMilliseconds} ms");
            
            // Print some TimeManager properties
            Logger.Info($"DeltaTime: {timeManager.DeltaTime}");
            Logger.Info($"TimeScale: {timeConfig.TimeScale}");
            
            
            // SAMPLE ASPECT THREAD
            Logger.Info("--------------------------");
            Logger.Info("Thread sample");
            Logger.Info("--------------------------\n");
            ThreadManager threadManager = new ThreadManager();
            
            CancellationTokenSource cts1 = new CancellationTokenSource();
            ThreadTask task1 = new ThreadTask(token =>
            {
                for (int i = 0; (i < 3) && !token.IsCancellationRequested; i++)
                {
                    Logger.Info($"Task 1 - Count: {i}");
                    System.Threading.Thread.Sleep(1000);
                }
            }, cts1.Token);
            
            CancellationTokenSource cts2 = new CancellationTokenSource();
            ThreadTask task2 = new ThreadTask(token =>
            {
                for (int i = 0; (i < 3) && !token.IsCancellationRequested; i++)
                {
                    Logger.Info($"Task 2 - Count: {i}");
                    System.Threading.Thread.Sleep(1000);
                }
            }, cts2.Token);
            
            threadManager.StartThread(task1);
            threadManager.StartThread(task2);
            
            Logger.Info("Press any key to stop threads...");
            Console.ReadKey();
            
            threadManager.StopAllThreads();
            
            // SAMPLE ASPECT MEMORY
            Logger.Info("--------------------------");
            Logger.Info("Memory sample");
            Logger.Info("--------------------------\n");
            
            try
            {
                _nonZeroValue = 0;
                Validator.Validate(_nonZeroValue, nameof(_nonZeroValue));
            }
            catch (NotZeroException ex)
            {
                Logger.Exception(ex);
            }
            
            
            // SAMPLE ASPECT LOGGING
            Logger.Info("--------------------------");
            Logger.Info("Logging sample");
            Logger.Info("--------------------------\n");
            Logger.LogLevel = LogLevel.Trace;
            Logger.Trace();
            Logger.Info();
            
            Logger.Trace("Sample");
            
            Logger.Log("Sample");
            Logger.Info("Sample");
            
            Logger.Event("Sample");
            
            Logger.Warning("Sample");
            Logger.Error("Sample");
            
            try
            {
                throw new NullReferenceException();
            }
            catch (Exception exception)
            {
                Logger.Exception(exception);
            }
        }
    }
}