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

using Alis.Core.Builders;
using Alis.Core.Exceptions;
using Alis.FluentApi;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Alis.Core.Entities
{
    /// <summary>Represent a object of the game.</summary>
    public class GameObject : IBuilder<GameObjectBuilder>
    {
        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        public GameObject()
        {
            Name = "Default";
            Tag = "Default";
            IsActive = true;
            IsStatic = false;
            Transform = new Transform();
            Components = new List<Component>(Game.Setting.GameObject.MaxComponents);
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
            Components = new List<Component>(Game.Setting.GameObject.MaxComponents);
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
        /// </summary>
        /// <param name="component"></param>
        /// <exception cref="ComponentTypeAlredyExist"></exception>
        /// <exception cref="ComponentInstancieIsTheSame"></exception>
        /// <exception cref="GameObjectIsFull"></exception>
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
        public Component Get<T>() where T : Component
        {
            return Components.Find(component => component.GetType() == typeof(T)) ?? throw new NullReferenceException();
        }

        /// <summary>Awakes this instance.</summary>
        public void Awake()
        {
            Components.ForEach(component => component.Awake());
        }

        /// <summary>Starts this instance.</summary>
        public void Start()
        {
            Components.ForEach(component => component.Start());
        }

        /// <summary>Befores the update.</summary>
        public void BeforeUpdate()
        {
            Components.ForEach(component => component.BeforeUpdate());
        }

        /// <summary>Updates this instance.</summary>
        public void Update()
        {
            Components.ForEach(component => component.Update());
        }

        /// <summary>Afters the update.</summary>
        public void AfterUpdate()
        {
            Components.ForEach(component => component.AfterUpdate());
        }

        /// <summary>Afters the update.</summary>
        public void FixedUpdate()
        {
            Components.ForEach(component => component.FixedUpdate());
        }

        /// <summary>
        ///     Dispatches the events.
        /// </summary>
        /// <returns></returns>
        public void DispatchEvents()
        {
            Components.ForEach(component => component.DispatchEvents());
        }

        /// <summary>Stops this instance.</summary>
        public void Stop()
        {
            Components.ForEach(component => component.Stop());
        }

        /// <summary>
        ///     Destroys this instance.
        /// </summary>
        /// <returns></returns>
        public void Destroy()
        {
            Components.ForEach(component => component.Destroy());
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
        ///     Determines whether this instance contains the object.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <returns>
        ///     <c>true</c> if [contains] [the specified component]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(Component component) => Components.Contains(component);

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The bool</returns>
        public bool Contains(Type type)
        {
            return Components.Find(component => component.GetType() == type) is not null;
        }
    }
}