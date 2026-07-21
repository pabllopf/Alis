// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GoogleDriveCloudManagerAdditionalTest.cs
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
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Extension.Cloud.GoogleDrive.Test
{
    public class GoogleDriveCloudManagerAdditionalTest
    {
        [Fact]
        public void InitializeAsync_WithEmptyToken_ThrowsArgumentException()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context());
            Exception ex = Assert.ThrowsAsync<ArgumentException>(() => manager.InitializeAsync(string.Empty)).GetAwaiter().GetResult();
            Assert.Contains("Access token cannot be null or empty", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void InitializeAsync_WithNullToken_ThrowsArgumentException()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context());
            Exception ex = Assert.ThrowsAsync<ArgumentException>(() => manager.InitializeAsync(null)).GetAwaiter().GetResult();
            Assert.Contains("Access token cannot be null or empty", ex.Message, StringComparison.OrdinalIgnoreCase);
        }



        [Fact]
        public void IsInitialized_AfterConstruction_ReturnsFalse()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context());
            Assert.False(manager.IsInitialized);
        }

        [Fact]
        public void Name_AfterConstruction_ReturnsGoogleDriveManager()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context());
            Assert.Equal("GoogleDriveManager", manager.Name);
        }

        [Fact]
        public void Tag_AfterConstruction_ReturnsCloud()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context());
            Assert.Equal("Cloud", manager.Tag);
        }
    }
}
