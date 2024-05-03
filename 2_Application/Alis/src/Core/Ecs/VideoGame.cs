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
using System.Collections.Generic;
using Alis.Builder.Core.Ecs.System;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.Entity.Property;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager;
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
    /// <seealso cref="ICrud{Manager}" />
    /// <seealso cref="IHasContext{Context}" />
    public sealed class VideoGame : IGame, ICrud<Manager>, IHasContext<Context>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class
        /// </summary>
        /// <param name="settings">The settings</param>
        /// <param name="audioManager">The audio manager</param>
        /// <param name="graphicManager">The graphic manager</param>
        /// <param name="inputManager">The input manager</param>
        /// <param name="networkManager">The network manager</param>
        /// <param name="physicManager">The physic manager</param>
        /// <param name="profileManager">The profile manager</param>
        /// <param name="sceneManager">The scene manager</param>
        /// <param name="context">The context</param>
        /// <param name="managers">The managers</param>
        public VideoGame(
            Settings settings,
            AudioManager audioManager,
            GraphicManager graphicManager,
            InputManager inputManager,
            NetworkManager networkManager,
            PhysicManager physicManager,
            SceneManager sceneManager,
            Context context = null,
            params Manager[] managers)
        {
            context ??= new Context(this, settings);
            Managers = new Dictionary<Type, Manager>();
            Context = context;
            audioManager.SetContext(context);
            graphicManager.SetContext(context);
            inputManager.SetContext(context);
            networkManager.SetContext(context);
            physicManager.SetContext(context);
            sceneManager.SetContext(context);
            
            foreach (Manager manager in managers)
            {
                Managers.Add(manager.GetType(), manager);
            }
            
            foreach (Manager manager in managers)
            {
                manager.SetContext(Context);
            }
            
            Add(audioManager);
            Add(graphicManager);
            Add(inputManager);
            Add(networkManager);
            Add(physicManager);
            Add(sceneManager);
        }
        
        /// <summary>
        ///     The time manager base
        /// </summary>
        internal TimeManager TimeManager { get; } = new TimeManager();
        
        /// <summary>
        ///     Gets or sets the value of the managers
        /// </summary>
        private Dictionary<Type, Manager> Managers { get; }
        
        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        private Context Context { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the settings
        /// </summary>
        public Settings Settings
        {
            get => Context.Settings;
            set => Context.Settings = value;
        }
        
        /// <summary>
        ///     Adds the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Add<T>(T component) where T : Manager
        {
            component.SetContext(Context);
            Managers.Add(typeof(T), component);
        }
        
        /// <summary>
        ///     Removes the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Remove<T>(T component) where T : Manager => Managers.Remove(typeof(T));
        
        /// <summary>
        ///     Gets this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public T Get<T>() where T : Manager => (T) Managers[typeof(T)];
        
        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public bool Contains<T>() where T : Manager => Managers.ContainsKey(typeof(T));
        
        /// <summary>
        ///     Clears this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        public void Clear<T>() where T : Manager => Managers.Clear();
        
        /// <summary>
        ///     Gets or sets the value of the is running
        /// </summary>
        public bool IsRunning { get; set; } = true;
        
        /// <summary>
        ///     Run program
        /// </summary>
        public void Run()
        {
            Dictionary<Type, Manager>.ValueCollection tempManagers = Managers.Values;
            
            foreach (Manager manager in tempManagers)
            {
                manager.OnInit();
            }
            
            foreach (Manager manager in tempManagers)
            {
                manager.OnAwake();
            }
            
            foreach (Manager manager in tempManagers)
            {
                manager.OnStart();
            }
            
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
                foreach (Manager manager in tempManagers)
                {
                    manager.OnDispatchEvents();
                }
                
                // Update Scripts
                foreach (Manager manager in tempManagers)
                {
                    manager.OnBeforeUpdate();
                }
                
                foreach (Manager manager in tempManagers)
                {
                    manager.OnUpdate();
                }
                
                foreach (Manager manager in tempManagers)
                {
                    manager.OnAfterUpdate();
                }
                
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
                    
                    foreach (Manager manager in tempManagers)
                    {
                        manager.OnBeforeFixedUpdate();
                    }
                    
                    foreach (Manager manager in tempManagers)
                    {
                        manager.OnFixedUpdate();
                    }
                    
                    foreach (Manager manager in tempManagers)
                    {
                        manager.OnAfterFixedUpdate();
                    }
                    
                    accumulator -= TimeManager.Configuration.FixedTimeStep;
                    
                    TimeManager.InFixedTimeStep = false;
                }
                
                // Calculate method to calculate math
                foreach (Manager manager in tempManagers)
                {
                    manager.OnCalculate();
                }
                
                // Render Game
                foreach (Manager manager in tempManagers)
                {
                    manager.OnDraw();
                }
                
                // Render the Ui
                foreach (Manager manager in tempManagers)
                {
                    manager.OnGui();
                }
                
                // Update SmoothDeltaTime
                smoothDeltaTimeSum += TimeManager.DeltaTime - lastDeltaTime;
                smoothDeltaTimeCount++;
                TimeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
                lastDeltaTime = TimeManager.DeltaTime;
                
                // Log output every 1 second
                if ((newTime - lastLogTime >= 0.5) && TimeManager.Configuration.LogOutput)
                {
                    Logger.Trace(
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
            
            
            foreach (Manager manager in tempManagers)
            {
                manager.OnStop();
            }
            
            foreach (Manager manager in tempManagers)
            {
                manager.OnExit();
            }
        }
        
        /// <summary>
        ///     Exits this instance
        /// </summary>
        public void Exit() => IsRunning = false;
        
        /// <summary>
        ///     Sets the context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        public void SetContext(Context context) => Context = context;
        
        /// <summary>
        ///     Gets this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public T Find<T>() where T : Manager => (T) Managers[typeof(T)];
        
        /// <summary>
        ///     Sets the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Set<T>(T component) where T : Manager
        {
            component.SetContext(Context);
            Managers[typeof(T)] = component;
        }
        
        /// <summary>
        ///     Builders
        /// </summary>
        /// <returns>The video game builder</returns>
        public static VideoGameBuilder Builder() => new VideoGameBuilder();
    }
}