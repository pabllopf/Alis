// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetManagerTest.cs
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
using System.Reflection;
using Xunit;

namespace Alis.Core.Aspect.Data.Test
{
    /// <summary>
    /// The asset manager test class
    /// </summary>
    public class AssetManagerTest
    {
        /// <summary>
        /// Tests that find valid asset name should return correct path
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        [Fact]
        public void Find_ValidAssetName_ShouldReturnCorrectPath()
        {
            // Arrange
            const string assetName = "example.txt";
            string expectedPath = Path.Combine(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? throw new InvalidOperationException()),"Assets"), assetName);

            // Act
            string result = AssetManager.Find(assetName);

            // Assert
            Assert.Equal(expectedPath, result);
        }

        /// <summary>
        /// Tests that find null asset name should throw argument null exception
        /// </summary>
        [Fact]
        public void Find_NullAssetName_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => AssetManager.Find(null));
        }
    }
}