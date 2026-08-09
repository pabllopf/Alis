using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic.Dynamics;
using Xunit;
using Scene = Alis.Core.Ecs.Scene;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    /// The box collider full coverage test class
    /// </summary>
    public class BoxColliderFullCoverageTest
    {
        /// <summary>
        /// Tests that constructor default sets expected values
        /// </summary>
        [Fact]
        public void Constructor_Default_SetsExpectedValues()
        {
            BoxCollider collider = new BoxCollider();

            Assert.Equal(10f, collider.Width, 5);
            Assert.Equal(10f, collider.Height, 5);
            Assert.Equal(0f, collider.Rotation, 5);
            Assert.Equal(BodyType.Static, collider.BodyType);
            Assert.Equal(0.5f, collider.Restitution, 5);
            Assert.Equal(0.5f, collider.Friction, 5);
            Assert.False(collider.FixedRotation);
            Assert.Equal(1.0f, collider.Mass, 5);
            Assert.False(collider.IgnoreGravity);
            Assert.False(collider.AutoTilling);
            Assert.False(collider.IsTrigger);
            Assert.Equal(new Vector2F(0, 0), collider.RelativePosition);
            Assert.Equal(new Vector2F(0, 0), collider.LinearVelocity);
            Assert.Equal(0f, collider.AngularVelocity, 5);
        }

        /// <summary>
        /// Tests that constructor with settings sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithSettings_SetsProperties()
        {
            BoxCollider.BoxColliderSettings settings = new BoxCollider.BoxColliderSettings(
                IsTrigger: true,
                Width: 20f,
                Height: 30f,
                Rotation: 45f,
                RelativePosition: new Vector2F(1, 2),
                AutoTilling: true,
                BodyType: BodyType.Dynamic,
                Restitution: 0.8f,
                Friction: 0.3f,
                FixedRotation: true,
                Mass: 5f,
                IgnoreGravity: true,
                LinearVelocity: new Vector2F(10, 20),
                AngularVelocity: 90f
            );

            BoxCollider collider = new BoxCollider(settings);

            Assert.True(collider.IsTrigger);
            Assert.Equal(20f, collider.Width, 5);
            Assert.Equal(30f, collider.Height, 5);
            Assert.Equal(45f, collider.Rotation, 5);
            Assert.Equal(new Vector2F(1, 2), collider.RelativePosition);
            Assert.True(collider.AutoTilling);
            Assert.Equal(BodyType.Dynamic, collider.BodyType);
            Assert.Equal(0.8f, collider.Restitution, 5);
            Assert.Equal(0.3f, collider.Friction, 5);
            Assert.True(collider.FixedRotation);
            Assert.Equal(5f, collider.Mass, 5);
            Assert.True(collider.IgnoreGravity);
            Assert.Equal(new Vector2F(10, 20), collider.LinearVelocity);
            Assert.Equal(90f, collider.AngularVelocity, 5);
        }

        /// <summary>
        /// Tests that properties can be set and get
        /// </summary>
        [Fact]
        public void Properties_CanBeSetAndGet()
        {
            BoxCollider collider = new BoxCollider();

            collider.Width = 100f;
            collider.Height = 200f;
            collider.Rotation = 90f;
            collider.IsTrigger = true;
            collider.AutoTilling = true;
            collider.BodyType = BodyType.Kinematic;
            collider.Restitution = 1.0f;
            collider.Friction = 0.0f;
            collider.FixedRotation = true;
            collider.Mass = 10f;
            collider.IgnoreGravity = true;
            collider.LinearVelocity = new Vector2F(5, 10);
            collider.AngularVelocity = 180f;
            collider.SizeOfTexture = new Vector2F(64, 64);
            collider.RelativePosition = new Vector2F(3, 4);

            Assert.Equal(100f, collider.Width, 5);
            Assert.Equal(200f, collider.Height, 5);
            Assert.Equal(90f, collider.Rotation, 5);
            Assert.True(collider.IsTrigger);
            Assert.True(collider.AutoTilling);
            Assert.Equal(BodyType.Kinematic, collider.BodyType);
            Assert.Equal(1.0f, collider.Restitution, 5);
            Assert.Equal(0.0f, collider.Friction, 5);
            Assert.True(collider.FixedRotation);
            Assert.Equal(10f, collider.Mass, 5);
            Assert.True(collider.IgnoreGravity);
            Assert.Equal(new Vector2F(5, 10), collider.LinearVelocity);
            Assert.Equal(180f, collider.AngularVelocity, 5);
            Assert.Equal(new Vector2F(64, 64), collider.SizeOfTexture);
            Assert.Equal(new Vector2F(3, 4), collider.RelativePosition);
        }

        /// <summary>
        /// Tests that render when not initialized throws exception
        /// </summary>
        [Fact]
        public void Render_WhenNotInitialized_ThrowsException()
        {
            BoxCollider collider = new BoxCollider();
            Context context = new Context();
            collider.Context = context;
            Scene scene = new Scene();
            GameObject gameObject = scene.Create();
            gameObject.Add(new Transform());
            gameObject.Add(collider);

            Assert.ThrowsAny<Exception>(() =>
                collider.Render(gameObject, new Vector2F(0, 0), new Vector2F(800, 600), 32f));
        }

    }
}
