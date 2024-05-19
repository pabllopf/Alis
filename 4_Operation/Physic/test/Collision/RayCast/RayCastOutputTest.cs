// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RayCastOutputTest.cs
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
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.RayCast
{
    /// <summary>
    ///     The ray cast output test class
    /// </summary>
    public class RayCastOutputTest
    {
        /// <summary>
        ///     Tests that test contact constructor
        /// </summary>
        [Fact]
        public void Test_Contact_Constructor()
        {
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter());
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter());
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            Assert.NotNull(contact);
            Assert.Equal(fixtureA, contact.FixtureA);
            Assert.Equal(fixtureB, contact.FixtureB);
        }
        
        /// <summary>
        ///     Tests that test contact reset
        /// </summary>
        [Fact]
        public void Test_Contact_Reset()
        {
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter());
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter());
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            Fixture newFixtureA = new Fixture(new CircleShape(2), new Filter());
            Fixture newFixtureB = new Fixture(new CircleShape(2), new Filter());
            
            contact.Reset(newFixtureA, 1, newFixtureB, 1);
            
            Assert.Equal(newFixtureA, contact.FixtureA);
            Assert.Equal(newFixtureB, contact.FixtureB);
        }
        
        /// <summary>
        ///     Tests that test contact is sensor contact
        /// </summary>
        [Fact]
        public void Test_Contact_IsSensorContact()
        {
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter());
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter());
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            Assert.False(contact.IsSensorContact());
            
            fixtureA.IsSensor = true;
            Assert.True(contact.IsSensorContact());
        }
        
        /// <summary>
        ///     Tests that test contact enabled
        /// </summary>
        [Fact]
        public void Test_Contact_Enabled()
        {
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter());
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter());
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            Assert.True(contact.Enabled);
            
            contact.Enabled = false;
            Assert.False(contact.Enabled);
        }
        
        /// <summary>
        ///     Tests that test contact reset restitution
        /// </summary>
        [Fact]
        public void Test_Contact_ResetRestitution()
        {
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter())
            {
                Restitution = 0.5f
            };
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter())
            {
                Restitution = 0.6f
            };
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            contact.ResetRestitution();
            
            Assert.Equal(Settings.MixRestitution(fixtureA.Restitution, fixtureB.Restitution), contact.Restitution);
        }
        
        /// <summary>
        ///     Tests that test contact reset friction
        /// </summary>
        [Fact]
        public void Test_Contact_ResetFriction()
        {
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter())
            {
                Friction = 0.5f
            };
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter())
            {
                Friction = 0.6f
            };
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            contact.ResetFriction();
            
            Assert.Equal(Settings.MixFriction(fixtureA.Friction, fixtureB.Friction), contact.Friction);
        }
        
        /// <summary>
        ///     Tests that test contact reset restitution threshold
        /// </summary>
        [Fact]
        public void Test_Contact_ResetRestitutionThreshold()
        {
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter());
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter());
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            contact.ResetRestitutionThreshold();
            
            Assert.Equal(0, contact.RestitutionThreshold);
        }
        
        /// <summary>
        /// Tests that ray cast output fraction property set and get
        /// </summary>
        [Fact]
        public void RayCastOutput_FractionProperty_SetAndGet()
        {
            RayCastOutput output = new RayCastOutput();
            output.Fraction = 0.5f;
            
            Assert.Equal(0.5f, output.Fraction);
        }
        
        /// <summary>
        /// Tests that ray cast output normal property set and get
        /// </summary>
        [Fact]
        public void RayCastOutput_NormalProperty_SetAndGet()
        {
            RayCastOutput output = new RayCastOutput();
            output.Normal = new Vector2(1, 0);
            
            Assert.Equal(new Vector2(1, 0), output.Normal);
        }
    }
}