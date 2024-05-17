// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeneralSettingBuilderTest.cs
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

using Alis.Builder.Core.Ecs.System.Setting.General;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System.Setting.General
{
    /// <summary>
    /// The general setting builder test class
    /// </summary>
    public class GeneralSettingBuilderTest
    {
        /// <summary>
        /// Tests that general setting builder default constructor valid input
        /// </summary>
        [Fact]
        public void GeneralSettingBuilder_DefaultConstructor_ValidInput()
        {
            var generalSettingBuilder = new GeneralSettingBuilder();
            
            Assert.NotNull(generalSettingBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            var generalSettingBuilder = new GeneralSettingBuilder();
            
            var generalSetting = generalSettingBuilder.Build();
            
            Assert.NotNull(generalSetting);
        }
        
        /// <summary>
        /// Tests that author valid input
        /// </summary>
        [Fact]
        public void Author_ValidInput()
        {
            var generalSettingBuilder = new GeneralSettingBuilder();
            
            generalSettingBuilder.Author("Test Author");
            
            Assert.Equal("Test Author", generalSettingBuilder.Build().Author);
        }
        
        /// <summary>
        /// Tests that debug valid input
        /// </summary>
        [Fact]
        public void Debug_ValidInput()
        {
            var generalSettingBuilder = new GeneralSettingBuilder();
            
            generalSettingBuilder.Debug(true);
            
            Assert.True(generalSettingBuilder.Build().Debug);
        }
        
        /// <summary>
        /// Tests that description valid input
        /// </summary>
        [Fact]
        public void Description_ValidInput()
        {
            var generalSettingBuilder = new GeneralSettingBuilder();
            
            generalSettingBuilder.Description("Test Description");
            
            Assert.Equal("Test Description", generalSettingBuilder.Build().Description);
        }
        
        /// <summary>
        /// Tests that icon valid input
        /// </summary>
        [Fact]
        public void Icon_ValidInput()
        {
            var generalSettingBuilder = new GeneralSettingBuilder();
            
            generalSettingBuilder.Icon("Test Icon");
            
            Assert.Equal("Test Icon", generalSettingBuilder.Build().Icon);
        }
        
        /// <summary>
        /// Tests that license valid input
        /// </summary>
        [Fact]
        public void License_ValidInput()
        {
            var generalSettingBuilder = new GeneralSettingBuilder();
            
            generalSettingBuilder.License("Test License");
            
            Assert.Equal("Test License", generalSettingBuilder.Build().License);
        }
        
        /// <summary>
        /// Tests that name valid input
        /// </summary>
        [Fact]
        public void Name_ValidInput()
        {
            var generalSettingBuilder = new GeneralSettingBuilder();
            
            generalSettingBuilder.Name("Test Name");
            
            Assert.Equal("Test Name", generalSettingBuilder.Build().Name);
        }
        
        /// <summary>
        /// Tests that version valid input
        /// </summary>
        [Fact]
        public void Version_ValidInput()
        {
            var generalSettingBuilder = new GeneralSettingBuilder();
            
            generalSettingBuilder.Version("Test Version");
            
            Assert.Equal("Test Version", generalSettingBuilder.Build().Version);
        }
    }
}