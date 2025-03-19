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
using Alis.Builder.Core.EcsOld.Entity.Scene;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.EcsOld.System.Manager.Scene;
using Alis.Core.EcsOld.System.Scope;

namespace Alis.Builder.Core.EcsOld.System.Manager.Scene
{
    /// <summary>
    ///     The scene manager builder class
    /// </summary>
    public class SceneManagerBuilder :
        IBuild<SceneManager>,
        IAdd<SceneManagerBuilder, Func<SceneBuilder, Alis.Core.EcsOld.Entity.Scene>>
    {
        /// <summary>
        ///     The context
        /// </summary>
        private readonly Context context;

        /// <summary>
        ///     Gets the value of the scene manager
        /// </summary>
        private readonly SceneManager sceneManager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneManagerBuilder" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public SceneManagerBuilder(Context context)
        {
            this.context = context;
            sceneManager = new SceneManager(context);
        }

        /// <summary>
        ///     Adds the value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The scene builder</returns>
        public SceneManagerBuilder Add<T>(Func<SceneBuilder, Alis.Core.EcsOld.Entity.Scene> value)
        {
            sceneManager.Add(value.Invoke(new SceneBuilder(context)));
            sceneManager.CurrentScene = sceneManager.Scenes[0];
            return this;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The scene manager</returns>
        public SceneManager Build() => sceneManager;
    }
}