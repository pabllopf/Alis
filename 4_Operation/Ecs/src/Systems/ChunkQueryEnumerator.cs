using System;
using Frent.Core;


namespace Frent.Systems;



/// <summary>
/// The chunk query enumerator
/// </summary>
public ref struct ChunkQueryEnumerator<T>
{
    //ptr, ptr, int, int is better alignment
    /// <summary>
    /// The world
    /// </summary>
    private World _world;
    /// <summary>
    /// The archetypes
    /// </summary>
    private Span<Archetype> _archetypes;
    /// <summary>
    /// The archetype index
    /// </summary>
    private int _archetypeIndex;
    /// <summary>
    /// Initializes a new instance of the <see cref="ChunkQueryEnumerator"/> class
    /// </summary>
    /// <param name="query">The query</param>
    private ChunkQueryEnumerator(Query query)
    {
        _world = query.World;
        _world.EnterDisallowState();
        _archetypes = query.AsSpan();
        _archetypeIndex = -1;
    }

    /// <summary>
    /// Gets the value of the current
    /// </summary>
    public ChunkTuple<T> Current
    {
        get
        {
            Archetype cur = _archetypes[_archetypeIndex];
            return new()
            {
                Span = cur.GetComponentSpan<T>(),
            };
        }
    }
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
    public bool MoveNext() => ++_archetypeIndex < _archetypes.Length;

    /// <summary>
    /// The query enumerable
    /// </summary>
    public struct QueryEnumerable(Query query)
    {
        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>A chunk query enumerator of t</returns>
        public ChunkQueryEnumerator<T> GetEnumerator() => new(query);
    }
}