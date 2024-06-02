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

using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Ecs.System.Setting.Audio;
using Alis.Core.Ecs.System.Setting.General;
using Alis.Core.Ecs.System.Setting.Graphic;
using Alis.Core.Ecs.System.Setting.Input;
using Alis.Core.Ecs.System.Setting.Network;
using Alis.Core.Ecs.System.Setting.Physic;
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
        /// Initializes a new instance of the <see cref="Settings"/> class
        /// </summary>
        public Settings()
        {
            General = new GeneralSetting();
            Audio = new AudioSetting();
            Graphic = new GraphicSetting();
            Input = new InputSetting();
            Network = new NetworkSetting();
            Physic = new PhysicSetting();
            Scene = new SceneSetting();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class
        /// </summary>
        /// <param name="general">The general</param>
        /// <param name="audio">The audio</param>
        /// <param name="graphic">The graphic</param>
        /// <param name="input">The input</param>
        /// <param name="network">The network</param>
        /// <param name="physic">The physic</param>
        /// <param name="scene">The scene</param>
        [JsonConstructor]
        [ExcludeFromCodeCoverage]
        public Settings(GeneralSetting general, AudioSetting audio, GraphicSetting graphic, InputSetting input, NetworkSetting network, PhysicSetting physic, SceneSetting scene)
        {
            General = general;
            Audio = audio;
            Graphic = graphic;
            Input = input;
            Network = network;
            Physic = physic;
            Scene = scene;
        }
        
        /// <summary>
        ///     Gets or sets the value of the general
        /// </summary>
        [JsonPropertyName("_General_")]
        public GeneralSetting General { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the audio
        /// </summary>
        [JsonPropertyName("_Audio_")]
        public AudioSetting Audio { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the graphic
        /// </summary>
        [JsonPropertyName("_Graphic_")]
        public GraphicSetting Graphic { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the input
        /// </summary>
        [JsonPropertyName("_Input_")]
        public InputSetting Input { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the network
        /// </summary>
        [JsonPropertyName("_Network_")]
        public NetworkSetting Network { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the physic
        /// </summary>
        [JsonPropertyName("_Physic_")]
        public PhysicSetting Physic { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the scene
        /// </summary>
        [JsonPropertyName("_Scene_")]
        public SceneSetting Scene { get; set; }
    }
}