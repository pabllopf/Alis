// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoadingFailedExceptionTest.cs
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
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The loading failed exception test class
    /// </summary>
    public class LoadingFailedExceptionTest
    {
        /// <summary>
        /// Tests that default constructor sets default message
        /// </summary>
        [Fact]
        public void DefaultConstructor_SetsDefaultMessage()
        {
            LoadingFailedException ex = new LoadingFailedException();
            Assert.Equal("Failed to load a resource", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with resource name sets message
        /// </summary>
        [Fact]
        public void Constructor_WithResourceName_SetsMessage()
        {
            LoadingFailedException ex = new LoadingFailedException("texture");
            Assert.Equal("Failed to load texture from memory", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with resource name and inner exception sets message
        /// </summary>
        [Fact]
        public void Constructor_WithResourceNameAndInnerException_SetsMessage()
        {
            Exception inner = new Exception("cause");
            LoadingFailedException ex = new LoadingFailedException("image", inner);
            Assert.Equal("Failed to load image from memory", ex.Message);
            Assert.Equal(inner, ex.InnerException);
        }

        /// <summary>
        /// Tests that constructor with resource name and filename sets message
        /// </summary>
        [Fact]
        public void Constructor_WithResourceNameAndFilename_SetsMessage()
        {
            LoadingFailedException ex = new LoadingFailedException("font", "arial.ttf");
            Assert.Equal("Failed to load font from file arial.ttf", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with resource name filename and inner exception sets message
        /// </summary>
        [Fact]
        public void Constructor_WithResourceNameFilenameAndInnerException_SetsMessage()
        {
            Exception inner = new Exception("io error");
            LoadingFailedException ex = new LoadingFailedException("sound", "song.ogg", inner);
            Assert.Equal("Failed to load sound from file song.ogg", ex.Message);
            Assert.Equal(inner, ex.InnerException);
        }
    }
}
