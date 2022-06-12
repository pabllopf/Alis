// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Controller.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Extensions.PhysicsLogics.PhysicsLogicBase;

namespace Alis.Core.Systems.Physics2D.Extensions.Controllers.ControllerBase
{
    /// <summary>
    ///     The controller class
    /// </summary>
    /// <seealso cref="FilterData" />
    public abstract class Controller : FilterData
    {
        /// <summary>
        ///     The type
        /// </summary>
        private readonly ControllerType type;

        /// <summary>
        ///     The enabled
        /// </summary>
        public bool Enabled;

        /// <summary>
        ///     The world
        /// </summary>
        public World World;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Controller" /> class
        /// </summary>
        /// <param name="controllerType">The controller type</param>
        protected Controller(ControllerType controllerType)
        {
            type = controllerType;
        }

        /// <summary>
        ///     Describes whether this instance is active on
        /// </summary>
        /// <param name="body">The body</param>
        /// <returns>The bool</returns>
        public override bool IsActiveOn(Body body)
        {
            if (body.ControllerFilter.IsControllerIgnored(type))
            {
                return false;
            }

            return base.IsActiveOn(body);
        }

        /// <summary>
        ///     Updates the dt
        /// </summary>
        /// <param name="dt">The dt</param>
        public abstract void Update(float dt);
    }
}