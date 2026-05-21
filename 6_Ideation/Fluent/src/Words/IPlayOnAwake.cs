// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IPlayOnAwake.cs
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
    ///     Fluent builder interface that configures whether an audio clip,
    ///     animation, or system starts playing automatically when activated.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The play-on-awake setting — typically <see langword="true"/> or <see langword="false"/>.</typeparam>
    /// <remarks>
    ///     Commonly used for audio sources (music, ambient sounds) and animations
    ///     that should begin without an explicit <c>Play()</c> call. When <c>false</c>,
    ///     the asset remains paused until manually triggered.
    /// </remarks>
    public interface IPlayOnAwake<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets whether the asset should begin playing automatically when activated.
        /// </summary>
        /// <param name="value"><see langword="true"/> to play immediately on activation; <see langword="false"/> to remain paused.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder PlayOnAwake(TArgument value);
    }
}