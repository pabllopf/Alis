// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SettingBuilder.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core;
using Alis.Core.Configurations;
using Alis.Core.FluentApi;
using Alis.Core.FluentApi.Words;

namespace Alis.Builders
{
    /// <summary>
    ///     The setting builder class
    /// </summary>
    /// <seealso cref="IBuild{TOrigin}" />
    /// <seealso cref="IGeneral{TBuilder,TArgument}" />
    /// <seealso cref="IWindow{SettingBuilder, Func{WindowBuilder, Window}}" />
    /// <seealso cref="IDebug{SettingBuilder, Func{DebugBuilder, Debug}}" />
    public class SettingBuilder :
        IBuild<Setting>,
        IGeneral<SettingBuilder, Func<GeneralBuilder, General>>,
        IWindow<SettingBuilder, Func<WindowBuilder, Window>>,
        IDebug<SettingBuilder, Func<DebugBuilder, Debug>>
    {
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The setting</returns>
        public Setting Build() => Game.Setting;

        /// <summary>
        ///     Debugs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The setting builder</returns>
        public SettingBuilder Debug(Func<DebugBuilder, Debug> value)
        {
            Game.Setting.Debug = value.Invoke(new DebugBuilder());
            return this;
        }

        /// <summary>Generals the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public SettingBuilder General(Func<GeneralBuilder, General> value)
        {
            Game.Setting.General = value.Invoke(new GeneralBuilder());
            return this;
        }

        /// <summary>Windows the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     <br />
        /// </returns>
        public SettingBuilder Window(Func<WindowBuilder, Window> value)
        {
            Game.Setting.Window = value.Invoke(new WindowBuilder());
            return this;
        }
    }
}