// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObject.cs
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

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.System;

namespace Alis.Core.Ecs.Entity
{
  
    /// <summary>
    /// The game object class
    /// </summary>
    /// <seealso cref="IGameObject{AComponent}"/>
    /// <seealso cref="ISerializable"/>
    public class GameObject : IGameObject<AComponent>
    {
        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        [JsonIgnore]
        public Context Context => VideoGame.GetContext();
        
        /// <summary>
        ///     Gets or sets the value of the is enable
        /// </summary>
        [JsonPropertyName("_IsEnable_")]
        public bool IsEnable { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        [JsonPropertyName("_Name_")]
        public string Name { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the id
        /// </summary>
        [JsonPropertyName("_Id_")]
        public string Id { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the tag
        /// </summary>
        [JsonPropertyName("_Tag_")]
        public string Tag { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the components
        /// </summary>
        [JsonPropertyName("_Components_")]
        public List<AComponent> Components { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the transform
        /// </summary>
        [JsonPropertyName("_Transform_")]
        public Transform Transform { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GameObject"/> class
        /// </summary>
        public GameObject()
        {
            IsEnable = true;
            Name = GetType().Name;
            Id = Guid.NewGuid().ToString();
            Tag = GetType().Name;
            Transform = new Transform(new Vector2(0, 0), new Rotation(0), new Vector2(1, 1));
            Components = new List<AComponent>();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GameObject"/> class
        /// </summary>
        /// <param name="isEnable">The is enable</param>
        /// <param name="name">The name</param>
        /// <param name="id">The id</param>
        /// <param name="tag">The tag</param>
        /// <param name="transform">The transform</param>
        [JsonConstructor]
        [ExcludeFromCodeCoverage]
        public GameObject(bool isEnable, string name, string id, string tag, Transform transform)
        {
            IsEnable = isEnable;
            Name = name;
            Id = id;
            Tag = tag;
            Transform = transform;
            Components = new List<AComponent>();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GameObject"/> class
        /// </summary>
        /// <param name="isEnable">The is enable</param>
        /// <param name="name">The name</param>
        /// <param name="id">The id</param>
        /// <param name="tag">The tag</param>
        /// <param name="transform">The transform</param>
        /// <param name="components">The components</param>
        [ExcludeFromCodeCoverage]
        public GameObject(bool isEnable, string name, string id, string tag, Transform transform, List<AComponent> components) : this()
        {
            IsEnable = isEnable;
            Name = name;
            Id = id;
            Tag = tag;
            Transform = transform;
            Components = components;
        }
        
        /// <summary>
        ///     Adds the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Add<T>(T component) where T : AComponent => Components.Add(component);
        
        /// <summary>
        ///     Removes the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Remove<T>(T component) where T : AComponent => Components.Remove(component);
        
        /// <summary>
        ///     Gets this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public T Get<T>() where T : AComponent => Components.Find(i => i is T) as T;
        
        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public bool Contains<T>() where T : AComponent => Components.Exists(i => i is T);
        
        /// <summary>
        ///     Clears this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        public void Clear<T>() where T : AComponent => Components.Clear();
        
        /// <summary>
        ///     Ons the enable
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnEnable()
        {
            IsEnable = true;
            Components.ForEach(i => i.OnEnable());
        }
        
        /// <summary>
        ///     Ons the init
        /// </summary>
        public void OnInit()
        {
            Components.ForEach(i => i.Attach(this));
            Components.ForEach(i => i.OnInit());
        }
        
        /// <summary>
        ///     Ons the awake
        /// </summary>
        public void OnAwake() => Components.ForEach(i => i.OnAwake());
        
        /// <summary>
        ///     Ons the start
        /// </summary>
        public void OnStart() => Components.ForEach(i => i.OnStart());
        
        /// <summary>
        ///     Ons the before update
        /// </summary>
        public void OnBeforeUpdate() => Components.ForEach(i => i.OnBeforeUpdate());
        
        /// <summary>
        ///     Ons the update
        /// </summary>
        public void OnUpdate() => Components.ForEach(i => i.OnUpdate());
        
        /// <summary>
        ///     Ons the after update
        /// </summary>
        public void OnAfterUpdate() => Components.ForEach(i => i.OnAfterUpdate());
        
        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public void OnBeforeFixedUpdate() => Components.ForEach(i => i.OnBeforeFixedUpdate());
        
        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public void OnFixedUpdate() => Components.ForEach(i => i.OnFixedUpdate());
        
        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public void OnAfterFixedUpdate() => Components.ForEach(i => i.OnAfterFixedUpdate());
        
        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public void OnDispatchEvents() => Components.ForEach(i => i.OnDispatchEvents());
        
        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public void OnCalculate() => Components.ForEach(i => i.OnCalculate());
        
        /// <summary>
        ///     Ons the draw
        /// </summary>
        public void OnDraw() => Components.ForEach(i => i.OnDraw());
        
        /// <summary>
        ///     Ons the gui
        /// </summary>
        public void OnGui() => Components.ForEach(i => i.OnGui());
        
        /// <summary>
        ///     Ons the disable
        /// </summary>
        public void OnDisable()
        {
            IsEnable = false;
            Components.ForEach(i => i.OnDisable());
        }
        
        /// <summary>
        ///     Ons the reset
        /// </summary>
        public void OnReset() => Components.ForEach(i => i.OnReset());
        
        /// <summary>
        ///     Ons the stop
        /// </summary>
        public void OnStop() => Components.ForEach(i => i.OnStop());
        
        /// <summary>
        ///     Ons the exit
        /// </summary>
        public void OnExit() => Components.ForEach(i => i.OnExit());
        
        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public void OnDestroy() => Components.ForEach(i => i.OnDestroy());
    }
}