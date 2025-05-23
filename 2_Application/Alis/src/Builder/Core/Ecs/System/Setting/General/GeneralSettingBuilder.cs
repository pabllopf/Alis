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

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems.Configuration.General;

namespace Alis.Builder.Core.Ecs.System.Setting.General
{
    /// <summary>
    ///     The general setting builder class
    /// </summary>
    /// <seealso cref="IBuild{GeneralSetting}" />
    public class GeneralSettingBuilder :
        IBuild<GeneralSetting>,
        IName<GeneralSettingBuilder, string>,
        IVersion<GeneralSettingBuilder, string>,
        IDebug<GeneralSettingBuilder, bool>,
        ILicense<GeneralSettingBuilder, string>,
        IAuthor<GeneralSettingBuilder, string>,
        IDescription<GeneralSettingBuilder, string>,
        IIcon<GeneralSettingBuilder, string>
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
        ///     Debugs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder Debug(bool value)
        {
            generalSetting.Debug = value;
            return this;
        }

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
            generalSetting.Icon = value;
            return this;
        }

        /// <summary>
        ///     Licences the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder License(string value)
        {
            generalSetting.License = value;
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
        ///     Versions the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder Version(string value)
        {
            generalSetting.Version = value;
            return this;
        }
    }
}