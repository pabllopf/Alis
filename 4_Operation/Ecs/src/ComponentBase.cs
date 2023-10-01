// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentBase.cs
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

using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Logging;

namespace Alis.Core.Ecs
{
    /// <summary>Define a general component.</summary>
    public abstract class ComponentBase
    {
        /// <summary>
        ///     Game Object.
        /// </summary>
        public GameObjectBase GameObject { get; set; }

        /// <summary>
        ///     Gets or sets the value of the is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets the value of the tag
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        ///     Gets or sets the value of the tag
        /// </summary>
        public TransformBase Transform { get; set; }

        /// <summary>
        ///     Gets or sets the value of the destroyed
        /// </summary>
        public bool Destroyed { get; set; }

        /// <summary>
        ///     Attaches the game object using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public void AttachGameObject(GameObjectBase gameObject)
        {
            GameObject = gameObject;
            Tag = GameObject.Tag;
            Transform = GameObject.Transform;
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
            Logger.Trace();
        }

        /// <summary>Disables this instance.</summary>
        public virtual void Disable()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public virtual void Draw()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public virtual void Init()
        {
            Logger.Trace();
        }

        /// <summary>Awakes this instance.</summary>
        public virtual void Awake()
        {
            Logger.Trace();
        }

        /// <summary>Starts this instance.</summary>
        public abstract void Start();

        /// <summary>Befores the update.</summary>
        public virtual void BeforeUpdate()
        {
            Logger.Trace();
        }

        /// <summary>Updates this instance.</summary>
        public abstract void Update();

        /// <summary>Afters the update.</summary>
        public virtual void AfterUpdate()
        {
            Logger.Trace();
        }

        /// <summary>Fixeds the update.</summary>
        public virtual void FixedUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public virtual void DispatchEvents()
        {
            Logger.Trace();
        }

        /// <summary>Stops this instance.</summary>
        public virtual void Stop()
        {
            Logger.Trace();
        }

        /// <summary>Resets this instance.</summary>
        public virtual void Reset()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public virtual void Destroy()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public virtual void OnPressKey(Key key)
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public virtual void OnPressDownKey(Key key)
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public virtual void OnReleaseKey(Key key)
        {
            Logger.Trace();
        }


        /// <summary>
        ///     Ons the press button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="device">The device</param>
        public virtual void OnPressButton(Button button, int device)
        {
            Logger.Trace();
        }


        /// <summary>
        ///     Ons the press down button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="device">The device</param>
        public virtual void OnPressDownButton(Button button, int device)
        {
            Logger.Trace();
        }


        /// <summary>
        ///     Ons the release button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="device">The device</param>
        public virtual void OnReleaseButton(Button button, int device)
        {
            Logger.Trace();
        }

        /// <summary>Exits this instance.</summary>
        public virtual void Exit()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Destroys the immediate
        /// </summary>
        public static void DestroyImmediate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Donts the destroy on load
        /// </summary>
        public static void DontDestroyOnLoad()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Finds the object of type
        /// </summary>
        public static void FindObjectOfType()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Finds the objects of type
        /// </summary>
        public static void FindObjectsOfType()
        {
            Logger.Trace();
        }
    }
}