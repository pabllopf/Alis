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
            const string assetName = "Find_ValidAssetName_ShouldReturnCorrectPath.txt";
            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
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
        }

        /// <summary>
        ///     Tests that find null asset name should throw argument null exception
        /// </summary>
        [Fact]
        public void Find_NullAssetName_ShouldThrowArgumentNullException()
        {
            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => AssetManager.Find(null));
        }


        /// <summary>
        ///     Tests that find should return correct path when asset exists
        /// </summary>
        [Fact]
        public void Find_ShouldReturnCorrectPath_WhenAssetExists()
        {
            // Arrange
            const string assetName = "Find_ShouldReturnCorrectPath_WhenAssetExists.txt";

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
        }

        /// <summary>
        ///     Tests that find should throw invalid operation exception when multiple assets exist
        /// </summary>
        [Fact]
        public void Find_ShouldThrowInvalidOperationException_WhenMultipleAssetsExist()
        {
            // Arrange
            const string assetName = "Find_ShouldThrowInvalidOperationException_WhenMultipleAssetsExist.txt";

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
        }

        /// <summary>
        ///     Tests that find should return empty string when asset does not exist
        /// </summary>
        [Fact]
        public void Find_ShouldReturnEmptyString_WhenAssetDoesNotExist()
        {
            // Arrange
            const string assetName = "Find_ShouldReturnEmptyString_WhenAssetDoesNotExist.txt";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act
            string actualAssetPath = AssetManager.Find(assetName);

            // Assert
            Assert.Equal(string.Empty, actualAssetPath);
        }

        /// <summary>
        ///     Tests that find empty asset name should return empty string
        /// </summary>
        [Fact]
        public void Find_EmptyAssetName_ShouldReturnEmptyString()
        {
            // Arrange
            string assetName = string.Empty;

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName));
        }

        /// <summary>
        ///     Tests that find null asset name should throw argument null exception
        /// </summary>
        [Fact]
        public void Find_NullAssetName_v2_ShouldThrowArgumentNullException()
        {
            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => AssetManager.Find(null));
        }

        /// <summary>
        ///     Tests that find invalid asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_InvalidAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = "invali€?3*'¡1d:asset:namestxt";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName));
        }


        /// <summary>
        ///     Tests that find assets directory does not exist should return empty string
        /// </summary>
        [Fact]
        public void Find_AssetsDirectoryDoesNotExist_ShouldReturnEmptyString()
        {
            // Arrange
            string assetName = "asset.txt";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act
            string actualAssetPath = AssetManager.Find(assetName);

            // Assert
            Assert.Equal(string.Empty, actualAssetPath);
        }

        /// <summary>
        ///     Tests that find white space asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_WhiteSpaceAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = "   ";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName));
        }

        /// <summary>
        ///     Tests that find only invalid chars asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_OnlyInvalidCharsAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = "invali€?3*'¡1d:asset:nametxt";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName));
        }

        /// <summary>
        ///     Tests that find invalid and valid chars asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_InvalidAndValidCharsAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = "invali€?3*'¡1d:asset:nametxt";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName));
        }

        /// <summary>
        ///     Tests that find white space and invalid chars asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_WhiteSpaceAndInvalidCharsAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = " invalid:assettxt ";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName.Trim()));
        }

        /// <summary>
        ///     Tests that find white space invalid and valid chars asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_WhiteSpaceInvalidAndValidCharsAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = " invalid:assettxt ";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName.Trim()));
        }

        /// <summary>
        ///     Tests that find invalid chars around valid chars asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_InvalidCharsAroundValidCharsAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = ":validasset:";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName));
        }

        /// <summary>
        ///     Tests that find white space around valid chars asset name should return correct path
        /// </summary>
        [Fact]
        public void Find_WhiteSpaceAroundValidCharsAssetName_ShouldReturnCorrectPath()
        {
            // Arrange
            string assetName = " validasset .txt";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act
            string actualAssetPath = AssetManager.Find(assetName.Trim());

            // Assert
            Assert.Empty(actualAssetPath);
        }

        /// <summary>
        ///     Tests that find white space around invalid chars asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_WhiteSpaceAroundInvalidCharsAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = " :invalidasset: ";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName.Trim()));
        }

        /// <summary>
        ///     Tests that find white space invalid chars around valid chars asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_WhiteSpaceInvalidCharsAroundValidCharsAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = " :validasset: ";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName.Trim()));
        }

        /// <summary>
        ///     Tests that find invalid chars white space around valid chars asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_InvalidCharsWhiteSpaceAroundValidCharsAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = ": validasset :";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName.Trim()));
        }

        /// <summary>
        ///     Tests that find valid chars white space around invalid chars asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_ValidCharsWhiteSpaceAroundInvalidCharsAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = "validasset :invalidasset: validasset";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName.Trim()));
        }

        /// <summary>
        ///     Tests that find valid chars invalid chars around white space asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_ValidCharsInvalidCharsAroundWhiteSpaceAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = "validasset: :validasset";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName.Trim()));
        }

        /// <summary>
        ///     Tests that find invalid chars valid chars around white space asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_InvalidCharsValidCharsAroundWhiteSpaceAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = ":validasset :validasset:";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName.Trim()));
        }

        /// <summary>
        ///     Tests that find white space valid chars around invalid chars asset name should throw argument exception
        /// </summary>
        [Fact]
        public void Find_WhiteSpaceValidCharsAroundInvalidCharsAssetName_ShouldThrowArgumentException()
        {
            // Arrange
            string assetName = " validasset:invalidasset:validasset ";

            string directory = Path.Combine(Environment.CurrentDirectory, "Assets");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            // Act & Assert
            Assert.Throws<ArgumentException>(() => AssetManager.Find(assetName.Trim()));
        }
    }
}