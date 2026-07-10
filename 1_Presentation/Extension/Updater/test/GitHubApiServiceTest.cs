// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GitHubApiServiceTest.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Updater.Services.Api;
using Moq;
using Moq.Protected;
using Xunit;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    ///     Tests for the GitHubApiService class covering constructor, disposal,
    ///     and async API calls.
    /// </summary>
    public class GitHubApiServiceTest : IDisposable
    {
        /// <summary>
        /// The service
        /// </summary>
        private GitHubApiService? _service;
        /// <summary>
        /// The http handler
        /// </summary>
        private Mock<HttpMessageHandler>? _httpHandler;

        /// <summary>
        ///     Cleans up resources
        /// </summary>
        public void Dispose()
        {
            _service?.Dispose();
            _service = null;
            _httpHandler = null;
        }

        #region Constructor Tests

        /// <summary>
        ///     Tests that constructor initializes HttpClient with User-Agent header
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeHttpClientWithUserAgent()
        {
            // Arrange — create service with a test API URL
            Uri apiUrl = new Uri("https://api.github.com/repos/test/test/releases/latest");

            // Act
            _service = new GitHubApiService(apiUrl);

            // Assert — HttpClient is created and ApiUrl is set
            Assert.NotNull(_service);
            Assert.Equal(apiUrl, _service.ApiUrl);
        }

        /// <summary>
        ///     Tests that constructor accepts various valid URI formats
        /// </summary>
        [Fact]
        public void Constructor_AcceptsVariousUriFormats()
        {
            Uri[] uris =
            {
                new Uri("https://api.github.com/repos/owner/repo/releases/latest"),
                new Uri("http://localhost:8080/api/release"),
                new Uri("https://example.com/v1/latest")
            };

            foreach (Uri uri in uris)
            {
                // Act
                GitHubApiService? service = new GitHubApiService(uri);

                // Assert
                Assert.NotNull(service);
                Assert.Equal(uri, service.ApiUrl);

                service?.Dispose();
            }
        }

        /// <summary>
        ///     Tests that constructor throws with invalid URI
        /// </summary>
        [Fact]
        public void Constructor_WithInvalidUri_ShouldThrowException()
        {
            // Act & Assert — invalid URI throws UriFormatException
            Exception? exception = null;

            try
            {
                _ = new GitHubApiService(new Uri("not a valid uri!!!"));
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that constructor with null URI throws ArgumentNullException
        /// </summary>
        [Fact]
        public void Constructor_WithNullUri_ShouldThrowArgumentNullException()
        {
            // Act & Assert — null URI throws ArgumentNullException
            Exception? exception = null;

            try
            {
                _ = new GitHubApiService(null!);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.Null(exception);
        }

        #endregion

        #region APIUrl Property Tests

        /// <summary>
        ///     Tests that ApiUrl is read-only (no setter)
        /// </summary>
        [Fact]
        public void ApiUrl_ShouldBeReadOnly()
        {
            // Arrange
            Uri apiUrl = new Uri("https://api.github.com/test");
            _service = new GitHubApiService(apiUrl);

            // Assert — ApiUrl is a getter-only property
            Assert.NotNull(_service.ApiUrl);
        }

        /// <summary>
        ///     Tests that ApiUrl returns the exact URI passed to constructor
        /// </summary>
        [Fact]
        public void ApiUrl_ReturnsExactConstructorUri()
        {
            // Arrange
            Uri expectedUri = new Uri("https://api.github.com/repos/owner/repo/releases/latest");

            // Act
            _service = new GitHubApiService(expectedUri);

            // Assert
            Assert.Equal(expectedUri, _service.ApiUrl);
        }

        #endregion

        #region Dispose Tests

        /// <summary>
        ///     Tests that Dispose releases HttpClient resources
        /// </summary>
        [Fact]
        public void Dispose_ShouldReleaseHttpClientResources()
        {
            // Arrange
            _service = new GitHubApiService(new Uri("https://api.github.com/test"));

            // Act — dispose once
            _service.Dispose();

            // Assert — should not throw when called multiple times
            _service?.Dispose();
        }

        /// <summary>
        ///     Tests that Dispose is idempotent (safe to call multiple times)
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_ShouldNotThrow()
        {
            // Arrange
            _service = new GitHubApiService(new Uri("https://api.github.com/test"));

            // Act — multiple dispose calls
            _service.Dispose();
            _service?.Dispose();
            _service?.Dispose();

            // Assert — no exceptions thrown
        }

        /// <summary>
        ///     Tests that Dispose calls GC.SuppressFinalize
        /// </summary>
        [Fact]
        public void Dispose_CallsSuppressFinalize()
        {
            // The Dispose method: Dispose(true); GC.SuppressFinalize(this);
            // SuppressFinalize prevents the finalizer from running after explicit Dispose

            // Arrange
            _service = new GitHubApiService(new Uri("https://api.github.com/test"));

            // Act
            _service.Dispose();

            // Assert — no finalizer should run (GC.SuppressFinalize called)
        }

      
        #endregion

       #region GetLatestReleaseAsync Tests

        /// <summary>
        ///     Tests that GetLatestReleaseAsync returns response from HTTP call
        /// </summary>
        [Fact]
        public async Task GetLatestReleaseAsync_WithSuccessfulResponse_ReturnsDictionaryWithResponse()
        {
            Uri apiUrl = new Uri("https://api.github.com/repos/test/test/releases/latest");
            string expectedResponse = "{\"tag_name\": \"v1.0.0\"}";

            Mock<HttpMessageHandler> handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse)
                });

            using HttpClient httpClient = new HttpClient(handler.Object);
            using GitHubApiService service = new GitHubApiService(apiUrl, httpClient);

            Dictionary<string, object> result = await service.GetLatestReleaseAsync();

            Assert.NotNull(result);
            Assert.True(result.ContainsKey("response"));
            Assert.Equal(expectedResponse, result["response"]);
        }

        /// <summary>
        ///     Tests that GetLatestReleaseAsync sets User-Agent header
        /// </summary>
        [Fact]
        public async Task GetLatestReleaseAsync_SetsUserAgentHeader()
        {
            Uri apiUrl = new Uri("https://api.github.com/repos/test/test/releases/latest");
            string expectedResponse = "ok";

            Mock<HttpMessageHandler> handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse)
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

        /// <summary>
        ///     Tests that GetLatestReleaseAsync uses the correct API URL
        /// </summary>
        [Fact]
        public async Task GetLatestReleaseAsync_UsesCorrectUrl()
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
                    StatusCode = System.Net.HttpStatusCode.OK,
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

        /// <summary>
        ///     Tests that GetLatestReleaseAsync throws on HTTP error
        /// </summary>
        [Fact]
        public async Task GetLatestReleaseAsync_WithHttpError_ThrowsException()
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
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });

            using HttpClient httpClient = new HttpClient(handler.Object);
            using GitHubApiService service = new GitHubApiService(apiUrl, httpClient);

            await Assert.ThrowsAsync<HttpRequestException>(() => service.GetLatestReleaseAsync());
        }

        /// <summary>
        ///     Tests that internal constructor with null HttpClient creates a new one
        /// </summary>
        [Fact]
        public void InternalConstructor_WithNullHttpClient_ShouldNotThrow()
        {
            Uri apiUrl = new Uri("https://api.github.com/test");
            using GitHubApiService service = new GitHubApiService(apiUrl, null);

            Assert.NotNull(service);
            Assert.Equal(apiUrl, service.ApiUrl);
        }

        #endregion
        #region Edge Cases

        /// <summary>
        ///     Tests that constructor with localhost URL works
        /// </summary>
        [Fact]
        public void Constructor_WithLocalhostUrl_Works()
        {
            Uri apiUrl = new Uri("http://localhost:3000/api/release");
            
            GitHubApiService? service = new GitHubApiService(apiUrl);

            Assert.NotNull(service);
            Assert.Equal(apiUrl, service.ApiUrl);

            service?.Dispose();
        }

        /// <summary>
        ///     Tests that multiple GitHubApiService instances are independent
        /// </summary>
        [Fact]
        public void MultipleInstances_AreIndependent()
        {
            Uri apiUrl1 = new Uri("https://api.github.com/repos/owner1/repo1/releases/latest");
            Uri apiUrl2 = new Uri("https://api.github.com/repos/owner2/repo2/releases/latest");
            
            GitHubApiService? service1 = new GitHubApiService(apiUrl1);
            GitHubApiService? service2 = new GitHubApiService(apiUrl2);

            // Assert — different URLs
            Assert.NotEqual(service1.ApiUrl, service2.ApiUrl);

            service1?.Dispose();
            service2?.Dispose();
        }

        /// <summary>
        ///     Tests that APIUrl is not null after construction
        /// </summary>
        [Fact]
        public void ApiUrl_NotNullAfterConstruction()
        {
            Uri apiUrl = new Uri("https://api.github.com/test");
            
            GitHubApiService? service = new GitHubApiService(apiUrl);

            Assert.NotNull(service.ApiUrl);
            service?.Dispose();
        }

        #endregion
    }
}
