using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Updater.Services.Api;
using Moq;
using Moq.Protected;
using Xunit;

namespace Alis.Extension.Updater.Test.Services.Api
{
    public class GitHubApiServiceRemainingCoverageTests
    {
        [Fact]
        public async Task GetLatestReleaseAsync_ReturnsResponseDictionary()
        {
            Uri apiUrl = new Uri("https://api.github.com/repos/test/test/releases/latest");
            string expected = "{\"tag_name\": \"v1.0.0\"}";

            Mock<HttpMessageHandler> handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expected)
                });

            using HttpClient httpClient = new HttpClient(handler.Object);
            using GitHubApiService service = new GitHubApiService(apiUrl, httpClient);

            Dictionary<string, object> result = await service.GetLatestReleaseAsync();

            Assert.NotNull(result);
            Assert.True(result.ContainsKey("response"));
            Assert.Equal(expected, result["response"]);
        }

        [Fact]
        public async Task GetLatestReleaseAsync_SetsUserAgentHeader()
        {
            Uri apiUrl = new Uri("https://api.github.com/repos/test/test/releases/latest");

            Mock<HttpMessageHandler> handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{}")
                });

            using HttpClient httpClient = new HttpClient(handler.Object);
            using GitHubApiService service = new GitHubApiService(apiUrl, httpClient);

            await service.GetLatestReleaseAsync();

            handler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Headers.UserAgent.ToString() == "request"),
                ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task GetLatestReleaseAsync_UsesCorrectApiUrl()
        {
            Uri apiUrl = new Uri("https://api.github.com/repos/test/test/releases/latest");

            Mock<HttpMessageHandler> handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{}")
                });

            using HttpClient httpClient = new HttpClient(handler.Object);
            using GitHubApiService service = new GitHubApiService(apiUrl, httpClient);

            await service.GetLatestReleaseAsync();

            handler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.RequestUri == apiUrl),
                ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task GetLatestReleaseAsync_ThrowsOnHttpError()
        {
            Uri apiUrl = new Uri("https://api.github.com/repos/test/test/releases/latest");

            Mock<HttpMessageHandler> handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound
                });

            using HttpClient httpClient = new HttpClient(handler.Object);
            using GitHubApiService service = new GitHubApiService(apiUrl, httpClient);

            await Assert.ThrowsAsync<HttpRequestException>(() => service.GetLatestReleaseAsync());
        }

        [Fact]
        public async Task GetLatestReleaseAsync_WithEmptyResponse_ReturnsEmptyString()
        {
            Uri apiUrl = new Uri("https://api.github.com/repos/test/test/releases/latest");

            Mock<HttpMessageHandler> handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(string.Empty)
                });

            using HttpClient httpClient = new HttpClient(handler.Object);
            using GitHubApiService service = new GitHubApiService(apiUrl, httpClient);

            Dictionary<string, object> result = await service.GetLatestReleaseAsync();

            Assert.NotNull(result);
            Assert.Equal(string.Empty, result["response"]);
        }

        [Fact]
        public void InternalConstructor_WithNullHttpClient_CreatesDefaultClient()
        {
            Uri apiUrl = new Uri("https://api.github.com/repos/test/test/releases/latest");

            using GitHubApiService service = new GitHubApiService(apiUrl, null);

            Assert.NotNull(service);
            Assert.Equal(apiUrl, service.ApiUrl);
        }

        [Fact]
        public void Dispose_CalledAfterHttpClientDisposed_DoesNotThrow()
        {
            Uri apiUrl = new Uri("https://api.github.com/test");
            GitHubApiService service = new GitHubApiService(apiUrl);

            service.Dispose();
            service.Dispose();
        }
    }
}
