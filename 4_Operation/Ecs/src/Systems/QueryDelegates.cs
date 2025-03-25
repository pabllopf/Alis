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
    ///     Delegates for executing a functions on a <see cref="Query" />
    /// </summary>
    public static class QueryDelegates
    {
        /// <summary>
        ///     The query
        /// </summary>
        public delegate void Query<T>(ref T comp1);
        
        public delegate void Query<T1, T2>(ref T1 comp1, ref T2 comp2);
        
        public delegate void Query<T1, T2, T3>(ref T1 comp1, ref T2 comp2, ref T3 comp3);
        
        public delegate void Query<T1, T2, T3, T4>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4);
        
        public delegate void Query<T1, T2, T3, T4, T5>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5);
        
        public delegate void Query<T1, T2, T3, T4, T5, T6>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5, ref T6 comp6);
        
        public delegate void Query<T1, T2, T3, T4, T5, T6, T7>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5, ref T6 comp6, ref T7 comp7);
        
        public delegate void Query<T1, T2, T3, T4, T5, T6, T7, T8>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5, ref T6 comp6, ref T7 comp7, ref T8 comp8);
        
        public delegate void Query<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5, ref T6 comp6, ref T7 comp7, ref T8 comp8, ref T9 comp9);
        
        public delegate void Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5, ref T6 comp6, ref T7 comp7, ref T8 comp8, ref T9 comp9, ref T10 comp10);
        
        public delegate void Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5, ref T6 comp6, ref T7 comp7, ref T8 comp8, ref T9 comp9, ref T10 comp10, ref T11 comp11);
        
        public delegate void Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5, ref T6 comp6, ref T7 comp7, ref T8 comp8, ref T9 comp9, ref T10 comp10, ref T11 comp11, ref T12 comp12);
        
        public delegate void Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5, ref T6 comp6, ref T7 comp7, ref T8 comp8, ref T9 comp9, ref T10 comp10, ref T11 comp11, ref T12 comp12, ref T13 comp13);
        
        public delegate void Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5, ref T6 comp6, ref T7 comp7, ref T8 comp8, ref T9 comp9, ref T10 comp10, ref T11 comp11, ref T12 comp12, ref T13 comp13, ref T14 comp14);
        
        public delegate void Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5, ref T6 comp6, ref T7 comp7, ref T8 comp8, ref T9 comp9, ref T10 comp10, ref T11 comp11, ref T12 comp12, ref T13 comp13, ref T14 comp14, ref T15 comp15);
        
        public delegate void Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5, ref T6 comp6, ref T7 comp7, ref T8 comp8, ref T9 comp9, ref T10 comp10, ref T11 comp11, ref T12 comp12, ref T13 comp13, ref T14 comp14, ref T15 comp15, ref T16 comp16);
            
        
        
    }
}