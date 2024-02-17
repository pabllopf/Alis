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
using Alis.Builder.Core.Ecs.System.Setting.Ads;
using Alis.Builder.Core.Ecs.System.Setting.Ai;
using Alis.Builder.Core.Ecs.System.Setting.Audio;
using Alis.Builder.Core.Ecs.System.Setting.Cloud;
using Alis.Builder.Core.Ecs.System.Setting.General;
using Alis.Builder.Core.Ecs.System.Setting.Graphic;
using Alis.Builder.Core.Ecs.System.Setting.Input;
using Alis.Builder.Core.Ecs.System.Setting.Network;
using Alis.Builder.Core.Ecs.System.Setting.Physic;
using Alis.Builder.Core.Ecs.System.Setting.Plugin;
using Alis.Builder.Core.Ecs.System.Setting.Profile;
using Alis.Builder.Core.Ecs.System.Setting.Scene;
using Alis.Builder.Core.Ecs.System.Setting.Script;
using Alis.Builder.Core.Ecs.System.Setting.Store;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.System.Setting;
using Alis.Core.Ecs.System.Setting.Ads;
using Alis.Core.Ecs.System.Setting.Ai;
using Alis.Core.Ecs.System.Setting.Audio;
using Alis.Core.Ecs.System.Setting.Cloud;
using Alis.Core.Ecs.System.Setting.General;
using Alis.Core.Ecs.System.Setting.Graphic;
using Alis.Core.Ecs.System.Setting.Input;
using Alis.Core.Ecs.System.Setting.Network;
using Alis.Core.Ecs.System.Setting.Physic;
using Alis.Core.Ecs.System.Setting.Plugin;
using Alis.Core.Ecs.System.Setting.Profile;
using Alis.Core.Ecs.System.Setting.Scene;
using Alis.Core.Ecs.System.Setting.Script;
using Alis.Core.Ecs.System.Setting.Store;

namespace Alis.Builder.Core.Ecs.System.Setting
{
    /// <summary>
    ///     Setting builder
    /// </summary>
    public class SettingsBuilder :
        IBuild<Settings>,
        IAds<SettingsBuilder, Func<AdsSettingBuilder, AdsSetting>>,
        IAi<SettingsBuilder, Func<AiSettingBuilder, AiSetting>>,
        IAudio<SettingsBuilder, Func<AudioSettingBuilder, AudioSetting>>,
        ICloud<SettingsBuilder, Func<CloudSettingBuilder, CloudSetting>>,
        IGeneral<SettingsBuilder, Func<GeneralSettingBuilder, GeneralSetting>>,
        IGraphic<SettingsBuilder, Func<GraphicSettingBuilder, GraphicSetting>>,
        IInput<SettingsBuilder, Func<InputSettingBuilder, InputSetting>>,
        INetwork<SettingsBuilder, Func<NetworkSettingBuilder, NetworkSetting>>,
        IPhysic<SettingsBuilder, Func<PhysicSettingBuilder, PhysicSetting>>,
        IPlugin<SettingsBuilder, Func<PluginSettingBuilder, PluginSetting>>,
        IProfile<SettingsBuilder, Func<ProfileSettingBuilder, ProfileSetting>>,
        IScene<SettingsBuilder, Func<SceneSettingBuilder, SceneSetting>>,
        IScript<SettingsBuilder, Func<ScriptSettingBuilder, ScriptSetting>>,
        IStore<SettingsBuilder, Func<StoreSettingBuilder, StoreSetting>>
    {
        /// <summary>
        ///     The setting base
        /// </summary>
        private readonly Settings settingBase = new Settings();

        /// <summary>
        ///     Ads the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Ads(Func<AdsSettingBuilder, AdsSetting> value)
        {
            settingBase.Ads = value.Invoke(new AdsSettingBuilder());
            return this;
        }

        /// <summary>
        ///     Ais the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Ai(Func<AiSettingBuilder, AiSetting> value)
        {
            settingBase.Ai = value.Invoke(new AiSettingBuilder());
            return this;
        }

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
        public Settings Build() => settingBase;

        /// <summary>
        ///     Clouds the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Cloud(Func<CloudSettingBuilder, CloudSetting> value)
        {
            settingBase.Cloud = value.Invoke(new CloudSettingBuilder());
            return this;
        }

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
        ///     Plugins the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Plugin(Func<PluginSettingBuilder, PluginSetting> value)
        {
            settingBase.Plugin = value.Invoke(new PluginSettingBuilder());
            return this;
        }

        /// <summary>
        ///     Profiles the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Profile(Func<ProfileSettingBuilder, ProfileSetting> value)
        {
            settingBase.Profile = value.Invoke(new ProfileSettingBuilder());
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

        /// <summary>
        ///     Scripts the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Script(Func<ScriptSettingBuilder, ScriptSetting> value)
        {
            settingBase.Script = value.Invoke(new ScriptSettingBuilder());
            return this;
        }

        /// <summary>
        ///     Stores the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Store(Func<StoreSettingBuilder, StoreSetting> value)
        {
            settingBase.Store = value.Invoke(new StoreSettingBuilder());
            return this;
        }
    }
}