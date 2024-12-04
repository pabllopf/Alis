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
using System.Runtime.Serialization;
using Alis.Builder.Core.Ecs.Entity.GameObject;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.System.Scope;

namespace Alis.Core.Ecs.Entity
{
    /// <summary>
    ///     The game object class
    /// </summary>
    /// <seealso cref="IGameObject{AComponent}" />
    /// <seealso cref="ISerializable" />
    public class GameObject : IGameObject<AComponent>, IHasBuilder<GameObjectBuilder>
    {
        /// <summary>
        ///     The context
        /// </summary>
        private Context _context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObject" /> class
        /// </summary>
        public GameObject()
        {
            IsEnable = true;
            Name = GetType().Name;
            Id = Guid.NewGuid().ToString();
            Tag = GetType().Name;
            Transform = new Transform(new Vector2(0, 0), 0, new Vector2(1, 1));
            Components = new List<AComponent>();
            PendingComponentsToAdd = new Stack<AComponent>();
            PendingComponentsToRemove = new Stack<AComponent>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObject" /> class
        /// </summary>
        /// <param name="isEnable">The is enable</param>
        /// <param name="name">The name</param>
        /// <param name="id">The id</param>
        /// <param name="tag">The tag</param>
        /// <param name="transform">The transform</param>
        [JsonConstructor]
        public GameObject(bool isEnable, string name, string id, string tag, Transform transform)
        {
            IsEnable = isEnable;
            Name = name;
            Id = id;
            Tag = tag;
            Transform = transform;
            Components = new List<AComponent>();
            PendingComponentsToAdd = new Stack<AComponent>();
            PendingComponentsToRemove = new Stack<AComponent>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObject" /> class
        /// </summary>
        /// <param name="isEnable">The is enable</param>
        /// <param name="name">The name</param>
        /// <param name="id">The id</param>
        /// <param name="tag">The tag</param>
        /// <param name="transform">The transform</param>
        /// <param name="components">The components</param>
        public GameObject(bool isEnable, string name, string id, string tag, Transform transform, List<AComponent> components) : this()
        {
            IsEnable = isEnable;
            Name = name;
            Id = id;
            Tag = tag;
            Transform = transform;
            Components = components;
            components.ForEach(i => i.Attach(this));
            PendingComponentsToAdd = new Stack<AComponent>();
            PendingComponentsToRemove = new Stack<AComponent>();
        }

        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        [JsonIgnore]
        public Context Context => _context;

        /// <summary>
        ///     Gets or sets the value of the transform
        /// </summary>
        [JsonPropertyName("_Transform_")]
        public Transform Transform { get; set; }

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
        
        [JsonIgnore]
        public Stack<AComponent> PendingComponentsToAdd { get; }
        
        [JsonIgnore]
        public Stack<AComponent> PendingComponentsToRemove { get; }
        
        /// <summary>
        ///     Gets or sets the value of the is static
        /// </summary>
        [JsonPropertyName("_IsStatic_")]
        public bool IsStatic { get; set; } = false;

        /// <summary>
        ///     Adds the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The component</param>
        public void Add<T>(T value) where T : AComponent
        {
            if (!PendingComponentsToAdd.Contains(value) && !Components.Contains(value))
            {
                PendingComponentsToAdd.Push(value);
            }
        }

        /// <summary>
        ///     Removes the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The component</param>
        public void Remove<T>(T value) where T : AComponent
        {
            if (Components.Contains(value) && !PendingComponentsToRemove.Contains(value))
            {
                PendingComponentsToRemove.Push(value);
            }
        }
        
        /// <summary>
        ///     Gets this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public T Get<T>() where T : AComponent
        {
            return Components.Find(i => i is T) as T;
        }

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public bool Contains<T>() where T : AComponent => Components.Contains(Get<T>());

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear() => Components.Clear();

        /// <summary>
        ///     Ons the enable
        /// </summary>
        public void OnEnable()
        {
            IsEnable = true;
            foreach (AComponent component in Components)
            {
                component.OnEnable();
            }
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public void OnInit()
        {
            foreach (AComponent component in Components)
            {
                component.Attach(this);
                component.OnInit();
            }
        }

        /// <summary>
        ///     Ons the awake
        /// </summary>
        public void OnAwake()
        {
            foreach (AComponent component in Components)
            {
                component.OnAwake();
            }
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public void OnStart()
        {
            foreach (AComponent component in Components)
            {
                component.OnStart();
            }
        }

        /// <summary>
        ///     Ons the physic update
        /// </summary>
        public void OnPhysicUpdate()
        {
            foreach (AComponent component in Components)
            {
                component.OnPhysicUpdate();
            }
        }

        /// <summary>
        ///     Ons the before update
        /// </summary>
        public void OnBeforeUpdate()
        {
            foreach (AComponent component in Components)
            {
                component.OnBeforeUpdate();
            }
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public void OnUpdate()
        {
            foreach (AComponent component in Components)
            {
                component.OnUpdate();
            }
        }

        /// <summary>
        ///     Ons the after update
        /// </summary>
        public void OnAfterUpdate()
        {
            foreach (AComponent component in Components)
            {
                component.OnAfterUpdate();
            }
        }

        public void OnProcessPendingChanges()
        {
            int count = PendingComponentsToAdd.Count;
            
            while (PendingComponentsToAdd.Count > 0)
            {
                AComponent component = PendingComponentsToAdd.Pop();
                component.Attach(this);
                Components.Add(component);
            }
            
            while (PendingComponentsToRemove.Count > 0)
            {
                AComponent component = PendingComponentsToRemove.Pop();
                component.OnStop();
                component.OnExit();
                Components.Remove(component);
            }
            
            if (count > 0)
            {
                foreach (AComponent component in Components)
                {
                    component.OnInit();
                }
                foreach (AComponent component in Components)
                {
                    component.OnAwake();
                }

                foreach (AComponent component in Components)
                {
                    component.OnStart();
                }
            }
            
        }

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public void OnBeforeFixedUpdate()
        {
            foreach (AComponent component in Components)
            {
                component.OnBeforeFixedUpdate();
            }
        }

        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public void OnFixedUpdate()
        {
            foreach (AComponent component in Components)
            {
                component.OnFixedUpdate();
            }
        }

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public void OnAfterFixedUpdate()
        {
            foreach (AComponent component in Components)
            {
                component.OnAfterFixedUpdate();
            }
        }

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public void OnDispatchEvents()
        {
            foreach (AComponent component in Components)
            {
                component.OnDispatchEvents();
            }
        }

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public void OnCalculate()
        {
            foreach (AComponent component in Components)
            {
                component.OnCalculate();
            }
        }

        /// <summary>
        ///     Ons the before draw
        /// </summary>
        public void OnBeforeDraw()
        {
            foreach (AComponent component in Components)
            {
                component.OnBeforeDraw();
            }
        }

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public void OnDraw()
        {
            foreach (AComponent component in Components)
            {
                component.OnDraw();
            }
        }

        /// <summary>
        ///     Ons the after draw
        /// </summary>
        public void OnAfterDraw()
        {
            foreach (AComponent component in Components)
            {
                component.OnAfterDraw();
            }
        }

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public void OnGui()
        {
            foreach (AComponent component in Components)
            {
                component.OnGui();
            }
        }

        /// <summary>
        ///     Ons the render present
        /// </summary>
        public void OnRenderPresent()
        {
            foreach (AComponent component in Components)
            {
                component.OnRenderPresent();
            }
        }

        /// <summary>
        ///     Ons the disable
        /// </summary>
        public void OnDisable()
        {
            IsEnable = false;
            foreach (AComponent component in Components)
            {
                component.OnDisable();
            }
        }

        /// <summary>
        ///     Ons the reset
        /// </summary>
        public void OnReset()
        {
            foreach (AComponent component in Components)
            {
                component.OnReset();
            }
        }

        /// <summary>
        ///     Ons the stop
        /// </summary>
        public void OnStop()
        {
            foreach (AComponent component in Components)
            {
                component.OnStop();
            }
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public void OnExit()
        {
            foreach (AComponent component in Components)
            {
                component.OnExit();
            }
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public void OnDestroy()
        {
            foreach (AComponent component in Components)
            {
                component.OnDestroy();
            }
        }

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Builder() => new GameObjectBuilder(_context);

        /// <summary>
        ///     Sets the context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        public void SetContext(Context context)
        {
            _context = context;
        }
    }
}