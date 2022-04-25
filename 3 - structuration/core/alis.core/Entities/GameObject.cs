// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GameObject.cs
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
using System.Text.Json.Serialization;
using Alis.Core.Components;
using Alis.Core.Input;
using Alis.Exceptions;

namespace Alis.Core.Entities
{
    /// <summary>Represent a object of the game.</summary>
    public class GameObject
    {
        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        public GameObject()
        {
            Name = "Default";
            Tag = "Default";
            IsActive = true;
            IsStatic = false;
            Transform = new Transform();
            Components = new List<Component>();

            InputManager.OnPressKey += OnPressKey;
            InputManager.OnReleaseKey += OnReleaseKey;
            InputManager.OnPressDownKey += OnPressDownKey;
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        public GameObject(string name)
        {
            Name = name;
            Tag = "Default";
            IsActive = true;
            IsStatic = false;
            Transform = new Transform();
            Components = new List<Component>();

            InputManager.OnPressKey += OnPressKey;
            InputManager.OnReleaseKey += OnReleaseKey;
            InputManager.OnPressDownKey += OnPressDownKey;
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="isStatic">The is static.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        [JsonConstructor]
        public GameObject(string name, string tag, bool isActive, bool isStatic, Transform transform,
            List<Component> components)
        {
            Name = name;
            Tag = tag;
            IsActive = isActive;
            IsStatic = isStatic;
            Transform = transform;
            Components = new List<Component>(components);

            InputManager.OnPressKey += OnPressKey;
            InputManager.OnReleaseKey += OnReleaseKey;
            InputManager.OnPressDownKey += OnPressDownKey;
        }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [JsonPropertyName("_Name")]
        public string Name { get; set; }

        /// <summary>Gets or sets the tag.</summary>
        /// <value>The tag.</value>
        [JsonPropertyName("_Tag")]
        public string Tag { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("_IsActive")]
        public bool IsActive { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is static.</summary>
        /// <value>
        ///     <c>true</c> if this instance is static; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("_IsStatic")]
        public bool IsStatic { get; set; }

        /// <summary>Gets or sets the transform.</summary>
        /// <value>The transform.</value>
        [JsonPropertyName("_Transform")]
        public Transform Transform { get; set; }

        /// <summary>Gets the components.</summary>
        /// <value>The components.</value>
        [JsonPropertyName("_Components")]
        public List<Component> Components { get; internal set; }


        /// <summary>
        ///     Adds the component
        /// </summary>
        /// <param name="component">The component</param>
        public void Add(Component component)
        {
            component.AttachTo(this);
            Components.Add(component);
        }

        /// <summary>
        ///     Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ComponentDontExits"></exception>
        public T Get<T>() where T : Component
        {
            Component? component = Components.Find(component => component.GetType() == typeof(T));
            return (T) (component ?? throw new NullReferenceException());
        }

        /// <summary>
        ///     Gets the name
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="name">The name</param>
        /// <exception cref="NullReferenceException"></exception>
        /// <returns>The</returns>
        public T Get<T>(string name) where T : Component
        {
            return (T) (Components.Find(component => component.GetType().Name == name) ??
                        throw new NullReferenceException());
        }

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public void Init()
        {
            Components.ForEach(component => component.Init());
        }

        /// <summary>
        ///     Befores the awake
        /// </summary>
        public void BeforeAwake()
        {
            Components.ForEach(component => component.BeforeAwake());
        }

        /// <summary>Awakes this instance.</summary>
        public void Awake()
        {
            Components.ForEach(component => component.Awake());
        }

        /// <summary>
        ///     Afters the awake
        /// </summary>
        public void AfterAwake()
        {
            Components.ForEach(component => component.AfterAwake());
        }

        /// <summary>
        ///     Befores the start
        /// </summary>
        public void BeforeStart()
        {
            Components.ForEach(component => component.BeforeStart());
        }

        /// <summary>Starts this instance.</summary>
        public void Start()
        {
            Components.ForEach(component => component.Start());
        }

        /// <summary>
        ///     Afters the start
        /// </summary>
        public void AfterStart()
        {
            Components.ForEach(component => component.AfterStart());
        }

        /// <summary>Befores the update.</summary>
        public void BeforeUpdate()
        {
            Components.ForEach(component =>
            {
                if (component.IsActive)
                {
                    component.BeforeUpdate();
                }
            });
        }

        /// <summary>Updates this instance.</summary>
        public void Update()
        {
            Components.ForEach(component =>
            {
                if (component.IsActive)
                {
                    component.Update();
                }
            });
        }

        /// <summary>Afters the update.</summary>
        public void AfterUpdate()
        {
            Components.ForEach(component =>
            {
                if (component.IsActive)
                {
                    component.AfterUpdate();
                }
            });
        }

        /// <summary>Afters the update.</summary>
        public void FixedUpdate()
        {
            Components.ForEach(component =>
            {
                if (component.IsActive)
                {
                    component.FixedUpdate();
                }
            });
        }

        /// <summary>
        ///     Dispatches the events.
        /// </summary>
        /// <returns></returns>
        public void DispatchEvents()
        {
            Components.ForEach(component =>
            {
                if (component.IsActive)
                {
                    component.DispatchEvents();
                }
            });
        }

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public void Draw()
        {
            Components.ForEach(component =>
            {
                if (component.IsActive)
                {
                    component.Draw();
                }
            });
        }

        /// <summary>Stops this instance.</summary>
        public void Stop()
        {
            Components.ForEach(component =>
            {
                if (component.IsActive)
                {
                    component.Stop();
                }
            });
        }

        /// <summary>
        ///     Destroys this instance.
        /// </summary>
        /// <returns></returns>
        public void Destroy()
        {
            Components.ForEach(component =>
            {
                if (component.IsActive)
                {
                    component.Destroy();
                }
            });
        }

        /// <summary>Resets this instance.</summary>
        public void Reset()
        {
            Components.ForEach(component => component.Reset());
        }

        /// <summary>Exits this instance.</summary>
        public void Exit()
        {
            Components.ForEach(component => component.Exit());
        }

        /// <summary>
        ///     Removes the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <returns></returns>
        /// <exception cref="ComponentDontExits"></exception>
        public void Remove(Component component)
        {
            Components.Remove(component);
        }

        /// <summary>
        ///     Determines whether this instance contains the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///     <c>true</c> if [contains]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains<T>() where T : Component
        {
            return Components.Find(component => component.GetType() == typeof(T)) is not null;
        }

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The bool</returns>
        public bool Contains(string name)
        {
            return Components.Find(component => component.GetType().Name == name) is not null;
        }

        /// <summary>
        ///     Determines whether this instance contains the object.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <returns>
        ///     <c>true</c> if [contains] [the specified component]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(Component component)
        {
            return Components.Contains(component);
        }

        /// <summary>
        ///     Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        private void OnPressKey(string key)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Components[i].OnPressKey(key);
            }
        }

        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        private void OnPressDownKey(string key)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Components[i].OnPressDownKey(key);
            }
        }

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        private void OnReleaseKey(string key)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Components[i].OnReleaseKey(key);
            }
        }

        /// <summary>
        ///     Ons the press down key using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void OnPressDownKey(object? sender, string e)
        {
            OnPressDownKey(e);
        }

        /// <summary>
        ///     Ons the release key using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void OnReleaseKey(object? sender, string e)
        {
            OnReleaseKey(e);
        }

        /// <summary>
        ///     Ons the press key using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void OnPressKey(object? sender, string e)
        {
            OnPressKey(e);
        }
    }
}