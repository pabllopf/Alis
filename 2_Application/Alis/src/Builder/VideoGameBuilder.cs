// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoGameBuilder.cs
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
using Alis.Builder.Core.Manager;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Manager.Scene;
using Alis.Core.Manager.Setting;

namespace Alis.Builder
{
    /// <summary>
    ///     The video game builder class
    /// </summary>
    /// <seealso cref="IBuild{VideoGame}" />
    public class VideoGameBuilder :
        IBuild<VideoGame>,
        IManager<VideoGameBuilder, SceneManager, Func<SceneManagerBuilder, SceneManager>>,
        ISettings<VideoGameBuilder, Func<SettingManagerBuilder, SettingManager>>
    {
        /// <summary>Gets or sets the video game.</summary>
        /// <value>The video game.</value>
        private VideoGame VideoGame { get; } = new VideoGame();

        /// <summary>Builds this instance.</summary>
        /// <returns></returns>
        public VideoGame Build() => VideoGame;

        /// <summary>
        ///     Managers the value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The video game builder</returns>
        public VideoGameBuilder Manager<T>(Func<SceneManagerBuilder, SceneManager> value) where T : SceneManager
        {
            VideoGame.SetManager(value.Invoke(new SceneManagerBuilder()));
            return this;
        }

        /// <summary>
        ///     Setting the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The video game builder</returns>
        public VideoGameBuilder Settings(Func<SettingManagerBuilder, SettingManager> value)
        {
            VideoGame.Setting = value.Invoke(new SettingManagerBuilder());
            return this;
        }

        /// <summary>Runs this instance.</summary>
        public void Run() => VideoGame.Run();
    }
}