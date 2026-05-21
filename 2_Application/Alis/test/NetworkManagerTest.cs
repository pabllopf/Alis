// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 

//  File:NetworkManagerTest.cs
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


using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Manager.Network;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Network
{
    /// <summary>
    ///     Contains unit tests for the <see cref="NetworkManager" /> class.
    /// </summary>
    public class NetworkManagerTest
    {
        /// <summary>
        ///     Tests that the constructor creates a NetworkManager with the provided context.
        /// </summary>
        [Fact]
        public void Constructor_CreatesNetworkManager_WithContext()
        {
            // Arrange
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            // Act
            NetworkManager networkManager = new NetworkManager(context);

            // Assert
            Assert.NotNull(networkManager);
            Assert.Same(context, networkManager.Context);
        }

        /// <summary>
        ///     Tests that NetworkManager inherits from AManager.
        /// </summary>
        [Fact]
        public void NetworkManager_InheritsFromAManager()
        {
            // Arrange & Act
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            NetworkManager networkManager = new NetworkManager(context);

            // Assert
            Assert.IsAssignableFrom<AManager>(networkManager);
        }

        /// <summary>
        ///     Tests that NetworkManager has the expected default properties.
        /// </summary>
        [Fact]
        public void NetworkManager_HasExpectedProperties()
        {
            // Arrange & Act
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            NetworkManager networkManager = new NetworkManager(context);

            // Assert
            Assert.NotNull(networkManager.Id);
            Assert.Equal("Manager", networkManager.Name);
            Assert.Equal("Untagged", networkManager.Tag);
            Assert.True(networkManager.IsEnable);
        }
        
        /// <summary>
        ///     Tests that the NetworkManager context is set correctly.
        /// </summary>
        [Fact]
        public void NetworkManager_Context_IsSetCorrectly()
        {
            // Arrange
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            // Act
            NetworkManager networkManager = new NetworkManager(context);

            // Assert
            Assert.NotNull(networkManager.Context);
            Assert.Same(context, networkManager.Context);
        }

        /// <summary>
        ///     Tests that NetworkManager implements IManager interface.
        /// </summary>
        [Fact]
        public void NetworkManager_ImplementsIManagerInterface()
        {
            // Arrange & Act
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            NetworkManager networkManager = new NetworkManager(context);

            // Assert
            Assert.IsAssignableFrom<IManager>(networkManager);
        }

        /// <summary>
        ///     Tests that the NetworkManager default state is valid.
        /// </summary>
        [Fact]
        public void NetworkManager_DefaultState_IsValid()
        {
            // Arrange & Act
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            NetworkManager networkManager = new NetworkManager(context);

            // Assert
            Assert.NotNull(networkManager.Id);
            Assert.NotEmpty(networkManager.Id);
            Assert.NotNull(networkManager.Name);
            Assert.NotNull(networkManager.Tag);
            Assert.True(networkManager.IsEnable);
        }

        /// <summary>
        ///     Tests that NetworkManager properties are accessible.
        /// </summary>
        [Fact]
        public void NetworkManager_Properties_AreAccessible()
        {
            // Arrange
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            // Act
            NetworkManager networkManager = new NetworkManager(context);
            networkManager.Name = "Network";
            networkManager.Tag = "NetworkTag";
            networkManager.IsEnable = false;

            // Assert
            Assert.Equal("Network", networkManager.Name);
            Assert.Equal("NetworkTag", networkManager.Tag);
            Assert.False(networkManager.IsEnable);
        }

        /// <summary>
        ///     Tests the full constructor with all parameters.
        /// </summary>
        [Theory]
        [InlineData("test-id", "TestNetwork", "NetworkTag", true)]
        [InlineData("", "", "", false)]
        public void FullConstructor_SetsAllProperties(string id, string name, string tag, bool isEnable)
        {
            // Arrange
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            // Act
            NetworkManager networkManager = new NetworkManager(id, name, tag, isEnable, context);

            // Assert
            Assert.Equal(id, networkManager.Id);
            Assert.Equal(name, networkManager.Name);
            Assert.Equal(tag, networkManager.Tag);
            Assert.Equal(isEnable, networkManager.IsEnable);
        }
    }
}
