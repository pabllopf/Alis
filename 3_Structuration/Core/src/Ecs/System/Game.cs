// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameBase.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.System.Manager;

namespace Alis.Core.Ecs.System
{
    /// <summary>
    ///     Define a game.
    /// </summary>
    public abstract class Game: IGame
    {
        /// <summary>
        /// Gets or sets the value of the managers
        /// </summary>
        public List<IManager> Managers { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the is running
        /// </summary>
        public bool IsRunning { get; set; } = true;
        
        /// <summary>
        ///     The time manager base
        /// </summary>
        private static TimeManager TimeManager { get; } = new TimeManager();
        
        /// <summary>
        ///     Run program
        /// </summary>
        public virtual void Run()
        {
            Managers.ForEach(i => i.OnInit());
            Managers.ForEach(i => i.OnAwake());
            Managers.ForEach(i => i.OnStart());
            
            double currentTime = TimeManager.Clock.Elapsed.TotalSeconds;
            double accumulator = 0;
            
            while (IsRunning)
            {
                double newTime = TimeManager.Clock.Elapsed.TotalSeconds;
                TimeManager.DeltaTime = (float) (newTime - currentTime);
                currentTime = newTime;
                accumulator += TimeManager.DeltaTime;
                    
                // Dispatch Events
                Managers.ForEach(i => i.OnDispatchEvents());
                
                // Update Scripts
                Managers.ForEach(j => j.OnBeforeUpdate());
                Managers.ForEach(j => j.OnUpdate());
                Managers.ForEach(j => j.OnAfterUpdate());
                
                // Run methods fixed
                if( accumulator >= TimeManager.Configuration.FixedTimeStep )
                {
                    Managers.ForEach(i => i.OnBeforeFixedUpdate());
                    Managers.ForEach(i => i.OnFixedUpdate());
                    Managers.ForEach(i => i.OnAfterFixedUpdate());
                    accumulator -= TimeManager.Configuration.FixedTimeStep;
                }
                
                // Calculate method to calculate math
                Managers.ForEach(i => i.OnCalculate());
                
                // Render Game
                Managers.ForEach(j => j.OnDraw());
                
                // Render the Ui
                Managers.ForEach(j => j.OnGui());
            }

            Managers.ForEach(i => i.OnStop());
            Managers.ForEach(i => i.OnExit());
        }

        /// <summary>
        /// Adds the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Add<T>(T component) where T : IManager => Managers.Add(component);
        
        /// <summary>
        /// Sets the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
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

        /// <summary>
        /// Removes the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Remove<T>(T component) where T : IManager => Managers.Remove(component);

        /// <summary>
        /// Gets this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public T Get<T>() where T : IManager => (T) Managers.Find(i => i.GetType() == typeof(T));

        /// <summary>
        /// Describes whether this instance contains
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public bool Contains<T>() where T : IManager => Get<T>() != null;

        /// <summary>
        /// Cleans this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        public void Clear<T>() where T : IManager => Managers.Clear();
    }
}