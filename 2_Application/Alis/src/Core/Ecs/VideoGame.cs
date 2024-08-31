// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoGame.cs
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
using Alis.Builder.Core.Ecs.System;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Setting;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The video game class
    /// </summary>
    /// <seealso cref="IGame" />
    public sealed class VideoGame : IGame
    {
        /// <summary>
        ///     The instancie
        /// </summary>
        [JsonIgnore] public static VideoGame _instancie;
        
        /// <summary>
        ///     The accumulator
        /// </summary>
        private double accumulator;
        
        /// <summary>
        ///     The current time
        /// </summary>
        private double currentTime;
        
        /// <summary>
        ///     The last delta time
        /// </summary>
        private float lastDeltaTime;
        
        /// <summary>
        ///     The last log time
        /// </summary>
        private double lastLogTime;
        
        /// <summary>
        ///     The last time
        /// </summary>
        private double lastTime;
        
        /// <summary>
        ///     The smooth delta time count
        /// </summary>
        private int smoothDeltaTimeCount;
        
        /// <summary>
        ///     The smooth delta time sum
        /// </summary>
        private float smoothDeltaTimeSum;
        
        /// <summary>
        ///     The total time
        /// </summary>
        private double totalTime;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class
        /// </summary>
        public VideoGame()
        {
            Context = new Context(new Settings());
            _instancie = this;
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class
        /// </summary>
        /// <param name="context">The context</param>
        [JsonConstructor]
        public VideoGame(Context context)
        {
            Context = context;
            _instancie = this;
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class
        /// </summary>
        /// <param name="settings">The settings</param>
        /// <param name="audioManager">The audio manager</param>
        /// <param name="graphicManager">The graphic manager</param>
        /// <param name="inputManager">The input manager</param>
        /// <param name="networkManager">The network manager</param>
        /// <param name="physicManager">The physic manager</param>
        /// <param name="sceneManager">The scene manager</param>
        public VideoGame(Settings settings, AudioManager audioManager, GraphicManager graphicManager, InputManager inputManager, NetworkManager networkManager, PhysicManager physicManager, SceneManager sceneManager)
        {
            Context = new Context
            {
                Settings = settings,
                AudioManager = audioManager,
                GraphicManager = graphicManager,
                InputManager = inputManager,
                NetworkManager = networkManager,
                PhysicManager = physicManager,
                SceneManager = sceneManager
            };
            
            _instancie = this;
        }
        
        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        [JsonPropertyName("_Context_")]
        public Context Context { get; set; }
        
        
        /// <summary>
        /// The target frame duration
        /// </summary>
        private const double TargetFrameDuration = 1.0 / 240.0;

        /// <summary>
        ///     Run program
        /// </summary>
        public void Run()
        {
            OnInit();
            OnAwake();
            OnStart();

            currentTime = Context.TimeManager.Clock.Elapsed.TotalSeconds;
            accumulator = 0;

            // Variables for calculating FPS
            lastTime = Context.TimeManager.Clock.Elapsed.TotalSeconds;
            Context.TimeManager.FrameCount = 0;
            Context.TimeManager.TotalFrames = 0;
            Context.TimeManager.AverageFrames = 0;

            // Variables for calculating average FPS
            totalTime = 0;

            // Variables for SmoothDeltaTime
            lastDeltaTime = 0f;
            smoothDeltaTimeSum = 0f;
            smoothDeltaTimeCount = 0;

            // Variable for log output
            lastLogTime = Context.TimeManager.Clock.Elapsed.TotalSeconds;

            while (Context.TimeManager.IsRunning)
            {
                double frameStartTime = Context.TimeManager.Clock.Elapsed.TotalSeconds;
                double newTime = frameStartTime;
                Context.TimeManager.DeltaTime = (float) (newTime - currentTime);

                // Update Context.TimeManager properties
                Context.TimeManager.UnscaledDeltaTime = (float) (newTime - currentTime);
                Context.TimeManager.UnscaledTime += Context.TimeManager.UnscaledDeltaTime;
                Context.TimeManager.UnscaledTimeAsDouble += Context.TimeManager.UnscaledDeltaTime;
                Context.TimeManager.Time = Context.TimeManager.UnscaledTime * Context.TimeManager.TimeScale;
                Context.TimeManager.TimeAsDouble = Context.TimeManager.UnscaledTimeAsDouble * Context.TimeManager.TimeScale;

                // Update MaximumDeltaTime
                Context.TimeManager.MaximumDeltaTime = Math.Max(Context.TimeManager.MaximumDeltaTime, Context.TimeManager.DeltaTime);

                currentTime = newTime;
                accumulator += Context.TimeManager.DeltaTime;

                // Increment frame counter
                Context.TimeManager.FrameCount++;
                Context.TimeManager.TotalFrames++;

                // If a second has passed since the last FPS calculation
                if (newTime - lastTime >= 1.0)
                {
                    // Calculate average FPS
                    totalTime += newTime - lastTime;
                    Context.TimeManager.AverageFrames = (int) (Context.TimeManager.TotalFrames / totalTime);

                    // Reset frame counter and update last time
                    Context.TimeManager.FrameCount = 0;
                    lastTime = newTime;
                }

                OnDispatchEvents();
                OnBeforeUpdate();
                OnUpdate();
                OnAfterUpdate();

                // Run fixed methods
                while (accumulator >= Context.TimeManager.Configuration.FixedTimeStep)
                {
                    Context.TimeManager.InFixedTimeStep = true;

                    Context.TimeManager.FixedTime += Context.TimeManager.Configuration.FixedTimeStep;
                    Context.TimeManager.FixedTimeAsDouble += Context.TimeManager.Configuration.FixedTimeStep;
                    Context.TimeManager.FixedDeltaTime = Context.TimeManager.Configuration.FixedTimeStep;
                    Context.TimeManager.FixedUnscaledDeltaTime = Context.TimeManager.Configuration.FixedTimeStep / Context.TimeManager.TimeScale;

                    // Update FixedUnscaledTime and FixedUnscaledTimeAsDouble
                    Context.TimeManager.FixedUnscaledTime += Context.TimeManager.FixedUnscaledDeltaTime;
                    Context.TimeManager.FixedUnscaledTimeAsDouble += Context.TimeManager.FixedUnscaledDeltaTime;

                    OnBeforeFixedUpdate();
                    OnFixedUpdate();
                    OnAfterFixedUpdate();

                    accumulator %= Context.TimeManager.Configuration.FixedTimeStep;

                    Context.TimeManager.InFixedTimeStep = false;
                }

                OnCalculate();
                OnDraw();
                OnGui();

                // Update SmoothDeltaTime
                smoothDeltaTimeSum += Context.TimeManager.DeltaTime - lastDeltaTime;
                smoothDeltaTimeCount++;
                Context.TimeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
                lastDeltaTime = Context.TimeManager.DeltaTime;

                lastLogTime = LastLogTime(newTime, lastLogTime);

                // Calculate frame duration and sleep if necessary
                double frameEndTime = Context.TimeManager.Clock.Elapsed.TotalSeconds;
                double frameDuration = frameEndTime - frameStartTime;
                if (frameDuration < TargetFrameDuration)
                {
                    Thread.Sleep((int) ((TargetFrameDuration - frameDuration) * 1000));
                }
            }

            OnStop();
            OnExit();
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public void Exit() => Context.TimeManager.IsRunning = false;
        
        /// <summary>
        ///     Inits the preview
        /// </summary>
        public void InitPreview()
        {
            OnInit();
            OnAwake();
            OnStart();
            
            currentTime = Context.TimeManager.Clock.Elapsed.TotalSeconds;
            accumulator = 0;
            
            // Variables for calculating FPS
            lastTime = Context.TimeManager.Clock.Elapsed.TotalSeconds;
            Context.TimeManager.FrameCount = 0;
            Context.TimeManager.TotalFrames = 0;
            Context.TimeManager.AverageFrames = 0;
            
            // Variables for calculating average FPS
            totalTime = 0;
            
            // Variables for SmoothDeltaTime
            lastDeltaTime = 0f;
            smoothDeltaTimeSum = 0f;
            smoothDeltaTimeCount = 0;
            
            // Variable for log output
            lastLogTime = Context.TimeManager.Clock.Elapsed.TotalSeconds;
        }
        
        /// <summary>
        ///     Runs the preview
        /// </summary>
        public void RunPreview()
        {
            double newTime = Context.TimeManager.Clock.Elapsed.TotalSeconds;
            Context.TimeManager.DeltaTime = (float) (newTime - currentTime);
            
            // Update Context.TimeManager properties
            Context.TimeManager.UnscaledDeltaTime = (float) (newTime - currentTime);
            Context.TimeManager.UnscaledTime += Context.TimeManager.UnscaledDeltaTime;
            Context.TimeManager.UnscaledTimeAsDouble += Context.TimeManager.UnscaledDeltaTime;
            Context.TimeManager.Time = Context.TimeManager.UnscaledTime * Context.TimeManager.TimeScale;
            Context.TimeManager.TimeAsDouble = Context.TimeManager.UnscaledTimeAsDouble * Context.TimeManager.TimeScale;
            
            // Update MaximumDeltaTime
            Context.TimeManager.MaximumDeltaTime = Math.Max(Context.TimeManager.MaximumDeltaTime, Context.TimeManager.DeltaTime);
            
            currentTime = newTime;
            accumulator += Context.TimeManager.DeltaTime;
            
            // Increment frame counter
            Context.TimeManager.FrameCount++;
            Context.TimeManager.TotalFrames++;
            
            // If a second has passed since the last FPS calculation
            if (newTime - lastTime >= 1.0)
            {
                // Calculate average FPS
                totalTime += newTime - lastTime;
                Context.TimeManager.AverageFrames = (int) (Context.TimeManager.TotalFrames / totalTime);
                
                // Reset frame counter and update last time
                Context.TimeManager.FrameCount = 0;
                lastTime = newTime;
            }
            
            OnDispatchEvents();
            OnBeforeUpdate();
            OnUpdate();
            OnAfterUpdate();
            
            // Run fixed methods
            while (accumulator >= Context.TimeManager.Configuration.FixedTimeStep)
            {
                Context.TimeManager.InFixedTimeStep = true;
                
                Context.TimeManager.FixedTime += Context.TimeManager.Configuration.FixedTimeStep;
                Context.TimeManager.FixedTimeAsDouble += Context.TimeManager.Configuration.FixedTimeStep;
                Context.TimeManager.FixedDeltaTime = Context.TimeManager.Configuration.FixedTimeStep;
                Context.TimeManager.FixedUnscaledDeltaTime = Context.TimeManager.Configuration.FixedTimeStep / Context.TimeManager.TimeScale;
                
                // Update FixedUnscaledTime and FixedUnscaledTimeAsDouble
                Context.TimeManager.FixedUnscaledTime += Context.TimeManager.FixedUnscaledDeltaTime;
                Context.TimeManager.FixedUnscaledTimeAsDouble += Context.TimeManager.FixedUnscaledDeltaTime;
                
                OnBeforeFixedUpdate();
                OnFixedUpdate();
                OnAfterFixedUpdate();
                
                accumulator -= Context.TimeManager.Configuration.FixedTimeStep;
                
                Context.TimeManager.InFixedTimeStep = false;
            }
            
            OnCalculate();
            OnDraw();
            OnGui();
            
            // Update SmoothDeltaTime
            smoothDeltaTimeSum += Context.TimeManager.DeltaTime - lastDeltaTime;
            smoothDeltaTimeCount++;
            Context.TimeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
            lastDeltaTime = Context.TimeManager.DeltaTime;
            
            lastLogTime = LastLogTime(newTime, lastLogTime);
        }
        
        /// <summary>
        ///     Exits the preview
        /// </summary>
        public void ExitPreview()
        {
            OnStop();
            OnExit();
        }
        
        /// <summary>
        ///     Ons the exit
        /// </summary>
        public void OnExit()
        {
            Context.OnExit();
        }
        
        /// <summary>
        ///     Ons the stop
        /// </summary>
        public void OnStop()
        {
            Context.OnStop();
        }
        
        /// <summary>
        ///     Lasts the log time using the specified new time
        /// </summary>
        /// <param name="newTime">The new time</param>
        /// <param name="lastLogTime">The last log time</param>
        /// <returns>The last log time</returns>
        public double LastLogTime(double newTime, double lastLogTime)
        {
            // Log output every 1 second
            if ((newTime - lastLogTime >= 0.5) && Context.TimeManager.Configuration.LogOutput)
            {
                Logger.Warning(
                    " FrameCount: " + Context.TimeManager.FrameCount + "\n" +
                    " TotalFrames: " + Context.TimeManager.TotalFrames + "\n" +
                    " AverageFps: " + Context.TimeManager.AverageFrames + "\n");
                /*
                Logger.Warning(
                    " FrameCount: " + Context.TimeManager.FrameCount + "\n" +
                    " TotalFrames: " + Context.TimeManager.TotalFrames + "\n" +
                    " AverageFps: " + Context.TimeManager.AverageFrames +"\n" +
                    " Time: " + Context.TimeManager.DeltaTime +"\n" +
                    " FixedTimeStep: " + Context.TimeManager.Configuration.FixedTimeStep +"\n" +
                    " FixedTime: " + Context.TimeManager.FixedTime +"\n" +
                    " FixedUnscaledDeltaTime: " + Context.TimeManager.FixedUnscaledDeltaTime +"\n" +
                    " FixedDeltaTime: " + Context.TimeManager.FixedDeltaTime +"\n" +
                    " FixedTimeAsDouble: " + Context.TimeManager.FixedTimeAsDouble +"\n" +
                    " FixedUnscaledTime: " + Context.TimeManager.FixedUnscaledTime +"\n" +
                    " FixedUnscaledTimeAsDouble: " + Context.TimeManager.FixedUnscaledTimeAsDouble +"\n" +
                    " InFixedTimeStep: " + Context.TimeManager.InFixedTimeStep +"\n" +
                    " MaximumDeltaTime: " + Context.TimeManager.MaximumDeltaTime +"\n" +
                    " RealtimeSinceStartup: " + Context.TimeManager.RealtimeSinceStartup +"\n" +
                    " RealtimeSinceStartupAsDouble: " + Context.TimeManager.RealtimeSinceStartupAsDouble +"\n" +
                    " SmoothDeltaTime: " + Context.TimeManager.SmoothDeltaTime +"\n" +
                    " TimeAsDouble: " + Context.TimeManager.TimeAsDouble +"\n" +
                    " TimeScale: " + Context.TimeManager.TimeScale +"\n" +
                    " UnscaledDeltaTime: " + Context.TimeManager.UnscaledDeltaTime +"\n" +
                    " UnscaledTime: " + Context.TimeManager.UnscaledTime +"\n" +
                    " UnscaledTimeAsDouble: " + Context.TimeManager.UnscaledTimeAsDouble);*/
                lastLogTime = newTime;
            }
            
            return lastLogTime;
        }
        
        /// <summary>
        ///     Ons the gui
        /// </summary>
        public void OnGui()
        {
            Context.OnGui();
        }
        
        /// <summary>
        ///     Ons the draw
        /// </summary>
        public void OnDraw()
        {
            Context.OnDraw();
        }
        
        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public void OnCalculate()
        {
            Context.OnCalculate();
        }
        
        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public void OnAfterFixedUpdate()
        {
            Context.OnAfterFixedUpdate();
        }
        
        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public void OnFixedUpdate()
        {
            Context.OnFixedUpdate();
        }
        
        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public void OnBeforeFixedUpdate()
        {
            Context.OnBeforeFixedUpdate();
        }
        
        /// <summary>
        ///     Ons the after update
        /// </summary>
        public void OnAfterUpdate()
        {
            Context.OnAfterUpdate();
        }
        
        /// <summary>
        ///     Ons the update
        /// </summary>
        public void OnUpdate()
        {
            Context.OnUpdate();
        }
        
        /// <summary>
        ///     Ons the before update
        /// </summary>
        public void OnBeforeUpdate()
        {
            Context.OnBeforeUpdate();
        }
        
        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public void OnDispatchEvents()
        {
            Context.OnDispatchEvents();
        }
        
        /// <summary>
        ///     Ons the start
        /// </summary>
        public void OnStart()
        {
            Context.OnStart();
        }
        
        /// <summary>
        ///     Ons the awake
        /// </summary>
        public void OnAwake()
        {
            Context.OnAwake();
        }
        
        /// <summary>
        ///     Ons the init
        /// </summary>
        public void OnInit()
        {
            Context.OnInit();
        }
        
        /// <summary>
        ///     Builders
        /// </summary>
        /// <returns>The video game builder</returns>
        public static VideoGameBuilder Builder() => new VideoGameBuilder();
        
        /// <summary>
        ///     Gets the context
        /// </summary>
        /// <returns>The context</returns>
        public static Context GetContext() => _instancie.Context;
        
        /// <summary>
        ///     Sets the context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        public static void SetContext(Context context) => _instancie.Context = context;
    }
}