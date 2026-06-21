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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     Tests for the BoxCollider component class
    /// </summary>
    public class BoxColliderTest
    {
        /// <summary>
        ///     Tests that the constructor creates a BoxCollider with default values
        /// </summary>
        [Fact]
        public void BoxCollider_DefaultConstructor_ShouldCreateWithDefaultValues()
        {
            BoxCollider collider = new BoxCollider();

            Assert.False(collider.IsTrigger);
            Assert.Equal(10, collider.Width);
            Assert.Equal(10, collider.Height);
            Assert.Equal(0, collider.Rotation);
            Assert.Equal(0f, collider.RelativePosition.X);
            Assert.Equal(0f, collider.RelativePosition.Y);
            Assert.False(collider.AutoTilling);
            Assert.Equal(BodyType.Static, collider.BodyType);
            Assert.Equal(0.5f, collider.Restitution);
            Assert.Equal(0.5f, collider.Friction);
            Assert.False(collider.FixedRotation);
            Assert.Equal(1.0f, collider.Mass);
            Assert.False(collider.IgnoreGravity);
            Assert.Equal(0f, collider.LinearVelocity.X);
            Assert.Equal(0f, collider.LinearVelocity.Y);
            Assert.Equal(0, collider.AngularVelocity);
        }

        /// <summary>
        ///     Tests that BoxCollider implements IBoxCollider interface
        /// </summary>
        [Fact]
        public void BoxCollider_ShouldImplementIBoxColliderInterface()
        {
            BoxCollider collider = new BoxCollider();

            Assert.IsAssignableFrom<IBoxCollider>(collider);
        }

        /// <summary>
        ///     Tests that BoxCollider properties are gettable and settable
        /// </summary>
        [Fact]
        public void BoxCollider_Properties_ShouldBeGetAndSettable()
        {
            BoxCollider collider = new BoxCollider();

            collider.IsTrigger = true;
            Assert.True(collider.IsTrigger);

            collider.Width = 20f;
            Assert.Equal(20, collider.Width);

            collider.Height = 30f;
            Assert.Equal(30, collider.Height);

            collider.Rotation = 45f;
            Assert.Equal(45, collider.Rotation);

            collider.RelativePosition = new Vector2F(5f, 10f);
            Assert.Equal(5f, collider.RelativePosition.X);
            Assert.Equal(10f, collider.RelativePosition.Y);

            collider.AutoTilling = true;
            Assert.True(collider.AutoTilling);

            collider.BodyType = BodyType.Dynamic;
            Assert.Equal(BodyType.Dynamic, collider.BodyType);

            collider.Restitution = 0.8f;
            Assert.Equal(0.8f, collider.Restitution);

            collider.Friction = 0.3f;
            Assert.Equal(0.3f, collider.Friction);

            collider.FixedRotation = true;
            Assert.True(collider.FixedRotation);

            collider.Mass = 5.0f;
            Assert.Equal(5.0f, collider.Mass);

            collider.IgnoreGravity = true;
            Assert.True(collider.IgnoreGravity);

            collider.LinearVelocity = new Vector2F(1f, 2f);
            Assert.Equal(1f, collider.LinearVelocity.X);
            Assert.Equal(2f, collider.LinearVelocity.Y);

            collider.AngularVelocity = 10f;
            Assert.Equal(10, collider.AngularVelocity);
        }

        /// <summary>
        ///     Tests that the OnUpdate method exists and is callable
        /// </summary>
        [Fact]
        public void BoxCollider_OnUpdateMethod_ShouldExistAndBeCallable()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Throws<NullReferenceException>(() =>
            {
                collider.OnUpdate(null!);
            });
        }

        /// <summary>
        ///     Tests that the OnStart method exists and is callable
        /// </summary>
        [Fact]
        public void BoxCollider_OnStartMethod_ShouldExistAndBeCallable()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Throws<NullReferenceException>(() =>
            {
                collider.OnStart(null!);
            });
        }

        /// <summary>
        ///     Tests that the OnExit method exists and is callable
        /// </summary>
        [Fact]
        public void BoxCollider_OnExitMethod_ShouldExistAndBeCallable()
        {
            BoxCollider collider = new BoxCollider();

            collider.OnExit(null!);
        }

        /// <summary>
        ///     Tests that BoxCollider can be created without exceptions
        /// </summary>
        [Fact]
        public void BoxCollider_Constructor_ShouldNotThrow()
        {
            BoxCollider collider = new BoxCollider();

            Assert.NotNull(collider);
        }

        /// <summary>
        ///     Tests that BoxCollider properties can be modified independently
        /// </summary>
        [Fact]
        public void BoxCollider_Properties_ShouldBeModifiedIndependently()
        {
            BoxCollider collider = new BoxCollider();

            collider.Width = 50f;
            Assert.Equal(50, collider.Width);
            Assert.Equal(10, collider.Height);

            collider.Height = 60f;
            Assert.Equal(50, collider.Width);
            Assert.Equal(60, collider.Height);

            collider.Rotation = 90f;
            Assert.Equal(90, collider.Rotation);
            Assert.Equal(50, collider.Width);
            Assert.Equal(60, collider.Height);
        }

        /// <summary>
        ///     Tests that BoxCollider default state is valid
        /// </summary>
        [Fact]
        public void BoxCollider_DefaultState_ShouldBeValid()
        {
            BoxCollider collider = new BoxCollider();

            Assert.NotNull(collider);
            Assert.Equal(10, collider.Width);
            Assert.Equal(10, collider.Height);
            Assert.Equal(BodyType.Static, collider.BodyType);
            Assert.Null(collider.Body);
        }

        /// <summary>
        ///     Tests that BoxCollider has expected public members
        /// </summary>
        [Fact]
        public void BoxCollider_ShouldHaveExpectedPublicMembers()
        {
            BoxCollider collider = new BoxCollider();

            Assert.NotNull(collider.IsTrigger);
            Assert.NotNull(collider.Width);
            Assert.NotNull(collider.Height);
            Assert.NotNull(collider.Rotation);
            Assert.NotNull(collider.RelativePosition);
            Assert.Null(collider.Body);
            Assert.NotNull(collider.AutoTilling);
            Assert.NotNull(collider.BodyType);
            Assert.NotNull(collider.Restitution);
            Assert.NotNull(collider.Friction);
            Assert.NotNull(collider.FixedRotation);
            Assert.NotNull(collider.Mass);
            Assert.NotNull(collider.IgnoreGravity);
            Assert.NotNull(collider.LinearVelocity);
            Assert.NotNull(collider.AngularVelocity);
            Assert.NotNull(collider.OnUpdate);
            Assert.NotNull(collider.OnStart);
            Assert.NotNull(collider.OnExit);
        }

        /// <summary>
        ///     Tests that constructor with settings copies all values
        /// </summary>
        [Fact]
        public void BoxCollider_SettingsConstructor_ShouldCopyAllValues()
        {
            BoxCollider.BoxColliderSettings settings = new BoxCollider.BoxColliderSettings(
                IsTrigger: true,
                Width: 20f,
                Height: 30f,
                Rotation: 45f,
                RelativePosition: new Vector2F(5f, 10f),
                AutoTilling: true,
                BodyType: BodyType.Dynamic,
                Restitution: 0.8f,
                Friction: 0.3f,
                FixedRotation: true,
                Mass: 5.0f,
                IgnoreGravity: true,
                LinearVelocity: new Vector2F(1f, 2f),
                AngularVelocity: 10f
            );

            BoxCollider collider = new BoxCollider(settings);

            Assert.True(collider.IsTrigger);
            Assert.Equal(20f, collider.Width);
            Assert.Equal(30f, collider.Height);
            Assert.Equal(45f, collider.Rotation);
            Assert.Equal(5f, collider.RelativePosition.X);
            Assert.Equal(10f, collider.RelativePosition.Y);
            Assert.True(collider.AutoTilling);
            Assert.Equal(BodyType.Dynamic, collider.BodyType);
            Assert.Equal(0.8f, collider.Restitution);
            Assert.Equal(0.3f, collider.Friction);
            Assert.True(collider.FixedRotation);
            Assert.Equal(5.0f, collider.Mass);
            Assert.True(collider.IgnoreGravity);
            Assert.Equal(1f, collider.LinearVelocity.X);
            Assert.Equal(2f, collider.LinearVelocity.Y);
            Assert.Equal(10f, collider.AngularVelocity);
        }

        /// <summary>
        ///     Tests that BoxColliderSettings record stores all values
        /// </summary>
        [Fact]
        public void BoxColliderSettings_ShouldStoreValues()
        {
            BoxCollider.BoxColliderSettings settings = new BoxCollider.BoxColliderSettings(
                IsTrigger: true,
                Width: 15f,
                Height: 25f,
                Rotation: 90f,
                RelativePosition: new Vector2F(1f, 2f),
                AutoTilling: false,
                BodyType: BodyType.Kinematic,
                Restitution: 0.1f,
                Friction: 0.9f,
                FixedRotation: false,
                Mass: 10f,
                IgnoreGravity: true,
                LinearVelocity: new Vector2F(3f, 4f),
                AngularVelocity: 5f
            );

            Assert.True(settings.IsTrigger);
            Assert.Equal(15f, settings.Width);
            Assert.Equal(25f, settings.Height);
            Assert.Equal(90f, settings.Rotation);
            Assert.Equal(BodyType.Kinematic, settings.BodyType);
            Assert.Equal(0.1f, settings.Restitution);
            Assert.Equal(0.9f, settings.Friction);
            Assert.Equal(10f, settings.Mass);
            Assert.Equal(5f, settings.AngularVelocity);
        }

        /// <summary>
        ///     Tests that Context property can be set and read
        /// </summary>
        [Fact]
        public void BoxCollider_Context_ShouldBeSettable()
        {
            BoxCollider collider = new BoxCollider();
            Context context = new Context();

            collider.Context = context;
            Assert.Same(context, collider.Context);
        }

        /// <summary>
        ///     Tests that SizeOfTexture property can be set and read
        /// </summary>
        [Fact]
        public void BoxCollider_SizeOfTexture_ShouldBeSettable()
        {
            BoxCollider collider = new BoxCollider();
            Vector2F size = new Vector2F(32f, 32f);

            collider.SizeOfTexture = size;
            Assert.Equal(32f, collider.SizeOfTexture.X);
            Assert.Equal(32f, collider.SizeOfTexture.Y);
        }

        /// <summary>
        ///     Tests that BoxColliderSettings record supports equality
        /// </summary>
        [Fact]
        public void BoxColliderSettings_Equality_ShouldWork()
        {
            BoxCollider.BoxColliderSettings settings1 = new BoxCollider.BoxColliderSettings(
                false, 10f, 10f, 0f, new Vector2F(0f, 0f), false, BodyType.Static, 0.5f, 0.5f, false, 1f, false, new Vector2F(0f, 0f), 0f
            );

            BoxCollider.BoxColliderSettings settings2 = new BoxCollider.BoxColliderSettings(
                false, 10f, 10f, 0f, new Vector2F(0f, 0f), false, BodyType.Static, 0.5f, 0.5f, false, 1f, false, new Vector2F(0f, 0f), 0f
            );

            Assert.Equal(settings1, settings2);
            Assert.True(settings1 == settings2);
        }

        /// <summary>
        ///     Tests that BoxCollider Body property defaults to null
        /// </summary>
        [Fact]
        public void BoxCollider_Body_ShouldDefaultToNull()
        {
            BoxCollider collider = new BoxCollider();
            Assert.Null(collider.Body);
        }

        /// <summary>
        ///     Tests that BoxColliderSettings with different values are not equal
        /// </summary>
        [Fact]
        public void BoxColliderSettings_Inequality_ShouldWork()
        {
            BoxCollider.BoxColliderSettings settings1 = new BoxCollider.BoxColliderSettings(
                false, 10f, 10f, 0f, new Vector2F(0f, 0f), false, BodyType.Static, 0.5f, 0.5f, false, 1f, false, new Vector2F(0f, 0f), 0f
            );

            BoxCollider.BoxColliderSettings settings2 = new BoxCollider.BoxColliderSettings(
                true, 10f, 10f, 0f, new Vector2F(0f, 0f), false, BodyType.Static, 0.5f, 0.5f, false, 1f, false, new Vector2F(0f, 0f), 0f
            );

            Assert.NotEqual(settings1, settings2);
            Assert.True(settings1 != settings2);
        }

        /// <summary>
        ///     Tests that SizeOfTexture defaults to zero vector
        /// </summary>
        [Fact]
        public void BoxCollider_SizeOfTexture_DefaultShouldBeZero()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Equal(0f, collider.SizeOfTexture.X);
            Assert.Equal(0f, collider.SizeOfTexture.Y);
        }

        /// <summary>
        ///     Tests that Context property defaults to null
        /// </summary>
        [Fact]
        public void BoxCollider_Context_ShouldDefaultToNull()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Null(collider.Context);
        }

        /// <summary>
        ///     Tests that Body property can be set and retrieved
        /// </summary>
        [Fact]
        public void BoxCollider_Body_ShouldBeSettable()
        {
            BoxCollider collider = new BoxCollider();
            Alis.Core.Physic.Dynamics.Body body = new Alis.Core.Physic.Dynamics.Body();

            collider.Body = body;

            Assert.Same(body, collider.Body);
        }

        /// <summary>
        ///     Tests that BoxColliderSettings with different width are not equal
        /// </summary>
        [Fact]
        public void BoxColliderSettings_DifferentWidth_ShouldNotBeEqual()
        {
            var settings1 = new BoxCollider.BoxColliderSettings(
                false, 10f, 10f, 0f, new Vector2F(0f, 0f), false, BodyType.Static, 0.5f, 0.5f, false, 1f, false, new Vector2F(0f, 0f), 0f
            );

            var settings2 = new BoxCollider.BoxColliderSettings(
                false, 20f, 10f, 0f, new Vector2F(0f, 0f), false, BodyType.Static, 0.5f, 0.5f, false, 1f, false, new Vector2F(0f, 0f), 0f
            );

            Assert.NotEqual(settings1, settings2);
        }

        /// <summary>
        ///     Tests that BoxColliderSettings with different height are not equal
        /// </summary>
        [Fact]
        public void BoxColliderSettings_DifferentHeight_ShouldNotBeEqual()
        {
            var settings1 = new BoxCollider.BoxColliderSettings(
                false, 10f, 10f, 0f, new Vector2F(0f, 0f), false, BodyType.Static, 0.5f, 0.5f, false, 1f, false, new Vector2F(0f, 0f), 0f
            );

            var settings2 = new BoxCollider.BoxColliderSettings(
                false, 10f, 20f, 0f, new Vector2F(0f, 0f), false, BodyType.Static, 0.5f, 0.5f, false, 1f, false, new Vector2F(0f, 0f), 0f
            );

            Assert.NotEqual(settings1, settings2);
        }

        /// <summary>
        ///     Tests that BoxColliderSettings with different rotation are not equal
        /// </summary>
        [Fact]
        public void BoxColliderSettings_DifferentRotation_ShouldNotBeEqual()
        {
            var settings1 = new BoxCollider.BoxColliderSettings(
                false, 10f, 10f, 0f, new Vector2F(0f, 0f), false, BodyType.Static, 0.5f, 0.5f, false, 1f, false, new Vector2F(0f, 0f), 0f
            );

            var settings2 = new BoxCollider.BoxColliderSettings(
                false, 10f, 10f, 90f, new Vector2F(0f, 0f), false, BodyType.Static, 0.5f, 0.5f, false, 1f, false, new Vector2F(0f, 0f), 0f
            );

            Assert.NotEqual(settings1, settings2);
        }
    }
}
