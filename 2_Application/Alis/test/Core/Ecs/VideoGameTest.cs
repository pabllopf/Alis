// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoGameTest.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Builder.Core.Ecs.System;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Configuration;
using Alis.Core.Ecs.System.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs
{
    /// <summary>
    ///     The video game test class
    /// </summary>
    	  
	 public class VideoGameTest 
    {
        /// <summary>
        ///     Tests that is running set value should change is running
        /// </summary>
        [Fact]
        public void IsRunning_SetValue_ShouldChangeIsRunning()
        {
            VideoGame videoGame = new VideoGame();

            videoGame.Context.IsRunning = false;

            Assert.False(videoGame.Context.IsRunning);
        }

        /// <summary>
        ///     Tests that is running set value should change is running
        /// </summary>
        [Fact]
        public void IsRunning_SetValue_ShouldChangeIsRunning_v2()
        {
            VideoGame videoGame = new VideoGame(new Setting());

            videoGame.Context.IsRunning = false;

            Assert.False(videoGame.Context.IsRunning);
        }

        /// <summary>
        ///     Tests that builder should return video game builder
        /// </summary>
        [Fact]
        public void Builder_ShouldReturnVideoGameBuilder()
        {
            VideoGameBuilder result = VideoGame.Create();

            Assert.IsType<VideoGameBuilder>(result);
        }

        /// <summary>
        ///     Tests that set context should set context
        /// </summary>
        [Fact]
        public void SetContext_ShouldSetContext()
        {
            Context newContext = new Context(new Setting());

            VideoGame videoGame = new VideoGame(newContext);

            Assert.Equal(newContext.GetType(), videoGame.Context.GetType());
        }
    }
}