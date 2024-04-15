// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Settings.cs
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

using Alis.Core.Ecs.System.Setting.Audio;
using Alis.Core.Ecs.System.Setting.General;
using Alis.Core.Ecs.System.Setting.Graphic;
using Alis.Core.Ecs.System.Setting.Input;
using Alis.Core.Ecs.System.Setting.Network;
using Alis.Core.Ecs.System.Setting.Physic;
using Alis.Core.Ecs.System.Setting.Profile;
using Alis.Core.Ecs.System.Setting.Scene;

namespace Alis.Core.Ecs.System.Setting
{
    /// <summary>
    ///     The setting class
    /// </summary>
    /// <seealso cref="ISetting" />
    public class Settings : ISetting
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
        ///     Gets or sets the value of the graphic
        /// </summary>
        public GraphicSetting Graphic { get; set; } = new GraphicSetting();
        
        /// <summary>
        ///     Gets or sets the value of the input
        /// </summary>
        public InputSetting Input { get; set; } = new InputSetting();
        
        /// <summary>
        ///     Gets or sets the value of the network
        /// </summary>
        public NetworkSetting Network { get; set; } = new NetworkSetting();
        
        /// <summary>
        ///     Gets or sets the value of the physic
        /// </summary>
        public PhysicSetting Physic { get; set; } = new PhysicSetting();
        
        /// <summary>
        ///     Gets or sets the value of the profile
        /// </summary>
        public ProfileSetting Profile { get; set; } = new ProfileSetting();
        
        /// <summary>
        ///     Gets or sets the value of the scene
        /// </summary>
        public SceneSetting Scene { get; set; } = new SceneSetting();
    }
}