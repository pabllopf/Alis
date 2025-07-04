using System;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Kernel.Events
{
    /// <summary>
    ///     The gameObject only event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public struct GameObjectOnlyEvent()
    {
        /// <summary>
        ///     Gets the value of the has listeners
        /// </summary>
        public bool HasListeners => _first is not null;

        /// <summary>
        ///     The first
        /// </summary>
        private Action<GameObject> _first;

        /// <summary>
        ///     The second
        /// </summary>
        private Action<GameObject> _second;

        /// <summary>
        ///     The gameObject
        /// </summary>
        private FrugalStack<Action<GameObject>> _invokationList = new FrugalStack<Action<GameObject>>();

        /// <summary>
        ///     Adds the action
        /// </summary>
        /// <param name="action">The action</param>
        public void Add(Action<GameObject> action)
        {
            if (_first is null)
                _first = action;
            else if (_second is null)
                _second = action;
            else
                _invokationList.Push(action);
        }

        /// <summary>
        ///     Removes the action
        /// </summary>
        /// <param name="action">The action</param>
        public void Remove(Action<GameObject> action)
        {
            if (_first == action)
            {
                _first = null;
                if (_invokationList.TryPop(out Action<GameObject> v))
                    _first = v;
            }
            else if (_second == action)
            {
                _second = null;
                if (_invokationList.TryPop(out Action<GameObject> v))
                    _second = v;
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
        public readonly void Invoke(GameObject gameObject)
        {
            if (_first is not null)
                Execute(gameObject);
        }

        /// <summary>
        ///     Executes the gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        private readonly void Execute(GameObject gameObject)
        {
            _first!.Invoke(gameObject);
            if (_second is not null)
            {
                _second.Invoke(gameObject);
                foreach (Action<GameObject> item in _invokationList.AsSpan())
                    item.Invoke(gameObject);
            }
        }
    }
}