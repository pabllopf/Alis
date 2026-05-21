

using Alis.Builder.Core.Ecs.System;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Represents a video game with context handling capabilities.
    /// </summary>
    /// <seealso cref="IGame" />
    /// <seealso cref="IHasBuilder{TOut}" />
    public sealed class VideoGame : IGame
    {
        /// <summary>
        ///     The context handler
        /// </summary>
        private readonly IContextHandler<Context> _contextHandler;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class
        /// </summary>
        public VideoGame() : this(new ContextHandler(new Context()))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class
        /// </summary>
        /// <param name="setting">The setting</param>
        public VideoGame(Setting setting) : this(new ContextHandler(new Context(setting)))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public VideoGame(Context context) : this(new ContextHandler(context))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class.
        /// </summary>
        /// <param name="contextHandler">The context handler.</param>
        public VideoGame(IContextHandler<Context> contextHandler) => _contextHandler = contextHandler;

        /// <summary>
        ///     Gets the current context.
        /// </summary>

        public Context Context => _contextHandler.Context;

        /// <summary>
        ///     Runs the game.
        /// </summary>
        public void Run() => _contextHandler.Run();

        /// <summary>
        ///     Exits the game.
        /// </summary>
        public void Exit() => _contextHandler.Exit();

        /// <summary>
        ///     Creates
        /// </summary>
        /// <returns>The video game builder</returns>
        public static VideoGameBuilder Create() => new VideoGameBuilder();

        /// <summary>
        ///     Saves this instance
        /// </summary>
        public void Save() => _contextHandler.Save();

        /// <summary>
        ///     Inits the preview
        /// </summary>
        public void InitPreview() => _contextHandler.InitPreview();

        /// <summary>
        ///     Previews this instance
        /// </summary>
        public void Preview() => _contextHandler.Preview();
    }
}