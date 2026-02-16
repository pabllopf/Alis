// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InputSettingBuilder.cs
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
using Alis.Core.Ecs.Systems.Configuration.Input;

namespace Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Input
{
    /// <summary>
    ///     The audio setting builder class
    /// </summary>
    public class InputSettingBuilder :
        IBuild<InputSetting>
    {
        /// <summary>
        ///     The sensitivity
        /// </summary>
        private float sensitivity = 1.0f;

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The audio setting</returns>
        public InputSetting Build() => new InputSetting(sensitivity);

        /// <summary>
        ///     Mouses the sensitivity using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The input setting builder</returns>
        public InputSettingBuilder MouseSensitivity(float value)
        {
            sensitivity = value;
            return this;
        }
    }
}