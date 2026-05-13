// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Event.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Kernel.Events
{
/// <summary>
///     Represents a typed event in the ECS system that can be raised and listened to by GameObjects.
///     This struct uses a combination of a single Action reference for the first listener and a
///     FrugalStack for additional listeners to minimize memory allocations.
///     Events are generic over the event argument type T, allowing type-safe event handling.
/// </summary>
/// <typeparam name="T">The type of the event argument passed to listeners when the event is invoked.</typeparam>
/// <remarks>
///     Memory layout optimized: Action reference (8 bytes) + FrugalStack struct (12 bytes)
///     Total: 20 bytes + 4 bytes padding = 24 bytes aligned
///     Pack = 8 for optimal alignment with reference types
///     
///     The Event struct is designed to be a lightweight, allocation-free way to handle events
///     in an ECS (Entity Component System) architecture. It uses a hybrid storage approach:
///     - The first listener is stored directly in a field (_first)
///     - Additional listeners are stored in a FrugalStack (_invokationList)
///     
///     Usage example:
///     <code>
///     // Define an event argument type
///     public struct CollisionEvent {
///         public GameObject Other;
///         public Vector2F Normal;
///     }
///     
///     // Create an event
///     Event&lt;CollisionEvent&gt; collisionEvent = new Event&lt;CollisionEvent&gt;();
///     
///     // Subscribe to the event
///     collisionEvent.Add((gameObject, arg) => {
///         // Handle collision
///         Console.WriteLine($"Collided with {arg.Other.Name}");
///     });
///     
///     // Invoke the event
///     collisionEvent.Invoke(someGameObject, new CollisionEvent { /* ... */ });
///     </code>
/// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct Event<T>()
    {
        /// <summary>
        ///     Gets the value of the has listeners
        /// </summary>
        public bool HasListeners => _first is not null;

        /// <summary>
        ///     The first
        /// </summary>
        private Action<GameObject, T> _first;

        /// <summary>
        ///     The
        /// </summary>
        private FrugalStack<Action<GameObject, T>> _invokationList = new FrugalStack<Action<GameObject, T>>();

        /// <summary>
        ///     Adds the action
        /// </summary>
        /// <param name="action">The action</param>
        public void Add(Action<GameObject, T> action)
        {
            if (_first is null)
            {
                _first = action;
            }
            else
            {
                _invokationList.Push(action);
            }
        }

        /// <summary>
        ///     Removes the action
        /// </summary>
        /// <param name="action">The action</param>
        public void Remove(Action<GameObject, T> action)
        {
            if (_first == action)
            {
                _first = null;
                if (_invokationList.TryPop(out Action<GameObject, T> v))
                {
                    _first = v;
                }
            }
            else
            {
                _invokationList.Remove(action);
            }
        }

        /// <summary>
        ///     Invokes the gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="arg">The arg</param>
        public readonly void Invoke(GameObject gameObject, T arg)
        {
            if (_first is not null)
            {
                InvokeInternal(gameObject, arg);
            }
        }

        /// <summary>
        ///     Invokes the internal using the specified gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="arg">The arg</param>
        public readonly void InvokeInternal(GameObject gameObject, T arg)
        {
            _first!.Invoke(gameObject, arg);
            foreach (Action<GameObject, T> item in _invokationList.AsSpan())
            {
                item.Invoke(gameObject, arg);
            }
        }
    }
}