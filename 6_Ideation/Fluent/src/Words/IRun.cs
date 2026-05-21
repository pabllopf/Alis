// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IRun.cs
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

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder terminal interface that executes the configured
    ///     entity pipeline or action chain.
    /// </summary>
    /// <remarks>
    ///     Calling <c>Run()</c> finalizes the fluent chain — it validates the configuration,
    ///     creates the entity (if applicable), and triggers any registered behaviors.
    ///     After <c>Run()</c>, the builder state is typically consumed and cannot be reused.
    /// </remarks>
    public interface IRun
    {
        /// <summary>
        ///     Executes the configured builder pipeline and creates or modifies the target entity.
        ///     This is the terminal operation in a fluent chain.
        /// </summary>
        void Run();
    }
}