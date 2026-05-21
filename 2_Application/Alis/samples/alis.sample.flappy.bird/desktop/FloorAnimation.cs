

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Sample.Flappy.Bird.Desktop
{
    /// <summary>
    ///     The floor animation class
    /// </summary>
    public class FloorAnimation : IOnStart, IOnUpdate, IHasContext<Context>
    {
        /// <summary>
        ///     The velocity
        /// </summary>
        private const float Velocity = 2.0f;

        /// <summary>
        ///     The old
        /// </summary>
        private float xOld;

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
            xOld = self.Get<Transform>().Position.X;
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

            float displace = Velocity * Context.TimeManager.DeltaTime;

            Vector2F newPosition = x < -1.0f ? new Vector2F(xOld, y) : new Vector2F(x - displace, y);

            t.Position = newPosition;
        }
    }
}