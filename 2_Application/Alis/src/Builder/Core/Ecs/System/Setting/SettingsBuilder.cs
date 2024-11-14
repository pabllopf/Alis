// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingsBuilder.cs
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

using System;
using Alis.Builder.Core.Ecs.System.Setting.Audio;
using Alis.Builder.Core.Ecs.System.Setting.General;
using Alis.Builder.Core.Ecs.System.Setting.Graphic;
using Alis.Builder.Core.Ecs.System.Setting.Input;
using Alis.Builder.Core.Ecs.System.Setting.Network;
using Alis.Builder.Core.Ecs.System.Setting.Physic;
using Alis.Builder.Core.Ecs.System.Setting.Scene;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.System.Configuration.Audio;
using Alis.Core.Ecs.System.Configuration.General;
using Alis.Core.Ecs.System.Configuration.Graphic;
using Alis.Core.Ecs.System.Configuration.Input;
using Alis.Core.Ecs.System.Configuration.Network;
using Alis.Core.Ecs.System.Configuration.Physic;
using Alis.Core.Ecs.System.Configuration.Scene;

namespace Alis.Builder.Core.Ecs.System.Setting
{
    /// <summary>
    ///     Setting builder
    /// </summary>
    public class SettingsBuilder :
        IBuild<Alis.Core.Ecs.System.Configuration.Setting>,
        IAudio<SettingsBuilder, Func<AudioSettingBuilder, AudioSetting>>,
        IGeneral<SettingsBuilder, Func<GeneralSettingBuilder, GeneralSetting>>,
        IGraphic<SettingsBuilder, Func<GraphicSettingBuilder, GraphicSetting>>,
        IInput<SettingsBuilder, Func<InputSettingBuilder, InputSetting>>,
        INetwork<SettingsBuilder, Func<NetworkSettingBuilder, NetworkSetting>>,
        IPhysic<SettingsBuilder, Func<PhysicSettingBuilder, PhysicSetting>>,
        IScene<SettingsBuilder, Func<SceneSettingBuilder, SceneSetting>>
    {
        /// <summary>
        ///     The setting base
        /// </summary>
        private readonly Alis.Core.Ecs.System.Configuration.Setting settingBase = new Alis.Core.Ecs.System.Configuration.Setting();

        /// <summary>
        ///     Audio the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Audio(Func<AudioSettingBuilder, AudioSetting> value)
        {
            settingBase.Audio = value.Invoke(new AudioSettingBuilder());
            return this;
        }

        /// <summary>
        ///     Build setting
        /// </summary>
        /// <returns></returns>
        public Alis.Core.Ecs.System.Configuration.Setting Build() => settingBase;

        /// <summary>
        ///     Generals the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder General(Func<GeneralSettingBuilder, GeneralSetting> value)
        {
            settingBase.General = value.Invoke(new GeneralSettingBuilder());
            return this;
        }

        /// <summary>
        ///     Graphics the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Graphic(Func<GraphicSettingBuilder, GraphicSetting> value)
        {
            settingBase.Graphic = value.Invoke(new GraphicSettingBuilder());
            return this;
        }


        /// <summary>
        ///     Inputs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Input(Func<InputSettingBuilder, InputSetting> value)
        {
            settingBase.Input = value.Invoke(new InputSettingBuilder());
            return this;
        }

        /// <summary>
        ///     Networks the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Network(Func<NetworkSettingBuilder, NetworkSetting> value)
        {
            settingBase.Network = value.Invoke(new NetworkSettingBuilder());
            return this;
        }

        /// <summary>
        ///     Physics the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Physic(Func<PhysicSettingBuilder, PhysicSetting> value)
        {
            settingBase.Physic = value.Invoke(new PhysicSettingBuilder());
            return this;
        }

        /// <summary>
        ///     Scenes the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Scene(Func<SceneSettingBuilder, SceneSetting> value)
        {
            settingBase.Scene = value.Invoke(new SceneSettingBuilder());
            return this;
        }
    }
}