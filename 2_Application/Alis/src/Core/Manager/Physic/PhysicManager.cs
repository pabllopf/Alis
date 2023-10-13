// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PhysicManager.cs
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
using Alis.Core.Physic;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Manager.Physic
{
    /// <summary>
    ///     The physic manager class
    /// </summary>
    /// <seealso cref="ManagerBase" />
    public class PhysicManager : PhysicManagerBase
    {
        /// <summary>
        ///     Gets or sets the value of the world
        /// </summary>
        public World World { get; set; }

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void Init()
        {
            World = new World(VideoGame.Setting.Physic.Gravity);
            Logger.Trace();
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update() => World.Step((float) (1f / GameBase.TimeManager.MaximumFramesPerSecond));

        /// <summary>
        ///     Attaches the body using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        public void AttachBody(Body body) => World.AddBody(body);
    }
}