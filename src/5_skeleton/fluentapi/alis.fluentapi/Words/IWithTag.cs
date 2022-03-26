// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   IWithTag.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.FluentApi.Words
{
    /// <summary>
    ///     Define the word "Tag"
    /// </summary>
    /// <typeparam name="TBuilder">The type of the uilder.</typeparam>
    /// <typeparam name="TArgument">The type of the rgument.</typeparam>
    public interface IWithTag<TBuilder, TArgument>
    {
        /// <summary>Withes the tag.</summary>
        /// <param name="value">The value.</param>
        /// <returns>return the object that you want.</returns>
        public TBuilder WithTag(TArgument value);
    }
}