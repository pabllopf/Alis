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
        private double maxFps;
        private readonly Stopwatch stopwatch;
        private double fixedDeltaTime;
        private double frameCount;

        public double CurrentFrame { get; private set; }
        public double RealFps { get; private set; }
        public double FixedTime { get; private set; }
        public double FixedDeltaTime => fixedDeltaTime;
        public double MaximumFramesPerSecond => maxFps;
        public double ElapsedSeconds { get; private set; }
        public double TimeStep { get; private set; }

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

        public void SyncFixedDeltaTime()
        {
            fixedDeltaTime = 1.0 / maxFps;
        }

        public bool IsNewFrame()
        {
            return stopwatch.Elapsed.TotalSeconds - FixedTime >= FixedDeltaTime;
        }

        public void UpdateTimeStep()
        {
            // Puedes implementar lógica aquí para ajustar el TimeStep según tus necesidades
            // En este ejemplo, simplemente fijamos el TimeStep a un valor constante.
            TimeStep = 1.0 / 60.0; // Aproximadamente 60 FPS
        }

        public void CounterFrames()
        {
            frameCount += 1.0;
            CurrentFrame = (frameCount < MaximumFramesPerSecond ? frameCount : frameCount % MaximumFramesPerSecond) + 1;
        }

        public void UpdateFixedTime()
        {
            double newFixedTime = stopwatch.Elapsed.TotalSeconds;
            ElapsedSeconds = newFixedTime - FixedTime;
            FixedTime = newFixedTime;
        }

        public void SetMaxFps(double fps)
        {
            maxFps = Math.Max(fps, double.Epsilon);
        }

        public void UpdateAverageFps()
        {
            RealFps = frameCount / stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine($"Target FPS: {MaximumFramesPerSecond}, Real FPS: {RealFps}, FrameCount: {frameCount}");
        }
    }
}