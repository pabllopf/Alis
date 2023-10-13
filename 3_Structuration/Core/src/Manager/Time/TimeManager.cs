// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeManagerBase.cs
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
using System.Diagnostics;

namespace Alis.Core.Manager.Time
{
    /// <summary>
    ///     The time manager base class
    /// </summary>
    /// <seealso cref="ManagerBase" />
    public class TimeManager : ManagerBase
    {
        /// <summary>
        /// The max fps
        /// </summary>
        private double maxFps;
        /// <summary>
        /// The stopwatch
        /// </summary>
        private readonly Stopwatch stopwatch;
        /// <summary>
        /// The fixed delta time
        /// </summary>
        private double fixedDeltaTime;
        /// <summary>
        /// The frame count
        /// </summary>
        private double frameCount;

        /// <summary>
        /// Gets or sets the value of the current frame
        /// </summary>
        public double CurrentFrame { get; private set; }
        /// <summary>
        /// Gets or sets the value of the real fps
        /// </summary>
        public double RealFps { get; private set; }
        /// <summary>
        /// Gets or sets the value of the fixed time
        /// </summary>
        public double FixedTime { get; private set; }
        /// <summary>
        /// Gets the value of the fixed delta time
        /// </summary>
        public double FixedDeltaTime => fixedDeltaTime;
        /// <summary>
        /// Gets the value of the maximum frames per second
        /// </summary>
        public double MaximumFramesPerSecond => maxFps;
        /// <summary>
        /// Gets or sets the value of the elapsed seconds
        /// </summary>
        public double ElapsedSeconds { get; private set; }
        /// <summary>
        /// Gets or sets the value of the time step
        /// </summary>
        public double TimeStep { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeManager"/> class
        /// </summary>
        /// <param name="maxFps">The max fps</param>
        public TimeManager(double maxFps)
        {
            this.maxFps = maxFps;
            stopwatch = new Stopwatch();
            stopwatch.Start();

            fixedDeltaTime = 1.0 / maxFps;
            TimeStep = 1.0 / 60.0; // Valor inicial arbitrario

            // Ajustar el TimeStep según tus necesidades
            UpdateTimeStep();
        }

        /// <summary>
        /// Syncs the fixed delta time
        /// </summary>
        public void SyncFixedDeltaTime()
        {
            fixedDeltaTime = 1.0 / maxFps;
        }

        /// <summary>
        /// Describes whether this instance is new frame
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsNewFrame()
        {
            return stopwatch.Elapsed.TotalSeconds - FixedTime >= FixedDeltaTime;
        }

        /// <summary>
        /// Updates the time step
        /// </summary>
        public void UpdateTimeStep()
        {
            // Puedes implementar lógica aquí para ajustar el TimeStep según tus necesidades
            // En este ejemplo, simplemente fijamos el TimeStep a un valor constante.
            TimeStep = 1.0 / 60.0; // Aproximadamente 60 FPS
        }

        /// <summary>
        /// Counters the frames
        /// </summary>
        public void CounterFrames()
        {
            frameCount += 1.0;
            CurrentFrame = (frameCount < MaximumFramesPerSecond ? frameCount : frameCount % MaximumFramesPerSecond) + 1;
        }

        /// <summary>
        /// Updates the fixed time
        /// </summary>
        public void UpdateFixedTime()
        {
            double newFixedTime = stopwatch.Elapsed.TotalSeconds;
            ElapsedSeconds = newFixedTime - FixedTime;
            FixedTime = newFixedTime;
        }

        /// <summary>
        /// Sets the max fps using the specified fps
        /// </summary>
        /// <param name="fps">The fps</param>
        public void SetMaxFps(double fps)
        {
            maxFps = Math.Max(fps, double.Epsilon);
        }

        /// <summary>
        /// Updates the average fps
        /// </summary>
        public void UpdateAverageFps()
        {
            RealFps = frameCount / stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine($"Target FPS: {MaximumFramesPerSecond}, Real FPS: {RealFps}, FrameCount: {frameCount}");
        }
    }
}