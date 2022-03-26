// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   VideoGameBuilder.cs
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
using Alis.Core.Managers;
using Alis.FluentApi;
using Alis.FluentApi.Words;

namespace Alis.Builders
{
    /// <summary>Game builder.</summary>
    public class VideoGameBuilder :
        IBuild<VideoGame>,
        ISettings<VideoGameBuilder, Func<SettingBuilder, Setting>>
    {
        /// <summary>Gets or sets the video game.</summary>
        /// <value>The video game.</value>
        private VideoGame VideoGame { get; } = new VideoGame();

        /// <summary>Builds this instance.</summary>
        /// <returns></returns>
        public VideoGame Build() => VideoGame;

        /// <summary>Configurations the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     <br />
        /// </returns>
        public VideoGameBuilder Settings(Func<SettingBuilder, Setting> value)
        {
            Game.Setting = value.Invoke(new SettingBuilder());
            return this;
        }

        /// <summary>
        ///     Managers the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The video game builder</returns>
        public VideoGameBuilder Manager(Func<SceneManagerBuilder, SceneManager> value)
        {
            VideoGame.SceneSystem = value.Invoke(new SceneManagerBuilder());
            return this;
        }

        /// <summary>Run the game immediately</summary>
        public void Run() => VideoGame.Run();
    }
}