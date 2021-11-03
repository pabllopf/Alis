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
using System.Text.Json.Serialization;
using Alis.Core.Builders;
using Alis.Core.Exceptions;
using Alis.FluentApi;
using Alis.FluentApi.Validations;

namespace Alis.Core.Entities
{
    /// <summary>Represent a object of the videogame.</summary>
    public class GameObject : IBuilder<GameObjectBuilder>
    {
        #region Add<Component>()

        /// <summary>
        /// 
        /// </summary>
        /// <param name="component"></param>
        /// <exception cref="ComponentTypeAlredyExist"></exception>
        /// <exception cref="ComponentInstancieIsTheSame"></exception>
        /// <exception cref="GameObjectIsFull"></exception>
        public void Add(NotNull<Component> component)
        {
            if (!Game.Setting.GameObject.HasDuplicateComponents && Contains(component.Value.GetType()))
            {
                throw new ComponentTypeAlredyExist();
            }

            if (Contains(component.Value))
            {
                throw new ComponentInstancieIsTheSame();
            }

            Span<Component> temp = Components.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (!temp[i].Destroyed)
                {
                    continue;
                }

                component.Value.AttachTo(this);
                temp[i] = component.Value;
                Count++;
                return;
            }

            throw new GameObjectIsFull();
        }

        #endregion

        #region Get<Component>()

