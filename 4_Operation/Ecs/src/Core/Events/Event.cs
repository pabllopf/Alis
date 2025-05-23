﻿global using TagEvent = Alis.Core.Ecs.Core.Events.Event<Alis.Core.Ecs.Core.TagID>;
using System;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Core.Events
{
    internal struct Event<T>()
    {
        public bool HasListeners => _first is not null;

        private Action<Entity, T>? _first;
        private FrugalStack<Action<Entity, T>> _invokationList = new FrugalStack<Action<Entity, T>>();

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

        public void Remove(Action<Entity, T> action)
        {
            if (_first == action)
            {
                _first = null;
                if (_invokationList.TryPop(out var v))
                    _first = v;
            }
            else
            {
                _invokationList.Remove(action);
            }
        }

        public readonly void Invoke(Entity entity, T arg)
        {
            if (_first is not null)
            {
                InvokeInternal(entity, arg);
            }
        }

        public readonly void InvokeInternal(Entity entity, T arg)
        {
            _first!.Invoke(entity, arg);
            foreach (var item in _invokationList.AsSpan())
                item.Invoke(entity, arg);
        }
    }
}