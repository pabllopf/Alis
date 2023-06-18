// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeneralSettingBuilder.cs
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
using Alis.Builder.Core.Entity;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Entity;
using Alis.Core.Setting;

namespace Alis.Builder.Core.Setting
{
    /// <summary>
    ///     The general setting builder class
    /// </summary>
    public class GeneralSettingBuilder :
        IBuild<GeneralSetting>,
        IName<GeneralSettingBuilder, string>,
        IAuthor<GeneralSettingBuilder, string>,
        IDescription<GeneralSettingBuilder, string>,
        IIcon<GeneralSettingBuilder, string>,
        ISplashScreen<GeneralSettingBuilder, Func<SplashScreenBuilder, SplashScreen>>
    {
        /// <summary>
        ///     The general setting
        /// </summary>
        private readonly GeneralSetting generalSetting = new GeneralSetting();

        /// <summary>
        ///     Authors the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder Author(string value)
        {
            generalSetting.Author = value;
            return this;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The general setting</returns>
        public GeneralSetting Build() => generalSetting;

        /// <summary>
        ///     Descriptions the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder Description(string value)
        {
            generalSetting.Description = value;
            return this;
        }

        /// <summary>
        ///     Icons the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder Icon(string value)
        {
            generalSetting.IconFile = value;
            return this;
        }

        /// <summary>
        ///     Names the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder Name(string value)
        {
            generalSetting.Name = value;
            return this;
        }

        /// <summary>
        ///     Splashes the screen using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder SplashScreen(Func<SplashScreenBuilder, SplashScreen> value)
        {
            generalSetting.SplashScreen = value.Invoke(new SplashScreenBuilder());
            return this;
        }
    }
}