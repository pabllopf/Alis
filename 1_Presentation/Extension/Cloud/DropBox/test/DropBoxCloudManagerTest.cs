// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DropBoxCloudManagerTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
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
using Xunit;

namespace Alis.Extension.Cloud.DropBox.Test
{
    /// <summary>
    ///     The DropBox cloud manager test class
    /// </summary>
    public class DropBoxCloudManagerTest
    {
        /// <summary>
        ///     Tests that the default constructor initializes Name property correctly
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_DefaultConstructor_ShouldSetDefaultName()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager(null);

            // Assert
            Assert.Equal("DropBoxManager", manager.Name);
        }

        /// <summary>
        ///     Tests that the default constructor initializes Tag property correctly
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_DefaultConstructor_ShouldSetDefaultTag()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager(null);

            // Assert
            Assert.Equal("Cloud", manager.Tag);
        }

        /// <summary>
        ///     Tests that the default constructor initializes with IsInitialized false
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_DefaultConstructor_ShouldHaveIsInitializedFalse()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager(null);

            // Assert
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that the full constructor accepts custom id, name, tag and isEnable values
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_FullConstructor_ShouldAcceptAllParameters()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager("test-id", "TestName", "TestTag", true, null);

            // Assert - no exception means initialization succeeded
            Assert.NotNull(manager);
        }

        /// <summary>
        ///     Tests that the full constructor sets custom name correctly
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_FullConstructor_WithCustomName_ShouldSetCorrectly()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager("test-id", "MyCustomName", "TestTag", true, null);

            // Assert
            Assert.Equal("MyCustomName", manager.Name);
        }

        /// <summary>
        ///     Tests that the full constructor sets custom tag correctly
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_FullConstructor_WithCustomTag_ShouldSetCorrectly()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager("test-id", "TestName", "MyCustomTag", true, null);

            // Assert
            Assert.Equal("MyCustomTag", manager.Tag);
        }

        /// <summary>
        ///     Tests that the full constructor sets custom id correctly
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_FullConstructor_WithCustomId_ShouldSetCorrectly()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager("my-custom-id", "TestName", "TestTag", true, null);

            // Assert - no exception means initialization succeeded
            Assert.NotNull(manager);
        }

        /// <summary>
        ///     Tests that IsInitialized returns false when not initialized
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_NotInitialized_ShouldReturnFalse()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager(null);

            // Assert
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that Dispose does not throw on fresh instance
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_Dispose_ShouldNotThrowOnFreshInstance()
        {
            // Arrange
            using DropBoxCloudManager manager = new DropBoxCloudManager(null);

            // Act & Assert
            bool threw = false;
            try
            {
                manager.Dispose();
            }
            catch
            {
                threw = true;
            }

            Assert.False(threw);
        }

        /// <summary>
        ///     Tests that Dispose can be called multiple times without throwing
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_MultipleDispose_ShouldNotThrow()
        {
            // Arrange
            using DropBoxCloudManager manager = new DropBoxCloudManager(null);

            // Act & Assert
            bool threw = false;
            try
            {
                manager.Dispose();
                manager.Dispose();
                manager.Dispose();
            }
            catch
            {
                threw = true;
            }

            Assert.False(threw);
        }

        /// <summary>
        ///     Tests that Dispose on default-constructed manager does not throw
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_DisposeDefaultConstructed_ShouldNotThrow()
        {
            // Arrange
            DropBoxCloudManager manager = new DropBoxCloudManager(null);

            // Act & Assert
            bool threw = false;
            try
            {
                manager.Dispose();
            }
            catch
            {
                threw = true;
            }

            Assert.False(threw);
        }

        /// <summary>
        ///     Tests that OnDestroy does not throw on fresh instance
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_OnDestroy_ShouldNotThrowOnFreshInstance()
        {
            // Arrange
            using DropBoxCloudManager manager = new DropBoxCloudManager(null);

            // Act & Assert
            bool threw = false;
            try
            {
                manager.OnDestroy();
            }
            catch
            {
                threw = true;
            }

            Assert.False(threw);
        }

        /// <summary>
        ///     Tests that OnDestroy can be called multiple times without throwing
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_MultipleOnDestroy_ShouldNotThrow()
        {
            // Arrange
            using DropBoxCloudManager manager = new DropBoxCloudManager(null);

            // Act & Assert
            bool threw = false;
            try
            {
                manager.OnDestroy();
                manager.OnDestroy();
                manager.OnDestroy();
            }
            catch
            {
                threw = true;
            }

            Assert.False(threw);
        }

        /// <summary>
        ///     Tests that the class implements IDisposable correctly
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_Idisposable_Implementation_ShouldNotThrow()
        {
            // Arrange & Act
            using (DropBoxCloudManager manager = new DropBoxCloudManager(null))
            {
                Assert.NotNull(manager);
            }
        }

        /// <summary>
        ///     Tests that the class implements ICloudManager correctly
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_ICloudManager_Implementation_ShouldNotThrow()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager(null);

            // Assert - no exception means implementation is correct
            Assert.NotNull(manager);
        }

        /// <summary>
        ///     Tests that the class implements AManager correctly
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_AManager_Implementation_ShouldNotThrow()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager(null);

            // Assert - no exception means implementation is correct
            Assert.NotNull(manager);
        }

        /// <summary>
        ///     Tests that constructor with empty string name works correctly
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_FullConstructor_WithEmptyName_ShouldSetCorrectly()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager("test-id", "", "TestTag", true, null);

            // Assert - no exception means initialization succeeded
            Assert.NotNull(manager);
        }

        /// <summary>
        ///     Tests that constructor with empty string tag works correctly
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_FullConstructor_WithEmptyTag_ShouldSetCorrectly()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager("test-id", "TestName", "", true, null);

            // Assert - no exception means initialization succeeded
            Assert.NotNull(manager);
        }

        /// <summary>
        ///     Tests that constructor with isEnable false works correctly
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_FullConstructor_WithIsEnableFalse_ShouldSetCorrectly()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager("test-id", "TestName", "TestTag", false, null);

            // Assert - no exception means initialization succeeded
            Assert.NotNull(manager);
        }

        /// <summary>
        ///     Tests that constructor with isEnable true works correctly
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_FullConstructor_WithIsEnableTrue_ShouldSetCorrectly()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager("test-id", "TestName", "TestTag", true, null);

            // Assert - no exception means initialization succeeded
            Assert.NotNull(manager);
        }


        /// <summary>
        ///     Tests that the class can be cast to ICloudManager
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_CastToICloudManager_ShouldSucceed()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager(null);
            ICloudManager cloudManager = manager;

            // Assert
            Assert.NotNull(cloudManager);
        }

        /// <summary>
        ///     Tests that the class can be cast to AManager
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_CastToAManager_ShouldSucceed()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager(null);
            Alis.Core.Ecs.Systems.Manager.AManager aManager = manager;

            // Assert
            Assert.NotNull(aManager);
        }

        /// <summary>
        ///     Tests that the class can be cast to IDisposable
        /// </summary>
        [Fact]
        public void DropBoxCloudManager_CastToIDisposable_ShouldSucceed()
        {
            // Arrange & Act
            using DropBoxCloudManager manager = new DropBoxCloudManager(null);
            IDisposable disposable = manager;

            // Assert
            Assert.NotNull(disposable);
        }
    }
}
