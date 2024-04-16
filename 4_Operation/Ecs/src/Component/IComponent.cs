// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IComponent.cs
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

using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Ecs.Entity.GameObject;
using Alis.Core.Ecs.System.Property;

namespace Alis.Core.Ecs.Component
{
    /// <summary>
    ///     The component interface
    /// </summary>
    public interface IComponent<T> : IEnabled, IIdentifier, IRuntime
    {
        /// <summary>
        ///     Gets or sets the value of the game object
        /// </summary>
        public T GameObject { get; set; }
        
        /// <summary>
        ///     Attaches the game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public void Attach(T gameObject);
        
        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public void OnPressDownKey(KeyCode key);
        
        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public void OnReleaseKey(KeyCode key);
        
        /// <summary>
        ///     Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public void OnPressKey(KeyCode key);
        
        /// <summary>
        ///     Ons the collision enter using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public void OnCollisionEnter(T gameObject);
        
        /// <summary>
        ///     Ons the collision exit using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public void OnCollisionExit(T gameObject);
    }
}