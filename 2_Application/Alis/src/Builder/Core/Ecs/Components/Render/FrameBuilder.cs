

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Components.Render;

namespace Alis.Builder.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The frame builder class
    /// </summary>
    public class FrameBuilder :
        IBuild<Frame>,
        IFilePath<FrameBuilder, string>
    {
        /// <summary>
        ///     The frame
        /// </summary>
        private Frame frame;

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The frame</returns>
        public Frame Build() => frame;

        /// <summary>
        ///     Files the path using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The frame builder</returns>
        public FrameBuilder File(string value)
        {
            frame.NameFile = value;
            return this;
        }
    }
}