        /// <summary>
        ///     Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ComponentDontExits"></exception>
        public Component Get<T>() where T : Component
        {
            Span<Component> temp = Components.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].GetType() == typeof(T) && !temp[i].Destroyed)
                {
                    return temp[i];
                }
            }

            throw new ComponentDontExits();
        }

        #endregion

        #region HasSpace()

        /// <summary>
        ///     Describes whether this instance has space
        /// </summary>
        /// <returns>The bool</returns>
        public bool HasSpace() => Count >= Size;

        #endregion

        #region Awake()

        /// <summary>Awakes this instance.</summary>
        public void Awake()
        {
            Span<Component> temp = Components.AsSpan();
            for (int index = 0; index < temp.Length; index++)
            {
                temp[index].Awake();
            }
        }

        #endregion

        #region Start()

        /// <summary>Starts this instance.</summary>
        public void Start()
        {
            Span<Component> temp = Components.AsSpan();
            for (int index = 0; index < temp.Length; index++)
            {
                temp[index].Start();
            }
        }

        #endregion

        #region BeforeUpdate()

        /// <summary>Befores the update.</summary>
        public void BeforeUpdate()
        {
            Span<Component> temp = Components.AsSpan();
            for (int index = 0; index < temp.Length; index++)
            {
                temp[index].BeforeUpdate();
            }
        }

        #endregion

        #region Update()

        /// <summary>Updates this instance.</summary>
        public void Update()
        {
            Span<Component> temp = Components.AsSpan();
            for (int index = 0; index < temp.Length; index++)
            {
                temp[index].Update();
            }
        }

        #endregion

        #region AfterUpdate()

        /// <summary>Afters the update.</summary>
        public void AfterUpdate()
        {
            Span<Component> temp = Components.AsSpan();
            for (int index = 0; index < temp.Length; index++)
            {
                temp[index].AfterUpdate();
            }
        }

        #endregion

        #region FixedUpdate()

        /// <summary>Afters the update.</summary>
        public void FixedUpdate()
        {
            Span<Component> temp = Components.AsSpan();
            for (int index = 0; index < temp.Length; index++)
            {
                temp[index].FixedUpdate();
            }
        }

        #endregion

        #region DispatchEvents()

        /// <summary>
        ///     Dispatches the events.
        /// </summary>
        /// <returns></returns>
        public void DispatchEvents()
        {
            Span<Component> temp = Components.AsSpan();
            for (int index = 0; index < temp.Length; index++)
            {
                temp[index].DispatchEvents();
            }
        }

        #endregion

        #region Stop()

        /// <summary>Stops this instance.</summary>
        public void Stop()
        {
            Span<Component> temp = Components.AsSpan();
            for (int index = 0; index < temp.Length; index++)
            {
                temp[index].Stop();
            }
        }

        #endregion

        #region Destroy()

        /// <summary>
        ///     Destroys this instance.
        /// </summary>
        /// <returns></returns>
        public void Destroy()
        {
            IsActive = false;
            Span<Component> temp = Components.AsSpan();
            for (int index = 0; index < temp.Length; index++)
            {
                temp[index].Destroy();
            }
        }

        #endregion

        #region Reset()

        /// <summary>Resets this instance.</summary>
        public void Reset()
        {
            Span<Component> temp = Components.AsSpan();
            for (int index = 0; index < temp.Length; index++)
            {
                temp[index].Reset();
            }
        }

        #endregion

        #region Exit()

        /// <summary>Exits this instance.</summary>
        public void Exit()
        {
            Span<Component> temp = Components.AsSpan();
            for (int index = 0; index < temp.Length; index++)
            {
                temp[index].Exit();
            }
        }

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        public GameObject()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        public GameObject(NotNull<string> name) => Name = name.Value;

        /// <summary>Initializes a new instance of the <see cref="GameObject" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="isStatic">The is static.</param>
        /// <param name="transform">The transform.</param>
        /// <param name="components">The components.</param>
        [JsonConstructor]
        public GameObject(NotNull<string> name, NotNull<string> tag, NotNull<bool> isActive, NotNull<bool> isStatic,
            NotNull<Transform> transform, NotNull<Component[]> components)
        {
            Name = name.Value;
            Tag = tag.Value;
            IsActive = isActive.Value;
            IsStatic = isStatic.Value;
            Transform = transform.Value;
            Components = new Component[Game.Setting.GameObject.MaxComponents];

            if (components.Value.Length > Game.Setting.GameObject.MaxComponents)
            {
                throw new LimitOfComponents();
            }

            for (int i = 0; i < components.Value.Length; i++)
            {
                Add(components.Value[i]);
                Count++;
            }
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [JsonPropertyName("_Name")]
        public string Name { get; set; } = "Default";

        /// <summary>Gets or sets the tag.</summary>
        /// <value>The tag.</value>
        [JsonPropertyName("_Tag")]
        public string Tag { get; set; } = "Default";

        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("_IsActive")]
        public bool IsActive { get; set; } = true;

        /// <summary>Gets or sets a value indicating whether this instance is static.</summary>
        /// <value>
        ///     <c>true</c> if this instance is static; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("_IsStatic")]
        public bool IsStatic { get; set; } = true;

        /// <summary>Gets or sets the transform.</summary>
        /// <value>The transform.</value>
        [JsonPropertyName("_Transform")]
        public Transform Transform { get; set; } = new Transform();

        /// <summary>Gets the components.</summary>
        /// <value>The components.</value>
        [JsonPropertyName("_Components")]
        public Component[] Components { get; internal set; } = new Component[Game.Setting.GameObject.MaxComponents];

        /// <summary>
        ///     Gets the count.
        /// </summary>
        /// <value>
        ///     The count.
        /// </value>
        [JsonPropertyName("_Count")]
        public int Count { get; private set; }

        /// <summary>
        ///     Gets the size.
        /// </summary>
        /// <value>
        ///     The size.
        /// </value>
        [JsonPropertyName("_Size")]
        public int Size { get; } = Game.Setting.GameObject.MaxComponents;

        #endregion

        #region Remove<Component>()

        /// <summary>
        ///     Removes this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ComponentDontExits"></exception>
        public void Remove<T>() where T : Component
        {
            Span<Component> temp = Components.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].GetType() == typeof(T) && !temp[i].Destroyed)
                {
                    temp[i].OnDestroy();
                    Count--;
                    return;
                }
            }

            throw new ComponentDontExits();
        }

        /// <summary>
        ///     Removes the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <returns></returns>
        /// <exception cref="ComponentDontExits"></exception>
        public void Remove(Component component)
        {
            Span<Component> temp = Components.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Equals(component) && !temp[i].Destroyed)
                {
                    temp[i].OnDestroy();
                    Count--;
                    return;
                }
            }

            throw new ComponentDontExits();
        }

        #endregion

        #region Contains<Component>()

        /// <summary>
        ///     Determines whether this instance contains the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///     <c>true</c> if [contains]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains<T>() where T : Component
        {
            Span<Component> temp = Components.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].GetType() == typeof(T) && !temp[i].Destroyed)
                {
                    return true;
                }
            }

            return false;
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
            Span<Component> temp = Components.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Equals(component) && !temp[i].Destroyed)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The bool</returns>
        public bool Contains(Type type)
        {
            Span<Component> temp = Components.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].GetType() == type && !temp[i].Destroyed)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}