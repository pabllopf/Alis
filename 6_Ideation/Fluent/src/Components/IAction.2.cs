// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAction.2.cs
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

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Defines a fluent action delegate that operates on 2 arguments
    ///     of types TArg1, TArg2.
    /// </summary>
    /// <typeparam name="TArg1">The type of the 1st argument passed to the action.</typeparam>
    /// <typeparam name="TArg2">The type of the 2nd argument passed to the action.</typeparam>
    public partial interface IAction<TArg1, TArg2>
    {
        /// <summary>
        ///     Executes the action with the provided 2 arguments, passed by reference.
        /// </summary>
        /// <param name="arg1">The 1st action argument of type <typeparamref name="TArg1"/>, passed by reference so the action can mutate it.</param>
        /// <param name="arg2">The 2nd action argument of type <typeparamref name="TArg2"/>, passed by reference so the action can mutate it.</param>
        void Run(ref TArg1 arg1, ref TArg2 arg2);
    }
}