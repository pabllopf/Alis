using System;
using Frent.Core;


namespace Frent.Systems;





/// <summary>
/// The entity query enumerator
/// </summary>
public ref struct EntityQueryEnumerator<T>
{
    /// <summary>
    /// The archetype index
    /// </summary>
    private int _archetypeIndex;
    /// <summary>
    /// The component index
    /// </summary>
    private int _componentIndex;
    /// <summary>
    /// The world
    /// </summary>
    private World _world;
    /// <summary>
    /// The archetypes
    /// </summary>
    private Span<Archetype> _archetypes;
    /// <summary>
    /// The entity ids
    /// </summary>
    private Span<EntityIDOnly> _entityIds;
    /// <summary>
    /// The current span
    /// </summary>
    private Span<T> _currentSpan1;
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityQueryEnumerator"/> class
    /// </summary>
    /// <param name="query">The query</param>
    private EntityQueryEnumerator(Query query)
    {
        _world = query.World;
        _world.EnterDisallowState();
        _archetypes = query.AsSpan();
        _archetypeIndex = -1;
    }

    /// <summary>
    /// Gets the value of the current
    /// </summary>
    public EntityRefTuple<T> Current => new()
    {
        Entity = _entityIds[_componentIndex].ToEntity(_world),
        Item1 = new Ref<T>(_currentSpan1, _componentIndex),
    };

    /// <summary>
    /// Disposes this instance
    /// </summary>
    public void Dispose()
    {
        _world.ExitDisallowState();
    }

    /// <summary>
    /// Moves the next
    /// </summary>
    /// <returns>The bool</returns>
    public bool MoveNext()
    {
        if (++_componentIndex < _currentSpan1.Length)
        {
            return true;
        }

        do
        {
            _componentIndex = 0;
            _archetypeIndex++;

            if ((uint)_archetypeIndex < (uint)_archetypes.Length)
            {
                var cur = _archetypes[_archetypeIndex];
                _entityIds = cur.GetEntitySpan();
                _currentSpan1 = cur.GetComponentSpan<T>();
            }
            else
            {
                return false;
            }
        } while (!(_componentIndex < _currentSpan1.Length));

        return true;
    }

    /// <summary>
    /// The query enumerable
    /// </summary>
    public struct QueryEnumerable(Query query)
    {
        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>An entity query enumerator of t</returns>
        public EntityQueryEnumerator<T> GetEnumerator() => new EntityQueryEnumerator<T>(query);
    }
}

/// <summary>
/// The entity query enumerator
/// </summary>
public ref struct EntityQueryEnumerator
{
    /// <summary>
    /// The archetype index
    /// </summary>
    private int _archetypeIndex;
    /// <summary>
    /// The component index
    /// </summary>
    private int _componentIndex;
    /// <summary>
    /// The world
    /// </summary>
    private World _world;
    /// <summary>
    /// The archetypes
    /// </summary>
    private Span<Archetype> _archetypes;
    /// <summary>
    /// The entity ids
    /// </summary>
    private Span<EntityIDOnly> _entityIds;
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityQueryEnumerator"/> class
    /// </summary>
    /// <param name="query">The query</param>
    private EntityQueryEnumerator(Query query)
    {
        _world = query.World;
        _world.EnterDisallowState();
        _archetypes = query.AsSpan();
        _archetypeIndex = -1;
    }

    /// <summary>
    /// Gets the value of the current
    /// </summary>
    public Entity Current => _entityIds[_componentIndex].ToEntity(_world);

    /// <summary>
    /// Disposes this instance
    /// </summary>
    public void Dispose()
    {
        _world.ExitDisallowState();
    }

    /// <summary>
    /// Moves the next
    /// </summary>
    /// <returns>The bool</returns>
    public bool MoveNext()
    {
        if (++_componentIndex < _entityIds.Length)
        {
            return true;
        }

        _componentIndex = 0;
        _archetypeIndex++;

        if ((uint)_archetypeIndex < (uint)_archetypes.Length)
        {
            var cur = _archetypes[_archetypeIndex];
            _entityIds = cur.GetEntitySpan();
            return true;
        }

        return false;
    }

    /// <summary>
    /// The query enumerable
    /// </summary>
    public struct QueryEnumerable(Query query)
    {
        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>The entity query enumerator</returns>
        public EntityQueryEnumerator GetEnumerator() => new EntityQueryEnumerator(query);
    }
}