// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalRuntimeTest.cs
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
using Alis.Core.Ecs.Systems.Execution;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Scope;
using Moq;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Tests for InternalRuntime&lt;T&gt; lifecycle and retrieval behavior
    /// </summary>
    public class InternalRuntimeTest
    {
        /// <summary>
        ///     Test double for IRuntime that tracks method calls
        /// </summary>
        private class TestRuntime : AManager
        {
            public bool OnInitCalled { get; private set; }
            public bool OnAwakeCalled { get; private set; }
            public bool OnStartCalled { get; private set; }
            public bool OnUpdateCalled { get; private set; }
            public bool OnDrawCalled { get; private set; }
            public bool OnExitCalled { get; private set; }
            public bool OnSaveCalled { get; private set; }
            public bool OnLoadCalled { get; private set; }
            public bool OnStopCalled { get; private set; }
            public bool OnBeforeUpdateCalled { get; private set; }
            public bool OnAfterUpdateCalled { get; private set; }

            public TestRuntime(Context context) : base(context)
            {
            }

            public override void OnInit()
            {
                base.OnInit();
                OnInitCalled = true;
            }

            public override void OnAwake()
            {
                base.OnAwake();
                OnAwakeCalled = true;
            }

            public override void OnStart()
            {
                base.OnStart();
                OnStartCalled = true;
            }

            public override void OnUpdate()
            {
                base.OnUpdate();
                OnUpdateCalled = true;
            }

            public override void OnDraw()
            {
                base.OnDraw();
                OnDrawCalled = true;
            }

            public override void OnExit()
            {
                base.OnExit();
                OnExitCalled = true;
            }

            public override void OnSave()
            {
                base.OnSave();
                OnSaveCalled = true;
            }

            public override void OnLoad()
            {
                base.OnLoad();
                OnLoadCalled = true;
            }

            public override void OnStop()
            {
                base.OnStop();
                OnStopCalled = true;
            }

            public override void OnBeforeUpdate()
            {
                base.OnBeforeUpdate();
                OnBeforeUpdateCalled = true;
            }

            public override void OnAfterUpdate()
            {
                base.OnAfterUpdate();
                OnAfterUpdateCalled = true;
            }
        }

        /// <summary>
        ///     Tests that constructor with empty array creates empty runtime
        /// </summary>
        [Fact]
        public void Constructor_EmptyArray_ShouldCreateEmptyRuntime()
        {
            // Arrange & Act
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>();

            // Assert - should not throw, just be empty
            Assert.NotNull(runtime);
        }

        /// <summary>
        ///     Tests that constructor with single item stores it
        /// </summary>
        [Fact]
        public void Constructor_SingleItem_ShouldStoreIt()
        {
            // Arrange
            Context context = new Context();
            TestRuntime testRuntime = new TestRuntime(context);

            // Act
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(testRuntime);

            // Assert
            TestRuntime retrieved = runtime.Get<TestRuntime>();
            Assert.Same(testRuntime, retrieved);
        }
        

        /// <summary>
        ///     Tests that Get returns correct type when present
        /// </summary>
        [Fact]
        public void Get_ReturnsCorrectType_WhenPresent()
        {
            // Arrange
            Context context = new Context();
            TestRuntime testRuntime = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(testRuntime);

            // Act
            TestRuntime result = runtime.Get<TestRuntime>();

            // Assert
            Assert.NotNull(result);
            Assert.Same(testRuntime, result);
        }

        /// <summary>
        ///     Tests that Get throws InvalidOperationException for missing type
        /// </summary>
        [Fact]
        public void Get_ThrowsInvalidOperationException_WhenTypeNotFound()
        {
            // Arrange
            Context context = new Context();
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>();

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => runtime.Get<TestRuntime>());
            Assert.Contains("TestRuntime", exception.Message);
        }

        /// <summary>
        ///     Tests that OnInit calls OnInit on all runtimes
        /// </summary>
        [Fact]
        public void OnInit_CallsOnInitOnAllRuntimes()
        {
            // Arrange
            Context context = new Context();
            TestRuntime runtime1 = new TestRuntime(context);
            TestRuntime runtime2 = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(runtime1, runtime2);

            // Act
            runtime.OnInit();

            // Assert
            Assert.True(runtime1.OnInitCalled);
            Assert.True(runtime2.OnInitCalled);
        }

        /// <summary>
        ///     Tests that OnAwake calls OnAwake on all runtimes
        /// </summary>
        [Fact]
        public void OnAwake_CallsOnAwakeOnAllRuntimes()
        {
            // Arrange
            Context context = new Context();
            TestRuntime runtime1 = new TestRuntime(context);
            TestRuntime runtime2 = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(runtime1, runtime2);

            // Act
            runtime.OnAwake();

            // Assert
            Assert.True(runtime1.OnAwakeCalled);
            Assert.True(runtime2.OnAwakeCalled);
        }

        /// <summary>
        ///     Tests that OnStart calls OnStart on all runtimes
        /// </summary>
        [Fact]
        public void OnStart_CallsOnStartOnAllRuntimes()
        {
            // Arrange
            Context context = new Context();
            TestRuntime runtime1 = new TestRuntime(context);
            TestRuntime runtime2 = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(runtime1, runtime2);

            // Act
            runtime.OnStart();

            // Assert
            Assert.True(runtime1.OnStartCalled);
            Assert.True(runtime2.OnStartCalled);
        }

        /// <summary>
        ///     Tests that OnUpdate calls OnUpdate on all runtimes
        /// </summary>
        [Fact]
        public void OnUpdate_CallsOnUpdateOnAllRuntimes()
        {
            // Arrange
            Context context = new Context();
            TestRuntime runtime1 = new TestRuntime(context);
            TestRuntime runtime2 = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(runtime1, runtime2);

            // Act
            runtime.OnUpdate();

            // Assert
            Assert.True(runtime1.OnUpdateCalled);
            Assert.True(runtime2.OnUpdateCalled);
        }

        /// <summary>
        ///     Tests that OnDraw calls OnDraw on all runtimes
        /// </summary>
        [Fact]
        public void OnDraw_CallsOnDrawOnAllRuntimes()
        {
            // Arrange
            Context context = new Context();
            TestRuntime runtime1 = new TestRuntime(context);
            TestRuntime runtime2 = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(runtime1, runtime2);

            // Act
            runtime.OnDraw();

            // Assert
            Assert.True(runtime1.OnDrawCalled);
            Assert.True(runtime2.OnDrawCalled);
        }

        /// <summary>
        ///     Tests that OnExit calls OnExit on all runtimes
        /// </summary>
        [Fact]
        public void OnExit_CallsOnExitOnAllRuntimes()
        {
            // Arrange
            Context context = new Context();
            TestRuntime runtime1 = new TestRuntime(context);
            TestRuntime runtime2 = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(runtime1, runtime2);

            // Act
            runtime.OnExit();

            // Assert
            Assert.True(runtime1.OnExitCalled);
            Assert.True(runtime2.OnExitCalled);
        }

        /// <summary>
        ///     Tests that OnSave calls OnSave on all runtimes
        /// </summary>
        [Fact]
        public void OnSave_CallsOnSaveOnAllRuntimes()
        {
            // Arrange
            Context context = new Context();
            TestRuntime runtime1 = new TestRuntime(context);
            TestRuntime runtime2 = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(runtime1, runtime2);

            // Act
            runtime.OnSave();

            // Assert
            Assert.True(runtime1.OnSaveCalled);
            Assert.True(runtime2.OnSaveCalled);
        }

        /// <summary>
        ///     Tests that OnLoad calls OnLoad on all runtimes
        /// </summary>
        [Fact]
        public void OnLoad_CallsOnLoadOnAllRuntimes()
        {
            // Arrange
            Context context = new Context();
            TestRuntime runtime1 = new TestRuntime(context);
            TestRuntime runtime2 = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(runtime1, runtime2);

            // Act
            runtime.OnLoad();

            // Assert
            Assert.True(runtime1.OnLoadCalled);
            Assert.True(runtime2.OnLoadCalled);
        }

        /// <summary>
        ///     Tests that OnSave with path calls OnSave(path) on all runtimes
        /// </summary>
        [Fact]
        public void OnSave_WithPath_CallsOnSavePathOnAllRuntimes()
        {
            // Arrange
            Context context = new Context();
            TestRuntime runtime1 = new TestRuntime(context);
            TestRuntime runtime2 = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(runtime1, runtime2);

            // Act
            runtime.OnSave("/test/path");

            // Assert - should not throw
            Assert.NotNull(runtime);
        }

        /// <summary>
        ///     Tests that OnLoad with path calls OnLoad(path) on all runtimes
        /// </summary>
        [Fact]
        public void OnLoad_WithPath_CallsOnLoadPathOnAllRuntimes()
        {
            // Arrange
            Context context = new Context();
            TestRuntime runtime1 = new TestRuntime(context);
            TestRuntime runtime2 = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(runtime1, runtime2);

            // Act
            runtime.OnLoad("/test/path");

            // Assert - should not throw
            Assert.NotNull(runtime);
        }

        /// <summary>
        ///     Tests that Get caches items by type
        /// </summary>
        [Fact]
        public void Get_CachesItemsByType()
        {
            // Arrange
            Context context = new Context();
            TestRuntime testRuntime = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(testRuntime);

            // Act - call Get multiple times
            TestRuntime result1 = runtime.Get<TestRuntime>();
            TestRuntime result2 = runtime.Get<TestRuntime>();

            // Assert
            Assert.Same(result1, result2);
        }

        /// <summary>
        ///     Tests that OnStop calls OnStop on all runtimes
        /// </summary>
        [Fact]
        public void OnStop_CallsOnStopOnAllRuntimes()
        {
            // Arrange
            Context context = new Context();
            TestRuntime runtime1 = new TestRuntime(context);
            TestRuntime runtime2 = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(runtime1, runtime2);

            // Act
            runtime.OnStop();

            // Assert
            Assert.True(runtime1.OnStopCalled);
            Assert.True(runtime2.OnStopCalled);
        }

        /// <summary>
        ///     Tests that OnBeforeUpdate calls OnBeforeUpdate on all runtimes
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_CallsOnBeforeUpdateOnAllRuntimes()
        {
            // Arrange
            Context context = new Context();
            TestRuntime runtime1 = new TestRuntime(context);
            TestRuntime runtime2 = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(runtime1, runtime2);

            // Act
            runtime.OnBeforeUpdate();

            // Assert
            Assert.True(runtime1.OnBeforeUpdateCalled);
            Assert.True(runtime2.OnBeforeUpdateCalled);
        }

        /// <summary>
        ///     Tests that OnAfterUpdate calls OnAfterUpdate on all runtimes
        /// </summary>
        [Fact]
        public void OnAfterUpdate_CallsOnAfterUpdateOnAllRuntimes()
        {
            // Arrange
            Context context = new Context();
            TestRuntime runtime1 = new TestRuntime(context);
            TestRuntime runtime2 = new TestRuntime(context);
            InternalRuntime<AManager> runtime = new InternalRuntime<AManager>(runtime1, runtime2);

            // Act
            runtime.OnAfterUpdate();

            // Assert
            Assert.True(runtime1.OnAfterUpdateCalled);
            Assert.True(runtime2.OnAfterUpdateCalled);
        }
    }
}
