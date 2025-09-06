// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PhysicSetting.cs
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

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.Systems.Configuration.Physic
{
    /// <summary>
    ///     The physic setting
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PhysicSetting(
        Vector2F gravity = default(Vector2F)) : IPhysicSetting
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PhysicSetting" /> class
        /// </summary>
        public PhysicSetting() : this(new Vector2F(0, -9.81f))
        {
        }

        /// <summary>
        ///     Gets or sets the value of the gravity
        /// </summary>
        public Vector2F Gravity { get; set; } = gravity;
    }
}