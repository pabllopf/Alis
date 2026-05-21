

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.Components
{
    /// <summary>
    ///     The transform
    /// </summary>
    public struct Transform : IOnStart, IOnExit
    {
        /// <summary>
        ///     The position origin
        /// </summary>
        private readonly Vector2F positionOrigin;

        /// <summary>
        ///     The rotation origin
        /// </summary>
        private readonly float rotationOrigin;

        /// <summary>
        ///     The scale origin
        /// </summary>
        private readonly Vector2F scaleOrigin;

        /// <summary>
        ///     The position
        /// </summary>
        public Vector2F Position { get; set; }

        /// <summary>
        ///     The rotation
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        ///     The scale
        /// </summary>
        public Vector2F Scale { get; set; }

        /// <summary>
        ///     Initialize using a position vector and a Complex rotation.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation</param>
        public Transform(Vector2F position, float rotation)
        {
            Rotation = rotation;
            Position = position;
            Scale = Vector2F.One;

            positionOrigin = position;
            rotationOrigin = rotation;
            scaleOrigin = Vector2F.One;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Transform" /> class
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        public Transform(Vector2F position, float rotation, Vector2F scale)
        {
            Rotation = rotation;
            Position = position;
            Scale = scale;

            positionOrigin = position;
            rotationOrigin = rotation;
            scaleOrigin = scale;
        }

        /// <summary>
        ///     Ons the start using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
        }

        /// <summary>
        ///     Ons the exit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnExit(IGameObject self)
        {
            Position = positionOrigin;
            Rotation = rotationOrigin;
            Scale = scaleOrigin;
        }
    }
}