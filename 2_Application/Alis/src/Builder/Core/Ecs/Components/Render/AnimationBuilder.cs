

using System;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Builder.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The animation builder class
    /// </summary>
    /// <seealso cref="IBuild{Animation}" />
    public class AnimationBuilder :
        IBuild<Animation>,
        IName<AnimationBuilder, string>,
        ISpeed<AnimationBuilder, float>,
        IOrder<AnimationBuilder, int>,
        IAddFrame<AnimationBuilder, Func<FrameBuilder, Frame>>
    {
        /// <summary>
        ///     The animation
        /// </summary>
        private Animation animation = new Animation();

        /// <summary>
        ///     The context
        /// </summary>
        private readonly Context context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AnimationBuilder" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public AnimationBuilder(Context context) => this.context = context;

        /// <summary>
        ///     Adds the frame using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The animation builder</returns>
        public AnimationBuilder AddFrame(Func<FrameBuilder, Frame> value)
        {
            FrameBuilder frameBuilder = new FrameBuilder();
            Frame frame = value(frameBuilder);
            animation.AddFrame(frame);
            return this;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The animation</returns>
        public Animation Build() => animation;

        /// <summary>
        ///     Names the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The animation builder</returns>
        public AnimationBuilder Name(string value)
        {
            animation.Name = value;
            return this;
        }

        /// <summary>
        ///     Orders the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The animation builder</returns>
        public AnimationBuilder Order(int value)
        {
            animation.Order = value;
            return this;
        }

        /// <summary>
        ///     Speeds the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The animation builder</returns>
        public AnimationBuilder Speed(float value)
        {
            animation.Speed = value;
            return this;
        }
    }
}