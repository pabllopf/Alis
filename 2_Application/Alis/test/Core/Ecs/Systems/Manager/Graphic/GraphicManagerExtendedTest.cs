// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicManagerExtendedTest.cs
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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Alis.Core.Ecs.Systems.Scope;
using Context = Alis.Core.Ecs.Systems.Scope.Context;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Graphic
{
    /// <summary>
    ///     Extended tests for <see cref="GraphicManager" /> covering Renderer property,
    ///     combined key-interface callbacks, hold-duration computation, and timestamp edge cases.
    /// </summary>
    public class GraphicManagerExtendedTest
    {
        private static GameObject CreateGameObjectWithComponent<T>(T component) where T : class
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            GameObject go = scene.Create();
            go.Add(component);
            return go;
        }

        /// <summary>
        ///     Tests that Renderer getter returns the value set by the setter.
        /// </summary>
        [Fact]
        public void Renderer_GetSet_Works()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);
            IntPtr expected = new IntPtr(42);

            manager.Renderer = expected;
            IntPtr result = manager.Renderer;

            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that Renderer defaults to zero.
        /// </summary>
        [Fact]
        public void Renderer_Default_IsZero()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            IntPtr result = manager.Renderer;

            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that ProcessKeyEventForComponent invokes all three callbacks when the
        ///     component implements IOnPressKey, IOnHoldKey, and IOnReleaseKey simultaneously.
        /// </summary>
        [Fact]
        public void ProcessKeyEventForComponent_AllInterfaces_CallsAllCallbacks()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            bool pressCalled = false;
            bool holdCalled = false;
            bool releaseCalled = false;

            TestAllKeysComponent component = new TestAllKeysComponent();
            component.OnPressKeyAction = (info) => pressCalled = true;
            component.OnHoldKeyAction = (info) => holdCalled = true;
            component.OnReleaseKeyAction = (info) => releaseCalled = true;

            HashSet<ConsoleKey> pressed = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> held = new HashSet<ConsoleKey> { ConsoleKey.B };
            HashSet<ConsoleKey> released = new HashSet<ConsoleKey> { ConsoleKey.C };
            DateTime now = DateTime.UtcNow;

            manager.UpdateKeyTimestamps(new HashSet<ConsoleKey> { ConsoleKey.B }, new HashSet<ConsoleKey>(), now);

            GameObject go = CreateGameObjectWithComponent(component);
            manager.ProcessKeyEventForComponent(typeof(TestAllKeysComponent), go, pressed, held, released, now);

            Assert.True(pressCalled);
            Assert.True(holdCalled);
            Assert.True(releaseCalled);
        }

        /// <summary>
        ///     Tests that ProcessKeyEventForComponent calls the press callback once per pressed key.
        /// </summary>
        [Fact]
        public void ProcessKeyEventForComponent_MultiplePressedKeys_CallsForEachKey()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            int callCount = 0;
            TestPressKeyComponent component = new TestPressKeyComponent();
            component.OnPressKeyAction = (info) => callCount++;

            HashSet<ConsoleKey> pressed = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B, ConsoleKey.C };

            GameObject go = CreateGameObjectWithComponent(component);
            manager.ProcessKeyEventForComponent(typeof(TestPressKeyComponent), go, pressed, new HashSet<ConsoleKey>(), new HashSet<ConsoleKey>(), DateTime.UtcNow);

            Assert.Equal(3, callCount);
        }

        /// <summary>
        ///     Tests that ProcessKeyEventForComponent passes <see cref="TimeSpan.Zero" />
        ///     as hold duration when no timestamp was previously recorded for the held key.
        /// </summary>
        [Fact]
        public void ProcessKeyEventForComponent_HeldKeyWithoutTimestamp_ZeroDuration()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            TimeSpan? actualDuration = null;
            TestHoldKeyComponent component = new TestHoldKeyComponent();
            component.OnHoldKeyAction = (info) => actualDuration = info.HoldDuration;

            HashSet<ConsoleKey> held = new HashSet<ConsoleKey> { ConsoleKey.A };

            GameObject go = CreateGameObjectWithComponent(component);
            manager.ProcessKeyEventForComponent(typeof(TestHoldKeyComponent), go, new HashSet<ConsoleKey>(), held, new HashSet<ConsoleKey>(), DateTime.UtcNow);

            Assert.NotNull(actualDuration);
            Assert.Equal(TimeSpan.Zero, actualDuration.Value);
        }

        /// <summary>
        ///     Tests that ProcessKeyEventForComponent passes a positive hold duration
        ///     when a timestamp was previously recorded for the held key.
        /// </summary>
        [Fact]
        public void ProcessKeyEventForComponent_HeldKeyWithTimestamp_NonZeroDuration()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            TimeSpan? actualDuration = null;
            TestHoldKeyComponent component = new TestHoldKeyComponent();
            component.OnHoldKeyAction = (info) => actualDuration = info.HoldDuration;

            DateTime past = DateTime.UtcNow.AddSeconds(-2);
            manager.UpdateKeyTimestamps(new HashSet<ConsoleKey> { ConsoleKey.A }, new HashSet<ConsoleKey>(), past);

            HashSet<ConsoleKey> held = new HashSet<ConsoleKey> { ConsoleKey.A };

            GameObject go = CreateGameObjectWithComponent(component);
            DateTime now = DateTime.UtcNow;
            manager.ProcessKeyEventForComponent(typeof(TestHoldKeyComponent), go, new HashSet<ConsoleKey>(), held, new HashSet<ConsoleKey>(), now);

            Assert.NotNull(actualDuration);
            Assert.True(actualDuration.Value > TimeSpan.Zero, $"Expected positive hold duration, got {actualDuration.Value}");
        }

        /// <summary>
        ///     Tests that UpdateKeyTimestamps stores timestamps for pressed keys and
        ///     removes timestamps for released keys in a single call when a key appears in both sets.
        /// </summary>
        [Fact]
        public void UpdateKeyTimestamps_KeyInBothPressedAndReleased_RemovesTimestamp()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            manager.UpdateKeyTimestamps(
                new HashSet<ConsoleKey> { ConsoleKey.A },
                new HashSet<ConsoleKey>(),
                DateTime.UtcNow);

            manager.UpdateKeyTimestamps(
                new HashSet<ConsoleKey> { ConsoleKey.A },
                new HashSet<ConsoleKey> { ConsoleKey.A },
                DateTime.UtcNow);

            Assert.False(manager.keyDownTimestamps.ContainsKey(ConsoleKey.A));
        }

        /// <summary>
        ///     Tests that UpdateKeyTimestamps when a key is pressed and then later released
        ///     (in separate calls) the timestamp is stored then removed.
        /// </summary>
        [Fact]
        public void UpdateKeyTimestamps_PressThenRelease_RemovesTimestamp()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            manager.UpdateKeyTimestamps(
                new HashSet<ConsoleKey> { ConsoleKey.A },
                new HashSet<ConsoleKey>(),
                DateTime.UtcNow);

            Assert.True(manager.keyDownTimestamps.ContainsKey(ConsoleKey.A));

            manager.UpdateKeyTimestamps(
                new HashSet<ConsoleKey>(),
                new HashSet<ConsoleKey> { ConsoleKey.A },
                DateTime.UtcNow);

            Assert.False(manager.keyDownTimestamps.ContainsKey(ConsoleKey.A));
        }

        /// <summary>
        ///     Tests that UpdateKeyTimestamps replaces the timestamp when the same key is pressed twice.
        /// </summary>
        [Fact]
        public void UpdateKeyTimestamps_SameKeyPressedTwice_UpdatesTimestamp()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            DateTime firstPress = DateTime.UtcNow.AddMinutes(-1);
            manager.UpdateKeyTimestamps(
                new HashSet<ConsoleKey> { ConsoleKey.A },
                new HashSet<ConsoleKey>(),
                firstPress);

            DateTime secondPress = DateTime.UtcNow;
            manager.UpdateKeyTimestamps(
                new HashSet<ConsoleKey> { ConsoleKey.A },
                new HashSet<ConsoleKey>(),
                secondPress);

            Assert.True(manager.keyDownTimestamps.ContainsKey(ConsoleKey.A));

            long diffMs = (long)(manager.keyDownTimestamps[ConsoleKey.A] - secondPress).TotalMilliseconds;
            Assert.True(Math.Abs(diffMs) < 1000, $"Expected timestamp near secondPress, got offset {diffMs}ms");
        }

        /// <summary>
        ///     Tests that UpdateKeyTimestamps stores multiple pressed keys.
        /// </summary>
        [Fact]
        public void UpdateKeyTimestamps_MultiplePressedKeys_StoresAll()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            HashSet<ConsoleKey> pressed = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B, ConsoleKey.C };
            manager.UpdateKeyTimestamps(pressed, new HashSet<ConsoleKey>(), DateTime.UtcNow);

            Assert.True(manager.keyDownTimestamps.ContainsKey(ConsoleKey.A));
            Assert.True(manager.keyDownTimestamps.ContainsKey(ConsoleKey.B));
            Assert.True(manager.keyDownTimestamps.ContainsKey(ConsoleKey.C));
            Assert.Equal(3, manager.keyDownTimestamps.Count);
        }
    }

    /// <summary>
    ///     Test component that implements all three key event interfaces.
    /// </summary>
    public class TestAllKeysComponent : IOnPressKey, IOnHoldKey, IOnReleaseKey
    {
        /// <summary>
        ///     Gets or sets the action to invoke on press.
        /// </summary>
        public Action<KeyEventInfo> OnPressKeyAction { get; set; }

        /// <summary>
        ///     Gets or sets the action to invoke on hold.
        /// </summary>
        public Action<KeyEventInfo> OnHoldKeyAction { get; set; }

        /// <summary>
        ///     Gets or sets the action to invoke on release.
        /// </summary>
        public Action<KeyEventInfo> OnReleaseKeyAction { get; set; }

        /// <summary>
        ///     Called when the key is pressed.
        /// </summary>
        /// <param name="keyEventInfo">The key event info.</param>
        public void OnPressKey(KeyEventInfo keyEventInfo) => OnPressKeyAction?.Invoke(keyEventInfo);

        /// <summary>
        ///     Called when the key is held.
        /// </summary>
        /// <param name="keyEventInfo">The key event info.</param>
        public void OnHoldKey(KeyEventInfo keyEventInfo) => OnHoldKeyAction?.Invoke(keyEventInfo);

        /// <summary>
        ///     Called when the key is released.
        /// </summary>
        /// <param name="keyEventInfo">The key event info.</param>
        public void OnReleaseKey(KeyEventInfo keyEventInfo) => OnReleaseKeyAction?.Invoke(keyEventInfo);
    }
}
