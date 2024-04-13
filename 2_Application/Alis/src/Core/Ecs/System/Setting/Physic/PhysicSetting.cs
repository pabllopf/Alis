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

using Alis.Builder.Core.Ecs.System.Setting.Physic;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.System.Setting.Physic
{
    /// <summary>
    ///     The physic setting class
    /// </summary>
    /// <seealso cref="IPhysicSetting" />
    /// <seealso cref="IBuilder{PhysicSettingBuilder}" />
    public class PhysicSetting : IPhysicSetting,
        IBuilder<PhysicSettingBuilder>
    {
        /// <summary>
        ///     Gets or sets the value of the debug mode
        /// </summary>
        public bool DebugMode { get; set; } = false;
        
        /// <summary>
        ///     Gets or sets the value of the debug color
        /// </summary>
        public Color DebugColor { get; set; }
        
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The physic setting builder</returns>
        public PhysicSettingBuilder Builder() => new PhysicSettingBuilder();
        
        /// <summary>
        ///     Gets or sets the value of the gravity
        /// </summary>
        public Vector2 Gravity { get; set; } = new Vector2(0.0f, 9.8f);
    }
}