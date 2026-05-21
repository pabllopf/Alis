

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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
        public GitHubApiService(Uri apiUrl)
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
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Gets the latest release
        /// </summary>
        /// <returns>A task containing a dictionary of string and object</returns>
        public async Task<Dictionary<string, object>> GetLatestReleaseAsync()
        {
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "request");
            string response = await _httpClient.GetStringAsync(ApiUrl);
            return new Dictionary<string, object>
            {
                {"response", response}
            };
        }

        /// <summary>
        ///     Gets the value of the api url
        /// </summary>
        public Uri ApiUrl { get; }
    }
}