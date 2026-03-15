using System;
using Xunit;
using Alis.Extension.Updater.Services.Api;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    /// The git hub api service test class
    /// </summary>
    public class GitHubApiServiceTest
    {
        /// <summary>
        /// Tests that constructor assigns api url
        /// </summary>
        [Fact]
        public void Constructor_AssignsApiUrl()
        {
            Uri apiUrl = new Uri("http://127.0.0.1:50321/");

            using GitHubApiService service = new GitHubApiService(apiUrl);

            Assert.Equal(apiUrl, service.ApiUrl);
        }
    }
}

