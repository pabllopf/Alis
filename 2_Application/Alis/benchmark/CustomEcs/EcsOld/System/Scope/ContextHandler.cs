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
using Alis.Benchmark.CustomEcs.EcsOld.System.Configuration;
using Alis.Benchmark.CustomEcs.EcsOld.System.Execution;
using Alis.Benchmark.CustomEcs.EcsOld.System.Manager;
using Alis.Benchmark.CustomEcs.EcsOld.System.Manager.Time;

namespace Alis.Benchmark.CustomEcs.EcsOld.System.Scope
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
            TimeManager timeManager = _context.TimeManager;
            Setting setting = _context.Setting;

            runtime.OnInit();
            runtime.OnAwake();
            runtime.OnStart();

            double targetFrameDuration = 1 / setting.Graphic.TargetFrames;
            double currentTime = timeManager.Clock.Elapsed.TotalSeconds;
            float accumulator = 0;
            double lastTime = timeManager.Clock.Elapsed.TotalSeconds;
            double totalTime = 0;
            float lastDeltaTime = 0f;
            float smoothDeltaTimeSum = 0f;
            int smoothDeltaTimeCount = 0;

            while (_context.IsRunning)
            {
                double frameStartTime = timeManager.Clock.Elapsed.TotalSeconds;
                double newTime = frameStartTime;

                timeManager.DeltaTime = (float) (newTime - currentTime);
                timeManager.UnscaledDeltaTime = (float) (newTime - currentTime);
                timeManager.UnscaledTime += timeManager.UnscaledDeltaTime;
                timeManager.UnscaledTimeAsDouble += timeManager.UnscaledDeltaTime;
                timeManager.Time = timeManager.UnscaledTime * timeManager.TimeScale;
                timeManager.TimeAsDouble = timeManager.UnscaledTimeAsDouble * timeManager.TimeScale;
                timeManager.MaximumDeltaTime = Math.Max(timeManager.MaximumDeltaTime, timeManager.DeltaTime);
                currentTime = newTime;
                accumulator += timeManager.DeltaTime;
                timeManager.FrameCount++;
                timeManager.TotalFrames++;

                if (newTime - lastTime >= TimeManager.OneSecond)
                {
                    totalTime += newTime - lastTime;
                    timeManager.AverageFrames = (int) (timeManager.TotalFrames / totalTime);
                    timeManager.FrameCount = 0;
                    lastTime = newTime;
                }

                runtime.OnDispatchEvents();
                runtime.OnProcessPendingChanges();

                runtime.OnPhysicUpdate();
                runtime.OnBeforeUpdate();
                runtime.OnUpdate();
                runtime.OnAfterUpdate();

                while (accumulator >= timeManager.Configuration.FixedTimeStep)
                {
                    timeManager.InFixedTimeStep = true;
                    timeManager.FixedTime += timeManager.Configuration.FixedTimeStep;
                    timeManager.FixedTimeAsDouble += timeManager.Configuration.FixedTimeStep;
                    timeManager.FixedDeltaTime = timeManager.Configuration.FixedTimeStep;
                    timeManager.FixedUnscaledDeltaTime = timeManager.Configuration.FixedTimeStep / timeManager.TimeScale;
                    timeManager.FixedUnscaledTime += timeManager.FixedUnscaledDeltaTime;
                    timeManager.FixedUnscaledTimeAsDouble += timeManager.FixedUnscaledDeltaTime;
                    runtime.OnBeforeFixedUpdate();
                    runtime.OnFixedUpdate();
                    runtime.OnAfterFixedUpdate();
                    accumulator %= timeManager.Configuration.FixedTimeStep;
                    timeManager.InFixedTimeStep = false;
                }

                runtime.OnCalculate();

                // Render game:
                runtime.OnBeforeDraw();
                runtime.OnDraw();
                runtime.OnAfterDraw();
                runtime.OnGui();
                runtime.OnRenderPresent();


                smoothDeltaTimeSum += timeManager.DeltaTime - lastDeltaTime;
                smoothDeltaTimeCount++;
                timeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
                lastDeltaTime = timeManager.DeltaTime;

                double frameEndTime = timeManager.Clock.Elapsed.TotalSeconds;
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
        ///     Starts the preview
        /// </summary>
        public void StartPreview()
        {
            Runtime<AManager> runtime = _context.Runtime;
            Setting setting = _context.Setting;

            setting.Graphic.PreviewMode = true;
            runtime.OnInit();
            runtime.OnAwake();
            runtime.OnStart();
        }

        /// <summary>
        ///     Runs the preview
        /// </summary>
        public void RunPreview()
        {
            Runtime<AManager> runtime = _context.Runtime;
            TimeManager timeManager = _context.TimeManager;
            Setting setting = _context.Setting;

            double targetFrameDuration = 1 / setting.Graphic.TargetFrames;
            double currentTime = timeManager.Clock.Elapsed.TotalSeconds;
            float accumulator = 0;
            double lastTime = timeManager.Clock.Elapsed.TotalSeconds;
            double totalTime = 0;
            float lastDeltaTime = 0f;
            float smoothDeltaTimeSum = 0f;
            int smoothDeltaTimeCount = 0;

            double frameStartTime = timeManager.Clock.Elapsed.TotalSeconds;
            double newTime = frameStartTime;

            timeManager.DeltaTime = (float) (newTime - currentTime);
            timeManager.UnscaledDeltaTime = (float) (newTime - currentTime);
            timeManager.UnscaledTime += timeManager.UnscaledDeltaTime;
            timeManager.UnscaledTimeAsDouble += timeManager.UnscaledDeltaTime;
            timeManager.Time = timeManager.UnscaledTime * timeManager.TimeScale;
            timeManager.TimeAsDouble = timeManager.UnscaledTimeAsDouble * timeManager.TimeScale;
            timeManager.MaximumDeltaTime = Math.Max(timeManager.MaximumDeltaTime, timeManager.DeltaTime);
            currentTime = newTime;
            accumulator += timeManager.DeltaTime;
            timeManager.FrameCount++;
            timeManager.TotalFrames++;

            if (newTime - lastTime >= TimeManager.OneSecond)
            {
                totalTime += newTime - lastTime;
                timeManager.AverageFrames = (int) (timeManager.TotalFrames / totalTime);
                timeManager.FrameCount = 0;
                lastTime = newTime;
            }

            runtime.OnDispatchEvents();
            runtime.OnProcessPendingChanges();

            runtime.OnPhysicUpdate();
            runtime.OnBeforeUpdate();
            runtime.OnUpdate();
            runtime.OnAfterUpdate();

            while (accumulator >= timeManager.Configuration.FixedTimeStep)
            {
                timeManager.InFixedTimeStep = true;
                timeManager.FixedTime += timeManager.Configuration.FixedTimeStep;
                timeManager.FixedTimeAsDouble += timeManager.Configuration.FixedTimeStep;
                timeManager.FixedDeltaTime = timeManager.Configuration.FixedTimeStep;
                timeManager.FixedUnscaledDeltaTime = timeManager.Configuration.FixedTimeStep / timeManager.TimeScale;
                timeManager.FixedUnscaledTime += timeManager.FixedUnscaledDeltaTime;
                timeManager.FixedUnscaledTimeAsDouble += timeManager.FixedUnscaledDeltaTime;
                runtime.OnBeforeFixedUpdate();
                runtime.OnFixedUpdate();
                runtime.OnAfterFixedUpdate();
                accumulator %= timeManager.Configuration.FixedTimeStep;
                timeManager.InFixedTimeStep = false;
            }

            runtime.OnCalculate();

            // Render game:
            runtime.OnBeforeDraw();
            runtime.OnDraw();
            runtime.OnAfterDraw();
            runtime.OnGui();
            runtime.OnRenderPresent();

            smoothDeltaTimeSum += timeManager.DeltaTime - lastDeltaTime;
            smoothDeltaTimeCount++;
            timeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
            lastDeltaTime = timeManager.DeltaTime;

            double frameEndTime = timeManager.Clock.Elapsed.TotalSeconds;
            double frameDuration = frameEndTime - frameStartTime;
            if (frameDuration < targetFrameDuration)
            {
                Thread.Sleep((int) ((targetFrameDuration - frameDuration) * TimeManager.MillisecondsInSecond));
            }
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

        /// <summary>
        ///     Loads the path
        /// </summary>
        /// <param name="path">The path</param>
        public void Load(string path)
        {
            _context.Setting.OnLoad(path);
            _context.Runtime.OnLoad(path);
        }
    }
}