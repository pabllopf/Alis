using System;
using System.Net.Http;
using Alis.Extension.Updater.Services.Api;
using Xunit;

namespace Alis.Extension.Updater.Test.Services.Api
{
    public class GitHubApiServiceRemainingTest
    {
        private class TestableGitHubApiService : GitHubApiService
        {
            public TestableGitHubApiService(Uri apiUrl) : base(apiUrl) { }
            public void PublicDispose(bool disposing) => Dispose(disposing);
        }

        [Fact]
        public void Dispose_WithDisposingFalse_DoesNotThrow()
        {
            TestableGitHubApiService service = new TestableGitHubApiService(
                new Uri("https://api.github.com/test"));
            service.PublicDispose(false);
        }

        [Fact]
        public void Constructor_WithNullUri_SetsApiUrlToNull()
        {
            GitHubApiService service = new GitHubApiService(null);
            Assert.Null(service.ApiUrl);
            service.Dispose();
        }

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
