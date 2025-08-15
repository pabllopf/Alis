// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneManagerBuilder.cs
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
using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Builder.Core.Ecs.System.Manager.Scenes
{
    /// <summary>
    ///     The scene manager builder class
    /// </summary>
    public class SceneManagerBuilder :
        IBuild<SceneManager>
    {
        /// <summary>
        ///     Gets the value of the scene manager
        /// </summary>
        private readonly SceneManager sceneManager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneManagerBuilder" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public SceneManagerBuilder(Context context) => sceneManager = new SceneManager(context);
        
        /// <summary>
        /// Adds the config
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="config">The config</param>
        /// <returns>The scene manager builder</returns>
        public SceneManagerBuilder Add<T>(Action<SceneBuilder> config) where T : Scene
        { 
            SceneBuilder sceneBuilder = new SceneBuilder(sceneManager.Context);
            config(sceneBuilder);
            Scene scene = sceneBuilder.Build();
            sceneManager.World = scene;
            return this;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The scene manager</returns>
        public SceneManager Build() => sceneManager;
    }
}