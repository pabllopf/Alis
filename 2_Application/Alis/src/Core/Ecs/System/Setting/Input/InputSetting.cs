// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InputSetting.cs
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

using Alis.Builder.Core.Ecs.System.Setting.Input;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;

namespace Alis.Core.Ecs.System.Setting.Input
{
    /// <summary>
    ///     The input setting class
    /// </summary>
    /// <seealso cref="IInputSetting" />
    public class InputSetting : 
        IInputSetting,
        IBuilder<InputSettingBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputSetting"/> class
        /// </summary>
        public InputSetting()
        {
            UpdateMode = UpdateMode.DynamicUpdate;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InputSetting"/> class
        /// </summary>
        /// <param name="updateMode">The update mode</param>
        [JsonConstructor]
        public InputSetting(UpdateMode updateMode)
        {
            UpdateMode = updateMode;
        }
        
        /// <summary>
        /// Gets or sets the value of the update mode
        /// </summary>
        [JsonPropertyName("_UpdateMode_")]
        public UpdateMode UpdateMode { get; set; }
        
        /// <summary>
        /// Builders this instance
        /// </summary>
        /// <returns>The input setting builder</returns>
        public InputSettingBuilder Builder() => new InputSettingBuilder();
    }
}