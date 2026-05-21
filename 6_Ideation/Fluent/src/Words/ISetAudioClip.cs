// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ISetAudioClip.cs
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
    ///     Fluent builder interface that assigns a specific audio clip
    ///     to a sound source component.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The audio clip reference — typically a loaded <see cref="AudioClip"/> or resource key.</typeparam>
    /// <remarks>
    ///     This selects which audio asset plays when triggered. Combined with
    ///     <see cref="IAudio"/> for volume/pitch control and <see cref="IPlayOnAwake"/>
    ///     for auto-play behavior.
    /// </remarks>
    public interface ISetAudioClip<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Assigns the audio clip to the builder's audio source.
        /// </summary>
        /// <param name="value">The audio clip reference or resource key to assign.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder SetAudioClip(TArgument value);
    }
}