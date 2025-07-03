global using TagEvent = Alis.Core.Ecs.Kernel.Events.Event<Alis.Core.Ecs.Kernel.TagId>;
using System;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Kernel.Events
{
    /// <summary>
    ///     The event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
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
                _first = action;
            else
                _invokationList.Push(action);
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
                    _first = v;
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
            if (_first is not null) InvokeInternal(gameObject, arg);
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
                item.Invoke(gameObject, arg);
        }
    }
}