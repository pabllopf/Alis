// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicManagerTest.cs
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
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Contains unit tests for the <see cref="GraphicManager" /> class.
    /// </summary>
    public class GraphicManagerTest
    {
        /// <summary>
        ///     Tests that the constructor creates a GraphicManager with the provided context.
        /// </summary>
        [Fact]
        public void Constructor_CreatesGraphicManager_WithContext()
        {
            // Arrange
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            // Act
            GraphicManager graphicManager = new GraphicManager(context);

            // Assert
            Assert.NotNull(graphicManager);
            Assert.Same(context, graphicManager.Context);
        }

        /// <summary>
        ///     Tests that GraphicManager inherits from AManager.
        /// </summary>
        [Fact]
        public void GraphicManager_InheritsFromAManager()
        {
            // Arrange & Act
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            GraphicManager graphicManager = new GraphicManager(context);

            // Assert
            Assert.IsAssignableFrom<AManager>(graphicManager);
        }

        /// <summary>
        ///     Tests that GraphicManager has the expected default properties.
        /// </summary>
        [Fact]
        public void GraphicManager_HasExpectedProperties()
        {
            // Arrange & Act
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            GraphicManager graphicManager = new GraphicManager(context);

            // Assert
            Assert.NotNull(graphicManager.Id);
            Assert.Equal("Manager", graphicManager.Name);
            Assert.Equal("Untagged", graphicManager.Tag);
            Assert.True(graphicManager.IsEnable);
        }

        /// <summary>
        ///     Tests that the GraphicManager context is set correctly.
        /// </summary>
        [Fact]
        public void GraphicManager_Context_IsSetCorrectly()
        {
            // Arrange
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            // Act
            GraphicManager graphicManager = new GraphicManager(context);

            // Assert
            Assert.NotNull(graphicManager.Context);
            Assert.Same(context, graphicManager.Context);
        }

        /// <summary>
        ///     Tests that GraphicManager implements IManager interface.
        /// </summary>
        [Fact]
        public void GraphicManager_ImplementsIManagerInterface()
        {
            // Arrange & Act
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            GraphicManager graphicManager = new GraphicManager(context);

            // Assert
            Assert.IsAssignableFrom<IManager>(graphicManager);
        }

        /// <summary>
        ///     Tests that the GraphicManager default state is valid.
        /// </summary>
        [Fact]
        public void GraphicManager_DefaultState_IsValid()
        {
            // Arrange & Act
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            GraphicManager graphicManager = new GraphicManager(context);

            // Assert
            Assert.NotNull(graphicManager.Id);
            Assert.NotEmpty(graphicManager.Id);
            Assert.NotNull(graphicManager.Name);
            Assert.NotNull(graphicManager.Tag);
            Assert.True(graphicManager.IsEnable);
        }

        /// <summary>
        ///     Tests that GraphicManager properties are accessible.
        /// </summary>
        [Fact]
        public void GraphicManager_Properties_AreAccessible()
        {
            // Arrange
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            // Act
            GraphicManager graphicManager = new GraphicManager(context);
            graphicManager.Name = "Graphic";
            graphicManager.Tag = "GraphicTag";
            graphicManager.IsEnable = false;

            // Assert
            Assert.Equal("Graphic", graphicManager.Name);
            Assert.Equal("GraphicTag", graphicManager.Tag);
            Assert.False(graphicManager.IsEnable);
        }

        /// <summary>
        ///     Tests that the Renderer property is accessible.
        /// </summary>
        [Fact]
        public void GraphicManager_RendererProperty_IsAccessible()
        {
            // Arrange
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            GraphicManager graphicManager = new GraphicManager(context);

            // Act
            IntPtr renderer = new IntPtr(1234);
            graphicManager.Renderer = renderer;

            // Assert
            Assert.Equal(renderer, graphicManager.Renderer);
        }
    }
}
