// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactVelocityConstraintTest.cs
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

using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics.Solver;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Solver
{
    /// <summary>
    /// The contact velocity constraint test class
    /// </summary>
    public class ContactVelocityConstraintTest
    {
        /// <summary>
        /// Tests that contact velocity constraint constructor test
        /// </summary>
        [Fact]
        public void ContactVelocityConstraintConstructorTest()
        {
            // Arrange
            ContactVelocityConstraint contactVelocityConstraint = new ContactVelocityConstraint();
            
            // Assert
            Assert.NotNull(contactVelocityConstraint);
            Assert.NotNull(contactVelocityConstraint.Points);
            Assert.Equal(Settings.ManifoldPoints, contactVelocityConstraint.Points.Length);
        }
        
        /// <summary>
        /// Tests that contact velocity constraint properties test
        /// </summary>
        [Fact]
        public void ContactVelocityConstraintPropertiesTest()
        {
            // Arrange
            ContactVelocityConstraint contactVelocityConstraint = new ContactVelocityConstraint();
            
            // Act
            contactVelocityConstraint.ContactIndex = 1;
            contactVelocityConstraint.Friction = 0.5f;
            contactVelocityConstraint.IndexA = 1;
            contactVelocityConstraint.IndexB = 2;
            contactVelocityConstraint.InvIa = 0.5f;
            contactVelocityConstraint.InvIb = 0.5f;
            contactVelocityConstraint.InvMassA = 0.5f;
            contactVelocityConstraint.InvMassB = 0.5f;
            contactVelocityConstraint.K = new Matrix2X2();
            contactVelocityConstraint.Normal = new Vector2(1.0f, 1.0f);
            contactVelocityConstraint.NormalMass = new Matrix2X2();
            contactVelocityConstraint.PointCount = 1;
            contactVelocityConstraint.Restitution = 0.5f;
            contactVelocityConstraint.TangentSpeed = 0.5f;
            contactVelocityConstraint.Threshold = 0.5f;
            
            // Assert
            Assert.Equal(1, contactVelocityConstraint.ContactIndex);
            Assert.Equal(0.5f, contactVelocityConstraint.Friction);
            Assert.Equal(1, contactVelocityConstraint.IndexA);
            Assert.Equal(2, contactVelocityConstraint.IndexB);
            Assert.Equal(0.5f, contactVelocityConstraint.InvIa);
            Assert.Equal(0.5f, contactVelocityConstraint.InvIb);
            Assert.Equal(0.5f, contactVelocityConstraint.InvMassA);
            Assert.Equal(0.5f, contactVelocityConstraint.InvMassB);
            Assert.Equal(new Vector2(1.0f, 1.0f), contactVelocityConstraint.Normal);
            Assert.Equal(1, contactVelocityConstraint.PointCount);
            Assert.Equal(0.5f, contactVelocityConstraint.Restitution);
            Assert.Equal(0.5f, contactVelocityConstraint.TangentSpeed);
            Assert.Equal(0.5f, contactVelocityConstraint.Threshold);
        }
    }
}