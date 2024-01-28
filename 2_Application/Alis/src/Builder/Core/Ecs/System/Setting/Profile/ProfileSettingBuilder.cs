// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfileSettingBuilder.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.System.Setting.Profile;

namespace Alis.Builder.Core.Ecs.System.Setting.Profile
{
    /// <summary>
    ///     The audio setting builder class
    /// </summary>
    public class ProfileSettingBuilder :
        IBuild<ProfileSetting>,
        ILogLevel<ProfileSettingBuilder, LogLevel>
    {
        /// <summary>
        ///     The audio setting
        /// </summary>
        private readonly ProfileSetting profileSetting = new ProfileSetting();

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The audio setting</returns>
        public ProfileSetting Build() => profileSetting;

        /// <summary>
        ///     Logs the level using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The profile setting builder</returns>
        public ProfileSettingBuilder LogLevel(LogLevel value)
        {
            profileSetting.LogLevel = value;
            Logger.LogLevel = value;
            return this;
        }

        /// <summary>
        ///     Logs the detail using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The profile setting builder</returns>
        public ProfileSettingBuilder LogDetail(DetailLevel value)
        {
            profileSetting.DetailLevel = value;
            Logger.DetailLevel = value;
            return this;
        }
    }
}