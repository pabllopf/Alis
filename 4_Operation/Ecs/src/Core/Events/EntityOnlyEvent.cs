using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;


namespace Alis.Core.Ecs.Core.Events
{
    /// <summary>
    ///     The entity only event
    /// </summary>
    [StructLayout( LayoutKind.Sequential )]
    [SkipLocalsInit]
    internal struct EntityOnlyEvent()
    {
        /// <summary>
        ///     Gets the value of the has listeners
        /// </summary>
        public bool HasListeners => _first is not null;

        /// <summary>
        ///     The first
        /// </summary>
        private Action<Entity> _first;

        /// <summary>
        ///     The second
        /// </summary>
        private Action<Entity> _second;

        /// <summary>
        ///     The entity
        /// </summary>
        private FastStack<Action<Entity>> _invokationList = new FastStack<Action<Entity>>();

        /// <summary>
        ///     Adds the action
        /// </summary>
        /// <param name="action">The action</param>
        public void Add(Action<Entity> action)
        {
            if (_first is null)
            {
                _first = action;
            }
            else if (_second is null)
            {
                _second = action;
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
        public void Remove(Action<Entity> action)
        {
            if (_first == action)
            {
                _first = null;
                if (_invokationList.TryPop(out Action<Entity> v))
                {
                    _first = v;
                }
            }
            else if (_second == action)
            {
                _second = null;
                if (_invokationList.TryPop(out Action<Entity> v))
                {
                    _second = v;
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
        public readonly void Invoke(Entity entity)
        {
            if (_first is not null)
            {
                Execute(entity);
            }
        }

        /// <summary>
        ///     Executes the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        private readonly void Execute(Entity entity)
        {
            _first!.Invoke(entity);
            if (_second is not null)
            {
                _second.Invoke(entity);
                foreach (Action<Entity> item in _invokationList.AsSpan())
                {
                    item.Invoke(entity);
                }
            }
        }
    }
}