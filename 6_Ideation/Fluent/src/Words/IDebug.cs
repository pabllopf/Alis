// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IDebug.cs
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
    ///     Fluent builder interface that toggles or configures debug visualization
    ///     and diagnostic overlays for development builds.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The debug configuration type — a boolean toggle, debug flags enum, or debug settings object.</typeparam>
    /// <remarks>
    ///     Debug options may include bounding box visualization, collision wireframes,
    ///     FPS counters, or entity inspector panels. Debug features are typically
    ///     compiled out in release builds. Related interface: <see cref="IDebugColor"/>.
    /// </remarks>
    public interface IDebug<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures debug visualization settings on the builder.
        /// </summary>
        /// <param name="value">The debug configuration — enable/disable toggle, debug flags, or settings object.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Debug(TArgument value);
    }
}