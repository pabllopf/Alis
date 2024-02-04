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
using Alis.Core.Aspect.Translation;

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
            Console.WriteLine("--------------------------");
            Console.WriteLine("Fluent sample");
            Console.WriteLine("--------------------------\n");
            
            Car sampleCar = Car
                .Create()
                .WithName("Ferrari")
                .WithModel("F8")
                .WithColor("Red")
                .Build();
            
            Console.WriteLine($"Car: Name={sampleCar.Name} Model={sampleCar.Model} Color={sampleCar.Color}");
            
            // SAMPLE ASPECT DATA
            Console.WriteLine("--------------------------");
            Console.WriteLine("Data sample");
            Console.WriteLine("--------------------------\n");
                
            Music musicInfo2 = new Music
            {
                Name = "Prince Charming",
                Artist = "Metallica",
                Genre = "Rock and Metal",
                Album = "Reload"
            };

            // This will produce a JSON String
            string serialized2 = JsonSerializer.Serialize(musicInfo2);

            Console.WriteLine(serialized2);

            // This will produce a copy of the instance you created earlier
            JsonSerializer.Deserialize<Music>(serialized2);

            Console.WriteLine("deserialized 2");
            
            // SAMPLE ASPECT TRANSLATION
            Console.WriteLine("--------------------------");
            Console.WriteLine("Translation sample");
            Console.WriteLine("--------------------------\n");
            
            TranslationManager manager = new TranslationManager();

            manager.AddLanguage(new Language {Name = "English", Code = "en"});
            manager.AddLanguage(new Language {Name = "Spanish", Code = "es"});

            manager.AddTranslation("en", "hello", "Hello");
            manager.AddTranslation("es", "hello", "Hola");
            manager.AddTranslation("en", "world", "World");
            manager.AddTranslation("es", "world", "Mundo");

            manager.SetLanguage("Spanish", "es");
            Console.WriteLine($"Current language: {manager.Language.Name} - Language.Code:{manager.Language.Code} Translate result: {manager.Translate("hello")}");

            manager.SetLanguage("English", "en");
            Console.WriteLine($"Current language: {manager.Language.Name} - Language.Code:{manager.Language.Code} Translate result: {manager.Translate("hello")}");
            
            // SAMPLE ASPECT MATH
            Console.WriteLine("--------------------------");
            Console.WriteLine("Math sample");
            Console.WriteLine("--------------------------\n");
            
            Console.WriteLine(new Vector2(3.0f, 2.0f).ToString());
            Console.WriteLine(new Vector2(3.0f, 2.0f).ToString("F2", CultureInfo.InvariantCulture));
            
            // SAMPLE ASPECT TIME
            Console.WriteLine("--------------------------");
            Console.WriteLine("Time sample");
            Console.WriteLine("--------------------------\n");
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
            Console.WriteLine($"Elapsed time: {clock.ElapsedMilliseconds} ms");

            // Print some TimeManager properties
            Console.WriteLine($"DeltaTime: {timeManager.DeltaTime}");
            Console.WriteLine($"TimeScale: {timeConfig.TimeScale}");
            
            
            // SAMPLE ASPECT THREAD
            Console.WriteLine("--------------------------");
            Console.WriteLine("Thread sample");
            Console.WriteLine("--------------------------\n");
            ThreadManager threadManager = new ThreadManager();

            CancellationTokenSource cts1 = new CancellationTokenSource();
            ThreadTask task1 = new ThreadTask(token =>
            {
                for (int i = 0; (i < 3) && !token.IsCancellationRequested; i++)
                {
                    Console.WriteLine($"Task 1 - Count: {i}");
                    System.Threading.Thread.Sleep(1000);
                }
            }, cts1.Token);

            CancellationTokenSource cts2 = new CancellationTokenSource();
            ThreadTask task2 = new ThreadTask(token =>
            {
                for (int i = 0; (i < 3) && !token.IsCancellationRequested; i++)
                {
                    Console.WriteLine($"Task 2 - Count: {i}");
                    System.Threading.Thread.Sleep(1000);
                }
            }, cts2.Token);

            threadManager.StartThread(task1);
            threadManager.StartThread(task2);

            Console.WriteLine("Press any key to stop threads...");
            Console.ReadKey();

            threadManager.StopAllThreads();
            
            // SAMPLE ASPECT MEMORY
            Console.WriteLine("--------------------------");
            Console.WriteLine("Memory sample");
            Console.WriteLine("--------------------------\n");
            
            try
            {
                _nonZeroValue = 0;
                Validator.Validate(_nonZeroValue, nameof(_nonZeroValue));
            }
            catch (NotZeroException ex)
            {
                Console.WriteLine(ex);
            }
            
            
            // SAMPLE ASPECT LOGGING
            Console.WriteLine("--------------------------");
            Console.WriteLine("Logging sample");
            Console.WriteLine("--------------------------\n");
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