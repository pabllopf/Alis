// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextHandler.cs
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
using System.Threading;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Execution;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Manager.Time;

namespace Alis.Core.Ecs.Systems.Scope
{
    /// <summary>
    ///     The context handler class
    /// </summary>
    /// <seealso cref="IContextHandler{Context}" />
    public class ContextHandler : IContextHandler<Context>
    {
        /// <summary>
        ///     The context
        /// </summary>
        private readonly Context _context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContextHandler" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public ContextHandler(Context context) => _context = context;

        /// <summary>
        ///     Gets the value of the context
        /// </summary>
        public Context Context => _context;

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            Runtime<AManager> runtime = _context.Runtime;
            Setting setting = _context.Setting;

            runtime.OnInit();
            runtime.OnAwake();
            runtime.OnStart();

            double targetFrameDuration = 1 / setting.Graphic.TargetFrames;
            double currentTime = TimeManager.Clock.Elapsed.TotalSeconds;
            float accumulator = 0;
            double lastTime = TimeManager.Clock.Elapsed.TotalSeconds;
            double totalTime = 0;
            float lastDeltaTime = 0f;
            float smoothDeltaTimeSum = 0f;
            int smoothDeltaTimeCount = 0;

            while (_context.IsRunning)
            {
                double frameStartTime = TimeManager.Clock.Elapsed.TotalSeconds;
                double newTime = frameStartTime;

                TimeManager.DeltaTime = (float) (newTime - currentTime);
                TimeManager.UnscaledDeltaTime = (float) (newTime - currentTime);
                TimeManager.UnscaledTime += TimeManager.UnscaledDeltaTime;
                TimeManager.UnscaledTimeAsDouble += TimeManager.UnscaledDeltaTime;
                TimeManager.Time = TimeManager.UnscaledTime * TimeManager.TimeScale;
                TimeManager.TimeAsDouble = TimeManager.UnscaledTimeAsDouble * TimeManager.TimeScale;
                TimeManager.MaximumDeltaTime = Math.Max(TimeManager.MaximumDeltaTime, TimeManager.DeltaTime);
                currentTime = newTime;
                accumulator += TimeManager.DeltaTime;
                TimeManager.FrameCount++;
                TimeManager.TotalFrames++;

                if (newTime - lastTime >= TimeManager.OneSecond)
                {
                    totalTime += newTime - lastTime;
                    TimeManager.AverageFrames = (int) (TimeManager.TotalFrames / totalTime);
                    TimeManager.FrameCount = 0;
                    lastTime = newTime;
                }

                runtime.OnDispatchEvents();
                runtime.OnProcessPendingChanges();

                runtime.OnPhysicUpdate();
                runtime.OnBeforeUpdate();
                runtime.OnUpdate();
                runtime.OnAfterUpdate();

                while (accumulator >= TimeManager.Configuration.FixedTimeStep)
                {
                    TimeManager.InFixedTimeStep = true;
                    TimeManager.FixedTime += TimeManager.Configuration.FixedTimeStep;
                    TimeManager.FixedTimeAsDouble += TimeManager.Configuration.FixedTimeStep;
                    TimeManager.FixedDeltaTime = TimeManager.Configuration.FixedTimeStep;
                    TimeManager.FixedUnscaledDeltaTime = TimeManager.Configuration.FixedTimeStep / TimeManager.TimeScale;
                    TimeManager.FixedUnscaledTime += TimeManager.FixedUnscaledDeltaTime;
                    TimeManager.FixedUnscaledTimeAsDouble += TimeManager.FixedUnscaledDeltaTime;
                    runtime.OnBeforeFixedUpdate();
                    runtime.OnFixedUpdate();
                    runtime.OnAfterFixedUpdate();
                    accumulator %= TimeManager.Configuration.FixedTimeStep;
                    TimeManager.InFixedTimeStep = false;
                }

                runtime.OnCalculate();

                // Render game:
                runtime.OnBeforeDraw();
                runtime.OnDraw();
                runtime.OnAfterDraw();
                runtime.OnGui();
                runtime.OnRenderPresent();


                smoothDeltaTimeSum += TimeManager.DeltaTime - lastDeltaTime;
                smoothDeltaTimeCount++;
                TimeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
                lastDeltaTime = TimeManager.DeltaTime;

                double frameEndTime = TimeManager.Clock.Elapsed.TotalSeconds;
                double frameDuration = frameEndTime - frameStartTime;
                if (frameDuration < targetFrameDuration)
                {
                    Thread.Sleep((int) ((targetFrameDuration - frameDuration) * TimeManager.MillisecondsInSecond));
                }
            }

            runtime.OnStop();
            runtime.OnExit();
        }


        /// <summary>
        ///     Exits this instance
        /// </summary>
        public void Exit() => _context.IsRunning = false;

        /// <summary>
        ///     Saves this instance
        /// </summary>
        public void Save()
        {
            _context.Setting.OnSave();
            _context.Runtime.OnSave();
        }

        /// <summary>
        ///     Loads this instance
        /// </summary>
        public void Load()
        {
            _context.Setting.OnLoad();
            _context.Runtime.OnLoad();
        }

        /// <summary>
        ///     Loads the and run
        /// </summary>
        public void LoadAndRun()
        {
            _context.Setting.OnLoad();
            _context.Runtime.OnLoad();
            Run();
        }

        /// <summary>
        ///     Saves the path
        /// </summary>
        /// <param name="path">The path</param>
        public void Save(string path)
        {
            _context.Setting.OnSave();
            _context.Runtime.OnSave(path);
        }
    }
}