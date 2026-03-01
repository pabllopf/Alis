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

using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The time step test class
    /// </summary>
    public class TimeStepTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            TimeStep step = new TimeStep();
            
            Assert.Equal(0.0f, step.Dt);
            Assert.Equal(0.0f, step.InvDt);
            Assert.Equal(0.0f, step.DtRatio);
            Assert.Equal(0, step.VelocityIterations);
            Assert.Equal(0, step.PositionIterations);
        }

        /// <summary>
        ///     Tests that dt should set and get correctly
        /// </summary>
        [Fact]
        public void Dt_ShouldSetAndGetCorrectly()
        {
            TimeStep step = new TimeStep
            {
                Dt = 0.016f
            };
            
            Assert.Equal(0.016f, step.Dt);
        }

        /// <summary>
        ///     Tests that inv dt should set and get correctly
        /// </summary>
        [Fact]
        public void InvDt_ShouldSetAndGetCorrectly()
        {
            TimeStep step = new TimeStep
            {
                InvDt = 60.0f
            };
            
            Assert.Equal(60.0f, step.InvDt);
        }

        /// <summary>
        ///     Tests that dt ratio should set and get correctly
        /// </summary>
        [Fact]
        public void DtRatio_ShouldSetAndGetCorrectly()
        {
            TimeStep step = new TimeStep
            {
                DtRatio = 1.0f
            };
            
            Assert.Equal(1.0f, step.DtRatio);
        }

        /// <summary>
        ///     Tests that velocity iterations should set and get correctly
        /// </summary>
        [Fact]
        public void VelocityIterations_ShouldSetAndGetCorrectly()
        {
            TimeStep step = new TimeStep
            {
                VelocityIterations = 8
            };
            
            Assert.Equal(8, step.VelocityIterations);
        }

        /// <summary>
        ///     Tests that position iterations should set and get correctly
        /// </summary>
        [Fact]
        public void PositionIterations_ShouldSetAndGetCorrectly()
        {
            TimeStep step = new TimeStep
            {
                PositionIterations = 3
            };
            
            Assert.Equal(3, step.PositionIterations);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            TimeStep step = new TimeStep
            {
                Dt = 0.016f,
                InvDt = 60.0f,
                DtRatio = 1.0f,
                VelocityIterations = 8,
                PositionIterations = 3
            };
            
            Assert.Equal(0.016f, step.Dt);
            Assert.Equal(60.0f, step.InvDt);
            Assert.Equal(1.0f, step.DtRatio);
            Assert.Equal(8, step.VelocityIterations);
            Assert.Equal(3, step.PositionIterations);
        }

        /// <summary>
        ///     Tests that dt with zero should work
        /// </summary>
        [Fact]
        public void Dt_WithZero_ShouldWork()
        {
            TimeStep step = new TimeStep
            {
                Dt = 0.0f
            };
            
            Assert.Equal(0.0f, step.Dt);
        }

        /// <summary>
        ///     Tests that typical frame rate 60 fps should work
        /// </summary>
        [Fact]
        public void TypicalFrameRate60Fps_ShouldWork()
        {
            TimeStep step = new TimeStep
            {
                Dt = 1.0f / 60.0f,
                InvDt = 60.0f
            };
            
            Assert.InRange(step.Dt, 0.016f, 0.017f);
            Assert.Equal(60.0f, step.InvDt);
        }
    }
}

