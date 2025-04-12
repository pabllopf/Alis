// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IInitable.cs
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

namespace Alis.Core.Ecs.Comps
{
    /// <summary>
    ///     Marks a component to have a <see cref="Init(GameObject)" /> method to be called at the start of a component
    ///     lifetime.
    /// </summary>
    public interface IInitable
    {
        /// <summary>
        ///     This method is called whenever a component begins its lifetime, whether by any
        ///     <see cref="GameObject.Add{T}(in T)" />
        ///     method or any <see cref="Scene.Create{T}(in T)" /> method (but not <see cref="Scene.CreateMany{T}(int)" />).
        /// </summary>
        /// <param name="self">The <see cref="GameObject" /> this component belongs to.</param>
        void Init(GameObject self);
    }
}