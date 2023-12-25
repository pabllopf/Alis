// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ISceneManager.cs
// 
//  Author: Pablo Perdomo Falcón
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

using System.Collections.Generic;
using Alis.Core.Ecs.Entity.Scene;
using Alis.Core.Ecs.System.Property;

namespace Alis.Core.Ecs.System.Manager.Scene
{
    /// <summary>
    ///     The scene manager interface
    /// </summary>
    /// <seealso cref="IManager" />
    /// <seealso cref="ICrud{IScene}" />
    public interface ISceneManager : IManager, ICrud<IScene>
    {
        /// <summary>
        ///     Gets or sets the value of the current scene
        /// </summary>
        public IScene CurrentScene { get; set; }

        /// <summary>
        ///     Gets or sets the value of the scenes
        /// </summary>
        public List<IScene> Scenes { get; set; }

        /// <summary>
        ///     Loads the scene using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        public void LoadScene(IScene scene);

        /// <summary>
        ///     Reloads the scene using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        public void ReloadScene(IScene scene);
    }
}