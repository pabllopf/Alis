// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioReaderTest.cs
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
using Alis.Extension.Media.FFmpeg.Audio;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     The audio reader test class
    /// </summary>
    /// <seealso cref="AudioReader" />
    public class AudioReaderTest
    {
        [Fact]
        public void AudioReader_Constructor_ShouldThrowWhenFileMissing()
        {
            string missing = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".mp3");

            Assert.Throws<FileNotFoundException>(() => new AudioReader(missing));
        }

        [Fact]
        public void AudioReader_Load_ShouldThrowForInvalidBitDepth()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".mp3");
            File.WriteAllBytes(path, new byte[] {1});

            try
            {
                AudioReader reader = new AudioReader(path);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(8));

                Assert.Contains("Acceptable bit depths", ex.Message);
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
