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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Redefinition;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T>
    {
        //ptr, ptr, int, int is better alignment
        /// <summary>
        ///     The world
        /// </summary>
        private readonly World _world;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;

        /// <summary>
        ///     The archetype index
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
        ///     Gets the value of the current
        /// </summary>
        public ChunkTuple<T> Current
        {
            get
            {
                Archetype cur = _archetypes[_archetypeIndex];
                return new()
                {
                    Span = cur.GetComponentSpan<T>()
                };
            }
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _world.ExitDisallowState();
        }

        /// <summary>
        ///     Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++_archetypeIndex < _archetypes.Length;

        /// <summary>
        ///     The query enumerable
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        [SkipLocalsInit]
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t</returns>
            public ChunkQueryEnumerator<T> GetEnumerator() => new(query);
        }
    }
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [SkipLocalsInit]
    public ref struct ChunkQueryEnumerator<T1, T2>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }

        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>()
                };
            }
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();

        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;

        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2</returns>
            public ChunkQueryEnumerator<T1, T2> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2>(query);
            }
        }
    }


    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }

        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>()
                };
            }
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();

        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;

        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3</returns>
            public ChunkQueryEnumerator<T1, T2, T3> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3>(query);
            }
        }
    }
    
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }
    
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>(),
                    Span4 = archetype.GetComponentSpan<T4>()
                };
            }
        }
    
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();
    
        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;
    
        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3 and t 4</returns>
            public ChunkQueryEnumerator<T1, T2, T3, T4> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3, T4>(query);
            }
        }
    }
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }
    
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>(),
                    Span4 = archetype.GetComponentSpan<T4>(),
                    Span5 = archetype.GetComponentSpan<T5>()
                };
            }
        }
    
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();
    
        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;
    
        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3 and t 4 and t 5</returns>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3, T4, T5>(query);
            }
        }
    }
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }
    
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>(),
                    Span4 = archetype.GetComponentSpan<T4>(),
                    Span5 = archetype.GetComponentSpan<T5>(),
                    Span6 = archetype.GetComponentSpan<T6>()
                };
            }
        }
    
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();
    
        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;
    
        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3 and t 4 and t 5 and t 6</returns>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6>(query);
            }
        }
    }
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }
    
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>(),
                    Span4 = archetype.GetComponentSpan<T4>(),
                    Span5 = archetype.GetComponentSpan<T5>(),
                    Span6 = archetype.GetComponentSpan<T6>(),
                    Span7 = archetype.GetComponentSpan<T7>()
                };
            }
        }
    
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();
    
        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;
    
        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7</returns>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7>(query);
            }
        }
    }
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }
    
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>(),
                    Span4 = archetype.GetComponentSpan<T4>(),
                    Span5 = archetype.GetComponentSpan<T5>(),
                    Span6 = archetype.GetComponentSpan<T6>(),
                    Span7 = archetype.GetComponentSpan<T7>(),
                    Span8 = archetype.GetComponentSpan<T8>()
                };
            }
        }
    
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();
    
        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;
    
        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7 and t 8</returns>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8>(query);
            }
        }
    }
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }
    
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>(),
                    Span4 = archetype.GetComponentSpan<T4>(),
                    Span5 = archetype.GetComponentSpan<T5>(),
                    Span6 = archetype.GetComponentSpan<T6>(),
                    Span7 = archetype.GetComponentSpan<T7>(),
                    Span8 = archetype.GetComponentSpan<T8>(),
                    Span9 = archetype.GetComponentSpan<T9>()
                };
            }
        }
    
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();
    
        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;
    
        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7 and t 8 and t 9</returns>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9>(query);
            }
        }
    }
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }
    
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>(),
                    Span4 = archetype.GetComponentSpan<T4>(),
                    Span5 = archetype.GetComponentSpan<T5>(),
                    Span6 = archetype.GetComponentSpan<T6>(),
                    Span7 = archetype.GetComponentSpan<T7>(),
                    Span8 = archetype.GetComponentSpan<T8>(),
                    Span9 = archetype.GetComponentSpan<T9>(),
                    Span10 = archetype.GetComponentSpan<T10>()
                };
            }
        }
    
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();
    
        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;
    
        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7 and t 8 and t 9 and t 10</returns>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(query);
            }
        }
    }
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }
    
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>(),
                    Span4 = archetype.GetComponentSpan<T4>(),
                    Span5 = archetype.GetComponentSpan<T5>(),
                    Span6 = archetype.GetComponentSpan<T6>(),
                    Span7 = archetype.GetComponentSpan<T7>(),
                    Span8 = archetype.GetComponentSpan<T8>(),
                    Span9 = archetype.GetComponentSpan<T9>(),
                    Span10 = archetype.GetComponentSpan<T10>(),
                    Span11 = archetype.GetComponentSpan<T11>()
                };
            }
        }
    
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();
    
        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;
    
        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7 and t 8 and t 9 and t 10 and t 11</returns>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(query);
            }
        }
    }
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }
    
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>(),
                    Span4 = archetype.GetComponentSpan<T4>(),
                    Span5 = archetype.GetComponentSpan<T5>(),
                    Span6 = archetype.GetComponentSpan<T6>(),
                    Span7 = archetype.GetComponentSpan<T7>(),
                    Span8 = archetype.GetComponentSpan<T8>(),
                    Span9 = archetype.GetComponentSpan<T9>(),
                    Span10 = archetype.GetComponentSpan<T10>(),
                    Span11 = archetype.GetComponentSpan<T11>(),
                    Span12 = archetype.GetComponentSpan<T12>()
                };
            }
        }
    
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();
    
        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;
    
        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7 and t 8 and t 9 and t 10 and t 11 and t 12</returns>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(query);
            }
        }
    }
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }
    
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>(),
                    Span4 = archetype.GetComponentSpan<T4>(),
                    Span5 = archetype.GetComponentSpan<T5>(),
                    Span6 = archetype.GetComponentSpan<T6>(),
                    Span7 = archetype.GetComponentSpan<T7>(),
                    Span8 = archetype.GetComponentSpan<T8>(),
                    Span9 = archetype.GetComponentSpan<T9>(),
                    Span10 = archetype.GetComponentSpan<T10>(),
                    Span11 = archetype.GetComponentSpan<T11>(),
                    Span12 = archetype.GetComponentSpan<T12>(),
                    Span13 = archetype.GetComponentSpan<T13>()
                };
            }
        }
    
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();
    
        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;
    
        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7 and t 8 and t 9 and t 10 and t 11 and t 12 and t 13</returns>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(query);
            }
        }
    }
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }
    
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>(),
                    Span4 = archetype.GetComponentSpan<T4>(),
                    Span5 = archetype.GetComponentSpan<T5>(),
                    Span6 = archetype.GetComponentSpan<T6>(),
                    Span7 = archetype.GetComponentSpan<T7>(),
                    Span8 = archetype.GetComponentSpan<T8>(),
                    Span9 = archetype.GetComponentSpan<T9>(),
                    Span10 = archetype.GetComponentSpan<T10>(),
                    Span11 = archetype.GetComponentSpan<T11>(),
                    Span12 = archetype.GetComponentSpan<T12>(),
                    Span13 = archetype.GetComponentSpan<T13>(),
                    Span14 = archetype.GetComponentSpan<T14>()
                };
            }
        }
    
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();
    
        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;
    
        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7 and t 8 and t 9 and t 10 and t 11 and t 12 and t 13 and t 14</returns>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(query);
            }
        }
    }
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }
    
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>(),
                    Span4 = archetype.GetComponentSpan<T4>(),
                    Span5 = archetype.GetComponentSpan<T5>(),
                    Span6 = archetype.GetComponentSpan<T6>(),
                    Span7 = archetype.GetComponentSpan<T7>(),
                    Span8 = archetype.GetComponentSpan<T8>(),
                    Span9 = archetype.GetComponentSpan<T9>(),
                    Span10 = archetype.GetComponentSpan<T10>(),
                    Span11 = archetype.GetComponentSpan<T11>(),
                    Span12 = archetype.GetComponentSpan<T12>(),
                    Span13 = archetype.GetComponentSpan<T13>(),
                    Span14 = archetype.GetComponentSpan<T14>(),
                    Span15 = archetype.GetComponentSpan<T15>()
                };
            }
        }
    
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();
    
        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;
    
        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7 and t 8 and t 9 and t 10 and t 11 and t 12 and t 13 and t 14 and t 15</returns>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(query);
            }
        }
    }
    
    /// <summary>
    /// The chunk query enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
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
            this._world = query.World;
            this._world.EnterDisallowState();
            this._archetypes = query.AsSpan();
            this._archetypeIndex = -1;
        }
    
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Current
        {
            get
            {
                Archetype archetype = this._archetypes[this._archetypeIndex];
                return new ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
                {
                    Span1 = archetype.GetComponentSpan<T1>(),
                    Span2 = archetype.GetComponentSpan<T2>(),
                    Span3 = archetype.GetComponentSpan<T3>(),
                    Span4 = archetype.GetComponentSpan<T4>(),
                    Span5 = archetype.GetComponentSpan<T5>(),
                    Span6 = archetype.GetComponentSpan<T6>(),
                    Span7 = archetype.GetComponentSpan<T7>(),
                    Span8 = archetype.GetComponentSpan<T8>(),
                    Span9 = archetype.GetComponentSpan<T9>(),
                    Span10 = archetype.GetComponentSpan<T10>(),
                    Span11 = archetype.GetComponentSpan<T11>(),
                    Span12 = archetype.GetComponentSpan<T12>(),
                    Span13 = archetype.GetComponentSpan<T13>(),
                    Span14 = archetype.GetComponentSpan<T14>(),
                    Span15 = archetype.GetComponentSpan<T15>(),
                    Span16 = archetype.GetComponentSpan<T16>()
                };
            }
        }
    
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => this._world.ExitDisallowState();
    
        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++this._archetypeIndex < this._archetypes.Length;
    
        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A chunk query enumerator of t 1 and t 2 and t 3 and t 4 and t 5 and t 6 and t 7 and t 8 and t 9 and t 10 and t 11 and t 12 and t 13 and t 14 and t 15 and t 16</returns>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> GetEnumerator()
            {
                return new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(query);
            }
        }
    }
}