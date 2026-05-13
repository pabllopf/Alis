// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:OnCollisionEventHandler.cs
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

using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     Represents a callback that is invoked when a collision between two fixtures is detected.
    ///     The delegate can return <c>false</c> to prevent the collision from being processed,
    ///     providing a runtime option to ignore specific collision pairs.
    /// </summary>
    /// <param name="sender">The fixture on the first body involved in the collision.</param>
    /// <param name="other">The fixture on the second body involved in the collision.</param>
    /// <param name="contact">The contact object describing the collision manifold.</param>
    /// <returns><c>true</c> to process the collision; <c>false</c> to ignore it.</returns>
    public delegate bool OnCollisionEventHandler(Fixture sender, Fixture other, Contact contact);
}