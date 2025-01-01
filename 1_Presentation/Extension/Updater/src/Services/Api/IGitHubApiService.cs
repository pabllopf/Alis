// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IGitHubApiService.cs
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

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alis.Extension.Updater.Services.Api
{
    /// <summary>
    ///     The git hub api service interface
    /// </summary>
    public interface IGitHubApiService
    {
        /// <summary>
        ///     Gets the value of the api url
        /// </summary>
        string apiUrl { get; }

        /// <summary>
        ///     Gets the latest release using the specified api url
        /// </summary>
        /// <returns>A task containing a dictionary of string and object</returns>
        Task<Dictionary<string, object>> GetLatestReleaseAsync();
    }
}