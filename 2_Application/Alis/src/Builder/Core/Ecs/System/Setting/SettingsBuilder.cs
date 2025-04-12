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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;

namespace Alis.Builder.Core.Ecs.System.Setting
{
    /// <summary>
    ///     Setting builder
    /// </summary>
    public class SettingsBuilder :
        IBuild<Alis.Core.Ecs.Systems.Configuration.Setting>,
        IAudio<SettingsBuilder, Action<AudioSettingBuilder>>,
        IGeneral<SettingsBuilder, Action<GeneralSettingBuilder>>,
        IGraphic<SettingsBuilder, Action<GraphicSettingBuilder>>,
        IInput<SettingsBuilder, Action<InputSettingBuilder>>,
        INetwork<SettingsBuilder, Action<NetworkSettingBuilder>>,
        IPhysic<SettingsBuilder, Action<PhysicSettingBuilder>>
    {
        /// <summary>
        ///     The setting base
        /// </summary>
        private readonly Alis.Core.Ecs.Systems.Configuration.Setting settingBase = new Alis.Core.Ecs.Systems.Configuration.Setting();
        
        /// <summary>
        ///     Build setting
        /// </summary>
        /// <returns></returns>
        public Alis.Core.Ecs.Systems.Configuration.Setting Build() => settingBase;

        /// <summary>
        ///     Generals the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder General(Action<GeneralSettingBuilder> value)
        {
            GeneralSettingBuilder generalSettingBuilder = new GeneralSettingBuilder();
            value(generalSettingBuilder);
            settingBase.General = generalSettingBuilder.Build();
            return this;
        }

        /// <summary>
        ///     Graphics the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Graphic(Action<GraphicSettingBuilder> value)
        {
            GraphicSettingBuilder graphicSettingBuilder = new GraphicSettingBuilder();
            value(graphicSettingBuilder);
            settingBase.Graphic = graphicSettingBuilder.Build();
            return this;
        }
        
        /// <summary>
        ///     Inputs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Input(Action<InputSettingBuilder> value)
        {
            InputSettingBuilder inputSettingBuilder = new InputSettingBuilder();
            value(inputSettingBuilder);
            settingBase.Input = inputSettingBuilder.Build();
            return this;
        }

        /// <summary>
        ///     Networks the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Network(Action<NetworkSettingBuilder> value)
        {
            NetworkSettingBuilder networkSettingBuilder = new NetworkSettingBuilder();
            value(networkSettingBuilder);
            settingBase.Network = networkSettingBuilder.Build();
            return this;
        }

        /// <summary>
        ///     Physics the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Physic(Action<PhysicSettingBuilder> value)
        {
            PhysicSettingBuilder physicSettingBuilder = new PhysicSettingBuilder();
            value(physicSettingBuilder);
            settingBase.Physic = physicSettingBuilder.Build();
            return this;
        }
        
        /// <summary>
        ///     Audio the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Audio(Action<AudioSettingBuilder> value)
        {
            AudioSettingBuilder audioSettingBuilder = new AudioSettingBuilder();
            value(audioSettingBuilder);
            settingBase.Audio = audioSettingBuilder.Build();
            return this;
        }
    }
}