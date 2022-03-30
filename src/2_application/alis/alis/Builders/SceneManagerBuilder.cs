// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SceneManagerBuilder.cs
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
using System.Collections.Generic;
using Alis.Core.Builders;
using Alis.Core.Entities;
using Alis.Core.Managers;
using Alis.Core.Systems;
using Alis.FluentApi;
using Alis.FluentApi.Words;

namespace Alis.Builders
{
    /// <summary>
    ///     The scene manager builder class
    /// </summary>
    public class SceneManagerBuilder :
        IBuild<SceneSystem>,
        IAdd<SceneManagerBuilder, Scene, Func<SceneBuilder, Scene>>
    {
        /// <summary>
        ///     Gets or sets the value of the scene manager
        /// </summary>
        private SceneSystem SceneManager { get; } = new SceneSystem(new List<Scene>(){new Scene("Default", new List<GameObject>())});

        /// <summary>
        ///     Adds the value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The scene manager builder</returns>
        public SceneManagerBuilder Add<T>(Func<SceneBuilder, Scene> value) where T : Scene
        {
            SceneManager.Add(value.Invoke(new SceneBuilder()));
            return this;
        }


        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The scene manager</returns>
        public SceneSystem Build() => SceneManager;
    }
}