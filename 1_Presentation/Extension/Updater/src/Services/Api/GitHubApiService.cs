// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GitHubApiService.cs
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

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Updater.Services.Api
{
    /// <summary>
    ///     The git hub api service class
    /// </summary>
    /// <seealso cref="IGitHubApiService" />
    public class GitHubApiService : IGitHubApiService, IDisposable
    {
        /// <summary>
        ///     The http client
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GitHubApiService" /> class
        /// </summary>
        /// <param name="apiUrl"></param>
        public GitHubApiService(string apiUrl)
        {
            _httpClient = new HttpClient();
            ApiUrl = apiUrl;
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        /// <summary>
        ///     Gets the latest release
        /// </summary>
        /// <returns>A task containing a dictionary of string and object</returns>
        public async Task<Dictionary<string, object>> GetLatestReleaseAsync()
        {
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "request");
            string response = await _httpClient.GetStringAsync(ApiUrl);
            return JsonSerializer.Deserialize<Dictionary<string, object>>(response);
        }

        /// <summary>
        ///     Gets the value of the api url
        /// </summary>
        public string ApiUrl { get; }
    }
}