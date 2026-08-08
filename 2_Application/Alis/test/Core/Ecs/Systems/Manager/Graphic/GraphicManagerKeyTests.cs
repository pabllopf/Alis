using System;
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Context = Alis.Core.Ecs.Systems.Scope.Context;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Graphic
{
    /// <summary>
    /// The graphic manager key tests class
    /// </summary>
    public class GraphicManagerKeyTests
    {
        /// <summary>
        /// Tests that compute pressed keys with new key returns pressed
        /// </summary>
        [Fact]
        public void ComputePressedKeys_WithNewKey_ReturnsPressed()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey>();
            HashSet<ConsoleKey> result = new HashSet<ConsoleKey>();

            GraphicManager.ComputePressedKeys(newKeys, currentKeys, result);

            Assert.Contains(ConsoleKey.A, result);
        }

        /// <summary>
        /// Tests that compute pressed keys with existing key does not return it
        /// </summary>
        [Fact]
        public void ComputePressedKeys_WithExistingKey_DoesNotReturnIt()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> result = new HashSet<ConsoleKey>();

            GraphicManager.ComputePressedKeys(newKeys, currentKeys, result);

            Assert.DoesNotContain(ConsoleKey.A, result);
            Assert.Contains(ConsoleKey.B, result);
        }

        /// <summary>
        /// Tests that compute held keys with common key returns it
        /// </summary>
        [Fact]
        public void ComputeHeldKeys_WithCommonKey_ReturnsIt()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.C };
            HashSet<ConsoleKey> result = new HashSet<ConsoleKey>();

            GraphicManager.ComputeHeldKeys(newKeys, currentKeys, result);

            Assert.Contains(ConsoleKey.A, result);
            Assert.DoesNotContain(ConsoleKey.B, result);
            Assert.DoesNotContain(ConsoleKey.C, result);
        }

        /// <summary>
        /// Tests that compute held keys with no common keys returns empty
        /// </summary>
        [Fact]
        public void ComputeHeldKeys_WithNoCommonKeys_ReturnsEmpty()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.B };
            HashSet<ConsoleKey> result = new HashSet<ConsoleKey>();

            GraphicManager.ComputeHeldKeys(newKeys, currentKeys, result);

            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that compute released keys with removed key returns it
        /// </summary>
        [Fact]
        public void ComputeReleasedKeys_WithRemovedKey_ReturnsIt()
        {
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> result = new HashSet<ConsoleKey>();

            GraphicManager.ComputeReleasedKeys(currentKeys, newKeys, result);

            Assert.Contains(ConsoleKey.B, result);
            Assert.DoesNotContain(ConsoleKey.A, result);
        }

        /// <summary>
        /// Tests that compute released keys with all keys still present returns empty
        /// </summary>
        [Fact]
        public void ComputeReleasedKeys_WithAllKeysStillPresent_ReturnsEmpty()
        {
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> result = new HashSet<ConsoleKey>();

            GraphicManager.ComputeReleasedKeys(currentKeys, newKeys, result);

            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that all keys contains expected keys
        /// </summary>
        [Fact]
        public void AllKeys_ContainsExpectedKeys()
        {
            GraphicManager manager = new GraphicManager(new Alis.Core.Ecs.Systems.Scope.Context(new Alis.Core.Ecs.Systems.Configuration.Setting()));

            Assert.Contains(ConsoleKey.A, manager.allKeys);
            Assert.Contains(ConsoleKey.Z, manager.allKeys);
            Assert.Contains(ConsoleKey.Spacebar, manager.allKeys);
            Assert.Contains(ConsoleKey.Escape, manager.allKeys);
            Assert.Contains(ConsoleKey.Enter, manager.allKeys);
        }

        /// <summary>
        /// Tests that update key timestamps with pressed keys adds timestamps
        /// </summary>
        [Fact]
        public void UpdateKeyTimestamps_WithPressedKeys_AddsTimestamps()
        {
            Context context = CreateContext();
            GraphicManager manager = new GraphicManager(context);
            HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> releasedKeys = new HashSet<ConsoleKey>();
            DateTime now = DateTime.UtcNow;

            manager.UpdateKeyTimestamps(pressedKeys, releasedKeys, now);

            FieldInfo timestampsField = typeof(GraphicManager).GetField("keyDownTimestamps",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            Dictionary<ConsoleKey, DateTime> timestamps = (Dictionary<ConsoleKey, DateTime>)timestampsField.GetValue(manager);

            Assert.True(timestamps.ContainsKey(ConsoleKey.A));
        }

        /// <summary>
        ///     Tests that update key timestamps with released keys removes timestamps
        /// </summary>
        [Fact]
        public void UpdateKeyTimestamps_WithReleasedKeys_RemovesTimestamps()
        {
            Context context = CreateContext();
            GraphicManager manager = new GraphicManager(context);
            HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> releasedKeys = new HashSet<ConsoleKey>();
            DateTime now = DateTime.UtcNow;

            manager.UpdateKeyTimestamps(pressedKeys, releasedKeys, now);

            releasedKeys = new HashSet<ConsoleKey> { ConsoleKey.A };
            pressedKeys = new HashSet<ConsoleKey>();

            manager.UpdateKeyTimestamps(pressedKeys, releasedKeys, now);

            FieldInfo timestampsField = typeof(GraphicManager).GetField("keyDownTimestamps",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            Dictionary<ConsoleKey, DateTime> timestamps = (Dictionary<ConsoleKey, DateTime>)timestampsField.GetValue(manager);

            Assert.False(timestamps.ContainsKey(ConsoleKey.A));
        }
        
        /// <summary>
        /// Creates the context
        /// </summary>
        /// <returns>The ctx</returns>
        private static Context CreateContext()
        {
            Context ctx = new Context(new Setting());
            return ctx;
        }
    }
}
