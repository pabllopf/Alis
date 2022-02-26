// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TestTimeStep.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Systems.Physics2D.Dynamics;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Dynamics
{
    /// <summary>
    ///     The test time step class
    /// </summary>
    public class TestTimeStep
    {
        /// <summary>
        ///     The step
        /// </summary>
        private TimeStep step;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [SetUp]
        public void Setup() => step = new TimeStep();

        /// <summary>
        ///     Tests that test time step construction
        /// </summary>
        [Test]
        public void TestTimeStepConstruction()
        {
        }

        /// <summary>
        ///     Tests that test time step constructor empty
        /// </summary>
        [Test]
        public void TestTimeStepConstructorEmpty()
        {
            TimeStep step = new TimeStep();
            Assert.AreEqual(0.0, step.DeltaTime);
            Assert.AreEqual(0.0, step.InvertedDeltaTime);
            Assert.AreEqual(0.0, step.DeltaTimeRatio);
            Assert.AreEqual(0.0, step.PositionIterations);
            Assert.AreEqual(0.0, step.VelocityIterations);
            Assert.AreEqual(false, step.WarmStarting);
        }
    }
}