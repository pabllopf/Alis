

using System;
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
        Uri ApiUrl { get; }

        /// <summary>
        ///     Gets the latest release using the specified api url
        /// </summary>
        /// <returns>A task containing a dictionary of string and object</returns>
        Task<Dictionary<string, object>> GetLatestReleaseAsync();
    }
}