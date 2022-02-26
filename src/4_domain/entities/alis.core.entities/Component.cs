// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Component.cs
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

namespace Alis.Core.Entities
{
    /// <summary>Define a general component.</summary>
    public abstract class Component
    {
        /// <summary>
        ///     Gets or sets the value of the is active
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        ///     Gets or sets the value of the destroyed
        /// </summary>
        internal bool Destroyed { get; set; }

        /// <summary>
        ///     Gets or sets the value of the game object
        /// </summary>
        public GameObject GameObject { get; internal set; } = new GameObject();

        /// <summary>
        ///     Attaches the to using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public void AttachTo(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        internal void OnDestroy()
        {
            Destroyed = true;
            IsActive = false;
        }

        /// <summary>Enables this instance.</summary>
        public virtual void Enable()
        {
        }

        /// <summary>Disables this instance.</summary>
        public virtual void Disable()
        {
        }

        /// <summary>Awakes this instance.</summary>
        public virtual void Awake()
        {
        }

        /// <summary>Starts this instance.</summary>
        public abstract void Start();

        /// <summary>Befores the update.</summary>
        public virtual void BeforeUpdate()
        {
        }

        /// <summary>Updates this instance.</summary>
        public abstract void Update();

        /// <summary>Afters the update.</summary>
        public virtual void AfterUpdate()
        {
        }

        /// <summary>Fixeds the update.</summary>
        public virtual void FixedUpdate()
        {
        }

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public virtual void DispatchEvents()
        {
        }

        /// <summary>Stops this instance.</summary>
        public virtual void Stop()
        {
        }

        /// <summary>Resets this instance.</summary>
        public virtual void Reset()
        {
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public virtual void Destroy()
        {
        }

        /// <summary>Exits this instance.</summary>
        public virtual void Exit()
        {
        }
    }
}