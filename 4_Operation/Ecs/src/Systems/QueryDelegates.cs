// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryDelegates.cs
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

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Provides delegate types for executing actions on entity components retrieved through queries.
    /// </summary>
    public static class QueryDelegates
    {
        /// <summary>
        ///     Delegate for executing an action on a single component reference.
        /// </summary>
        /// <typeparam name="T">The type of the component reference.</typeparam>
        /// <param name="comp1">A reference to the component.</param>
        public delegate void Query<T>(ref T comp1);


        /// <summary>
        ///     Delegate for executing an action on two component references.
        /// </summary>
        /// <typeparam name="T1">The type of the first component reference.</typeparam>
        /// <typeparam name="T2">The type of the second component reference.</typeparam>
        /// <param name="comp1">A reference to the first component.</param>
        /// <param name="comp2">A reference to the second component.</param>
        public delegate void Query<T1, T2>(ref T1 comp1, ref T2 comp2);

        /// <summary>
        ///     Delegate for executing an action on three component references.
        /// </summary>
        /// <typeparam name="T1">The type of the first component reference.</typeparam>
        /// <typeparam name="T2">The type of the second component reference.</typeparam>
        /// <typeparam name="T3">The type of the third component reference.</typeparam>
        /// <param name="comp1">A reference to the first component.</param>
        /// <param name="comp2">A reference to the second component.</param>
        /// <param name="comp3">A reference to the third component.</param>
        public delegate void Query<T1, T2, T3>(ref T1 comp1, ref T2 comp2, ref T3 comp3);

        /// <summary>
        ///     Delegate for executing an action on four component references.
        /// </summary>
        /// <typeparam name="T1">The type of the first component reference.</typeparam>
        /// <typeparam name="T2">The type of the second component reference.</typeparam>
        /// <typeparam name="T3">The type of the third component reference.</typeparam>
        /// <typeparam name="T4">The type of the fourth component reference.</typeparam>
        /// <param name="comp1">A reference to the first component.</param>
        /// <param name="comp2">A reference to the second component.</param>
        /// <param name="comp3">A reference to the third component.</param>
        /// <param name="comp4">A reference to the fourth component.</param>
        public delegate void Query<T1, T2, T3, T4>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4);

        /// <summary>
        ///     Delegate for executing an action on five component references.
        /// </summary>
        /// <typeparam name="T1">The type of the first component reference.</typeparam>
        /// <typeparam name="T2">The type of the second component reference.</typeparam>
        /// <typeparam name="T3">The type of the third component reference.</typeparam>
        /// <typeparam name="T4">The type of the fourth component reference.</typeparam>
        /// <typeparam name="T5">The type of the fifth component reference.</typeparam>
        /// <param name="comp1">A reference to the first component.</param>
        /// <param name="comp2">A reference to the second component.</param>
        /// <param name="comp3">A reference to the third component.</param>
        /// <param name="comp4">A reference to the fourth component.</param>
        /// <param name="comp5">A reference to the fifth component.</param>
        public delegate void Query<T1, T2, T3, T4, T5>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5);

        /// <summary>
        ///     Delegate for executing an action on six component references.
        /// </summary>
        /// <typeparam name="T1">The type of the first component reference.</typeparam>
        /// <typeparam name="T2">The type of the second component reference.</typeparam>
        /// <typeparam name="T3">The type of the third component reference.</typeparam>
        /// <typeparam name="T4">The type of the fourth component reference.</typeparam>
        /// <typeparam name="T5">The type of the fifth component reference.</typeparam>
        /// <typeparam name="T6">The type of the sixth component reference.</typeparam>
        /// <param name="comp1">A reference to the first component.</param>
        /// <param name="comp2">A reference to the second component.</param>
        /// <param name="comp3">A reference to the third component.</param>
        /// <param name="comp4">A reference to the fourth component.</param>
        /// <param name="comp5">A reference to the fifth component.</param>
        /// <param name="comp6">A reference to the sixth component.</param>
        public delegate void Query<T1, T2, T3, T4, T5, T6>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4,
            ref T5 comp5, ref T6 comp6);

        /// <summary>
        ///     Delegate for executing an action on seven component references.
        /// </summary>
        /// <typeparam name="T1">The type of the first component reference.</typeparam>
        /// <typeparam name="T2">The type of the second component reference.</typeparam>
        /// <typeparam name="T3">The type of the third component reference.</typeparam>
        /// <typeparam name="T4">The type of the fourth component reference.</typeparam>
        /// <typeparam name="T5">The type of the fifth component reference.</typeparam>
        /// <typeparam name="T6">The type of the sixth component reference.</typeparam>
        /// <typeparam name="T7">The type of the seventh component reference.</typeparam>
        /// <param name="comp1">A reference to the first component.</param>
        /// <param name="comp2">A reference to the second component.</param>
        /// <param name="comp3">A reference to the third component.</param>
        /// <param name="comp4">A reference to the fourth component.</param>
        /// <param name="comp5">A reference to the fifth component.</param>
        /// <param name="comp6">A reference to the sixth component.</param>
        /// <param name="comp7">A reference to the seventh component.</param>
        public delegate void Query<T1, T2, T3, T4, T5, T6, T7>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4,
            ref T5 comp5, ref T6 comp6, ref T7 comp7);

        /// <summary>
        ///     Delegate for executing an action on eight component references.
        /// </summary>
        /// <typeparam name="T1">The type of the first component reference.</typeparam>
        /// <typeparam name="T2">The type of the second component reference.</typeparam>
        /// <typeparam name="T3">The type of the third component reference.</typeparam>
        /// <typeparam name="T4">The type of the fourth component reference.</typeparam>
        /// <typeparam name="T5">The type of the fifth component reference.</typeparam>
        /// <typeparam name="T6">The type of the sixth component reference.</typeparam>
        /// <typeparam name="T7">The type of the seventh component reference.</typeparam>
        /// <typeparam name="T8">The type of the eighth component reference.</typeparam>
        /// <param name="comp1">A reference to the first component.</param>
        /// <param name="comp2">A reference to the second component.</param>
        /// <param name="comp3">A reference to the third component.</param>
        /// <param name="comp4">A reference to the fourth component.</param>
        /// <param name="comp5">A reference to the fifth component.</param>
        /// <param name="comp6">A reference to the sixth component.</param>
        /// <param name="comp7">A reference to the seventh component.</param>
        /// <param name="comp8">A reference to the eighth component.</param>
        public delegate void Query<T1, T2, T3, T4, T5, T6, T7, T8>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4,
            ref T5 comp5, ref T6 comp6, ref T7 comp7, ref T8 comp8);
    }
}