// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:DropBoxCloudManagerSeamTests.cs
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
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Dropbox.Api;
using Xunit;

namespace Alis.Extension.Cloud.DropBox.Test
{
    /// <summary>
    ///     Covers Dropbox initialization through the injectable client factory.
    /// </summary>
    public class DropBoxCloudManagerSeamTests
    {
        private const string FullAccountJson =
            "{\"name\":{\"display_name\":\"Test User\",\"given_name\":\"Test\",\"surname\":\"User\",\"familiar_name\":\"Test\"}," +
            "\"email\":\"test@example.com\",\"email_verified\":true,\"disabled\":false,\"is_teams\":false," +
            "\"account_id\":\"dbid:test\",\"locale\":\"en\",\"referral_link\":\"https://db.tt/test\"}";

        [Fact]
        public async Task InitializeAsync_WithFactoryReturningStubClient_SetsIsInitializedTrue()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context());

            await manager.InitializeAsync("token", _ => CreateStubClient());

            Assert.True(manager.IsInitialized);
        }

        [Fact]
        public async Task InitializeAsync_WithFactoryThrowing_ResetsStateAndThrows()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), CreateStubClient());
            Assert.True(manager.IsInitialized);

            InvalidOperationException exception = await Assert.ThrowsAsync<InvalidOperationException>(
                () => manager.InitializeAsync("token", _ => throw new InvalidOperationException("factory failed")));

            Assert.Equal("factory failed", exception.Message);
            Assert.False(manager.IsInitialized);
        }

        private static DropboxClient CreateStubClient()
        {
            HttpClient httpClient = new HttpClient(new StubHandler(FullAccountJson));
            return new DropboxClient("sl.test-token", new DropboxClientConfig { HttpClient = httpClient, MaxRetriesOnError = 0 });
        }

        private sealed class StubHandler : HttpMessageHandler
        {
            private readonly string _json;

            public StubHandler(string json) => _json = json;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) =>
                Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(_json, Encoding.UTF8, "application/json")
                });
        }
    }
}
