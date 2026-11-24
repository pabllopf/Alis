// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:UpdateManagerSeamCoverageTests.cs
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
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Updater.Services.Api;
using Alis.Extension.Updater.Services.Files;
using Moq;
using Xunit;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    ///     Covers the platform, HTTP and shell boundaries through internal injection seams.
    /// </summary>
    public class UpdateManagerSeamCoverageTests
    {
        [Fact]
        public void ResolvePlatform_Windows_ReturnsWin() => Assert.Equal("win", UpdateManager.ResolvePlatform(true, false, false));

        [Fact]
        public void ResolvePlatform_Linux_ReturnsLinux() => Assert.Equal("linux", UpdateManager.ResolvePlatform(false, true, false));

        [Fact]
        public void ResolvePlatform_Osx_ReturnsOsx() => Assert.Equal("osx", UpdateManager.ResolvePlatform(false, false, true));

        [Fact]
        public void ResolvePlatform_Unsupported_Throws()
        {
            PlatformNotSupportedException exception = Assert.Throws<PlatformNotSupportedException>(() => UpdateManager.ResolvePlatform(false, false, false));

            Assert.Equal("Platform not supported.", exception.Message);
        }

        [Fact]
        public async Task GetLatestReleaseAsync_UsesInjectedClient_AndSetsUserAgent()
        {
            RecordingHandler handler = new RecordingHandler("{}");
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(new Uri("https://example.test/releases"));
            UpdateManager manager = CreateManager(api.Object, "v0.7.5", handler: handler);

            await manager.GetLatestReleaseAsync();

            Assert.Equal("request", handler.UserAgent);
            Assert.Equal("https://example.test/releases", handler.RequestUri);
        }

        [Fact]
        public async Task GetLatestReleaseAsync_HttpFailure_Throws()
        {
            RecordingHandler handler = new RecordingHandler("{}", fail: true);
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(new Uri("https://example.test/releases"));
            UpdateManager manager = CreateManager(api.Object, "latest", handler: handler);

            await Assert.ThrowsAsync<HttpRequestException>(() => manager.GetLatestReleaseAsync());
        }

        [Fact]
        public async Task DownloadFileAsync_UsesInjectedClient_WritesPayload()
        {
            string fileName = "alis-seam-" + Guid.NewGuid().ToString("N") + ".bin";
            string url = "https://example.test/downloads/" + fileName;
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            RecordingHandler handler = new RecordingHandler("seam payload");
            UpdateManager manager = CreateManager(Mock.Of<IGitHubApiService>(), "latest", handler: handler);
            try
            {
                string result = await manager.DownloadFileAsync(url);

                Assert.Equal(filePath, result);
                Assert.Equal("seam payload", File.ReadAllText(filePath));
                Assert.Equal(url, handler.RequestUri);
            }
            finally
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        [Fact]
        public async Task DownloadFileAsync_HttpFailure_Throws()
        {
            string fileName = "alis-seam-fail-" + Guid.NewGuid().ToString("N") + ".bin";
            string url = "https://example.test/downloads/" + fileName;
            RecordingHandler handler = new RecordingHandler(string.Empty, fail: true);
            UpdateManager manager = CreateManager(Mock.Of<IGitHubApiService>(), "latest", handler: handler);

            await Assert.ThrowsAsync<HttpRequestException>(() => manager.DownloadFileAsync(url));
        }

        [Fact]
        public void DmgHelpers_UseInjectedShellExecutor()
        {
            List<string> commands = new List<string>();
            UpdateManager manager = CreateManager(Mock.Of<IGitHubApiService>(), "latest", shellExecutor: commands.Add);

            manager.MountDmg("/tmp/sample.dmg", "/Volumes/sample");
            manager.CopyMountedDmgToProgramFolder("/Volumes/sample");
            manager.UnmountDmg("/Volumes/sample");

            Assert.Equal(new[]
            {
                "hdiutil attach \"/tmp/sample.dmg\" -nobrowse -mountpoint \"/Volumes/sample\"",
                "cp -R \"/Volumes/sample/.\" \"" + manager.ProgramFolder + "\"",
                "hdiutil detach \"/Volumes/sample\""
            }, commands);
        }

        [Fact]
        public void ResolvePlatform_MatchesCurrentHost()
        {
            string expected = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? "win"
                : RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "linux" : "osx";

            Assert.Equal(expected, UpdateManager.ResolvePlatform(
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows),
                RuntimeInformation.IsOSPlatform(OSPlatform.Linux),
                RuntimeInformation.IsOSPlatform(OSPlatform.OSX)));
        }

        private static UpdateManager CreateManager(
            IGitHubApiService api,
            string version,
            RecordingHandler handler = null,
            Action<string> shellExecutor = null)
        {
            UpdateManager manager = new UpdateManager(
                api,
                version,
                Mock.Of<IFileService>(),
                Path.Combine(Path.GetTempPath(), "alis-update-seam"),
                () => new HttpClient(handler ?? new RecordingHandler("{}")),
                shellExecutor ?? (_ => { }));
            manager.ContinueDelayMilliseconds = 0;
            return manager;
        }

        private sealed class RecordingHandler : HttpMessageHandler
        {
            private readonly string _content;
            private readonly bool _fail;

            public RecordingHandler(string content, bool fail = false)
            {
                _content = content;
                _fail = fail;
            }

            public string RequestUri { get; private set; }

            public string UserAgent { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestUri = request.RequestUri.ToString();
                if (request.Headers.TryGetValues("User-Agent", out IEnumerable<string> values))
                {
                    UserAgent = string.Join(",", values);
                }

                if (_fail)
                {
                    throw new HttpRequestException("injected failure");
                }

                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(_content)
                });
            }
        }
    }
}
