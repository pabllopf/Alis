// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PhysicSettingBuilder.cs
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

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.System.Configuration.Physic;

namespace Alis.Builder.Core.Ecs.System.Setting.Physic
{
    /// <summary>
    ///     The physic setting builder class
    /// </summary>
    /// <seealso cref="IBuild{PhysicSetting}" />
    public class PhysicSettingBuilder :
        IBuild<PhysicSetting>,
        IGravity<PhysicSettingBuilder, float>,
        IDebug<PhysicSettingBuilder, bool>,
        IDebugColor<PhysicSettingBuilder, Color>
    {
        /// <summary>
        ///     The physic setting
        /// </summary>
        private readonly PhysicSetting physicSetting = new PhysicSetting();

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The physic setting</returns>
        public PhysicSetting Build() => physicSetting;

        /// <summary>
        ///     Debugs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The physic setting builder</returns>
        public PhysicSettingBuilder Debug(bool value)
        {
            physicSetting.DebugMode = value;
            return this;
        }

        /// <summary>
        ///     Debugs the color using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The physic setting builder</returns>
        public PhysicSettingBuilder DebugColor(Color value)
        {
            physicSetting.DebugColor = value;
            return this;
        }

        /// <summary>
        ///     Gravities the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The physic setting builder</returns>
        public PhysicSettingBuilder Gravity(float x, float y)
        {
            physicSetting.Gravity = new Vector2F(x, y);
            return this;
        }
    }
}