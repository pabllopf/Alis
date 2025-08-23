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

using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Sample.Entities;
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

            
            // Serialize the musicInfo2 object to JSON
            string json = musicInfo2.ToJson();

            Logger.Info($"Serialized Music: {json}");
            
            // Load the musicInfo2 object from JSON
            Music musicInfo = Music.FromJson(json);
            Logger.Info($"Deserialized Music: Name={musicInfo.Name}, Artist={musicInfo.Artist}, Genre={musicInfo.Genre}, Album={musicInfo.Album}");
            
            
            Logger.Info("deserialized 2");

            // SAMPLE ASPECT MATH
            Logger.Info("--------------------------");
            Logger.Info("Math sample");
            Logger.Info("--------------------------\n");

            Logger.Info(new Vector2F(3.0f, 2.0f).ToString());

            // SAMPLE ASPECT TIME
            Logger.Info("--------------------------");
            Logger.Info("Time sample");
            Logger.Info("--------------------------\n");
            Clock clock = new Clock();
            clock.Start();
            
            int i = 0;
            while (i < 1000)
            {
                System.Threading.Thread.Sleep(1);
                i++;
            }

            // Stop the clock and print the elapsed time
            clock.Stop();
            Logger.Info($"Elapsed time: {clock.ElapsedMilliseconds} ms");
            
            // SAMPLE ASPECT MEMORY
            Logger.Info("--------------------------");
            Logger.Info("Memory sample");
            Logger.Info("--------------------------\n");

            // SAMPLE ASPECT LOGGING
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