using System;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Core.Events;

internal struct EntityOnlyEvent()
{
    public bool HasListeners => _first is not null;

    private Action<Entity>? _first;
    private Action<Entity>? _second;
    private FrugalStack<Action<Entity>> _invokationList = new FrugalStack<Action<Entity>>();

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

    public void Remove(Action<Entity> action)
    {
        if (_first == action)
        {
            _first = null;
            if (_invokationList.TryPop(out var v))
                _first = v;
        }
        else if (_second == action)
        {
            _second = null;
            if (_invokationList.TryPop(out var v))
                _second = v;
        }
        else
        {
            _invokationList.Remove(action);
        }
    }

    public readonly void Invoke(Entity entity)
    {
        if (_first is not null)
            Execute(entity);
    }

    private readonly void Execute(Entity entity)
    {
        _first!.Invoke(entity);
        if (_second is not null)
        {
            _second.Invoke(entity);
            foreach (var item in _invokationList.AsSpan())
                item.Invoke(entity);
        }
    }
}