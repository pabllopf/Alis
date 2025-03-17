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
using Alis.Builder.Core.EcsOld.System.Manager.Scene;
using Alis.Builder.Core.EcsOld.System.Setting;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.EcsOld.System;
using Alis.Core.EcsOld.System.Manager.Scene;
using Alis.Core.EcsOld.System.Scope;

namespace Alis.Builder.Core.EcsOld.System
{
    /// <summary>
    ///     The video game builder class
    /// </summary>
    /// <seealso cref="IBuild{VideoGame}" />
    public class VideoGameBuilder :
        IBuild<VideoGame>,
        IWorld<VideoGameBuilder, Func<SceneManagerBuilder, SceneManager>>,
        ISettings<VideoGameBuilder, Func<SettingsBuilder, Alis.Core.EcsOld.System.Configuration.Setting>>
    {
        /// <summary>Gets or sets the video game.</summary>
        /// <value>The video game.</value>
        public readonly Context Context = new Context(new Alis.Core.EcsOld.System.Configuration.Setting());

        /// <summary>Builds this instance.</summary>
        /// <returns></returns>
        public VideoGame Build() => new VideoGame(new ContextHandler(Context));

        /// <summary>
        ///     Setting the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The video game builder</returns>
        public VideoGameBuilder Settings(Func<SettingsBuilder, Alis.Core.EcsOld.System.Configuration.Setting> value)
        {
            Context.Setting = value.Invoke(new SettingsBuilder());
            return this;
        }

        /// <summary>
        ///     Worlds the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The video game builder</returns>
        public VideoGameBuilder World(Func<SceneManagerBuilder, SceneManager> value)
        {
            SceneManager sceneManager = value.Invoke(new SceneManagerBuilder(Context));
            Context.SceneManager.Scenes = sceneManager.Scenes;
            Context.SceneManager.CurrentScene = sceneManager.CurrentScene;
            return this;
        }
    }
}