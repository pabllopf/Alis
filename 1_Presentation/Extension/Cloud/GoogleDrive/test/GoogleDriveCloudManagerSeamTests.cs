// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:GoogleDriveCloudManagerSeamTests.cs
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
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Xunit;

namespace Alis.Extension.Cloud.GoogleDrive.Test
{
    /// <summary>
    ///     Covers Google Drive initialization through the injectable service factory.
    /// </summary>
    public class GoogleDriveCloudManagerSeamTests
    {
        [Fact]
        public async Task InitializeAsync_WithFactoryReturningService_SetsIsInitializedTrue()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context());

            await manager.InitializeAsync("token", _ => CreateService());

            Assert.True(manager.IsInitialized);
        }

        [Fact]
        public async Task InitializeAsync_WithFactoryThrowing_ResetsServiceAndThrows()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), CreateService());
            Assert.True(manager.IsInitialized);

            InvalidOperationException exception = await Assert.ThrowsAsync<InvalidOperationException>(
                () => manager.InitializeAsync("token", _ => throw new InvalidOperationException("factory failed")));

            Assert.Equal("factory failed", exception.Message);
            Assert.False(manager.IsInitialized);
        }

        private static DriveService CreateService() => new DriveService(new BaseClientService.Initializer
        {
            ApplicationName = "Test"
        });
    }
}
