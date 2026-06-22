// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderTest.cs
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
using Alis.Core.Ecs.Components.Collider;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Tests for the <see cref="BoxCollider"/> class.
    /// </summary>
    public class BoxColliderTest
    {
        /// <summary>
        ///     Tests that the default constructor initializes Width to 10.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWidthTo10()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Equal(10, collider.Width);
        }

        /// <summary>
        ///     Tests that the default constructor initializes Height to 10.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeHeightTo10()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Equal(10, collider.Height);
        }

        /// <summary>
        ///     Tests that the default constructor initializes Rotation to 0.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeRotationTo0()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Equal(0, collider.Rotation);
        }

        /// <summary>
        ///     Tests that the default constructor initializes RelativePosition to (0, 0).
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeRelativePositionToZero()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Equal(new Vector2F(0, 0), collider.RelativePosition);
        }

        /// <summary>
        ///     Tests that the default constructor initializes AutoTilling to false.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeAutoTillingToFalse()
        {
            BoxCollider collider = new BoxCollider();

            Assert.False(collider.AutoTilling);
        }

        /// <summary>
        ///     Tests that the default constructor initializes BodyType to Static.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeBodyTypeToStatic()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Equal(Alis.Core.Physic.Dynamics.BodyType.Static, collider.BodyType);
        }

        /// <summary>
        ///     Tests that the default constructor initializes Restitution to 0.5f.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeRestitutionTo05()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Equal(0.5f, collider.Restitution);
        }

        /// <summary>
        ///     Tests that the default constructor initializes Friction to 0.5f.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeFrictionTo05()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Equal(0.5f, collider.Friction);
        }

        /// <summary>
        ///     Tests that the default constructor initializes FixedRotation to false.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeFixedRotationToFalse()
        {
            BoxCollider collider = new BoxCollider();

            Assert.False(collider.FixedRotation);
        }

        /// <summary>
        ///     Tests that the default constructor initializes Mass to 1.0f.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeMassTo1()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Equal(1.0f, collider.Mass);
        }

        /// <summary>
        ///     Tests that the default constructor initializes IgnoreGravity to false.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeIgnoreGravityToFalse()
        {
            BoxCollider collider = new BoxCollider();

            Assert.False(collider.IgnoreGravity);
        }

        /// <summary>
        ///     Tests that the default constructor initializes LinearVelocity to (0, 0).
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeLinearVelocityToZero()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Equal(new Vector2F(0, 0), collider.LinearVelocity);
        }

        /// <summary>
        ///     Tests that the default constructor initializes AngularVelocity to 0.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeAngularVelocityTo0()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Equal(0, collider.AngularVelocity);
        }

        /// <summary>
        ///     Tests that IsTrigger property defaults to false.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeIsTriggerToFalse()
        {
            BoxCollider collider = new BoxCollider();

            Assert.False(collider.IsTrigger);
        }

        /// <summary>
        ///     Tests that IsTrigger property can be set and retrieved.
        /// </summary>
        [Fact]
        public void IsTrigger_Property_ShouldAllowGetAndSet()
        {
            BoxCollider collider = new BoxCollider();

            collider.IsTrigger = true;

            Assert.True(collider.IsTrigger);
        }

        /// <summary>
        ///     Tests that Width property can be set and retrieved.
        /// </summary>
        [Fact]
        public void Width_Property_ShouldAllowGetAndSet()
        {
            BoxCollider collider = new BoxCollider();

            collider.Width = 20;

            Assert.Equal(20, collider.Width);
        }

        /// <summary>
        ///     Tests that Height property can be set and retrieved.
        /// </summary>
        [Fact]
        public void Height_Property_ShouldAllowGetAndSet()
        {
            BoxCollider collider = new BoxCollider();

            collider.Height = 30;

            Assert.Equal(30, collider.Height);
        }

        /// <summary>
        ///     Tests that the constructor with settings initializes all properties correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithSettings_ShouldInitializeAllProperties()
        {
            var settings = new BoxCollider.BoxColliderSettings(
                IsTrigger: true,
                Width: 15,
                Height: 25,
                Rotation: 45,
                RelativePosition: new Vector2F(10, 20),
                AutoTilling: true,
                BodyType: Alis.Core.Physic.Dynamics.BodyType.Dynamic,
                Restitution: 0.8f,
                Friction: 0.3f,
                FixedRotation: true,
                Mass: 2.0f,
                IgnoreGravity: true,
                LinearVelocity: new Vector2F(5, 10),
                AngularVelocity: 1.5f);

            BoxCollider collider = new BoxCollider(settings);

            Assert.True(collider.IsTrigger);
            Assert.Equal(15, collider.Width);
            Assert.Equal(25, collider.Height);
            Assert.Equal(45, collider.Rotation);
            Assert.Equal(new Vector2F(10, 20), collider.RelativePosition);
            Assert.True(collider.AutoTilling);
            Assert.Equal(Alis.Core.Physic.Dynamics.BodyType.Dynamic, collider.BodyType);
            Assert.Equal(0.8f, collider.Restitution);
            Assert.Equal(0.3f, collider.Friction);
            Assert.True(collider.FixedRotation);
            Assert.Equal(2.0f, collider.Mass);
            Assert.True(collider.IgnoreGravity);
            Assert.Equal(new Vector2F(5, 10), collider.LinearVelocity);
            Assert.Equal(1.5f, collider.AngularVelocity);
        }

        /// <summary>
        ///     Tests that SizeOfTexture property can be set and retrieved.
        /// </summary>
        [Fact]
        public void SizeOfTexture_Property_ShouldAllowGetAndSet()
        {
            BoxCollider collider = new BoxCollider();
            var testSize = new Vector2F(100, 100);

            collider.SizeOfTexture = testSize;

            Assert.Equal(testSize, collider.SizeOfTexture);
        }

        /// <summary>
        ///     Tests that Body property can be set and retrieved.
        /// </summary>
        [Fact]
        public void Body_Property_ShouldAllowGetAndSet()
        {
            BoxCollider collider = new BoxCollider();
            var mockBody = new Alis.Core.Physic.Dynamics.Body();

            collider.Body = mockBody;

            Assert.Same(mockBody, collider.Body);
        }
    }
}
