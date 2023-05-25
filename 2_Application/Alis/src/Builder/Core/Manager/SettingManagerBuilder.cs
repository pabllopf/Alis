// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingManagerBuilder.cs
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
using Alis.Builder.Core.Setting;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Manager.Setting;
using Alis.Core.Setting;

namespace Alis.Builder.Core.Manager
{
    /// <summary>
    ///     The setting manager builder class
    /// </summary>
    /// <seealso cref="IBuild{SettingManager}" />
    public class SettingManagerBuilder :
        IBuild<SettingManager>,
        IDebug<SettingManagerBuilder, Func<DebugSettingBuilder, DebugSetting>>,
        IGeneral<SettingManagerBuilder, Func<GeneralSettingBuilder, GeneralSetting>>,
        IAudio<SettingManagerBuilder, Func<AudioSettingBuilder, AudioSetting>>,
        IGraphic<SettingManagerBuilder, Func<GraphicSettingBuilder, GraphicSetting>>,
        IPhysic<SettingManagerBuilder, Func<PhysicSettingBuilder, PhysicSetting>>
    {
        /// <summary>
        ///     The setting manager
        /// </summary>
        private SettingManager settingManager = new SettingManager();

        /// <summary>
        ///     Audioes the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The setting manager builder</returns>
        public SettingManagerBuilder Audio(Func<AudioSettingBuilder, AudioSetting> value)
        {
            settingManager.Audio = value.Invoke(new AudioSettingBuilder());
            return this;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The setting manager</returns>
        public SettingManager Build() => settingManager;

        /// <summary>
        ///     Debugs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The setting manager builder</returns>
        public SettingManagerBuilder Debug(Func<DebugSettingBuilder, DebugSetting> value)
        {
            settingManager.Debug = value.Invoke(new DebugSettingBuilder());
            return this;
        }

        /// <summary>
        ///     Generals the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The setting manager builder</returns>
        public SettingManagerBuilder General(Func<GeneralSettingBuilder, GeneralSetting> value)
        {
            settingManager.General = value.Invoke(new GeneralSettingBuilder());
            return this;
        }

        /// <summary>
        ///     Graphics the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The setting manager builder</returns>
        public SettingManagerBuilder Graphic(Func<GraphicSettingBuilder, GraphicSetting> value)
        {
            settingManager.Graphic = value.Invoke(new GraphicSettingBuilder());
            return this;
        }

        /// <summary>
        ///     Physics the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The setting manager builder</returns>
        public SettingManagerBuilder Physic(Func<PhysicSettingBuilder, PhysicSetting> value)
        {
            settingManager.Physic = value.Invoke(new PhysicSettingBuilder());
            return this;
        }
    }
}