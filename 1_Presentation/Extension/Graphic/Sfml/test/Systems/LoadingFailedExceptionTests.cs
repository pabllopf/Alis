// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoadingFailedExceptionTests.cs
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
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    /// <summary>
    ///     The loading failed exception tests class
    /// </summary>
    public class LoadingFailedExceptionTests
    {
        /// <summary>
        ///     Tests that default constructor sets default message
        /// </summary>
        [Fact]
        public void DefaultConstructor_SetsDefaultMessage()
        {
            LoadingFailedException ex = new LoadingFailedException();
            Assert.Equal("Failed to load a resource", ex.Message);
        }

        /// <summary>
        ///     Tests that constructor with resource name sets message
        /// </summary>
        [Fact]
        public void Constructor_WithResourceName_SetsMessage()
        {
            LoadingFailedException ex = new LoadingFailedException("Texture");
            Assert.Equal("Failed to load Texture from memory", ex.Message);
        }

        /// <summary>
        ///     Tests that constructor with resource name and inner exception sets message and inner
        /// </summary>
        [Fact]
        public void Constructor_WithResourceNameAndInnerException_SetsMessageAndInner()
        {
            Exception inner = new Exception("Inner");
            LoadingFailedException ex = new LoadingFailedException("Font", inner);
            Assert.Equal("Failed to load Font from memory", ex.Message);
            Assert.Equal(inner, ex.InnerException);
        }

        /// <summary>
        ///     Tests that constructor with resource name and filename sets message
        /// </summary>
        [Fact]
        public void Constructor_WithResourceNameAndFilename_SetsMessage()
        {
            LoadingFailedException ex = new LoadingFailedException("Image", "file.png");
            Assert.Equal("Failed to load Image from file file.png", ex.Message);
        }

        /// <summary>
        ///     Tests that constructor with resource name filename and inner sets message and inner
        /// </summary>
        [Fact]
        public void Constructor_WithResourceNameFilenameAndInner_SetsMessageAndInner()
        {
            Exception inner = new Exception("Inner");
            LoadingFailedException ex = new LoadingFailedException("Sound", "file.wav", inner);
            Assert.Equal("Failed to load Sound from file file.wav", ex.Message);
            Assert.Equal(inner, ex.InnerException);
        }
    }
}