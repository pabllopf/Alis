// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectRefTuple.cs
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

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Represents a tuple of references to a <see cref="GameObject"/> and a single component,
    ///     typically returned during query enumeration.
    /// </summary>
    /// <typeparam name="T1">The type of the first component reference.</typeparam>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct GameObjectRefTuple<T1>
    {
        /// <summary>
        ///     The <see cref="GameObject"/> that owns the components in this tuple.
        /// </summary>
        public GameObject GameObject;

        /// <summary>
        ///     Reference to the first component of type <typeparamref name="T1"/>.
        /// </summary>
        public Ref<T1> Item1;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject"/> instance.</param>
        /// <param name="ref1">Reference to the first component.</param>
        public void Deconstruct(out GameObject gameObject, out Ref<T1> ref1)
        {
            gameObject = GameObject;
            ref1 = Item1;
        }
    }

    /// <summary>
    ///     Represents a tuple of references to a <see cref="GameObject"/> and two components,
    ///     typically returned during query enumeration.
    /// </summary>
    /// <typeparam name="T1">The type of the first component reference.</typeparam>
    /// <typeparam name="T2">The type of the second component reference.</typeparam>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct GameObjectRefTuple<T1, T2>
    {
        /// <summary>
        ///     The <see cref="GameObject"/> that owns the components in this tuple.
        /// </summary>
        public GameObject GameObject;

        /// <summary>
        ///     Reference to the first component of type <typeparamref name="T1"/>.
        /// </summary>
        public Ref<T1> Item1;

        /// <summary>
        ///     Reference to the second component of type <typeparamref name="T2"/>.
        /// </summary>
        public Ref<T2> Item2;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject"/> instance.</param>
        /// <param name="ref1">Reference to the first component.</param>
        /// <param name="ref2">Reference to the second component.</param>
        public void Deconstruct(out GameObject gameObject, out Ref<T1> ref1, out Ref<T2> ref2)
        {
            gameObject = GameObject;
            ref1 = Item1;
            ref2 = Item2;
        }
    }

    /// <summary>
    ///     Represents a tuple of references to a <see cref="GameObject"/> and three components,
    ///     typically returned during query enumeration.
    /// </summary>
    /// <typeparam name="T1">The type of the first component reference.</typeparam>
    /// <typeparam name="T2">The type of the second component reference.</typeparam>
    /// <typeparam name="T3">The type of the third component reference.</typeparam>
    public ref struct GameObjectRefTuple<T1, T2, T3>
    {
        /// <summary>
        ///     The <see cref="GameObject"/> that owns the components in this tuple.
        /// </summary>
        public GameObject GameObject;

        /// <summary>
        ///     Reference to the first component of type <typeparamref name="T1"/>.
        /// </summary>
        public Ref<T1> Item1;

        /// <summary>
        ///     Reference to the second component of type <typeparamref name="T2"/>.
        /// </summary>
        public Ref<T2> Item2;

        /// <summary>
        ///     Reference to the third component of type <typeparamref name="T3"/>.
        /// </summary>
        public Ref<T3> Item3;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject"/> instance.</param>
        /// <param name="ref1">Reference to the first component.</param>
        /// <param name="ref2">Reference to the second component.</param>
        /// <param name="ref3">Reference to the third component.</param>
        public void Deconstruct(out GameObject gameObject, out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3)
        {
            gameObject = GameObject;
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
        }
    }

    /// <summary>
    ///     Represents a tuple of references to a <see cref="GameObject"/> and four components,
    ///     typically returned during query enumeration.
    /// </summary>
    /// <typeparam name="T1">The type of the first component reference.</typeparam>
    /// <typeparam name="T2">The type of the second component reference.</typeparam>
    /// <typeparam name="T3">The type of the third component reference.</typeparam>
    /// <typeparam name="T4">The type of the fourth component reference.</typeparam>
    public ref struct GameObjectRefTuple<T1, T2, T3, T4>
    {
        /// <summary>
        ///     The <see cref="GameObject"/> that owns the components in this tuple.
        /// </summary>
        public GameObject GameObject;

        /// <summary>
        ///     Reference to the first component of type <typeparamref name="T1"/>.
        /// </summary>
        public Ref<T1> Item1;

        /// <summary>
        ///     Reference to the second component of type <typeparamref name="T2"/>.
        /// </summary>
        public Ref<T2> Item2;

        /// <summary>
        ///     Reference to the third component of type <typeparamref name="T3"/>.
        /// </summary>
        public Ref<T3> Item3;

        /// <summary>
        ///     Reference to the fourth component of type <typeparamref name="T4"/>.
        /// </summary>
        public Ref<T4> Item4;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject"/> instance.</param>
        /// <param name="ref1">Reference to the first component.</param>
        /// <param name="ref2">Reference to the second component.</param>
        /// <param name="ref3">Reference to the third component.</param>
        /// <param name="ref4">Reference to the fourth component.</param>
        public void Deconstruct(out GameObject gameObject, out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3, out Ref<T4> ref4)
        {
            gameObject = GameObject;
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
            ref4 = Item4;
        }
    }

    /// <summary>
    ///     Represents a tuple of references to a <see cref="GameObject"/> and five components,
    ///     typically returned during query enumeration.
    /// </summary>
    /// <typeparam name="T1">The type of the first component reference.</typeparam>
    /// <typeparam name="T2">The type of the second component reference.</typeparam>
    /// <typeparam name="T3">The type of the third component reference.</typeparam>
    /// <typeparam name="T4">The type of the fourth component reference.</typeparam>
    /// <typeparam name="T5">The type of the fifth component reference.</typeparam>
    public ref struct GameObjectRefTuple<T1, T2, T3, T4, T5>
    {
        /// <summary>
        ///     The <see cref="GameObject"/> that owns the components in this tuple.
        /// </summary>
        public GameObject GameObject;

        /// <summary>
        ///     Reference to the first component of type <typeparamref name="T1"/>.
        /// </summary>
        public Ref<T1> Item1;

        /// <summary>
        ///     Reference to the second component of type <typeparamref name="T2"/>.
        /// </summary>
        public Ref<T2> Item2;

        /// <summary>
        ///     Reference to the third component of type <typeparamref name="T3"/>.
        /// </summary>
        public Ref<T3> Item3;

        /// <summary>
        ///     Reference to the fourth component of type <typeparamref name="T4"/>.
        /// </summary>
        public Ref<T4> Item4;

        /// <summary>
        ///     Reference to the fifth component of type <typeparamref name="T5"/>.
        /// </summary>
        public Ref<T5> Item5;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject"/> instance.</param>
        /// <param name="ref1">Reference to the first component.</param>
        /// <param name="ref2">Reference to the second component.</param>
        /// <param name="ref3">Reference to the third component.</param>
        /// <param name="ref4">Reference to the fourth component.</param>
        /// <param name="ref5">Reference to the fifth component.</param>
        public void Deconstruct(out GameObject gameObject, out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3, out Ref<T4> ref4,
            out Ref<T5> ref5)
        {
            gameObject = GameObject;
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
            ref4 = Item4;
            ref5 = Item5;
        }
    }

    /// <summary>
    ///     Represents a tuple of references to a <see cref="GameObject"/> and six components,
    ///     typically returned during query enumeration.
    /// </summary>
    /// <typeparam name="T1">The type of the first component reference.</typeparam>
    /// <typeparam name="T2">The type of the second component reference.</typeparam>
    /// <typeparam name="T3">The type of the third component reference.</typeparam>
    /// <typeparam name="T4">The type of the fourth component reference.</typeparam>
    /// <typeparam name="T5">The type of the fifth component reference.</typeparam>
    /// <typeparam name="T6">The type of the sixth component reference.</typeparam>
    public ref struct GameObjectRefTuple<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        ///     The <see cref="GameObject"/> that owns the components in this tuple.
        /// </summary>
        public GameObject GameObject;

        /// <summary>
        ///     Reference to the first component of type <typeparamref name="T1"/>.
        /// </summary>
        public Ref<T1> Item1;

        /// <summary>
        ///     Reference to the second component of type <typeparamref name="T2"/>.
        /// </summary>
        public Ref<T2> Item2;

        /// <summary>
        ///     Reference to the third component of type <typeparamref name="T3"/>.
        /// </summary>
        public Ref<T3> Item3;

        /// <summary>
        ///     Reference to the fourth component of type <typeparamref name="T4"/>.
        /// </summary>
        public Ref<T4> Item4;

        /// <summary>
        ///     Reference to the fifth component of type <typeparamref name="T5"/>.
        /// </summary>
        public Ref<T5> Item5;

        /// <summary>
        ///     Reference to the sixth component of type <typeparamref name="T6"/>.
        /// </summary>
        public Ref<T6> Item6;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject"/> instance.</param>
        /// <param name="ref1">Reference to the first component.</param>
        /// <param name="ref2">Reference to the second component.</param>
        /// <param name="ref3">Reference to the third component.</param>
        /// <param name="ref4">Reference to the fourth component.</param>
        /// <param name="ref5">Reference to the fifth component.</param>
        /// <param name="ref6">Reference to the sixth component.</param>
        public void Deconstruct(out GameObject gameObject, out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3, out Ref<T4> ref4,
            out Ref<T5> ref5, out Ref<T6> ref6)
        {
            gameObject = GameObject;
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
            ref4 = Item4;
            ref5 = Item5;
            ref6 = Item6;
        }
    }

    /// <summary>
    ///     Represents a tuple of references to a <see cref="GameObject"/> and seven components,
    ///     typically returned during query enumeration.
    /// </summary>
    /// <typeparam name="T1">The type of the first component reference.</typeparam>
    /// <typeparam name="T2">The type of the second component reference.</typeparam>
    /// <typeparam name="T3">The type of the third component reference.</typeparam>
    /// <typeparam name="T4">The type of the fourth component reference.</typeparam>
    /// <typeparam name="T5">The type of the fifth component reference.</typeparam>
    /// <typeparam name="T6">The type of the sixth component reference.</typeparam>
    /// <typeparam name="T7">The type of the seventh component reference.</typeparam>
    public ref struct GameObjectRefTuple<T1, T2, T3, T4, T5, T6, T7>
    {
        /// <summary>
        ///     The <see cref="GameObject"/> that owns the components in this tuple.
        /// </summary>
        public GameObject GameObject;

        /// <summary>
        ///     Reference to the first component of type <typeparamref name="T1"/>.
        /// </summary>
        public Ref<T1> Item1;

        /// <summary>
        ///     Reference to the second component of type <typeparamref name="T2"/>.
        /// </summary>
        public Ref<T2> Item2;

        /// <summary>
        ///     Reference to the third component of type <typeparamref name="T3"/>.
        /// </summary>
        public Ref<T3> Item3;

        /// <summary>
        ///     Reference to the fourth component of type <typeparamref name="T4"/>.
        /// </summary>
        public Ref<T4> Item4;

        /// <summary>
        ///     Reference to the fifth component of type <typeparamref name="T5"/>.
        /// </summary>
        public Ref<T5> Item5;

        /// <summary>
        ///     Reference to the sixth component of type <typeparamref name="T6"/>.
        /// </summary>
        public Ref<T6> Item6;

        /// <summary>
        ///     Reference to the seventh component of type <typeparamref name="T7"/>.
        /// </summary>
        public Ref<T7> Item7;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject"/> instance.</param>
        /// <param name="ref1">Reference to the first component.</param>
        /// <param name="ref2">Reference to the second component.</param>
        /// <param name="ref3">Reference to the third component.</param>
        /// <param name="ref4">Reference to the fourth component.</param>
        /// <param name="ref5">Reference to the fifth component.</param>
        /// <param name="ref6">Reference to the sixth component.</param>
        /// <param name="ref7">Reference to the seventh component.</param>
        public void Deconstruct(out GameObject gameObject, out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3, out Ref<T4> ref4,
            out Ref<T5> ref5, out Ref<T6> ref6, out Ref<T7> ref7)
        {
            gameObject = GameObject;
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
            ref4 = Item4;
            ref5 = Item5;
            ref6 = Item6;
            ref7 = Item7;
        }
    }

    /// <summary>
    ///     Represents a tuple of references to a <see cref="GameObject"/> and eight components,
    ///     typically returned during query enumeration.
    /// </summary>
    /// <typeparam name="T1">The type of the first component reference.</typeparam>
    /// <typeparam name="T2">The type of the second component reference.</typeparam>
    /// <typeparam name="T3">The type of the third component reference.</typeparam>
    /// <typeparam name="T4">The type of the fourth component reference.</typeparam>
    /// <typeparam name="T5">The type of the fifth component reference.</typeparam>
    /// <typeparam name="T6">The type of the sixth component reference.</typeparam>
    /// <typeparam name="T7">The type of the seventh component reference.</typeparam>
    /// <typeparam name="T8">The type of the eighth component reference.</typeparam>
    /// <remarks>
    ///     Memory layout optimized: <see cref="GameObject"/> struct (8 bytes) + eight <see cref="Ref{T}"/> structs (192 bytes)
    ///     Total: 200 bytes.
    ///     Pack = 4 for optimal alignment.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public ref struct GameObjectRefTuple<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>
        ///     The <see cref="GameObject"/> that owns the components in this tuple.
        /// </summary>
        public GameObject GameObject;

        /// <summary>
        ///     Reference to the first component of type <typeparamref name="T1"/>.
        /// </summary>
        public Ref<T1> Item1;

        /// <summary>
        ///     Reference to the second component of type <typeparamref name="T2"/>.
        /// </summary>
        public Ref<T2> Item2;

        /// <summary>
        ///     Reference to the third component of type <typeparamref name="T3"/>.
        /// </summary>
        public Ref<T3> Item3;

        /// <summary>
        ///     Reference to the fourth component of type <typeparamref name="T4"/>.
        /// </summary>
        public Ref<T4> Item4;

        /// <summary>
        ///     Reference to the fifth component of type <typeparamref name="T5"/>.
        /// </summary>
        public Ref<T5> Item5;

        /// <summary>
        ///     Reference to the sixth component of type <typeparamref name="T6"/>.
        /// </summary>
        public Ref<T6> Item6;

        /// <summary>
        ///     Reference to the seventh component of type <typeparamref name="T7"/>.
        /// </summary>
        public Ref<T7> Item7;

        /// <summary>
        ///     Reference to the eighth component of type <typeparamref name="T8"/>.
        /// </summary>
        public Ref<T8> Item8;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject"/> instance.</param>
        /// <param name="ref1">Reference to the first component.</param>
        /// <param name="ref2">Reference to the second component.</param>
        /// <param name="ref3">Reference to the third component.</param>
        /// <param name="ref4">Reference to the fourth component.</param>
        /// <param name="ref5">Reference to the fifth component.</param>
        /// <param name="ref6">Reference to the sixth component.</param>
        /// <param name="ref7">Reference to the seventh component.</param>
        /// <param name="ref8">Reference to the eighth component.</param>
        public void Deconstruct(out GameObject gameObject, out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3, out Ref<T4> ref4,
            out Ref<T5> ref5, out Ref<T6> ref6, out Ref<T7> ref7, out Ref<T8> ref8)
        {
            gameObject = GameObject;
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
            ref4 = Item4;
            ref5 = Item5;
            ref6 = Item6;
            ref7 = Item7;
            ref8 = Item8;
        }
    }
}