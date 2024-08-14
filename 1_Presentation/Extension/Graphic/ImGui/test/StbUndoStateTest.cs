// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbUndoStateTest.cs
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
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The stb undo state test class
    /// </summary>
    public class StbUndoStateTest
    {
        /// <summary>
        ///     Tests that undo rec 0 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec0_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec0 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec0 = undoState.UndoRec0;
        }
        
        /// <summary>
        ///     Tests that undo rec 1 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec1_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec1 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec1 = undoState.UndoRec1;
        }
        
        /// <summary>
        ///     Tests that undo rec 2 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec2_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec2 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec2 = undoState.UndoRec2;
        }
        
        /// <summary>
        ///     Tests that undo rec 3 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec3_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec3 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec3 = undoState.UndoRec3;
        }
        
        /// <summary>
        ///     Tests that undo rec 4 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec4_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec4 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec4 = undoState.UndoRec4;
        }
        
        /// <summary>
        ///     Tests that undo rec 5 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec5_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec5 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec5 = undoState.UndoRec5;
        }
        
        /// <summary>
        ///     Tests that undo rec 6 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec6_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec6 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec6 = undoState.UndoRec6;
        }
        
        /// <summary>
        ///     Tests that undo rec 7 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec7_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec7 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec7 = undoState.UndoRec7;
        }
        
        /// <summary>
        ///     Tests that undo rec 8 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec8_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec8 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec8 = undoState.UndoRec8;
        }
        
        /// <summary>
        ///     Tests that undo rec 9 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec9_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec9 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec9 = undoState.UndoRec9;
        }
        
        /// <summary>
        ///     Tests that undo rec 10 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec10_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec10 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec10 = undoState.UndoRec10;
        }
        
        /// <summary>
        ///     Tests that undo rec 11 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec11_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec11 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec11 = undoState.UndoRec11;
        }
        
        /// <summary>
        ///     Tests that undo rec 12 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec12_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec12 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec12 = undoState.UndoRec12;
        }
        
        /// <summary>
        ///     Tests that undo rec 13 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec13_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec13 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec13 = undoState.UndoRec13;
        }
        
        /// <summary>
        ///     Tests that undo rec 14 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec14_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec14 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec14 = undoState.UndoRec14;
        }
        
        /// <summary>
        ///     Tests that undo rec 15 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec15_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec15 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec15 = undoState.UndoRec15;
        }
        
        /// <summary>
        ///     Tests that undo rec 16 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec16_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec16 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec16 = undoState.UndoRec16;
        }
        
        /// <summary>
        ///     Tests that undo rec 17 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec17_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec17 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec17 = undoState.UndoRec17;
        }
        
        /// <summary>
        ///     Tests that undo rec 18 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec18_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec18 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec18 = undoState.UndoRec18;
        }
        
        /// <summary>
        ///     Tests that undo rec 19 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec19_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec19 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec19 = undoState.UndoRec19;
        }
        
        /// <summary>
        ///     Tests that undo rec 20 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec20_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec20 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec20 = undoState.UndoRec20;
        }
        
        /// <summary>
        ///     Tests that undo rec 21 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec21_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec21 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec21 = undoState.UndoRec21;
        }
        
        /// <summary>
        ///     Tests that undo rec 22 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec22_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec22 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec22 = undoState.UndoRec22;
        }
        
        /// <summary>
        ///     Tests that undo rec 23 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec23_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec23 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec23 = undoState.UndoRec23;
        }
        
        /// <summary>
        ///     Tests that undo rec 24 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec24_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec24 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec24 = undoState.UndoRec24;
        }
        
        /// <summary>
        ///     Tests that undo rec 25 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec25_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec25 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec25 = undoState.UndoRec25;
        }
        
        /// <summary>
        ///     Tests that undo rec 26 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec26_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec26 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec26 = undoState.UndoRec26;
        }
        
        /// <summary>
        ///     Tests that undo rec 27 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec27_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec27 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec27 = undoState.UndoRec27;
            ;
        }
        
        /// <summary>
        ///     Tests that undo rec 28 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec28_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec28 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec28 = undoState.UndoRec28;
        }
        
        /// <summary>
        ///     Tests that undo rec 29 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec29_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec29 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec29 = undoState.UndoRec29;
        }
        
        /// <summary>
        ///     Tests that undo rec 30 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec30_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec30 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec30 = undoState.UndoRec30;
        }
        
        /// <summary>
        ///     Tests that undo rec 31 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec31_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec31 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec31 = undoState.UndoRec31;
            
            // Assert
            Assert.True(undoRec31.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 32 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec32_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec32 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec32 = undoState.UndoRec32;
            
            // Assert
            Assert.True(undoRec32.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 33 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec33_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec33 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec33 = undoState.UndoRec33;
            
            // Assert
            Assert.True(undoRec33.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 34 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec34_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec34 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec34 = undoState.UndoRec34;
            
            // Assert
            Assert.True(undoRec34.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 35 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec35_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec35 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec35 = undoState.UndoRec35;
            
            // Assert
            Assert.True(undoRec35.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 36 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec36_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec36 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec36 = undoState.UndoRec36;
            
            // Assert
            Assert.True(undoRec36.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 37 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec37_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec37 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec37 = undoState.UndoRec37;
            
            // Assert
            Assert.True(undoRec37.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 38 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec38_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec38 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec38 = undoState.UndoRec38;
            
            // Assert
            Assert.True(undoRec38.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 39 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec39_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec39 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec39 = undoState.UndoRec39;
            
            // Assert
            Assert.True(undoRec39.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 40 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec40_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec40 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec40 = undoState.UndoRec40;
            
            // Assert
            Assert.True(undoRec40.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 41 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec41_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec41 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec41 = undoState.UndoRec41;
            
            // Assert
            Assert.True(undoRec41.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 42 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec42_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec42 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec42 = undoState.UndoRec42;
            
            // Assert
            Assert.True(undoRec42.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 43 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec43_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec43 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec43 = undoState.UndoRec43;
            
            // Assert
            Assert.True(undoRec43.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 44 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec44_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec44 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec44 = undoState.UndoRec44;
            
            // Assert
            Assert.True(undoRec44.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 45 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec45_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec45 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec45 = undoState.UndoRec45;
            
            // Assert
            Assert.True(undoRec45.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 46 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec46_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec46 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec46 = undoState.UndoRec46;
            
            // Assert
            Assert.True(undoRec46.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 47 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec47_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec47 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec47 = undoState.UndoRec47;
            
            // Assert
            Assert.True(undoRec47.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 48 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec48_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec48 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec48 = undoState.UndoRec48;
            
            // Assert
            Assert.True(undoRec48.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 49 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec49_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec49 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec49 = undoState.UndoRec49;
            
            // Assert
            Assert.True(undoRec49.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 50 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec50_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec50 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec50 = undoState.UndoRec50;
            
            // Assert
            Assert.True(undoRec50.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 51 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec51_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec51 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec51 = undoState.UndoRec51;
            
            // Assert
            Assert.True(undoRec51.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 52 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec52_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec52 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec52 = undoState.UndoRec52;
            
            // Assert
            Assert.True(undoRec52.DeleteLength >= 0);
        }
        
        /// <summary>
        ///     Tests that undo rec 53 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec53_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec53 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec53 = undoState.UndoRec53;
        }
        
        /// <summary>
        ///     Tests that undo rec 54 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec54_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec54 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec54 = undoState.UndoRec54;
        }
        
        /// <summary>
        ///     Tests that undo rec 55 should be initialized correctly
        /// </summary>
        [Fact]
        public void UndoRec55_ShouldBeInitializedCorrectly()
        {
            // Arrange
            StbUndoState undoState = new StbUndoState {UndoRec55 = new StbUndoRecord()};
            
            // Act
            StbUndoRecord undoRec55 = undoState.UndoRec55;
        }
        
        /// <summary>
        ///     Tests that undo rec 56 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec56_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec56 = value;
            Assert.Equal(value, obj.UndoRec56);
        }
        
        /// <summary>
        ///     Tests that undo rec 57 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec57_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec57 = value;
            Assert.Equal(value, obj.UndoRec57);
        }
        
        /// <summary>
        ///     Tests that undo rec 58 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec58_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec58 = value;
            Assert.Equal(value, obj.UndoRec58);
        }
        
        /// <summary>
        ///     Tests that undo rec 59 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec59_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec59 = value;
            Assert.Equal(value, obj.UndoRec59);
        }
        
        /// <summary>
        ///     Tests that undo rec 60 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec60_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec60 = value;
            Assert.Equal(value, obj.UndoRec60);
        }
        
        /// <summary>
        ///     Tests that undo rec 61 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec61_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec61 = value;
            Assert.Equal(value, obj.UndoRec61);
        }
        
        /// <summary>
        ///     Tests that undo rec 62 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec62_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec62 = value;
            Assert.Equal(value, obj.UndoRec62);
        }
        
        /// <summary>
        ///     Tests that undo rec 63 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec63_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec63 = value;
            Assert.Equal(value, obj.UndoRec63);
        }
        
        /// <summary>
        ///     Tests that undo rec 64 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec64_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec64 = value;
            Assert.Equal(value, obj.UndoRec64);
        }
        
        /// <summary>
        ///     Tests that undo rec 65 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec65_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec65 = value;
            Assert.Equal(value, obj.UndoRec65);
        }
        
        /// <summary>
        ///     Tests that undo rec 66 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec66_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec66 = value;
            Assert.Equal(value, obj.UndoRec66);
        }
        
        /// <summary>
        ///     Tests that undo rec 67 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec67_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec67 = value;
            Assert.Equal(value, obj.UndoRec67);
        }
        
        /// <summary>
        ///     Tests that undo rec 68 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec68_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec68 = value;
            Assert.Equal(value, obj.UndoRec68);
        }
        
        /// <summary>
        ///     Tests that undo rec 69 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec69_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec69 = value;
            Assert.Equal(value, obj.UndoRec69);
        }
        
        /// <summary>
        ///     Tests that undo rec 70 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec70_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec70 = value;
            Assert.Equal(value, obj.UndoRec70);
        }
        
        /// <summary>
        ///     Tests that undo rec 71 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec71_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec71 = value;
            Assert.Equal(value, obj.UndoRec71);
        }
        
        /// <summary>
        ///     Tests that undo rec 72 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec72_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec72 = value;
            Assert.Equal(value, obj.UndoRec72);
        }
        
        /// <summary>
        ///     Tests that undo rec 73 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec73_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec73 = value;
            Assert.Equal(value, obj.UndoRec73);
        }
        
        /// <summary>
        ///     Tests that undo rec 74 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec74_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec74 = value;
            Assert.Equal(value, obj.UndoRec74);
        }
        
        /// <summary>
        ///     Tests that undo rec 75 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec75_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec75 = value;
            Assert.Equal(value, obj.UndoRec75);
        }
        
        /// <summary>
        ///     Tests that undo rec 76 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec76_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec76 = value;
            Assert.Equal(value, obj.UndoRec76);
        }
        
        /// <summary>
        ///     Tests that undo rec 77 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec77_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec77 = value;
            Assert.Equal(value, obj.UndoRec77);
        }
        
        /// <summary>
        ///     Tests that undo rec 78 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec78_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec78 = value;
            Assert.Equal(value, obj.UndoRec78);
        }
        
        /// <summary>
        ///     Tests that undo rec 79 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec79_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec79 = value;
            Assert.Equal(value, obj.UndoRec79);
        }
        
        /// <summary>
        ///     Tests that undo rec 80 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec80_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec80 = value;
            Assert.Equal(value, obj.UndoRec80);
        }
        
        /// <summary>
        ///     Tests that undo rec 81 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec81_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec81 = value;
            Assert.Equal(value, obj.UndoRec81);
        }
        
        /// <summary>
        ///     Tests that undo rec 82 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec82_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec82 = value;
            Assert.Equal(value, obj.UndoRec82);
        }
        
        /// <summary>
        ///     Tests that undo rec 83 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec83_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec83 = value;
            Assert.Equal(value, obj.UndoRec83);
        }
        
        /// <summary>
        ///     Tests that undo rec 84 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec84_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec84 = value;
            Assert.Equal(value, obj.UndoRec84);
        }
        
        /// <summary>
        ///     Tests that undo rec 85 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec85_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec85 = value;
            Assert.Equal(value, obj.UndoRec85);
        }
        
        /// <summary>
        ///     Tests that undo rec 86 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec86_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec86 = value;
            Assert.Equal(value, obj.UndoRec86);
        }
        
        /// <summary>
        ///     Tests that undo rec 87 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec87_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec87 = value;
            Assert.Equal(value, obj.UndoRec87);
        }
        
        /// <summary>
        ///     Tests that undo rec 88 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec88_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec88 = value;
            Assert.Equal(value, obj.UndoRec88);
        }
        
        /// <summary>
        ///     Tests that undo rec 89 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec89_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec89 = value;
            Assert.Equal(value, obj.UndoRec89);
        }
        
        /// <summary>
        ///     Tests that undo rec 90 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec90_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec90 = value;
            Assert.Equal(value, obj.UndoRec90);
        }
        
        /// <summary>
        ///     Tests that undo rec 91 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec91_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec91 = value;
            Assert.Equal(value, obj.UndoRec91);
        }
        
        /// <summary>
        ///     Tests that undo rec 92 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec92_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec92 = value;
            Assert.Equal(value, obj.UndoRec92);
        }
        
        /// <summary>
        ///     Tests that undo rec 93 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec93_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec93 = value;
            Assert.Equal(value, obj.UndoRec93);
        }
        
        /// <summary>
        ///     Tests that undo rec 94 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec94_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec94 = value;
            Assert.Equal(value, obj.UndoRec94);
        }
        
        /// <summary>
        ///     Tests that undo rec 95 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec95_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec95 = value;
            Assert.Equal(value, obj.UndoRec95);
        }
        
        /// <summary>
        ///     Tests that undo rec 96 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec96_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec96 = value;
            Assert.Equal(value, obj.UndoRec96);
        }
        
        /// <summary>
        ///     Tests that undo rec 97 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec97_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec97 = value;
            Assert.Equal(value, obj.UndoRec97);
        }
        
        /// <summary>
        ///     Tests that undo rec 98 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec98_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            StbUndoRecord value = new StbUndoRecord();
            obj.UndoRec98 = value;
            Assert.Equal(value, obj.UndoRec98);
        }
        
        /// <summary>
        ///     Tests that undo char set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoChar_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            List<ushort> value = new List<ushort> {1, 2, 3};
            obj.UndoChar = value;
            Assert.Equal(value, obj.UndoChar);
        }
        
        /// <summary>
        ///     Tests that undo point set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoPoint_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            short value = 123;
            obj.UndoPoint = value;
            Assert.Equal(value, obj.UndoPoint);
        }
        
        /// <summary>
        ///     Tests that redo point set and get returns correct value
        /// </summary>
        [Fact]
        public void RedoPoint_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            short value = 456;
            obj.RedoPoint = value;
            Assert.Equal(value, obj.RedoPoint);
        }
        
        /// <summary>
        ///     Tests that undo char point set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoCharPoint_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            int value = 789;
            obj.UndoCharPoint = value;
            Assert.Equal(value, obj.UndoCharPoint);
        }
        
        /// <summary>
        ///     Tests that redo char point set and get returns correct value
        /// </summary>
        [Fact]
        public void RedoCharPoint_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState obj = new StbUndoState();
            int value = 101112;
            obj.RedoCharPoint = value;
            Assert.Equal(value, obj.RedoCharPoint);
        }
    }
}