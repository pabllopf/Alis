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
using Alis.Builder.Core.Ecs.System.Manager.Scene;
using Alis.Builder.Core.Ecs.System.Setting;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Setting;

namespace Alis.Builder.Core.Ecs.System
{
    /// <summary>
    ///     The video game builder class
    /// </summary>
    /// <seealso cref="IBuild{VideoGame}" />
    public class VideoGameBuilder :
        IBuild<VideoGame>,
        IWorld<VideoGameBuilder, Func<SceneManagerBuilder, SceneManager>>,
        ISettings<VideoGameBuilder, Func<SettingsBuilder, Settings>>
    {
        /// <summary>Gets or sets the video game.</summary>
        /// <value>The video game.</value>
        private readonly Context context = new Context(new Settings());
        
        /// <summary>Builds this instance.</summary>
        /// <returns></returns>
        public VideoGame Build() => new VideoGame(context);

        /// <summary>
        ///     Setting the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The video game builder</returns>
        public VideoGameBuilder Settings(Func<SettingsBuilder, Settings> value)
        {
            context.Settings = value.Invoke(new SettingsBuilder());
            return this;
        }

        /// <summary>
        ///     Worlds the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The video game builder</returns>
        public VideoGameBuilder World(Func<SceneManagerBuilder, SceneManager> value)
        {
            SceneManager sceneManager = value.Invoke(new SceneManagerBuilder(context));
            context.SceneManager.Scenes = sceneManager.Scenes;
            context.SceneManager.CurrentScene = sceneManager.CurrentScene;
            return this;
        }
    }
}