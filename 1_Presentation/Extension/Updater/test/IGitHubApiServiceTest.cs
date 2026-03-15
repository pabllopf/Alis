using System;
using Xunit;
using Alis.Extension.Updater.Services.Api;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    /// The git hub api service test class
    /// </summary>
    public class IGitHubApiServiceTest
    {
        /// <summary>
        /// Tests that git hub api service implements i git hub api service
        /// </summary>
        [Fact]
        public void GitHubApiService_Implements_IGitHubApiService()
        {
            using GitHubApiService service = new GitHubApiService(new Uri("http://127.0.0.1:50322/"));
            Assert.IsAssignableFrom<IGitHubApiService>(service);
        }
    }
}
