// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IFilePath.cs
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
    ///     Fluent builder interface that sets a file system path or resource path
    ///     on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The path type, typically <see cref="string"/> representing a file or resource path.</typeparam>
    /// <remarks>
    ///     Used to specify paths for assets, configuration files, level data, or log output.
    ///     The path may be absolute, relative to the application root, or a virtual resource path.
    /// </remarks>
    public interface IFilePath<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the file or resource path on the builder.
        /// </summary>
        /// <param name="value">The file path or resource path to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder File(TArgument value);
    }
}