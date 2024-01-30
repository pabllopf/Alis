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
using Alis.Core.Aspect.Data.Resource;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Resource
{
    /// <summary>
    ///     The asset manager test class
    /// </summary>
    public class AssetManagerTest
    {
        /// <summary>
        ///     Tests that find valid asset name should return correct path
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        [Fact]
        public void Find_ValidAssetName_ShouldReturnCorrectPath()
        {
            // Arrange
            const string assetName = "example.txt";
            string directory = Path.Combine(Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) ?? throw new InvalidOperationException()), "Assets");
            string expectedPath = Path.Combine(directory, assetName);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(expectedPath))
            {
                File.Create(expectedPath);
            }

            // Act
            string result = AssetManager.Find(assetName);

            // Assert
            Assert.Equal(expectedPath, result);
            
            //delete files
            File.Delete(expectedPath);
        }

        /// <summary>
        ///     Tests that find null asset name should throw argument null exception
        /// </summary>
        [Fact]
        public void Find_NullAssetName_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => AssetManager.Find(null));
        }
        
        
        /// <summary>
        /// Tests that find should return correct path when asset exists
        /// </summary>
        [Fact]
        public void Find_ShouldReturnCorrectPath_WhenAssetExists()
        {
            // Arrange
            const string assetName = "duplicateAsset.txt";
            
            // Create file 1
            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            string expectedPath1 = Path.Combine(directory, assetName);
            
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            if (!File.Exists(expectedPath1))
            {
                File.Create(expectedPath1);
            }
            
            // Act
            string actualAssetPath = AssetManager.Find(assetName);

            // Assert
            Assert.Equal(expectedPath1, actualAssetPath);
            
            //delete files
            File.Delete(expectedPath1);
        }

        /// <summary>
        /// Tests that find should throw invalid operation exception when multiple assets exist
        /// </summary>
        [Fact]
        public void Find_ShouldThrowInvalidOperationException_WhenMultipleAssetsExist()
        {
            // Arrange
            const string assetName = "duplicateAsset.txt";
            
            // Create file 1
            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            string expectedPath1 = Path.Combine(directory, assetName);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            if (!File.Exists(expectedPath1))
            {
                File.Create(expectedPath1);
            }
            
            // Create file 2
            directory = Path.Combine(directory, "Sample");
            string expectedPath2 = Path.Combine(directory, assetName);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            if (!File.Exists(expectedPath2))
            {
                File.Create(expectedPath2);
            }

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => AssetManager.Find(assetName));
            
            //delete files
            File.Delete(expectedPath1);
            File.Delete(expectedPath2);
        }

        /// <summary>
        /// Tests that find should return empty string when asset does not exist
        /// </summary>
        [Fact]
        public void Find_ShouldReturnEmptyString_WhenAssetDoesNotExist()
        {
            // Arrange
            const string assetName = "nonExistingAsset.txt";

            // Act
            string actualAssetPath = AssetManager.Find(assetName);

            // Assert
            Assert.Equal(string.Empty, actualAssetPath);
        }
    }
}