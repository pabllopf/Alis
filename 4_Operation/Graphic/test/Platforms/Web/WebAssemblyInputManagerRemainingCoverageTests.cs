// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyInputManagerRemainingCoverageTests.cs
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
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     The web assembly input manager remaining coverage tests class
    /// </summary>
    public class WebAssemblyInputManagerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor with null platform throws argument null
        /// </summary>
        [Fact]
        public void Constructor_WithNullPlatform_ThrowsArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => new WebAssemblyInputManager(null));
        }

        /// <summary>
        ///     Tests that constructor assigns platform
        /// </summary>
        [Fact]
        public void Constructor_AssignsPlatform()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);

            Assert.Same(platform, manager._platform);
        }

        /// <summary>
        ///     Tests that register key binding with single key stores binding
        /// </summary>
        [Fact]
        public void RegisterKeyBinding_WithSingleKey_StoresBinding()
        {
            WebAssemblyInputManager manager = new WebAssemblyInputManager(new WebAssemblyPlatform());

            manager.RegisterKeyBinding("jump", ConsoleKey.Spacebar);

            Assert.True(manager._keyBindings.ContainsKey("jump"));
        }

        /// <summary>
        ///     Tests that register key binding with multiple keys stores binding
        /// </summary>
        [Fact]
        public void RegisterKeyBinding_WithMultipleKeys_StoresBinding()
        {
            WebAssemblyInputManager manager = new WebAssemblyInputManager(new WebAssemblyPlatform());

            manager.RegisterKeyBinding("move", ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D);

            Assert.True(manager._keyBindings.ContainsKey("move"));
        }

        /// <summary>
        ///     Tests that register key binding twice accumulates keys
        /// </summary>
        [Fact]
        public void RegisterKeyBinding_Twice_AccumulatesKeys()
        {
            WebAssemblyInputManager manager = new WebAssemblyInputManager(new WebAssemblyPlatform());

            manager.RegisterKeyBinding("action", ConsoleKey.A);
            manager.RegisterKeyBinding("action", ConsoleKey.B);

            Assert.True(manager._keyBindings.ContainsKey("action"));
        }

        /// <summary>
        ///     Tests that clear key binding removes keys
        /// </summary>
        [Fact]
        public void ClearKeyBinding_RemovesKeys()
        {
            WebAssemblyInputManager manager = new WebAssemblyInputManager(new WebAssemblyPlatform());
            manager.RegisterKeyBinding("jump", ConsoleKey.Spacebar);

            manager.ClearKeyBinding("jump");

            Assert.Equal(0, manager._keyBindings["jump"]._keys.Count);
        }

        /// <summary>
        ///     Tests that clear key binding with unknown action does not throw
        /// </summary>
        [Fact]
        public void ClearKeyBinding_WithUnknownAction_DoesNotThrow()
        {
            WebAssemblyInputManager manager = new WebAssemblyInputManager(new WebAssemblyPlatform());

            manager.ClearKeyBinding("unknown");
        }

        /// <summary>
        ///     Tests that is action active with unknown action returns false
        /// </summary>
        [Fact]
        public void IsActionActive_WithUnknownAction_ReturnsFalse()
        {
            WebAssemblyInputManager manager = new WebAssemblyInputManager(new WebAssemblyPlatform());

            Assert.False(manager.IsActionActive("unknown"));
        }

        /// <summary>
        ///     Tests that is action just pressed with unknown action returns false
        /// </summary>
        [Fact]
        public void IsActionJustPressed_WithUnknownAction_ReturnsFalse()
        {
            WebAssemblyInputManager manager = new WebAssemblyInputManager(new WebAssemblyPlatform());

            Assert.False(manager.IsActionJustPressed("unknown"));
        }
    }
}
