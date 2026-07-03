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
using System.Collections.Generic;
using System.Reflection;
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

        /// <summary>
        ///     Tests that ComputePressedKeys returns keys in newKeys but not in currentKeys.
        /// </summary>
        [Fact]
        public void ComputePressedKeys_NewKeysMinusCurrentKeys()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B, ConsoleKey.C };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.B, ConsoleKey.D };
            MethodInfo method = typeof(GraphicManager).GetMethod("ComputePressedKeys", BindingFlags.Static | BindingFlags.NonPublic);
            HashSet<ConsoleKey> result = (HashSet<ConsoleKey>)method.Invoke(null, new object[] { newKeys, currentKeys });
            Assert.Equal(new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.C }, result);
        }

        /// <summary>
        ///     Tests that ComputePressedKeys returns empty when newKeys equals currentKeys.
        /// </summary>
        [Fact]
        public void ComputePressedKeys_AllKeysMatch_ReturnsEmpty()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            MethodInfo method = typeof(GraphicManager).GetMethod("ComputePressedKeys", BindingFlags.Static | BindingFlags.NonPublic);
            HashSet<ConsoleKey> result = (HashSet<ConsoleKey>)method.Invoke(null, new object[] { newKeys, currentKeys });
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that ComputePressedKeys returns all keys when currentKeys is empty.
        /// </summary>
        [Fact]
        public void ComputePressedKeys_NoCurrentKeys_ReturnsAllNewKeys()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey>();
            MethodInfo method = typeof(GraphicManager).GetMethod("ComputePressedKeys", BindingFlags.Static | BindingFlags.NonPublic);
            HashSet<ConsoleKey> result = (HashSet<ConsoleKey>)method.Invoke(null, new object[] { newKeys, currentKeys });
            Assert.Equal(2, result.Count);
            Assert.Contains(ConsoleKey.A, result);
            Assert.Contains(ConsoleKey.B, result);
        }

        /// <summary>
        ///     Tests that ComputeHeldKeys returns keys present in both sets.
        /// </summary>
        [Fact]
        public void ComputeHeldKeys_IntersectionOfBothSets()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B, ConsoleKey.C };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.B, ConsoleKey.D };
            MethodInfo method = typeof(GraphicManager).GetMethod("ComputeHeldKeys", BindingFlags.Static | BindingFlags.NonPublic);
            HashSet<ConsoleKey> result = (HashSet<ConsoleKey>)method.Invoke(null, new object[] { newKeys, currentKeys });
            Assert.Equal(new HashSet<ConsoleKey> { ConsoleKey.B }, result);
        }

        /// <summary>
        ///     Tests that ComputeHeldKeys returns empty when sets are disjoint.
        /// </summary>
        [Fact]
        public void ComputeHeldKeys_NoCommonKeys_ReturnsEmpty()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.C, ConsoleKey.D };
            MethodInfo method = typeof(GraphicManager).GetMethod("ComputeHeldKeys", BindingFlags.Static | BindingFlags.NonPublic);
            HashSet<ConsoleKey> result = (HashSet<ConsoleKey>)method.Invoke(null, new object[] { newKeys, currentKeys });
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that ComputeHeldKeys returns all keys when sets are identical.
        /// </summary>
        [Fact]
        public void ComputeHeldKeys_IdenticalSets_ReturnsAll()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            MethodInfo method = typeof(GraphicManager).GetMethod("ComputeHeldKeys", BindingFlags.Static | BindingFlags.NonPublic);
            HashSet<ConsoleKey> result = (HashSet<ConsoleKey>)method.Invoke(null, new object[] { newKeys, currentKeys });
            Assert.Equal(2, result.Count);
        }

        /// <summary>
        ///     Tests that ComputeReleasedKeys returns keys in currentKeys but not in newKeys.
        /// </summary>
        [Fact]
        public void ComputeReleasedKeys_CurrentKeysMinusNewKeys()
        {
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B, ConsoleKey.C };
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.B, ConsoleKey.D };
            MethodInfo method = typeof(GraphicManager).GetMethod("ComputeReleasedKeys", BindingFlags.Static | BindingFlags.NonPublic);
            HashSet<ConsoleKey> result = (HashSet<ConsoleKey>)method.Invoke(null, new object[] { currentKeys, newKeys });
            Assert.Equal(new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.C }, result);
        }

        /// <summary>
        ///     Tests that ComputeReleasedKeys returns empty when no keys were released.
        /// </summary>
        [Fact]
        public void ComputeReleasedKeys_AllKeysStillPressed_ReturnsEmpty()
        {
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            MethodInfo method = typeof(GraphicManager).GetMethod("ComputeReleasedKeys", BindingFlags.Static | BindingFlags.NonPublic);
            HashSet<ConsoleKey> result = (HashSet<ConsoleKey>)method.Invoke(null, new object[] { currentKeys, newKeys });
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that ComputeReleasedKeys returns all keys when no keys are in newKeys.
        /// </summary>
        [Fact]
        public void ComputeReleasedKeys_AllKeysReleased_ReturnsAll()
        {
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey>();
            MethodInfo method = typeof(GraphicManager).GetMethod("ComputeReleasedKeys", BindingFlags.Static | BindingFlags.NonPublic);
            HashSet<ConsoleKey> result = (HashSet<ConsoleKey>)method.Invoke(null, new object[] { currentKeys, newKeys });
            Assert.Equal(2, result.Count);
        }
    }
}
