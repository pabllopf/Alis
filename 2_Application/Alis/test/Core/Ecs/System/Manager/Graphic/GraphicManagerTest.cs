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

using Alis.Core.Ecs;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.System.Manager.Graphic;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Manager.Graphic
{
    /// <summary>
    /// The graphic manager test class
    /// </summary>
    public class GraphicManagerTest
    {
        /// <summary>
        /// Tests that on enable valid input
        /// </summary>
        [Fact]
        public void OnEnable_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            GraphicManager graphicManager = new GraphicManager();
            graphicManager.OnEnable();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on init valid input
        /// </summary>
        [Fact]
        public void OnInit_ValidInput()
        {
            //VideoGame videoGame = new VideoGame();
            GraphicManager graphicManager = new GraphicManager();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on start valid input
        /// </summary>
        [Fact]
        public void OnStart_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            GraphicManager graphicManager = new GraphicManager();
            graphicManager.OnStart();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on update valid input
        /// </summary>
        [Fact]
        public void OnUpdate_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            GraphicManager graphicManager = new GraphicManager();
            graphicManager.OnUpdate();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on exit valid input
        /// </summary>
        [Fact]
        public void OnExit_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            GraphicManager graphicManager = new GraphicManager();
            graphicManager.OnExit();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that attach valid input
        /// </summary>
        [Fact]
        public void Attach_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            GraphicManager graphicManager = new GraphicManager();
            Sprite sprite = new Sprite();
            graphicManager.Attach(sprite);
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that un attach valid input
        /// </summary>
        [Fact]
        public void UnAttach_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            GraphicManager graphicManager = new GraphicManager();
            Sprite sprite = new Sprite();
            graphicManager.Attach(sprite);
            graphicManager.UnAttach(sprite);
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
    }
}