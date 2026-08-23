// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DropBoxCloudManagerRemainingCoverageTests.cs
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
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Dropbox.Api;
using Xunit;

namespace Alis.Extension.Cloud.DropBox.Test
{
    /// <summary>
    ///     The drop box cloud manager remaining coverage tests class
    /// </summary>
    public class DropBoxCloudManagerRemainingCoverageTests
    {
       
        
        /// <summary>
        ///     Tests that download file async with null dropbox path throws null reference exception
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithNullDropboxPath_ThrowsNullReferenceException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                manager.DownloadFileAsync(null, "/temp/file.txt"));
        }

       
        /// <summary>
        ///     Tests that upload file async with null dropbox path throws null reference exception
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithNullDropboxPath_ThrowsNullReferenceException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));
            string tempFile = Path.GetTempFileName();

            try
            {
                await Assert.ThrowsAsync<NullReferenceException>(() =>
                    manager.UploadFileAsync(tempFile, null));
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        /// <summary>
        ///     Tests that delete async with null path throws null reference exception
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithNullPath_ThrowsNullReferenceException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                manager.DeleteAsync(null));
        }

        /// <summary>
        ///     Tests that get metadata async with null path throws null reference exception
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithNullPath_ThrowsNullReferenceException()
        {
            using DropBoxCloudManager manager = new DropBoxCloudManager(new Context(), new DropboxClient("dummy-token"));

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                manager.GetMetadataAsync(null));
        }
    }
}
