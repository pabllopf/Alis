// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InputManagerTest.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Scene;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Manager.Input
{
    /// <summary>
    /// The input manager test class
    /// </summary>
    public class InputManagerTest
    {
        /// <summary>
        /// Tests that on init valid input
        /// </summary>
        [Fact]
        public void OnInit_ValidInput()
        {
            InputManager inputManager = new InputManager();
            inputManager.OnInit();
            
            
        }
        
        /// <summary>
        /// Tests that on dispatch events valid input
        /// </summary>
        [Fact]
        public void OnDispatchEvents_ValidInput()
        {
            InputManager inputManager = new InputManager();
            inputManager.OnDispatchEvents();
            
            
        }
        
        /// <summary>
        /// Tests that handle sdl quit event valid input
        /// </summary>
        [Fact]
        public void HandleSdlQuitEvent_ValidInput()
        {
            InputManager inputManager = new InputManager();
            // You would need to simulate an SDL Quit event here
            
            
        }
        
        /// <summary>
        /// Tests that handle sdl keyup event valid input
        /// </summary>
        [Fact]
        public void HandleSdlKeyupEvent_ValidInput()
        {
            InputManager inputManager = new InputManager();
            // You would need to simulate an SDL Keyup event here
            
            
        }
        
        /// <summary>
        /// Tests that handle sdl keydown event valid input
        /// </summary>
        [Fact]
        public void HandleSdlKeydownEvent_ValidInput()
        {
            InputManager inputManager = new InputManager();
            // You would need to simulate an SDL Keydown event here
            
            
        }
        
        /// <summary>
        /// Tests that handle sdl joy button down event valid input
        /// </summary>
        [Fact]
        public void HandleSdlJoyButtonDownEvent_ValidInput()
        {
            InputManager inputManager = new InputManager();
            // You would need to simulate an SDL JoyButtonDown event here
            
            
        }
        
        /// <summary>
        /// Tests that handle sdl joy axis motion event valid input
        /// </summary>
        [Fact]
        public void HandleSdlJoyAxisMotionEvent_ValidInput()
        {
            InputManager inputManager = new InputManager();
            // You would need to simulate an SDL JoyAxisMotion event here
            
            
        }
        
        /// <summary>
        /// Tests that notify key hold valid input
        /// </summary>
        [Fact]
        public void NotifyKeyHold_ValidInput()
        {
            InputManager inputManager = new InputManager();
        }
        
        /// <summary>
        /// Tests that notify key press valid input
        /// </summary>
        [Fact]
        public void NotifyKeyPress_ValidInput()
        {
            InputManager inputManager = new InputManager();
            // You would need to simulate a key press here
            
            
        }
        
        /// <summary>
        /// Tests that notify key release valid input
        /// </summary>
        [Fact]
        public void NotifyKeyRelease_ValidInput()
        {
            InputManager inputManager = new InputManager();
            // You would need to simulate a key release here
        }
        
        /// <summary>
        /// Tests that notify key hold valid input v 2
        /// </summary>
        [Fact]
        public void NotifyKeyHold_ValidInput_v2()
        {
            InputManager inputManager = new InputManager();
            inputManager.tempListOfKeys = new List<KeyCode> {KeyCode.A, KeyCode.B};
            inputManager.NotifyKeyHold();
            
        }
        
        /// <summary>
        /// Tests that notify key press valid input v 2
        /// </summary>
        [Fact]
        public void NotifyKeyPress_ValidInput_v2()
        {
            InputManager inputManager = new InputManager();
            inputManager.NotifyKeyPress(KeyCode.A);
            
        }
        
        /// <summary>
        /// Tests that notify key release valid input v 2
        /// </summary>
        [Fact]
        public void NotifyKeyRelease_ValidInput_v2()
        {
            InputManager inputManager = new InputManager();
            inputManager.NotifyKeyRelease(KeyCode.A);
            
        }
        
        /// <summary>
        /// Tests that notify key hold with key valid input
        /// </summary>
        [Fact]
        public void NotifyKeyHoldWithKey_ValidInput()
        {
            InputManager inputManager = new InputManager();
            inputManager.NotifyKeyHold(KeyCode.A);
            
        }
    }
}