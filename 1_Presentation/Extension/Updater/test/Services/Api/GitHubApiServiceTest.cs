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
using System.Threading.Tasks;
using Alis.Extension.Updater.Services.Api;
using Xunit;

namespace Alis.Extension.Updater.Test.Services.Api
{
    /// <summary>
    ///     The git hub api service test class
    /// </summary>
    public class GitHubApiServiceTest : IDisposable
    {
        private GitHubApiService _service;

        public GitHubApiServiceTest()
        {
            _service = new GitHubApiService(new Uri("https://api.github.com/repos/test/test/releases/latest"));
        }

        public void Dispose()
        {
            _service?.Dispose();
        }

        /// <summary>
        ///     Tests that constructor initializes the service with the correct API URL
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithCorrectApiUrl()
        {
            Uri expectedUrl = new Uri("https://api.github.com/repos/test/test/releases/latest");

            Assert.Equal(expectedUrl, _service.ApiUrl);
        }

        /// <summary>
        ///     Tests that constructor with different URL works
        /// </summary>
        [Fact]
        public void Constructor_WithDifferentUrl_ShouldStoreCorrectly()
        {
            GitHubApiService service = new GitHubApiService(new Uri("https://custom.api.com/v1"));

            Assert.Equal(new Uri("https://custom.api.com/v1"), service.ApiUrl);
        }

        /// <summary>
        ///     Tests that ApiUrl property is readable
        /// </summary>
        [Fact]
        public void ApiUrl_ShouldBeReadable()
        {
            Uri url = _service.ApiUrl;

            Assert.NotNull(url);
            Assert.True(url.IsAbsoluteUri);
        }

        /// <summary>
        ///     Tests that Dispose does not throw
        /// </summary>
        [Fact]
        public void Dispose_ShouldNotThrow()
        {
            Assert.NotNull(_service);

            _service.Dispose();

            // No exception means success
        }

        /// <summary>
        ///     Tests that multiple Dispose calls do not throw
        /// </summary>
        [Fact]
        public void MultipleDisposeCalls_ShouldNotThrow()
        {
            Assert.NotNull(_service);

            _service.Dispose();
            _service.Dispose();
            _service.Dispose();

            // No exception means success
        }
    }
}
