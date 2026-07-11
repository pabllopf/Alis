using System;
using System.Net.Http;
using Alis.Extension.Updater.Services.Api;
using Xunit;

namespace Alis.Extension.Updater.Test.Services.Api
{
    /// <summary>
    /// The git hub api service remaining test class
    /// </summary>
    public class GitHubApiServiceRemainingTest
    {
        /// <summary>
        /// The testable git hub api service class
        /// </summary>
        /// <seealso cref="GitHubApiService"/>
        private class TestableGitHubApiService : GitHubApiService
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestableGitHubApiService"/> class
            /// </summary>
            /// <param name="apiUrl">The api url</param>
            public TestableGitHubApiService(Uri apiUrl) : base(apiUrl) { }
            /// <summary>
            /// Publics the dispose using the specified disposing
            /// </summary>
            /// <param name="disposing">The disposing</param>
            public void PublicDispose(bool disposing) => Dispose(disposing);
        }

        /// <summary>
        /// Tests that dispose with disposing false does not throw
        /// </summary>
        [Fact]
        public void Dispose_WithDisposingFalse_DoesNotThrow()
        {
            TestableGitHubApiService service = new TestableGitHubApiService(
                new Uri("https://api.github.com/test"));
            service.PublicDispose(false);
        }

        /// <summary>
        /// Tests that constructor with null uri sets api url to null
        /// </summary>
        [Fact]
        public void Constructor_WithNullUri_SetsApiUrlToNull()
        {
            GitHubApiService service = new GitHubApiService(null);
            Assert.Null(service.ApiUrl);
            service.Dispose();
        }

        /// <summary>
        /// Tests that internal constructor with http client uses provided client
        /// </summary>
        [Fact]
        public void InternalConstructor_WithHttpClient_UsesProvidedClient()
        {
            using HttpClient client = new HttpClient();
            Uri apiUrl = new Uri("https://api.github.com/test");
            using GitHubApiService service = new GitHubApiService(apiUrl, client);
            Assert.Equal(apiUrl, service.ApiUrl);
        }
    }
}
