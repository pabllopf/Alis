// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingManager.cs
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

using Alis.Core.Setting;

namespace Alis.Core.Manager.Setting
{
    /// <summary>
    ///     The setting manager class
    /// </summary>
    /// <seealso cref="SettingManagerBase" />
    public class SettingManager : SettingManagerBase
    {
        /// <summary>
        ///     Gets or sets the value of the general
        /// </summary>
        public GeneralSetting General { get; set; } = new GeneralSetting();

        /// <summary>
        ///     Gets or sets the value of the audio
        /// </summary>
        public AudioSetting Audio { get; set; } = new AudioSetting();

        /// <summary>
        ///     Gets or sets the value of the debug
        /// </summary>
        public DebugSetting Debug { get; set; } = new DebugSetting();

        /// <summary>
        ///     Gets or sets the value of the graphic
        /// </summary>
        public GraphicSetting Graphic { get; set; } = new GraphicSetting();
        
        /// <summary>
        /// Gets or sets the value of the physic
        /// </summary>
        public PhysicSetting Physic { get; set; } = new PhysicSetting();
    }
}