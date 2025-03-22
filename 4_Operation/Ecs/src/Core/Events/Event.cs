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

global using TagEvent = Alis.Core.Ecs.Core.Events.Event<Alis.Core.Ecs.Core.TagID>;
using System;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Core.Events
{
    /// <summary>
    ///     The event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)] 
    internal struct Event<T>()
    {
        /// <summary>
        ///     Gets the value of the has listeners
        /// </summary>
        public bool HasListeners => _first is not null;

        /// <summary>
        ///     The first
        /// </summary>
        private Action<Entity, T> _first;

        /// <summary>
        ///     The
        /// </summary>
        private FastStack<Action<Entity, T>> _invokationList = new FastStack<Action<Entity, T>>();

        /// <summary>
        ///     Adds the action
        /// </summary>
        /// <param name="action">The action</param>
        public void Add(Action<Entity, T> action)
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
        public void Remove(Action<Entity, T> action)
        {
            if (_first == action)
            {
                _first = null;
                if (_invokationList.TryPop(out Action<Entity, T> v))
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
        ///     Invokes the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="arg">The arg</param>
        public readonly void Invoke(Entity entity, T arg)
        {
            if (_first is not null)
            {
                InvokeInternal(entity, arg);
            }
        }

        /// <summary>
        ///     Invokes the internal using the specified entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="arg">The arg</param>
        public readonly void InvokeInternal(Entity entity, T arg)
        {
            _first!.Invoke(entity, arg);
            foreach (Action<Entity, T> item in _invokationList.AsSpan())
            {
                item.Invoke(entity, arg);
            }
        }
    }
}