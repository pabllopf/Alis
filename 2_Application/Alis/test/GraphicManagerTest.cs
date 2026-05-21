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
using Alis.Core.Ecs.Systems.Configuration;
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
            Context context = new Context(new Setting());

            GraphicManager graphicManager = new GraphicManager(context);

            Assert.NotNull(graphicManager);
            Assert.Same(context, graphicManager.Context);
        }

        /// <summary>
        ///     Tests that GraphicManager inherits from AManager.
        /// </summary>
        [Fact]
        public void GraphicManager_InheritsFromAManager()
        {
            Context context = new Context(new Setting());
            GraphicManager graphicManager = new GraphicManager(context);

            Assert.IsAssignableFrom<AManager>(graphicManager);
        }

        /// <summary>
        ///     Tests that GraphicManager has the expected default properties.
        /// </summary>
        [Fact]
        public void GraphicManager_HasExpectedProperties()
        {
            Context context = new Context(new Setting());
            GraphicManager graphicManager = new GraphicManager(context);

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
            Context context = new Context(new Setting());

            GraphicManager graphicManager = new GraphicManager(context);

            Assert.NotNull(graphicManager.Context);
            Assert.Same(context, graphicManager.Context);
        }

        /// <summary>
        ///     Tests that GraphicManager implements IManager interface.
        /// </summary>
        [Fact]
        public void GraphicManager_ImplementsIManagerInterface()
        {
            Context context = new Context(new Setting());
            GraphicManager graphicManager = new GraphicManager(context);

            Assert.IsAssignableFrom<IManager>(graphicManager);
        }

        /// <summary>
        ///     Tests that the GraphicManager default state is valid.
        /// </summary>
        [Fact]
        public void GraphicManager_DefaultState_IsValid()
        {
            Context context = new Context(new Setting());
            GraphicManager graphicManager = new GraphicManager(context);

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
            Context context = new Context(new Setting());

            GraphicManager graphicManager = new GraphicManager(context);
            graphicManager.Name = "Graphic";
            graphicManager.Tag = "GraphicTag";
            graphicManager.IsEnable = false;

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
            Context context = new Context(new Setting());
            GraphicManager graphicManager = new GraphicManager(context);

            IntPtr renderer = new IntPtr(1234);
            graphicManager.Renderer = renderer;

            Assert.Equal(renderer, graphicManager.Renderer);
        }
    }
}
