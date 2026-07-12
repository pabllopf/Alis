// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderTests.cs
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
using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic.Dynamics;
using Moq;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     Unit tests for <see cref="BoxCollider" /> covering constructor defaults,
    ///     settings-based construction, property accessors, and the no-op paths of
    ///     <c>OnUpdate</c> and <c>OnExit</c>.
    /// </summary>
    public class BoxColliderTests
    {
        #region Default Constructor

        /// <summary>
        ///     Verifies that the default constructor initializes all properties to their expected default values.
        /// </summary>
        [Fact]
        public void DefaultConstructor_SetsExpectedDefaultValues()
        {
            // Arrange & Act
            BoxCollider collider = new BoxCollider();

            // Assert — Width / Height
            Assert.Equal(10f, collider.Width);
            Assert.Equal(10f, collider.Height);

            // Assert — Rotation
            Assert.Equal(0f, collider.Rotation);

            // Assert — RelativePosition (default constructor creates a zero vector)
            Vector2F relativePos = collider.RelativePosition;
            Assert.Equal(0f, relativePos.X);
            Assert.Equal(0f, relativePos.Y);

            // Assert — AutoTilling
            Assert.False(collider.AutoTilling);

            // Assert — BodyType
            Assert.Equal(BodyType.Static, collider.BodyType);

            // Assert — Restitution / Friction
            Assert.Equal(0.5f, collider.Restitution);
            Assert.Equal(0.5f, collider.Friction);

            // Assert — FixedRotation
            Assert.False(collider.FixedRotation);

            // Assert — Mass
            Assert.Equal(1.0f, collider.Mass);

            // Assert — IgnoreGravity
            Assert.False(collider.IgnoreGravity);

            // Assert — LinearVelocity (default constructor creates a zero vector)
            Vector2F linVel = collider.LinearVelocity;
            Assert.Equal(0f, linVel.X);
            Assert.Equal(0f, linVel.Y);

            // Assert — AngularVelocity
            Assert.Equal(0f, collider.AngularVelocity);

            // Assert — IsTrigger (default value for bool)
            Assert.False(collider.IsTrigger);

            // Assert — Body (default value for reference type)
            Assert.Null(collider.Body);

            // Assert — SizeOfTexture (default value for struct)
            Vector2F size = collider.SizeOfTexture;
            Assert.Equal(0f, size.X);
            Assert.Equal(0f, size.Y);
        }

        #endregion

        #region Settings Constructor

        /// <summary>
        ///     Verifies that the settings constructor copies every property from the provided <see cref="BoxCollider.BoxColliderSettings" />.
        /// </summary>
        [Fact]
        public void SettingsConstructor_CopiesAllPropertiesFromSettings()
        {
            // Arrange — build a settings object with distinct values
            BoxCollider.BoxColliderSettings settings = new BoxCollider.BoxColliderSettings(
                IsTrigger: true,
                Width: 42f,
                Height: 17f,
                Rotation: 1.57f,
                RelativePosition: new Vector2F(3.3f, 7.7f),
                AutoTilling: true,
                BodyType: BodyType.Dynamic,
                Restitution: 0.9f,
                Friction: 0.1f,
                FixedRotation: true,
                Mass: 2.5f,
                IgnoreGravity: true,
                LinearVelocity: new Vector2F(1.1f, 2.2f),
                AngularVelocity: 0.75f
            );

            // Act
            BoxCollider collider = new BoxCollider(settings);

            // Assert — scalar properties
            Assert.True(collider.IsTrigger);
            Assert.Equal(42f, collider.Width);
            Assert.Equal(17f, collider.Height);
            Assert.Equal(1.57f, collider.Rotation);

            // Assert — RelativePosition
            Vector2F pos = collider.RelativePosition;
            Assert.Equal(3.3f, pos.X);
            Assert.Equal(7.7f, pos.Y);

            // Assert — AutoTilling / BodyType
            Assert.True(collider.AutoTilling);
            Assert.Equal(BodyType.Dynamic, collider.BodyType);

            // Assert — Restitution / Friction
            Assert.Equal(0.9f, collider.Restitution);
            Assert.Equal(0.1f, collider.Friction);

            // Assert — FixedRotation / Mass
            Assert.True(collider.FixedRotation);
            Assert.Equal(2.5f, collider.Mass);

            // Assert — IgnoreGravity
            Assert.True(collider.IgnoreGravity);

            // Assert — LinearVelocity
            Vector2F linVel = collider.LinearVelocity;
            Assert.Equal(1.1f, linVel.X);
            Assert.Equal(2.2f, linVel.Y);

            // Assert — AngularVelocity
            Assert.Equal(0.75f, collider.AngularVelocity);

            // Assert — Body (settings has no body reference)
            Assert.Null(collider.Body);

            // Assert — SizeOfTexture (settings has no texture size)
            Vector2F size = collider.SizeOfTexture;
            Assert.Equal(0f, size.X);
            Assert.Equal(0f, size.Y);
        }

        /// <summary>
        ///     Verifies that the settings constructor with zero / false values produces matching defaults.
        /// </summary>
        [Fact]
        public void SettingsConstructor_WithZeroValues_SetsZeroValues()
        {
            // Arrange
            BoxCollider.BoxColliderSettings settings = new BoxCollider.BoxColliderSettings(
                IsTrigger: false,
                Width: 0f,
                Height: 0f,
                Rotation: 0f,
                RelativePosition: Vector2F.Zero,
                AutoTilling: false,
                BodyType: BodyType.Static,
                Restitution: 0f,
                Friction: 0f,
                FixedRotation: false,
                Mass: 0f,
                IgnoreGravity: false,
                LinearVelocity: Vector2F.Zero,
                AngularVelocity: 0f
            );

            // Act
            BoxCollider collider = new BoxCollider(settings);

            // Assert
            Assert.False(collider.IsTrigger);
            Assert.Equal(0f, collider.Width);
            Assert.Equal(0f, collider.Height);
            Assert.Equal(0f, collider.Rotation);
            Assert.Equal(BodyType.Static, collider.BodyType);
            Assert.Equal(0f, collider.Restitution);
            Assert.Equal(0f, collider.Friction);
            Assert.False(collider.FixedRotation);
            Assert.Equal(0f, collider.Mass);
            Assert.False(collider.IgnoreGravity);
            Assert.Equal(0f, collider.AngularVelocity);
        }

        #endregion

        #region Property Getters and Setters

        /// <summary>
        ///     Verifies that all scalar properties can be read and written independently.
        /// </summary>
        [Fact]
        public void PropertyAccessors_AllScalarPropertiesCanBeGetAndSet()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();

            // Act — set each scalar property to a distinct value
            collider.IsTrigger = true;
            collider.Width = 5.0f;
            collider.Height = 3.0f;
            collider.Rotation = 0.5f;
            collider.AutoTilling = true;
            collider.BodyType = BodyType.Kinematic;
            collider.Restitution = 0.8f;
            collider.Friction = 0.2f;
            collider.FixedRotation = true;
            collider.Mass = 4.0f;
            collider.IgnoreGravity = true;
            collider.AngularVelocity = 2.0f;

            // Assert — read back each property
            Assert.True(collider.IsTrigger);
            Assert.Equal(5.0f, collider.Width);
            Assert.Equal(3.0f, collider.Height);
            Assert.Equal(0.5f, collider.Rotation);
            Assert.True(collider.AutoTilling);
            Assert.Equal(BodyType.Kinematic, collider.BodyType);
            Assert.Equal(0.8f, collider.Restitution);
            Assert.Equal(0.2f, collider.Friction);
            Assert.True(collider.FixedRotation);
            Assert.Equal(4.0f, collider.Mass);
            Assert.True(collider.IgnoreGravity);
            Assert.Equal(2.0f, collider.AngularVelocity);
        }

        /// <summary>
        ///     Verifies that the Vector2F properties (RelativePosition, LinearVelocity, SizeOfTexture)
        ///     can be independently assigned and read back.
        /// </summary>
        [Fact]
        public void PropertyAccessors_VectorPropertiesCanBeGetAndSet()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();

            // Act — assign each vector property
            collider.RelativePosition = new Vector2F(10f, 20f);
            collider.LinearVelocity = new Vector2F(5f, 15f);
            collider.SizeOfTexture = new Vector2F(2f, 4f);

            // Assert
            Vector2F pos = collider.RelativePosition;
            Assert.Equal(10f, pos.X);
            Assert.Equal(20f, pos.Y);

            Vector2F linVel = collider.LinearVelocity;
            Assert.Equal(5f, linVel.X);
            Assert.Equal(15f, linVel.Y);

            Vector2F size = collider.SizeOfTexture;
            Assert.Equal(2f, size.X);
            Assert.Equal(4f, size.Y);
        }

        /// <summary>
        ///     Verifies that the Body property can be get/set and that null is the default.
        /// </summary>
        [Fact]
        public void BodyProperty_DefaultIsNull_AndCanBeAssigned()
        {
            // Arrange — fresh collider has null body by default
            BoxCollider collider = new BoxCollider();
            Assert.Null(collider.Body);

            // Act — assign a mock body
            Mock<Alis.Core.Physic.Dynamics.Body> mockBody = new Mock<Alis.Core.Physic.Dynamics.Body>();
            collider.Body = mockBody.Object;

            // Assert
            Assert.Same(mockBody.Object, collider.Body);
        }

        #endregion

        #region OnUpdate — No-Op Paths

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.OnUpdate" /> is a no-op when the
        ///     <c>IGameObject</c> does not have a Transform component.
        /// </summary>
        [Fact]
        public void OnUpdate_WhenGameObjectLacksTransform_DoesNotThrow()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();

            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();
            mockGameObject.Setup(g => g.Has<Transform>()).Returns(false);

            // Act — should not throw
            Exception exception = Record.Exception(() => collider.OnUpdate(mockGameObject.Object));

            // Assert
            Assert.Null(exception);
        }

        #endregion

        #region OnExit — No-Op Paths

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.OnExit" /> is a no-op when Body is null.
        /// </summary>
        [Fact]
        public void OnExit_WhenBodyIsNull_DoesNotThrow()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();

            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();

            // Body is null, Context is null — both guards should prevent any action.

            // Act
            Exception exception = Record.Exception(() => collider.OnExit(mockGameObject.Object));

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Verifies that when Body is not null but Context is null, OnExit throws NullReferenceException.
        /// </summary>
        [Fact]
        public void OnExit_WhenBodyIsNotNullButContextIsNull_ThrowsNullReferenceException()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();

            Mock<Alis.Core.Physic.Dynamics.Body> mockBody = new Mock<Alis.Core.Physic.Dynamics.Body>();
            collider.Body = mockBody.Object;

            // Context is null — the OnExit method checks `Body != null` first,
            // then accesses Context.PhysicManager.WorldPhysic.Remove(Body). Since Body is not null
            // and Context is null, the code will attempt `Context.PhysicManager.WorldPhysic.Remove(Body)`
            // which throws NullReferenceException.

            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();

            // Act
            Exception exception = Record.Exception(() => collider.OnExit(mockGameObject.Object));

            // Assert — the implementation accesses Context.PhysicManager without null-check,
            // so it will throw NullReferenceException when Context is null.
            Assert.IsAssignableFrom<NullReferenceException>(exception);
        }

        #endregion

        #region BoxColliderSettings Record

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.BoxColliderSettings" /> records all values via its positional constructor.
        /// </summary>
        [Fact]
        public void BoxColliderSettings_Record_WithDistinctValues_ReturnsAllValues()
        {
            // Arrange
            BoxCollider.BoxColliderSettings settings = new BoxCollider.BoxColliderSettings(
                IsTrigger: true,
                Width: 7f,
                Height: 11f,
                Rotation: 0.25f,
                RelativePosition: new Vector2F(1f, 2f),
                AutoTilling: true,
                BodyType: BodyType.Kinematic,
                Restitution: 0.3f,
                Friction: 0.4f,
                FixedRotation: true,
                Mass: 1.5f,
                IgnoreGravity: true,
                LinearVelocity: new Vector2F(0.1f, 0.2f),
                AngularVelocity: 0.3f
            );

            // Assert — each positional property is accessible
            Assert.True(settings.IsTrigger);
            Assert.Equal(7f, settings.Width);
            Assert.Equal(11f, settings.Height);
            Assert.Equal(0.25f, settings.Rotation);
            Assert.Equal(new Vector2F(1f, 2f), settings.RelativePosition);
            Assert.True(settings.AutoTilling);
            Assert.Equal(BodyType.Kinematic, settings.BodyType);
            Assert.Equal(0.3f, settings.Restitution);
            Assert.Equal(0.4f, settings.Friction);
            Assert.True(settings.FixedRotation);
            Assert.Equal(1.5f, settings.Mass);
            Assert.True(settings.IgnoreGravity);
            Assert.Equal(new Vector2F(0.1f, 0.2f), settings.LinearVelocity);
            Assert.Equal(0.3f, settings.AngularVelocity);
        }

        /// <summary>
        ///     Verifies that two BoxColliderSettings with identical values are equal.
        /// </summary>
        [Fact]
        public void BoxColliderSettings_Record_EqualValues_AreEqual()
        {
            // Arrange
            BoxCollider.BoxColliderSettings settingsA = new BoxCollider.BoxColliderSettings(
                IsTrigger: false, Width: 1f, Height: 2f, Rotation: 0f,
                RelativePosition: Vector2F.Zero, AutoTilling: false, BodyType: BodyType.Static,
                Restitution: 0f, Friction: 0f, FixedRotation: false, Mass: 1f,
                IgnoreGravity: false, LinearVelocity: Vector2F.Zero, AngularVelocity: 0f);

            BoxCollider.BoxColliderSettings settingsB = new BoxCollider.BoxColliderSettings(
                IsTrigger: false, Width: 1f, Height: 2f, Rotation: 0f,
                RelativePosition: Vector2F.Zero, AutoTilling: false, BodyType: BodyType.Static,
                Restitution: 0f, Friction: 0f, FixedRotation: false, Mass: 1f,
                IgnoreGravity: false, LinearVelocity: Vector2F.Zero, AngularVelocity: 0f);

            // Assert
            Assert.Equal(settingsA, settingsB);
        }

        /// <summary>
        ///     Verifies that two BoxColliderSettings with different values are not equal.
        /// </summary>
        [Fact]
        public void BoxColliderSettings_Record_DifferentValues_AreNotEqual()
        {
            // Arrange
            BoxCollider.BoxColliderSettings settingsA = new BoxCollider.BoxColliderSettings(
                IsTrigger: true, Width: 1f, Height: 2f, Rotation: 0f,
                RelativePosition: Vector2F.Zero, AutoTilling: false, BodyType: BodyType.Static,
                Restitution: 0f, Friction: 0f, FixedRotation: false, Mass: 1f,
                IgnoreGravity: false, LinearVelocity: Vector2F.Zero, AngularVelocity: 0f);

            BoxCollider.BoxColliderSettings settingsB = new BoxCollider.BoxColliderSettings(
                IsTrigger: false, Width: 1f, Height: 2f, Rotation: 0f,
                RelativePosition: Vector2F.Zero, AutoTilling: false, BodyType: BodyType.Static,
                Restitution: 0f, Friction: 0f, FixedRotation: false, Mass: 1f,
                IgnoreGravity: false, LinearVelocity: Vector2F.Zero, AngularVelocity: 0f);

            // Assert
            Assert.NotEqual(settingsA, settingsB);
        }

        #endregion

        #region OnUpdate — Body Null with Transform

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.OnUpdate" /> does not modify the Transform
        ///     when the GameObject has a Transform component but Body is null.
        ///     This covers the branch where <c>Body is not null</c> evaluates to false.
        /// </summary>
        [Fact]
        public void OnUpdate_WhenTransformExistsAndBodyIsNull_DoesNotModifyTransform()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Transform(new Vector2F(7f, 13f), 2.5f));
            BoxCollider collider = new BoxCollider();

            // Act
            collider.OnUpdate(gameObject);

            // Assert — Transform unchanged because Body is null
            ref Transform transform = ref gameObject.Get<Transform>();
            Assert.Equal(7f, transform.Position.X);
            Assert.Equal(13f, transform.Position.Y);
            Assert.Equal(2.5f, transform.Rotation);
        }

        /// <summary>
        ///     Verifies that multiple calls to <see cref="BoxCollider.OnUpdate" /> when Body is null
        ///     are idempotent and do not modify the Transform.
        /// </summary>
        [Fact]
        public void OnUpdate_WhenTransformExistsAndBodyIsNull_MultipleCallsAreIdempotent()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Transform(new Vector2F(5f, 5f), 1.0f));
            BoxCollider collider = new BoxCollider();

            // Act — multiple calls
            collider.OnUpdate(gameObject);
            collider.OnUpdate(gameObject);
            collider.OnUpdate(gameObject);

            // Assert — Transform unchanged
            ref Transform transform = ref gameObject.Get<Transform>();
            Assert.Equal(5f, transform.Position.X);
            Assert.Equal(5f, transform.Position.Y);
            Assert.Equal(1.0f, transform.Rotation);
        }

        #endregion

        #region OnStart — No-Op and Full Path

        /// <summary>
        ///     Verifies that OnStart is a no-op when the GameObject lacks a Transform.
        /// </summary>
        [Fact]
        public void OnStart_WhenGameObjectLacksTransform_DoesNotCreateBody()
        {
            BoxCollider collider = new BoxCollider();
            collider.Context = new Context();

            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();
            mockGameObject.Setup(g => g.Has<Transform>()).Returns(false);

            collider.OnStart(mockGameObject.Object);

            Assert.Null(collider.Body);
        }

        /// <summary>
        ///     Verifies that OnStart throws NullReferenceException when Context is null
        ///     and the GameObject has a Transform.
        /// </summary>
        [Fact]
        public void OnStart_WhenContextIsNullAndTransformExists_ThrowsNullReferenceException()
        {
            BoxCollider collider = new BoxCollider();

            Transform transform = new Transform(new Vector2F(1f, 2f), 0.5f);
            MockGameObject gameObject = new MockGameObject(transform);

            Exception exception = Record.Exception(() => collider.OnStart(gameObject));

            Assert.IsAssignableFrom<NullReferenceException>(exception);
        }

        /// <summary>
        ///     Verifies that OnStart creates a physics body with configured properties
        ///     when Context and Transform are present.
        /// </summary>
        [Fact]
        public void OnStart_WithContextAndTransform_CreatesBody()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(10f, 20f), 0.5f, new Vector2F(2f, 3f)));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(5f, 6f),
                Rotation = 1.0f,
                RelativePosition = new Vector2F(1f, -1f),
                BodyType = BodyType.Dynamic,
                Restitution = 0.3f,
                Friction = 0.7f,
                FixedRotation = true,
                Mass = 2.5f,
                IgnoreGravity = true,
                LinearVelocity = new Vector2F(1f, 2f),
                IsTrigger = true
            };

            collider.OnStart(gameObject);

            Assert.NotNull(collider.Body);
            Assert.NotNull(collider.Body.Tag);
        }

        /// <summary>
        ///     Verifies that OnStart with Static body type creates a body.
        /// </summary>
        [Fact]
        public void OnStart_WithStaticBody_CreatesStaticBody()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(15f, 25f), 0f, new Vector2F(1f, 1f)));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(8f, 8f),
                BodyType = BodyType.Static,
                IgnoreGravity = false,
                IsTrigger = false
            };

            collider.OnStart(gameObject);

            Assert.NotNull(collider.Body);
            Assert.NotNull(collider.Body.Tag);
        }

        #endregion

        #region OnUpdate — Full Path with Body

        /// <summary>
        ///     Verifies that OnUpdate syncs Transform Position and Rotation from Body
        ///     when both Transform and Body are present.
        /// </summary>
        [Fact]
        public void OnUpdate_WhenTransformAndBodyPresent_SyncsTransformFromBody()
        {
            BoxCollider collider = new BoxCollider();

            Alis.Core.Physic.Dynamics.Body body = new Alis.Core.Physic.Dynamics.Body();
            body.Position = new Vector2F(42f, 99f);
            body.Rotation = 1.57f;
            collider.Body = body;

            Transform transform = new Transform(Vector2F.Zero, 0f);
            MockGameObject gameObject = new MockGameObject(transform);

            collider.OnUpdate(gameObject);

            Transform updatedTransform = gameObject.GetStoredTransform();
            Assert.Equal(42f, updatedTransform.Position.X);
            Assert.Equal(99f, updatedTransform.Position.Y);
            Assert.Equal(1.57f, updatedTransform.Rotation);
        }

        /// <summary>
        ///     Verifies that OnUpdate after OnStart syncs the Transform from the body.
        /// </summary>
        [Fact]
        public void OnUpdate_AfterOnStart_SyncsTransformFromBody()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(100f, 200f), 0f));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(10f, 10f),
                BodyType = BodyType.Dynamic
            };

            collider.OnStart(gameObject);
            Assert.NotNull(collider.Body);

            collider.Body.Position = new Vector2F(300f, 400f);
            collider.Body.Rotation = 2.5f;

            collider.OnUpdate(gameObject);

            ref Transform transform = ref gameObject.Get<Transform>();
            Assert.Equal(300f, transform.Position.X, 5);
            Assert.Equal(400f, transform.Position.Y, 5);
            Assert.Equal(2.5f, transform.Rotation, 5);
        }

        /// <summary>
        ///     Verifies that multiple OnUpdate calls keep the Transform synchronized.
        /// </summary>
        [Fact]
        public void OnUpdate_MultipleCallsAfterOnStart_KeepsSyncing()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(0f, 0f), 0f));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(10f, 10f),
                BodyType = BodyType.Dynamic
            };

            collider.OnStart(gameObject);

            collider.Body.Position = new Vector2F(50f, 60f);
            collider.Body.Rotation = 1.5f;
            collider.OnUpdate(gameObject);

            ref Transform t1 = ref gameObject.Get<Transform>();
            Assert.Equal(50f, t1.Position.X, 5);
            Assert.Equal(60f, t1.Position.Y, 5);

            collider.Body.Position = new Vector2F(70f, 80f);
            collider.Body.Rotation = 3.0f;
            collider.OnUpdate(gameObject);

            ref Transform t2 = ref gameObject.Get<Transform>();
            Assert.Equal(70f, t2.Position.X, 5);
            Assert.Equal(80f, t2.Position.Y, 5);
            Assert.Equal(3.0f, t2.Rotation, 5);
        }

        /// <summary>
        ///     Verifies that manually replacing the Body after OnStart causes OnUpdate
        ///     to sync from the new body.
        /// </summary>
        [Fact]
        public void OnUpdate_AfterBodyReplacement_SyncsFromNewBody()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(10f, 10f), 0f));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(10f, 10f),
                BodyType = BodyType.Dynamic
            };

            collider.OnStart(gameObject);
            Assert.NotNull(collider.Body);

            Alis.Core.Physic.Dynamics.Body newBody = new Alis.Core.Physic.Dynamics.Body
            {
                Position = new Vector2F(999f, 888f),
                Rotation = 4.5f
            };
            collider.Body = newBody;

            collider.OnUpdate(gameObject);

            ref Transform transform = ref gameObject.Get<Transform>();
            Assert.Equal(999f, transform.Position.X, 5);
            Assert.Equal(888f, transform.Position.Y, 5);
            Assert.Equal(4.5f, transform.Rotation, 5);
        }

        #endregion

        #region OnExit — Full Path

        /// <summary>
        ///     Verifies that OnExit removes the body from the physics world
        ///     and sets Body to null when both Context and Body are present.
        /// </summary>
        [Fact]
        public void OnExit_WhenBodyAndContextArePresent_RemovesBody()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(3f, 4f), 0.5f, new Vector2F(2f, 3f)));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(5f, 6f),
                Rotation = 1.0f,
                RelativePosition = new Vector2F(1f, -1f),
                BodyType = BodyType.Dynamic,
                Restitution = 0.3f,
                Friction = 0.7f,
                FixedRotation = true,
                Mass = 2f,
                IgnoreGravity = false,
                LinearVelocity = new Vector2F(1f, 2f),
                IsTrigger = false
            };

            collider.OnStart(gameObject);
            Assert.NotNull(collider.Body);

            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();
            Exception exception = Record.Exception(() => collider.OnExit(mockGameObject.Object));

            Assert.Null(collider.Body);
            Assert.Null(exception);
        }

        /// <summary>
        ///     Verifies that calling OnExit twice is safe: the second call is a no-op.
        /// </summary>
        [Fact]
        public void OnExit_CalledTwice_SecondCallIsNoOp()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(1f, 1f), 0f));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(3f, 4f),
                BodyType = BodyType.Static,
            };

            collider.OnStart(gameObject);
            Assert.NotNull(collider.Body);

            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();

            Exception firstException = Record.Exception(() => collider.OnExit(mockGameObject.Object));
            Assert.Null(firstException);

            Exception secondException = Record.Exception(() => collider.OnExit(mockGameObject.Object));
            Assert.Null(collider.Body);
            Assert.Null(secondException);
        }

        #endregion

        #region BoxColliderSettings — With Expression

        /// <summary>
        ///     Verifies that the with expression on BoxColliderSettings creates a modified copy.
        /// </summary>
        [Fact]
        public void BoxColliderSettings_WithExpression_CreatesModifiedCopy()
        {
            BoxCollider.BoxColliderSettings original = new BoxCollider.BoxColliderSettings(
                IsTrigger: false,
                Width: 10f,
                Height: 20f,
                Rotation: 0f,
                RelativePosition: Vector2F.Zero,
                AutoTilling: false,
                BodyType: BodyType.Static,
                Restitution: 0.5f,
                Friction: 0.5f,
                FixedRotation: false,
                Mass: 1.0f,
                IgnoreGravity: false,
                LinearVelocity: Vector2F.Zero,
                AngularVelocity: 0f);

            BoxCollider.BoxColliderSettings modified = original with
            {
                Width = 99f,
                Height = 55f,
                IsTrigger = true
            };

            Assert.Equal(10f, original.Width);
            Assert.Equal(20f, original.Height);
            Assert.False(original.IsTrigger);

            Assert.Equal(99f, modified.Width);
            Assert.Equal(55f, modified.Height);
            Assert.True(modified.IsTrigger);

            Assert.Equal(original.Rotation, modified.Rotation);
            Assert.Equal(original.BodyType, modified.BodyType);
            Assert.Equal(original.Restitution, modified.Restitution);
            Assert.Equal(original.Mass, modified.Mass);
        }

        #endregion

        #region Helper Classes

        /// <summary>
        ///     A concrete implementation of IGameObject that stores a Transform
        ///     and returns it by reference.
        /// </summary>
        internal sealed class MockGameObject : IGameObject
        {
            private Transform _transform;

            public MockGameObject(Transform transform) => _transform = transform;

            public ref T Get<T>() where T : notnull
            {
                if (typeof(T) == typeof(Transform))
                {
                    return ref Unsafe.As<Transform, T>(ref _transform);
                }

                throw new InvalidOperationException($"Component type {typeof(T).Name} not found.");
            }

            public bool Has<T>() => typeof(T) == typeof(Transform);

            public bool Has(Type type) => type == typeof(Transform);

            public bool TryHas<T>() => typeof(T) == typeof(Transform);

            public Transform GetStoredTransform() => _transform;
        }

        #endregion
    }
}
