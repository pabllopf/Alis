// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectSample.cs
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

using Alis.Core.Ecs.Entity.GameObject;
using NotImplementedException = System.NotImplementedException;

namespace Alis.Core.Test.Ecs.Entity.GameObject
{
    /// <summary>
    ///     The game object sample class
    /// </summary>
    /// <seealso cref="AGameObject" />
    public class GameObjectSample : Core.Ecs.Entity.GameObject.AGameObject
    {
        
        /// <summary>
        /// Adds the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Add<T>(T component)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Removes the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Remove<T>(T component)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Gets this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public override T Get<T>() => throw new NotImplementedException();
        
        /// <summary>
        /// Describes whether this instance contains
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public override bool Contains<T>() => throw new NotImplementedException();
        
        /// <summary>
        /// Clears this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <exception cref="NotImplementedException"></exception>
        public override void Clear<T>()
        {
            throw new NotImplementedException();
        }
    }
}