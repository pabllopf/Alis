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

#region

using System;
using Alis.Core.Settings;
using Alis.Core.Settings.Configurations;
using Alis.FluentApi;
using Alis.FluentApi.Words;

#endregion

namespace Alis.Core.Sfml.Builders
{
    /// <summary>Define a builder. </summary>
    public class SettingBuilder :
        IBuild<Setting>,
        IGeneral<SettingBuilder, Func<GeneralBuilder, General>>,
        IWindow<SettingBuilder, Func<WindowBuilder, Window>>
    {
        /// <summary>Builds this instance.</summary>
        /// <returns></returns>
        public Setting Build()
        {
            return Game.Setting;
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