// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IManager.cs
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

using Alis.Core.Ecs.Systems.Execution;

namespace Alis.Core.Ecs.Systems.Manager
{
    /// <summary>
    ///     Defines the contract for all managers in the Alis ECS framework.
    ///     Extends <see cref="IRuntime" /> to ensure managers participate in the game loop lifecycle.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <see cref="IManager" /> is the interface that all system managers (Audio, Graphic, Input,
    ///         Network, Physic, Scene, Time, etc.) implement. It inherits from <see cref="IRuntime" />
    ///         to guarantee that managers expose the full lifecycle callbacks required by the
    ///         <see cref="ContextHandler" />.
    ///     </para>
    ///     <para>
    ///         Concrete implementations should derive from <see cref="AManager" />, which provides
    ///         default no-op implementations for all lifecycle methods and standard properties
    ///         (Id, Name, Tag, Context).
    ///     </para>
    /// </remarks>
    public interface IManager : IRuntime
    {
    }
}