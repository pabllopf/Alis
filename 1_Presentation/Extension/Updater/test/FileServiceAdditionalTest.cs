// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FileServiceAdditionalTest.cs
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
using Alis.Extension.Updater.Services.Files;
using Xunit;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    /// The file service additional test class
    /// </summary>
    public class FileServiceAdditionalTest
    {
        /// <summary>
        /// Tests that download file async throws not implemented exception
        /// </summary>
        [Fact]
        public void DownloadFileAsync_ThrowsNotImplementedException()
        {
            FileService sut = new FileService();
            Assert.Throws<NotImplementedException>(new System.Action(() =>
            {
                Task<string> ignored = sut.DownloadFileAsync(new Uri("http://example.com/file.zip"), "/tmp");
            }));
        }
    }
}
