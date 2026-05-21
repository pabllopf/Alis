

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Builder.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The sprite builder class
    /// </summary>
    /// <seealso cref="IBuild{Sprite}" />
    public class SpriteBuilder :
        IBuild<Sprite>,
        IDepth<SpriteBuilder, int>,
        ISetTexture<SpriteBuilder, string>
    {
        /// <summary>
        ///     The context
        /// </summary>
        private readonly Context context;

        /// <summary>
        ///     The depth
        /// </summary>
        private int depth;

        /// <summary>
        ///     The empty
        /// </summary>
        private string nameFile = string.Empty;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SpriteBuilder" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public SpriteBuilder(Context context) => this.context = context;

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The sprite</returns>
        public Sprite Build() => new Sprite(context, nameFile, depth);

        /// <summary>
        ///     Depths the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The sprite builder</returns>
        public SpriteBuilder Depth(int value)
        {
            depth = value;
            return this;
        }

        /// <summary>
        ///     Textures the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The sprite builder</returns>
        public SpriteBuilder SetTexture(string value)
        {
            nameFile = value;
            return this;
        }
    }
}