// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoGameBuilderTest.cs
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

using Alis.Builder.Core.Ecs.System;
using Alis.Builder.Core.Ecs.System.Manager.Scene;
using Alis.Builder.Core.Ecs.System.Setting;
using Alis.Core.Ecs;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Setting;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System
{
    /// <summary>
    /// The video game builder test class
    /// </summary>
    public class VideoGameBuilderTest
    {
        /// <summary>
        /// Tests that video game builder default constructor valid input
        /// </summary>
        [Fact]
        public void VideoGameBuilder_DefaultConstructor_ValidInput()
        {
            VideoGameBuilder videoGameBuilder = new VideoGameBuilder();
            
            Assert.NotNull(videoGameBuilder);
        }
        
        /// <summary>
        /// Tests that settings valid input
        /// </summary>
        [Fact]
        public void Settings_ValidInput()
        {
            VideoGameBuilder videoGameBuilder = new VideoGameBuilder();
            Settings settings = new Settings();
            
            videoGameBuilder.Settings(s => settings);
            
            Assert.Equal(settings, videoGameBuilder.Build().Context.Settings);
        }
        
        /// <summary>
        /// Tests that world valid input
        /// </summary>
        [Fact]
        public void World_ValidInput()
        {
            VideoGameBuilder videoGameBuilder = new VideoGameBuilder();
            SceneManager sceneManager = new SceneManager();
            
            videoGameBuilder.World(s => sceneManager);
            
            Assert.Equal(sceneManager, videoGameBuilder.Build().Context.SceneManager);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput_v2()
        {
            VideoGameBuilder videoGameBuilder = new VideoGameBuilder();
            
            VideoGame videoGame = videoGameBuilder.Build();
            
            Assert.NotNull(videoGame);
        }
        
        /// <summary>
        /// Tests that video game builder default constructor valid input v 2
        /// </summary>
        [Fact]
        public void VideoGameBuilder_DefaultConstructor_ValidInput_v2()
        {
            VideoGameBuilder videoGameBuilder = new VideoGameBuilder();
            
            Assert.NotNull(videoGameBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            VideoGameBuilder videoGameBuilder = new VideoGameBuilder();
            
            VideoGame videoGame = videoGameBuilder.Build();
            
            Assert.NotNull(videoGame);
        }
        
        /// <summary>
        /// Tests that settings valid input v 2
        /// </summary>
        [Fact]
        public void Settings_ValidInput_v2()
        {
            VideoGameBuilder videoGameBuilder = new VideoGameBuilder();
            SettingsBuilder settingsBuilder = new SettingsBuilder();
            
            videoGameBuilder.Settings(s => settingsBuilder.Build());
            
            Assert.NotNull(videoGameBuilder.Build().Context.Settings);
        }
        
        /// <summary>
        /// Tests that world valid input v 2
        /// </summary>
        [Fact]
        public void World_ValidInput_v2()
        {
            VideoGameBuilder videoGameBuilder = new VideoGameBuilder();
            SceneManagerBuilder sceneManagerBuilder = new SceneManagerBuilder();
            
            videoGameBuilder.World(s => sceneManagerBuilder.Build());
            
            Assert.NotNull(videoGameBuilder.Build().Context.SceneManager);
        }
    }
}