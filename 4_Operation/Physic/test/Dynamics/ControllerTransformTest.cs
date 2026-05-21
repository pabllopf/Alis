

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The controller transform test class
    /// </summary>
    public class ControllerTransformTest
    {
        /// <summary>
        ///     Tests that constructor with position and rotation should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithPositionAndRotation_ShouldInitializeCorrectly()
        {
            Vector2F position = new Vector2F(1.0f, 2.0f);
            Complex rotation = Complex.One;

            ControllerTransform transform = new ControllerTransform(position, rotation);

            Assert.Equal(position, transform.Position);
            Assert.Equal(rotation, transform.Rotation);
            Assert.Equal(Vector2F.One, transform.Scale);
        }

        /// <summary>
        ///     Tests that constructor with position rotation and scale should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithPositionRotationAndScale_ShouldInitializeCorrectly()
        {
            Vector2F position = new Vector2F(1.0f, 2.0f);
            Complex rotation = Complex.One;
            Vector2F scale = new Vector2F(2.0f, 2.0f);

            ControllerTransform transform = new ControllerTransform(position, rotation, scale);

            Assert.Equal(position, transform.Position);
            Assert.Equal(rotation, transform.Rotation);
            Assert.Equal(scale, transform.Scale);
        }

        /// <summary>
        ///     Tests that constructor with position and angle should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithPositionAndAngle_ShouldInitializeCorrectly()
        {
            Vector2F position = new Vector2F(1.0f, 2.0f);
            float angle = 0.5f;

            ControllerTransform transform = new ControllerTransform(position, angle);

            Assert.Equal(position, transform.Position);
            Assert.NotEqual(Complex.One, transform.Rotation);
        }

        /// <summary>
        ///     Tests that identity should return default transform
        /// </summary>
        [Fact]
        public void Identity_ShouldReturnDefaultTransform()
        {
            ControllerTransform identity = ControllerTransform.Identity;

            Assert.Equal(Vector2F.Zero, identity.Position);
            Assert.Equal(Complex.One, identity.Rotation);
        }

        /// <summary>
        ///     Tests that position should set and get correctly
        /// </summary>
        [Fact]
        public void Position_ShouldSetAndGetCorrectly()
        {
            ControllerTransform transform = new ControllerTransform();
            Vector2F position = new Vector2F(5.0f, 10.0f);

            transform.Position = position;

            Assert.Equal(position, transform.Position);
        }

        /// <summary>
        ///     Tests that rotation should set and get correctly
        /// </summary>
        [Fact]
        public void Rotation_ShouldSetAndGetCorrectly()
        {
            ControllerTransform transform = new ControllerTransform();
            Complex rotation = new Complex(0.5f, 0.5f);

            transform.Rotation = rotation;

            Assert.Equal(rotation, transform.Rotation);
        }

        /// <summary>
        ///     Tests that scale should set and get correctly
        /// </summary>
        [Fact]
        public void Scale_ShouldSetAndGetCorrectly()
        {
            ControllerTransform transform = new ControllerTransform();
            Vector2F scale = new Vector2F(2.0f, 3.0f);

            transform.Scale = scale;

            Assert.Equal(scale, transform.Scale);
        }

        /// <summary>
        ///     Tests that transform with zero position should work
        /// </summary>
        [Fact]
        public void Transform_WithZeroPosition_ShouldWork()
        {
            ControllerTransform transform = new ControllerTransform(Vector2F.Zero, Complex.One);

            Assert.Equal(Vector2F.Zero, transform.Position);
        }

        /// <summary>
        ///     Tests that transform with negative scale should work
        /// </summary>
        [Fact]
        public void Transform_WithNegativeScale_ShouldWork()
        {
            Vector2F scale = new Vector2F(-1.0f, -1.0f);
            ControllerTransform transform = new ControllerTransform(Vector2F.Zero, Complex.One, scale);

            Assert.Equal(scale, transform.Scale);
        }
    }
}