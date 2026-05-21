

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Sample.Flappy.Bird.Desktop
{
    /// <summary>
    ///     The bird idle class
    /// </summary>
    public class BirdIdle : IOnStart, IOnUpdate, IHasContext<Context>
    {
        /// <summary>
        ///     The range movement
        /// </summary>
        private const float RangeMovement = 0.3f;

        /// <summary>
        ///     The velocity
        /// </summary>
        private const float Velocity = 1f;

        /// <summary>
        ///     The default position
        /// </summary>
        private Vector2F defaultPosition;

        /// <summary>
        ///     The go down
        /// </summary>
        private bool goDown;

        /// <summary>
        ///     The go up
        /// </summary>
        private bool goUp = true;

        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        ///     Ons the start using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
            defaultPosition = self.Get<Transform>().Position;
        }

        /// <summary>
        ///     Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
            ref Transform t = ref self.Get<Transform>();

            float x = t.Position.X;

            float y = t.Position.Y;

            Vector2F scale = t.Scale;


            float rotation = t.Rotation;

            Vector2F newPosition;

            if (goUp && !goDown)
            {
                float displace = Velocity * Context.TimeManager.DeltaTime;
                newPosition = new Vector2F(x, y - displace);
                Transform transform = new Transform
                {
                    Position = newPosition,
                    Rotation = rotation,
                    Scale = scale
                };

                self.Get<Transform>() = transform;
            }
            else if (goDown && !goUp)
            {
                float displace = Velocity * Context.TimeManager.DeltaTime;
                newPosition = new Vector2F(x, y + displace);
                Transform transform = new Transform
                {
                    Position = newPosition,
                    Rotation = rotation,
                    Scale = scale
                };

                self.Get<Transform>() = transform;
            }

            if (y < defaultPosition.Y - RangeMovement)
            {
                goUp = false;
                goDown = true;
            }

            if (y > defaultPosition.Y + RangeMovement)
            {
                goUp = true;
                goDown = false;
            }
        }
    }
}