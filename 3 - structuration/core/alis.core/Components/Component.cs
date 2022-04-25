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

using Alis.Core.Entities;

namespace Alis.Core.Components
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

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public virtual void Init()
        {
        }


        /// <summary>
        ///     Befores the awake
        /// </summary>
        public virtual void BeforeAwake()
        {
        }


        /// <summary>Awakes this instance.</summary>
        public virtual void Awake()
        {
        }

        /// <summary>
        ///     Afters the awake
        /// </summary>
        public virtual void AfterAwake()
        {
        }


        /// <summary>
        ///     Befores the start
        /// </summary>
        public virtual void BeforeStart()
        {
        }

        /// <summary>Starts this instance.</summary>
        public abstract void Start();

        /// <summary>
        ///     Afters the start
        /// </summary>
        public virtual void AfterStart()
        {
        }


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

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public virtual void Draw()
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

        /// <summary>
        ///     Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public virtual void OnPressKey(string key)
        {
        }

        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public virtual void OnPressDownKey(string key)
        {
        }

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public virtual void OnReleaseKey(string key)
        {
        }

        /// <summary>Exits this instance.</summary>
        public virtual void Exit()
        {
        }
    }
}