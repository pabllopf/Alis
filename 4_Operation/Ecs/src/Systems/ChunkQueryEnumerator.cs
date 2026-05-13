// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChunkQueryEnumerator.cs
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
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Enumerates component chunks that match a <see cref="Query" /> across all matching archetypes.
    /// </summary>
    /// <remarks>
    ///     Iterates over archetypes matched by a query, yielding a <see cref="ChunkTuple{T}" /> for each archetype
    ///     that contains the requested component type(s). Use the <see cref="QueryEnumerable" /> wrapper to
    ///     use this struct with <c>foreach</c> syntax.
    /// </remarks>
    /// <typeparam name="T">The component type to iterate over in each chunk.</typeparam>
    public ref struct ChunkQueryEnumerator<T>
    {
        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;

        /// <summary>
        ///     The archetype index
        /// </summary>
        private int _archetypeIndex;

        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="query">The query</param>
        private ChunkQueryEnumerator(Query query)
        {
            _scene = query.Scene;
            _scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     Gets the component chunk span for the current archetype.
        /// </summary>
        /// <remarks>
        ///     Returns a <see cref="ChunkTuple{T}" /> containing the span of component data
        ///     for the current archetype being iterated.
        /// </remarks>
        public ChunkTuple<T> Current
        {
            get
            {
                Archetype cur = _archetypes[_archetypeIndex];
                return new ChunkTuple<T>
                {
                    Span = cur.GetComponentSpan<T>()
                };
            }
        }

        /// <summary>
        ///     Releases the scene lock acquired during enumeration.
        /// </summary>
        /// <remarks>
        ///     Signals to the scene that enumeration is finished. After this call, the scene
        ///     may allow structural changes (such as adding or removing components/entities).
        /// </remarks>
        public void Dispose()
        {
            _scene.ExitDisallowState(null);
        }

        /// <summary>
        ///     Moves to the next chunk of components in this enumeration.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext() => ++_archetypeIndex < _archetypes.Length;

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query">The query to wrap.</param>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public readonly struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public ChunkQueryEnumerator<T> GetEnumerator() => new ChunkQueryEnumerator<T>(query);
        }
    }

    /// <summary>
    ///     Enumerates component chunks of up to two component types that match a <see cref="Query" /> across all matching archetypes.
    /// </summary>
    /// <remarks>
    ///     Iterates over archetypes matched by a query, yielding a <see cref="ChunkTuple{T1, T2}" /> for each archetype
    ///     that contains both requested component types. Use the <see cref="QueryEnumerable" /> wrapper to
    ///     use this struct with <c>foreach</c> syntax.
    /// </remarks>
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    public ref struct ChunkQueryEnumerator<T1, T2>
    {
        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;

        /// <summary>
        ///     The archetype index
        /// </summary>
        private int _archetypeIndex;

        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="query">The query</param>
        private ChunkQueryEnumerator(Query query)
        {
            _scene = query.Scene;
            _scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     Gets the component chunk spans for the current archetype.
        /// </summary>
        /// <remarks>
        ///     Returns a <see cref="ChunkTuple{T1, T2}" /> containing the spans of component data
        ///     for the current archetype being iterated.
        /// </remarks>
        public ChunkTuple<T1, T2> Current
        {
            get
            {
                Archetype cur = _archetypes[_archetypeIndex];
                return new ChunkTuple<T1, T2>
                {
                    Span1 = cur.GetComponentSpan<T1>(),
                    Span2 = cur.GetComponentSpan<T2>()
                };
            }
        }

        /// <summary>
        ///     Releases the scene lock acquired during enumeration.
        /// </summary>
        /// <remarks>
        ///     Signals to the scene that enumeration is finished. After this call, the scene
        ///     may allow structural changes (such as adding or removing components/entities).
        /// </remarks>
        public void Dispose()
        {
            _scene.ExitDisallowState(null);
        }

        /// <summary>
        ///     Moves to the next chunk of components in this enumeration.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext() => ++_archetypeIndex < _archetypes.Length;

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query">The query to wrap.</param>
        /// <remarks>
        ///     Memory layout optimized: Query reference (8 bytes) captured in primary constructor
        ///     Pack = 1 for minimal memory footprint
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public readonly struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public ChunkQueryEnumerator<T1, T2> GetEnumerator() => new ChunkQueryEnumerator<T1, T2>(query);
        }
    }

    /// <summary>
    ///     The chunk query enumerator
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Scene reference (8 bytes) + Span (16 bytes) + int (4 bytes)
    ///     Total: 28 bytes + 4 bytes padding = 32 bytes aligned
    ///     Pack = 4 for optimal alignment
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3>
    {
        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;

        /// <summary>
        ///     The archetype index
        /// </summary>
        private int _archetypeIndex;

        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="query">The query</param>
        private ChunkQueryEnumerator(Query query)
        {
            _scene = query.Scene;
            _scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     Gets the component chunk spans for the current archetype.
        /// </summary>
        public ChunkTuple<T1, T2, T3> Current
        {
            get
            {
                Archetype cur = _archetypes[_archetypeIndex];
                return new ChunkTuple<T1, T2, T3>
                {
                    Span1 = cur.GetComponentSpan<T1>(),
                    Span2 = cur.GetComponentSpan<T2>(),
                    Span3 = cur.GetComponentSpan<T3>()
                };
            }
        }

        /// <summary>
        ///     Releases the scene lock acquired during enumeration.
        /// </summary>
        /// <remarks>
        ///     Signals to the scene that enumeration is finished. After this call, the scene
        ///     may allow structural changes (such as adding or removing components/entities).
        /// </remarks>
        public void Dispose()
        {
            _scene.ExitDisallowState(null);
        }

        /// <summary>
        ///     Moves to the next chunk of components in this enumeration.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext() => ++_archetypeIndex < _archetypes.Length;

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query">The query to wrap.</param>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public readonly struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public ChunkQueryEnumerator<T1, T2, T3> GetEnumerator() => new ChunkQueryEnumerator<T1, T2, T3>(query);
        }
    }

    /// <summary>
    ///     Enumerates component chunks of up to four component types that match a <see cref="Query" /> across all matching archetypes.
    /// </summary>
    /// <remarks>
    ///     Iterates over archetypes matched by a query, yielding a <see cref="ChunkTuple{T1, T2, T3, T4}" /> for each archetype
    ///     that contains all requested component types. Use the <see cref="QueryEnumerable" /> wrapper to
    ///     use this struct with <c>foreach</c> syntax.
    /// </remarks>
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="T4">The fourth component type.</typeparam>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4>
    {
        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;

        /// <summary>
        ///     The archetype index
        /// </summary>
        private int _archetypeIndex;

        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="query">The query</param>
        private ChunkQueryEnumerator(Query query)
        {
            _scene = query.Scene;
            _scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     Gets the component chunk spans for the current archetype.
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4> Current
        {
            get
            {
                Archetype cur = _archetypes[_archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4>
                {
                    Span1 = cur.GetComponentSpan<T1>(),
                    Span2 = cur.GetComponentSpan<T2>(),
                    Span3 = cur.GetComponentSpan<T3>(),
                    Span4 = cur.GetComponentSpan<T4>()
                };
            }
        }

        /// <summary>
        ///     Releases the scene lock acquired during enumeration.
        /// </summary>
        /// <remarks>
        ///     Signals to the scene that enumeration is finished. After this call, the scene
        ///     may allow structural changes (such as adding or removing components/entities).
        /// </remarks>
        public void Dispose()
        {
            _scene.ExitDisallowState(null);
        }

        /// <summary>
        ///     Moves to the next chunk of components in this enumeration.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext() => ++_archetypeIndex < _archetypes.Length;

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query">The query to wrap.</param>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public readonly struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public ChunkQueryEnumerator<T1, T2, T3, T4> GetEnumerator() => new ChunkQueryEnumerator<T1, T2, T3, T4>(query);
        }
    }

    /// <summary>
    ///     Enumerates component chunks of up to six component types that match a <see cref="Query" /> across all matching archetypes.
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Scene reference (8 bytes) + Span (16 bytes) + int (4 bytes)
    ///     Total: 28 bytes + 4 bytes padding = 32 bytes aligned
    ///     Pack = 4 for optimal alignment
    /// </remarks>
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="T4">The fourth component type.</typeparam>
    /// <typeparam name="T5">The fifth component type.</typeparam>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5>
    {
        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;

        /// <summary>
        ///     The archetype index
        /// </summary>
        private int _archetypeIndex;

        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="query">The query</param>
        private ChunkQueryEnumerator(Query query)
        {
            _scene = query.Scene;
            _scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     Gets the component chunk spans for the current archetype.
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5> Current
        {
            get
            {
                Archetype cur = _archetypes[_archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5>
                {
                    Span1 = cur.GetComponentSpan<T1>(),
                    Span2 = cur.GetComponentSpan<T2>(),
                    Span3 = cur.GetComponentSpan<T3>(),
                    Span4 = cur.GetComponentSpan<T4>(),
                    Span5 = cur.GetComponentSpan<T5>()
                };
            }
        }

        /// <summary>
        ///     Releases the scene lock acquired during enumeration.
        /// </summary>
        /// <remarks>
        ///     Signals to the scene that enumeration is finished. After this call, the scene
        ///     may allow structural changes (such as adding or removing components/entities).
        /// </remarks>
        public void Dispose()
        {
            _scene.ExitDisallowState(null);
        }

        /// <summary>
        ///     Moves to the next chunk of components in this enumeration.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext() => ++_archetypeIndex < _archetypes.Length;

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query">The query to wrap.</param>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public readonly struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5> GetEnumerator() => new ChunkQueryEnumerator<T1, T2, T3, T4, T5>(query);
        }
    }

    /// <summary>
    ///     The chunk query enumerator
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Scene reference (8 bytes) + Span (16 bytes) + int (4 bytes)
    ///     Total: 28 bytes + 4 bytes padding = 32 bytes aligned
    ///     Pack = 4 for optimal alignment
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;

        /// <summary>
        ///     The archetype index
        /// </summary>
        private int _archetypeIndex;

        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="query">The query</param>
        private ChunkQueryEnumerator(Query query)
        {
            _scene = query.Scene;
            _scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     The current tuple of component chunks.
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6> Current
        {
            get
            {
                Archetype cur = _archetypes[_archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6>
                {
                    Span1 = cur.GetComponentSpan<T1>(),
                    Span2 = cur.GetComponentSpan<T2>(),
                    Span3 = cur.GetComponentSpan<T3>(),
                    Span4 = cur.GetComponentSpan<T4>(),
                    Span5 = cur.GetComponentSpan<T5>(),
                    Span6 = cur.GetComponentSpan<T6>()
                };
            }
        }

        /// <summary>
        ///     Releases the scene lock acquired during enumeration.
        /// </summary>
        /// <remarks>
        ///     Signals to the scene that enumeration is finished. After this call, the scene
        ///     may allow structural changes (such as adding or removing components/entities).
        /// </remarks>
        public void Dispose()
        {
            _scene.ExitDisallowState(null);
        }

        /// <summary>
        ///     Moves to the next chunk of components in this enumeration.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext() => ++_archetypeIndex < _archetypes.Length;

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query">The query to wrap.</param>
        /// <remarks>
        ///     Memory layout optimized: Query reference (8 bytes) captured in primary constructor
        ///     Pack = 1 for minimal memory footprint
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public readonly struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6> GetEnumerator() => new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6>(query);
        }
    }

    /// <summary>
    ///     The chunk query enumerator
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Scene reference (8 bytes) + Span (16 bytes) + int (4 bytes)
    ///     Total: 28 bytes + 4 bytes padding = 32 bytes aligned
    ///     Pack = 4 for optimal alignment
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7>
    {
        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;

        /// <summary>
        ///     The archetype index
        /// </summary>
        private int _archetypeIndex;

        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="query">The query</param>
        private ChunkQueryEnumerator(Query query)
        {
            _scene = query.Scene;
            _scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     The current tuple of component chunks.
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7> Current
        {
            get
            {
                Archetype cur = _archetypes[_archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7>
                {
                    Span1 = cur.GetComponentSpan<T1>(),
                    Span2 = cur.GetComponentSpan<T2>(),
                    Span3 = cur.GetComponentSpan<T3>(),
                    Span4 = cur.GetComponentSpan<T4>(),
                    Span5 = cur.GetComponentSpan<T5>(),
                    Span6 = cur.GetComponentSpan<T6>(),
                    Span7 = cur.GetComponentSpan<T7>()
                };
            }
        }

        /// <summary>
        ///     Releases the scene lock acquired during enumeration.
        /// </summary>
        /// <remarks>
        ///     Signals to the scene that enumeration is finished. After this call, the scene
        ///     may allow structural changes (such as adding or removing components/entities).
        /// </remarks>
        public void Dispose()
        {
            _scene.ExitDisallowState(null);
        }

        /// <summary>
        ///     Moves to the next chunk of components in this enumeration.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext() => ++_archetypeIndex < _archetypes.Length;

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query">The query to wrap.</param>
        /// <remarks>
        ///     Memory layout optimized: Query reference (8 bytes) captured in primary constructor
        ///     Pack = 1 for minimal memory footprint
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public readonly struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7> GetEnumerator() => new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7>(query);
        }
    }

    /// <summary>
    ///     Enumerates component chunks of up to eight component types that match a <see cref="Query" /> across all matching archetypes.
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Scene reference (8 bytes) + Span (16 bytes) + int (4 bytes)
    ///     Total: 28 bytes + 4 bytes padding = 32 bytes aligned
    ///     Pack = 4 for optimal alignment
    /// </remarks>
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="T4">The fourth component type.</typeparam>
    /// <typeparam name="T5">The fifth component type.</typeparam>
    /// <typeparam name="T6">The sixth component type.</typeparam>
    /// <typeparam name="T7">The seventh component type.</typeparam>
    /// <typeparam name="T8">The eighth component type.</typeparam>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;

        /// <summary>
        ///     The archetype index
        /// </summary>
        private int _archetypeIndex;

        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="query">The query</param>
        private ChunkQueryEnumerator(Query query)
        {
            _scene = query.Scene;
            _scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     Gets the component chunk spans for the current archetype.
        /// </summary>
        /// <remarks>
        ///     Returns a <see cref="ChunkTuple{T1, T2, T3, T4, T5, T6, T7, T8}" /> containing the spans of component data
        ///     for the current archetype being iterated.
        /// </remarks>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8> Current
        {
            get
            {
                Archetype cur = _archetypes[_archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8>
                {
                    Span1 = cur.GetComponentSpan<T1>(),
                    Span2 = cur.GetComponentSpan<T2>(),
                    Span3 = cur.GetComponentSpan<T3>(),
                    Span4 = cur.GetComponentSpan<T4>(),
                    Span5 = cur.GetComponentSpan<T5>(),
                    Span6 = cur.GetComponentSpan<T6>(),
                    Span7 = cur.GetComponentSpan<T7>(),
                    Span8 = cur.GetComponentSpan<T8>()
                };
            }
        }

        /// <summary>
        ///     Releases the scene lock acquired during enumeration.
        /// </summary>
        /// <remarks>
        ///     Signals to the scene that enumeration is finished. After this call, the scene
        ///     may allow structural changes (such as adding or removing components/entities).
        /// </remarks>
        public void Dispose()
        {
            _scene.ExitDisallowState(null);
        }

        /// <summary>
        ///     Moves to the next chunk of components in this enumeration.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext() => ++_archetypeIndex < _archetypes.Length;

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query">The query to wrap.</param>
        public readonly struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8> GetEnumerator() => new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8>(query);
        }
    }
}