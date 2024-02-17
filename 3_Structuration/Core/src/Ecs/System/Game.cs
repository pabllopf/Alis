// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Game.cs
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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.System.Manager;

namespace Alis.Core.Ecs.System
{
    /// <summary>
    ///     Define a game.
    /// </summary>
    public abstract class Game : IGame
    {
        /// <summary>
        ///     The time manager base
        /// </summary>
        public static TimeManager TimeManager { get; } = new TimeManager();

        /// <summary>
        ///     Gets or sets the value of the managers
        /// </summary>
        public List<IManager> Managers { get; set; }

        /// <summary>
        ///     Gets or sets the value of the is running
        /// </summary>
        public bool IsRunning { get; set; } = true;

        /// <summary>
        ///     Run program
        /// </summary>
        [ExcludeFromCodeCoverage]
        public virtual void Run()
        {
            Managers.ForEach(i => i.OnInit());
            Managers.ForEach(i => i.OnAwake());
            Managers.ForEach(i => i.OnStart());

            double currentTime = TimeManager.Clock.Elapsed.TotalSeconds;
            double accumulator = 0;

            // Variables for calculating FPS
            double lastTime = TimeManager.Clock.Elapsed.TotalSeconds;
            TimeManager.FrameCount = 0;
            TimeManager.TotalFrames = 0;
            TimeManager.AverageFrames = 0;

            // Variables for calculating average FPS
            double totalTime = 0;

            // Variables for SmoothDeltaTime
            float lastDeltaTime = 0f;
            float smoothDeltaTimeSum = 0f;
            int smoothDeltaTimeCount = 0;

            // Variable for log output
            double lastLogTime = TimeManager.Clock.Elapsed.TotalSeconds;


            while (IsRunning)
            {
                double newTime = TimeManager.Clock.Elapsed.TotalSeconds;
                TimeManager.DeltaTime = (float) (newTime - currentTime);

                // Update TimeManager properties
                TimeManager.UnscaledDeltaTime = (float) (newTime - currentTime);
                TimeManager.UnscaledTime += TimeManager.UnscaledDeltaTime;
                TimeManager.UnscaledTimeAsDouble += TimeManager.UnscaledDeltaTime;
                TimeManager.Time = TimeManager.UnscaledTime * TimeManager.TimeScale;
                TimeManager.TimeAsDouble = TimeManager.UnscaledTimeAsDouble * TimeManager.TimeScale;

                // Update MaximumDeltaTime
                TimeManager.MaximumDeltaTime = Math.Max(TimeManager.MaximumDeltaTime, TimeManager.DeltaTime);

                currentTime = newTime;
                accumulator += TimeManager.DeltaTime;

                // Increment frame counter
                TimeManager.FrameCount++;
                TimeManager.TotalFrames++;

                // If a second has passed since the last FPS calculation
                if (newTime - lastTime >= 1.0)
                {
                    // Calculate average FPS
                    totalTime += newTime - lastTime;
                    TimeManager.AverageFrames = (int) (TimeManager.TotalFrames / totalTime);

                    // Reset frame counter and update last time
                    TimeManager.FrameCount = 0;
                    lastTime = newTime;
                }

                // Dispatch Events
                Managers.ForEach(i => i.OnDispatchEvents());

                // Update Scripts
                Managers.ForEach(j => j.OnBeforeUpdate());
                Managers.ForEach(j => j.OnUpdate());
                Managers.ForEach(j => j.OnAfterUpdate());

                // Run fixed methods
                while (accumulator >= TimeManager.Configuration.FixedTimeStep)
                {
                    TimeManager.InFixedTimeStep = true;

                    TimeManager.FixedTime += TimeManager.Configuration.FixedTimeStep;
                    TimeManager.FixedTimeAsDouble += TimeManager.Configuration.FixedTimeStep;
                    TimeManager.FixedDeltaTime = TimeManager.Configuration.FixedTimeStep;
                    TimeManager.FixedUnscaledDeltaTime = TimeManager.Configuration.FixedTimeStep / TimeManager.TimeScale;

                    // Update FixedUnscaledTime and FixedUnscaledTimeAsDouble
                    TimeManager.FixedUnscaledTime += TimeManager.FixedUnscaledDeltaTime;
                    TimeManager.FixedUnscaledTimeAsDouble += TimeManager.FixedUnscaledDeltaTime;

                    Managers.ForEach(i => i.OnBeforeFixedUpdate());
                    Managers.ForEach(i => i.OnFixedUpdate());
                    Managers.ForEach(i => i.OnAfterFixedUpdate());
                    accumulator -= TimeManager.Configuration.FixedTimeStep;

                    TimeManager.InFixedTimeStep = false;
                }

                // Calculate method to calculate math
                Managers.ForEach(i => i.OnCalculate());

                // Render Game
                Managers.ForEach(j => j.OnDraw());

                // Render the Ui
                Managers.ForEach(j => j.OnGui());

                // Update SmoothDeltaTime
                smoothDeltaTimeSum += TimeManager.DeltaTime - lastDeltaTime;
                smoothDeltaTimeCount++;
                TimeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
                lastDeltaTime = TimeManager.DeltaTime;

                // Log output every 1 second
                if ((newTime - lastLogTime >= 0.5) && TimeManager.Configuration.LogOutput)
                {
                    Console.WriteLine(
                        " FrameCount: " + TimeManager.FrameCount +
                        " TotalFrames: " + TimeManager.TotalFrames +
                        " AverageFps: " + TimeManager.AverageFrames +
                        " Time: " + TimeManager.DeltaTime +
                        " Accumulator: " + accumulator +
                        " FixedTimeStep: " + TimeManager.Configuration.FixedTimeStep +
                        " FixedTime: " + TimeManager.FixedTime +
                        " FixedUnscaledDeltaTime: " + TimeManager.FixedUnscaledDeltaTime +
                        " FixedDeltaTime: " + TimeManager.FixedDeltaTime +
                        " FixedTimeAsDouble: " + TimeManager.FixedTimeAsDouble +
                        " FixedUnscaledTime: " + TimeManager.FixedUnscaledTime +
                        " FixedUnscaledTimeAsDouble: " + TimeManager.FixedUnscaledTimeAsDouble +
                        " InFixedTimeStep: " + TimeManager.InFixedTimeStep +
                        " MaximumDeltaTime: " + TimeManager.MaximumDeltaTime +
                        " RealtimeSinceStartup: " + TimeManager.RealtimeSinceStartup +
                        " RealtimeSinceStartupAsDouble: " + TimeManager.RealtimeSinceStartupAsDouble +
                        " SmoothDeltaTime: " + TimeManager.SmoothDeltaTime +
                        " TimeAsDouble: " + TimeManager.TimeAsDouble +
                        " TimeScale: " + TimeManager.TimeScale +
                        " UnscaledDeltaTime: " + TimeManager.UnscaledDeltaTime +
                        " UnscaledTime: " + TimeManager.UnscaledTime +
                        " UnscaledTimeAsDouble: " + TimeManager.UnscaledTimeAsDouble);
                    lastLogTime = newTime;
                }
            }

            Managers.ForEach(i => i.OnStop());
            Managers.ForEach(i => i.OnExit());
        }

        /// <summary>
        ///     Adds the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Add<T>(T component) where T : IManager => Managers.Add(component);

        /// <summary>
        ///     Removes the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Remove<T>(T component) where T : IManager => Managers.Remove(component);

        /// <summary>
        ///     Gets this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public T Get<T>() where T : IManager => (T) Managers.Find(i => i.GetType() == typeof(T));

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public bool Contains<T>() where T : IManager => Get<T>() != null;

        /// <summary>
        ///     Cleans this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        public void Clear<T>() where T : IManager => Managers.Clear();

        /// <summary>
        ///     Sets the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        [ExcludeFromCodeCoverage]
        public void Set<T>(T component) where T : IManager
        {
            for (int i = 0; i < Managers.Count; i++)
            {
                if (Managers[i].GetType() == component.GetType())
                {
                    Managers[i] = component;
                    return;
                }
            }

            Managers.Add(component);
        }
    }
}