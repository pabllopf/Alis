// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactPositionConstraintTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Dynamics.Solver;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Solver
{
    /// <summary>
    /// The contact position constraint test class
    /// </summary>
    public class ContactPositionConstraintTest
    {
        /// <summary>
        /// Tests that contact position constraint properties test
        /// </summary>
        [Fact]
        public void ContactPositionConstraintPropertiesTest()
        {
            // Arrange
            ContactPositionConstraint contactPositionConstraint = new ContactPositionConstraint();
            
            // Act
            contactPositionConstraint.IndexA = 1;
            contactPositionConstraint.IndexB = 2;
            contactPositionConstraint.InvIa = 0.5f;
            contactPositionConstraint.InvIb = 0.5f;
            contactPositionConstraint.InvMassA = 1.0f;
            contactPositionConstraint.InvMassB = 1.0f;
            contactPositionConstraint.LocalCenterA = new Vector2(1.0f, 1.0f);
            contactPositionConstraint.LocalCenterB = new Vector2(2.0f, 2.0f);
            contactPositionConstraint.LocalNormal = new Vector2(0.0f, 1.0f);
            contactPositionConstraint.LocalPoint = new Vector2(1.5f, 1.5f);
            contactPositionConstraint.PointCount = 1;
            contactPositionConstraint.RadiusA = 1.0f;
            contactPositionConstraint.RadiusB = 1.0f;
            contactPositionConstraint.Type = ManifoldType.Circles;
            
            // Assert
            Assert.Equal(1, contactPositionConstraint.IndexA);
            Assert.Equal(2, contactPositionConstraint.IndexB);
            Assert.Equal(0.5f, contactPositionConstraint.InvIa);
            Assert.Equal(0.5f, contactPositionConstraint.InvIb);
            Assert.Equal(1.0f, contactPositionConstraint.InvMassA);
            Assert.Equal(1.0f, contactPositionConstraint.InvMassB);
            Assert.Equal(new Vector2(1.0f, 1.0f), contactPositionConstraint.LocalCenterA);
            Assert.Equal(new Vector2(2.0f, 2.0f), contactPositionConstraint.LocalCenterB);
            Assert.Equal(new Vector2(0.0f, 1.0f), contactPositionConstraint.LocalNormal);
            Assert.Equal(new Vector2(1.5f, 1.5f), contactPositionConstraint.LocalPoint);
            Assert.Equal(1, contactPositionConstraint.PointCount);
            Assert.Equal(1.0f, contactPositionConstraint.RadiusA);
            Assert.Equal(1.0f, contactPositionConstraint.RadiusB);
            Assert.Equal(ManifoldType.Circles, contactPositionConstraint.Type);
        }
    }
}