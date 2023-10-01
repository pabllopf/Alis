// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneManagerBase.cs
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

namespace Alis.Core.Manager.Scene
{
    /// <summary>
    ///     The scene manager base class
    /// </summary>
    /// <seealso cref="ManagerBase" />
    public class SceneManagerBase : ManagerBase
    {
        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void Init() => Logger.Info($"Init {GetType().Name}");

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake() => Logger.Info($"Awake {GetType().Name}");

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start() => Logger.Info($"Start {GetType().Name}");

        /// <summary>
        ///     Before the update
        /// </summary>
        public override void BeforeUpdate() => Logger.Info($"BeforeUpdate {GetType().Name}");

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update() => Logger.Info($"Update {GetType().Name}");

        /// <summary>
        ///     Afters the update
        /// </summary>
        public override void AfterUpdate() => Logger.Info($"AfterUpdate {GetType().Name}");

        /// <summary>
        ///     Fix the update
        /// </summary>
        public override void FixedUpdate() => Logger.Info($"FixedUpdate {GetType().Name}");

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public override void DispatchEvents() => Logger.Info($"DispatchEvents {GetType().Name}");

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public override void Draw() => Logger.Info($"Draw {GetType().Name}");

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public override void Reset() => Logger.Info($"Reset {GetType().Name}");

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public override void Stop() => Logger.Info($"Stop {GetType().Name}");

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void Exit() => Logger.Info($"Exit {GetType().Name}");
    }
}