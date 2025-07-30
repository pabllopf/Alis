// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeStepTest.cs
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

using Xunit;

namespace Alis.Core.Aspect.Time.Test
{
    /// <summary>
    ///     The time step test class
    /// </summary>
    public class TimeStepTest
    {
        /// <summary>
        ///     Tests that delta time get set should get and set correctly
        /// </summary>
        [Fact]
        public void DeltaTime_GetSet_ShouldGetAndSetCorrectly()
        {
            // Arrange
            TimeStep timeStep = new TimeStep
            {
                // Act
                DeltaTime = 0.5f
            };

            // Assert
            Assert.Equal(0.5f, timeStep.DeltaTime);
        }

        /// <summary>
        ///     Tests that delta time ratio get set should get and set correctly
        /// </summary>
        [Fact]
        public void DeltaTimeRatio_GetSet_ShouldGetAndSetCorrectly()
        {
            // Arrange
            TimeStep timeStep = new TimeStep
            {
                // Act
                DeltaTimeRatio = 2.0f
            };

            // Assert
            Assert.Equal(2.0f, timeStep.DeltaTimeRatio);
        }

        /// <summary>
        ///     Tests that inverted delta time get set should get and set correctly
        /// </summary>
        [Fact]
        public void InvertedDeltaTime_GetSet_ShouldGetAndSetCorrectly()
        {
            // Arrange
            TimeStep timeStep = new TimeStep
            {
                // Act
                InvertedDeltaTime = 0.1f
            };

            // Assert
            Assert.Equal(0.1f, timeStep.InvertedDeltaTime);
        }

        /// <summary>
        ///     Tests that inverted delta time zero get set should get and set correctly
        /// </summary>
        [Fact]
        public void InvertedDeltaTimeZero_GetSet_ShouldGetAndSetCorrectly()
        {
            // Arrange
            TimeStep timeStep = new TimeStep
            {
                // Act
                InvertedDeltaTimeZero = 0.05f
            };

            // Assert
            Assert.Equal(0.05f, timeStep.InvertedDeltaTimeZero);
        }

        /// <summary>
        ///     Tests that position iterations get set should get and set correctly
        /// </summary>
        [Fact]
        public void PositionIterations_GetSet_ShouldGetAndSetCorrectly()
        {
            // Arrange
            TimeStep timeStep = new TimeStep
            {
                // Act
                PositionIterations = 3
            };

            // Assert
            Assert.Equal(3, timeStep.PositionIterations);
        }

        /// <summary>
        ///     Tests that velocity iterations get set should get and set correctly
        /// </summary>
        [Fact]
        public void VelocityIterations_GetSet_ShouldGetAndSetCorrectly()
        {
            // Arrange
            TimeStep timeStep = new TimeStep
            {
                // Act
                VelocityIterations = 5
            };

            // Assert
            Assert.Equal(5, timeStep.VelocityIterations);
        }

        /// <summary>
        ///     Tests that warm starting get set should get and set correctly
        /// </summary>
        [Fact]
        public void WarmStarting_GetSet_ShouldGetAndSetCorrectly()
        {
            // Arrange
            TimeStep timeStep = new TimeStep
            {
                // Act
                WarmStarting = true
            };

            // Assert
            Assert.True(timeStep.WarmStarting);
        }
    }
}