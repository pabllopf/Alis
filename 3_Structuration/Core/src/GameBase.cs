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
using Alis.Core.Manager;
using Alis.Core.Manager.Time;

namespace Alis.Core
{
    /// <summary>
    ///     Define a game.
    /// </summary>
    public abstract class GameBase
    {
        /// <summary>
        ///     The manager base
        /// </summary>
        protected List<ManagerBase> Managers = new List<ManagerBase>();

        /// <summary>
        ///     The time manager base
        /// </summary>
        public static TimeManagerBase TimeManager { get; set; } = new TimeManagerBase();

        /// <summary>
        ///     Active game
        /// </summary>
        public static bool IsRunning;

        /// <summary>
        ///     Run program
        /// </summary>
        public virtual void Run()
        {
            IsRunning = true;
            
            Managers.ForEach(i => i.Init());
            Managers.ForEach(i => i.Awake());
            Managers.ForEach(i => i.Start());
            
            while (IsRunning)
            {
                TimeManager.SyncFixedDeltaTime();

                if (TimeManager.IsNewFrame())
                {
                    TimeManager.UpdateTimeStep();

                    for (int i = 0; i < TimeManager.MaximunAllowedTimeStep; i++)
                    {
                        Managers.ForEach(j => j.BeforeUpdate());
                        Managers.ForEach(j => j.Update());
                        Managers.ForEach(j => j.AfterUpdate());
                        
                        Managers.ForEach(j => j.Draw());
                    }
                    
                    Managers.ForEach(i => i.FixedUpdate());
                    Managers.ForEach(i => i.DispatchEvents());

                    TimeManager.CounterFrames();
                }

                TimeManager.UpdateFixedTime();
            }

            Managers.ForEach(i => i.Stop());
            Managers.ForEach(i => i.Exit());

            IsRunning = false;
        }

        /// <summary>
        ///     Gets the manager using the specified type
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The manager base</returns>
        public T FindManager<T>() where T : ManagerBase
        {
            return (T) Managers.FindLast(i => i.GetType() == typeof(T));
        }

        /// <summary>
        ///     Sets the manager using the specified manager
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="manager">The manager</param>
        public void SetManager<T>(T manager) where T : ManagerBase
        {
            for (int i = 0; i < Managers.Count; i++)
            {
                if (Managers[i].GetType() == manager.GetType())
                {
                    Managers[i] = manager;
                    return;
                }
            }

            Managers.Add(manager);
        }
    }
}