// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAds.cs
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
    ///     Fluent builder interface that configures advertising and monetization settings
    ///     for a game entity or application.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The ads configuration type, typically containing ad placement IDs and display settings.</typeparam>
    /// <remarks>
    ///     Use this interface to configure banner ads, interstitial ads, rewarded videos,
    ///     or other monetization channels. The argument type typically includes ad unit IDs
    ///     for platforms such as Google AdMob, Unity Ads, or similar services.
    /// </remarks>
    public interface IAds<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures advertising settings on the builder.
        /// </summary>
        /// <param name="value">The ads configuration object containing placement IDs, test mode flags, and display options.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Ads(TArgument value);
    }
}