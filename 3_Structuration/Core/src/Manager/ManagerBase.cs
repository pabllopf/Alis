// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ManagerBase.cs
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

namespace Alis.Core.Manager
{
    /// <summary>
    ///     Manager base
    /// </summary>
    public abstract class ManagerBase
    {
        /// <summary>
        ///     Gets or sets the value of the is exit requested
        /// </summary>
        public bool IsExitRequested { get; set; } = false;

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public virtual void Init() => Logger.Info($"{GetType().Name} is initializing...");

        /// <summary>Awakes this instance.</summary>
        public virtual void Awake() => Logger.Info($"{GetType().Name} is awaking...");

        /// <summary>Starts this instance.</summary>
        public virtual void Start() => Logger.Info($"{GetType().Name} is starting...");

        /// <summary>Before the update.</summary>
        public virtual void BeforeUpdate() => Logger.Info($"{GetType().Name} is before updating...");

        /// <summary>Updates this instance.</summary>
        public virtual void Update() => Logger.Info($"{GetType().Name} is updating...");

        /// <summary>Afters the update.</summary>
        public virtual void AfterUpdate() => Logger.Info($"{GetType().Name} is after updating...");

        /// <summary>Fix the update.</summary>
        public virtual void FixedUpdate() => Logger.Info($"{GetType().Name} is fixed updating...");

        /// <summary>Dispatches the events.</summary>
        public virtual void DispatchEvents() => Logger.Info($"{GetType().Name} is dispatching events...");

        /// <summary>Draws this instance </summary>
        public virtual void Draw() => Logger.Info($"{GetType().Name} is drawing...");
        
        /// <summary>
        /// Calculates this instance
        /// </summary>
        public virtual void Calculate() => Logger.Info($"{GetType().Name} is calculating...");

        /// <summary>Resets this instance.</summary>
        public virtual void Reset() => Logger.Info($"{GetType().Name} is resetting...");

        /// <summary>Stops this instance.</summary>
        public virtual void Stop() => Logger.Info($"{GetType().Name} is stopping...");

        /// <summary>Exits this instance.</summary>
        public virtual void Exit() => Logger.Info($"{GetType().Name} is exiting...");
    }
}