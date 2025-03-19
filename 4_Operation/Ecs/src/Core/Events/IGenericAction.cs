// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IGenericAction.cs
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

namespace Alis.Core.Ecs.Core.Events
{
    /// <summary>
    ///     An generic action with known parameter
    /// </summary>
    /// <remarks>Since delegates cannot be unbound generics, we use an interface instead</remarks>
    /// <typeparam name="TParam">The first parameter, which is normally bound</typeparam>
    public interface IGenericAction<TParam>
    {
        /// <summary>
        ///     Runs the arbitrary generic method that this <see cref="IGenericAction{TParam}" /> represents
        /// </summary>
        /// <typeparam name="T">The unbound generic parameter</typeparam>
        /// <param name="param">The first parameter</param>
        /// <param name="type">The generic parameter</param>
        public void Invoke<T>(TParam param, ref T type);
    }

    /// <summary>
    ///     An generic action with known parameter
    /// </summary>
    /// <remarks>Since delegates cannot be unbound generics, we use an interface instead</remarks>
    public interface IGenericAction
    {
        /// <summary>
        ///     Runs the arbitrary generic method that this <see cref="IGenericAction" /> represents
        /// </summary>
        /// <typeparam name="T">The unbound generic parameter</typeparam>
        /// <param name="type">The generic parameter</param>
        public void Invoke<T>(ref T type);
    }
}