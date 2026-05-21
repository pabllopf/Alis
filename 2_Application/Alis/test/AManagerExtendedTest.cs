// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AManagerExtendedTest.cs
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

using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Extended tests for AManager base class properties and virtual lifecycle methods
    /// </summary>
    public class AManagerExtendedTest
    {
        /// <summary>
        ///     Tests that default constructor generates non-empty Id
        /// </summary>
        [Fact]
        public void AManager_DefaultConstructor_ShouldGenerateNonEmptyId()
        {
            TestManager manager = new TestManager(null);

            Assert.False(string.IsNullOrWhiteSpace(manager.Id));
        }

        /// <summary>
        ///     Tests that default constructor sets Name to "Manager"
        /// </summary>
        [Fact]
        public void AManager_DefaultConstructor_ShouldSetNameToManager()
        {
            TestManager manager = new TestManager(null);

            Assert.Equal("Manager", manager.Name);
        }

        /// <summary>
        ///     Tests that default constructor sets Tag to "Untagged"
        /// </summary>
        [Fact]
        public void AManager_DefaultConstructor_ShouldSetTagToUntagged()
        {
            TestManager manager = new TestManager(null);

            Assert.Equal("Untagged", manager.Tag);
        }

        /// <summary>
        ///     Tests that default constructor sets IsEnable to true
        /// </summary>
        [Fact]
        public void AManager_DefaultConstructor_ShouldSetIsEnableToTrue()
        {
            TestManager manager = new TestManager(null);

            Assert.True(manager.IsEnable);
        }

        /// <summary>
        ///     Tests that parameterized constructor uses provided values
        /// </summary>
        [Fact]
        public void AManager_ParameterizedConstructor_ShouldUseProvidedValues()
        {
            TestManager manager = new TestManager("custom-id", "CustomName", "CustomTag", false, null);

            Assert.Equal("custom-id", manager.Id);
            Assert.Equal("CustomName", manager.Name);
            Assert.Equal("CustomTag", manager.Tag);
            Assert.False(manager.IsEnable);
        }

        /// <summary>
        ///     Tests that OnEnable is virtual and can be overridden
        /// </summary>
        [Fact]
        public void AManager_OnEnable_ShouldBeOverridable()
        {
            OverrideTestManager manager = new OverrideTestManager(null);

            manager.OnEnable();

            Assert.True(manager.OnEnableCalled);
        }

        /// <summary>
        ///     Tests that OnDisable is virtual and can be overridden
        /// </summary>
        [Fact]
        public void AManager_OnDisable_ShouldBeOverridable()
        {
            OverrideTestManager manager = new OverrideTestManager(null);

            manager.OnDisable();

            Assert.True(manager.OnDisableCalled);
        }

        /// <summary>
        ///     Tests that OnReset is virtual and can be overridden
        /// </summary>
        [Fact]
        public void AManager_OnReset_ShouldBeOverridable()
        {
            OverrideTestManager manager = new OverrideTestManager(null);

            manager.OnReset();

            Assert.True(manager.OnResetCalled);
        }

        /// <summary>
        ///     Tests that OnDestroy is virtual and can be overridden
        /// </summary>
        [Fact]
        public void AManager_OnDestroy_ShouldBeOverridable()
        {
            OverrideTestManager manager = new OverrideTestManager(null);

            manager.OnDestroy();

            Assert.True(manager.OnDestroyCalled);
        }

        /// <summary>
        ///     Tests that Context property returns provided context
        /// </summary>
        [Fact]
        public void AManager_ContextProperty_ShouldReturnProvidedContext()
        {
            Context context = new Context();
            TestManager manager = new TestManager(context);

            Assert.Same(context, manager.Context);
        }

        /// <summary>
        ///     The test manager class
        /// </summary>
        /// <seealso cref="AManager"/>
        private sealed class TestManager : AManager
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestManager"/> class
            /// </summary>
            /// <param name="context">The context</param>
            public TestManager(Context context) : base(context)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="TestManager"/> class
            /// </summary>
            /// <param name="id">The id</param>
            /// <param name="name">The name</param>
            /// <param name="tag">The tag</param>
            /// <param name="isEnable">The is enable</param>
            /// <param name="context">The context</param>
            public TestManager(string id, string name, string tag, bool isEnable, Context context)
                : base(id, name, tag, isEnable, context)
            {
            }
        }

        /// <summary>
        ///     The override test manager class that tracks lifecycle method calls
        /// </summary>
        /// <seealso cref="AManager"/>
        private sealed class OverrideTestManager : AManager
        {
            /// <summary>
            /// Gets a value indicating whether OnEnable was called
            /// </summary>
            public bool OnEnableCalled { get; private set; }

            /// <summary>
            /// Gets a value indicating whether OnDisable was called
            /// </summary>
            public bool OnDisableCalled { get; private set; }

            /// <summary>
            /// Gets a value indicating whether OnReset was called
            /// </summary>
            public bool OnResetCalled { get; private set; }

            /// <summary>
            /// Gets a value indicating whether OnDestroy was called
            /// </summary>
            public bool OnDestroyCalled { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="OverrideTestManager"/> class
            /// </summary>
            /// <param name="context">The context</param>
            public OverrideTestManager(Context context) : base(context)
            {
            }

            /// <summary>
            /// Ons the enable
            /// </summary>
            public override void OnEnable()
            {
                OnEnableCalled = true;
            }

            /// <summary>
            /// Ons the disable
            /// </summary>
            public override void OnDisable()
            {
                OnDisableCalled = true;
            }

            /// <summary>
            /// Resets this instance
            /// </summary>
            public override void OnReset()
            {
                OnResetCalled = true;
            }

            /// <summary>
            /// Ons the destroy
            /// </summary>
            public override void OnDestroy()
            {
                OnDestroyCalled = true;
            }
        }
    }
}
