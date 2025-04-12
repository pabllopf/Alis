// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RefTuple.15.cs
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


namespace Alis.Core.Ecs.Operations
{
    /// <summary>
    /// The ref tuple
    /// </summary>
    public ref struct RefTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        /// <summary>
        /// The item
        /// </summary>
        public Ref<T1> Item1;
        /// <summary>
        /// The item
        /// </summary>
        public Ref<T2> Item2;
        /// <summary>
        /// The item
        /// </summary>
        public Ref<T3> Item3;
        /// <summary>
        /// The item
        /// </summary>
        public Ref<T4> Item4;
        /// <summary>
        /// The item
        /// </summary>
        public Ref<T5> Item5;
        /// <summary>
        /// The item
        /// </summary>
        public Ref<T6> Item6;
        /// <summary>
        /// The item
        /// </summary>
        public Ref<T7> Item7;
        /// <summary>
        /// The item
        /// </summary>
        public Ref<T8> Item8;
        /// <summary>
        /// The item
        /// </summary>
        public Ref<T9> Item9;
        /// <summary>
        /// The item 10
        /// </summary>
        public Ref<T10> Item10;
        /// <summary>
        /// The item 11
        /// </summary>
        public Ref<T11> Item11;
        /// <summary>
        /// The item 12
        /// </summary>
        public Ref<T12> Item12;
        /// <summary>
        /// The item 13
        /// </summary>
        public Ref<T13> Item13;
        /// <summary>
        /// The item 14
        /// </summary>
        public Ref<T14> Item14;
        /// <summary>
        /// The item 15
        /// </summary>
        public Ref<T15> Item15;


        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3, out Ref<T4> ref4, out Ref<T5> ref5, out Ref<T6> ref6, out Ref<T7> ref7, out Ref<T8> ref8, out Ref<T9> ref9, out Ref<T10> ref10, out Ref<T11> ref11, out Ref<T12> ref12, out Ref<T13> ref13, out Ref<T14> ref14, out Ref<T15> ref15)
        {
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
            ref4 = Item4;
            ref5 = Item5;
            ref6 = Item6;
            ref7 = Item7;
            ref8 = Item8;
            ref9 = Item9;
            ref10 = Item10;
            ref11 = Item11;
            ref12 = Item12;
            ref13 = Item13;
            ref14 = Item14;
            ref15 = Item15;
        }
    }
}