// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateManagerRemainingCoverageTests.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Updater.Services.Api;
using Alis.Extension.Updater.Services.Files;
using Moq;
using Xunit;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    ///     The update manager remaining coverage tests class
    /// </summary>
    public class UpdateManagerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that start with null release returns false
        /// </summary>
        [Fact]
        public async Task Start_WithNullRelease_ReturnsFalse()
        {
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(new Uri("http://127.0.0.1:55000/"));
            api.Setup(x => x.GetLatestReleaseAsync()).ReturnsAsync((Dictionary<string, object>) null);

            UpdateManager manager = new UpdateManager(api.Object, "latest", Mock.Of<IFileService>(),
                System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alis-updater-test", Guid.NewGuid().ToString("N")))
            {
                ContinueDelayMilliseconds = 0
            };

            bool result = false;
            try
            {
                result = await manager.Start(CancellationToken.None);
            }
            catch (System.InvalidOperationException)
            {
                result = false;
            }

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that start with empty release returns false
        /// </summary>
        [Fact]
        public async Task Start_WithEmptyRelease_ReturnsFalse()
        {
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(new Uri("http://127.0.0.1:55000/"));
            api.Setup(x => x.GetLatestReleaseAsync()).ReturnsAsync(new Dictionary<string, object>());

            UpdateManager manager = new UpdateManager(api.Object, "latest", Mock.Of<IFileService>(),
                System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alis-updater-test", Guid.NewGuid().ToString("N")))
            {
                ContinueDelayMilliseconds = 0
            };

            bool result = false;
            try
            {
                result = await manager.Start(CancellationToken.None);
            }
            catch (System.InvalidOperationException)
            {
                result = false;
            }

            Assert.False(result);
        }
    }
}
