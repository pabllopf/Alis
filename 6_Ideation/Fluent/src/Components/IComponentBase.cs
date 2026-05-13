// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IComponentBase.cs
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
    ///     Base marker interface for all component interfaces in the fluent game entity system.
    ///     Components implementing this interface are auto-registered for AOT compilation compatibility.
    /// </summary>
    /// <remarks>
    ///     This is a marker-only interface with no members. Derived interfaces define lifecycle hooks
    ///     (e.g., <see cref="IOnUpdate"/>, <see cref="IOnDraw"/>, <see cref="IOnCollisionEnter"/>)
    ///     and behavior contracts for game entities.
    /// </remarks>
    /// <example>
    /// <code>
    /// // A typical component combines multiple marker interfaces:
    /// public struct HealthComponent : IComponentBase, IOnUpdate&lt;float&gt;
    /// {
    ///     public float Value;
    ///     public void Update(IGameObject self, ref float deltaTime) { ... }
    /// }
    /// </code>
    /// </example>
    public interface IComponentBase;
}