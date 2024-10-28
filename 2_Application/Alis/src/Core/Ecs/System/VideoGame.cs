using Alis.Builder.Core.Ecs.System;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.System.Configuration;
using Alis.Core.Ecs.System.Scope;

namespace Alis.Core.Ecs.System
{
    /// <summary>
    /// Represents a video game with context handling capabilities.
    /// </summary>
    /// <seealso cref="IGame"/>
    /// <seealso cref="IHasBuilder{TOut}"/>
    public sealed class VideoGame : IGame, IHasBuilder<VideoGameBuilder>
    {
        /// <summary>
        /// The context handler
        /// </summary>
        private readonly IContextHandler<Context> _contextHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGame"/> class
        /// </summary>
        public VideoGame() : this(new ContextHandler(new Context())) { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGame"/> class
        /// </summary>
        /// <param name="setting">The setting</param>
        public VideoGame(Setting setting) : this(new ContextHandler(new Context(setting))) { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGame"/> class
        /// </summary>
        /// <param name="context">The context</param>
        public VideoGame(Context context) : this(new ContextHandler(context)) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGame"/> class.
        /// </summary>
        /// <param name="contextHandler">The context handler.</param>
        [JsonConstructor]
        public VideoGame(IContextHandler<Context> contextHandler) => _contextHandler = contextHandler;

        /// <summary>
        /// Gets the current context.
        /// </summary>
        [JsonPropertyName("_Context_")]
        public Context Context => _contextHandler.Context;

        /// <summary>
        /// Runs the game.
        /// </summary>
        public void Run() => _contextHandler.Run();

        /// <summary>
        /// Runs the game in preview mode.
        /// </summary>
        public void RunPreview() => _contextHandler.RunPreview();

        /// <summary>
        /// Exits the game.
        /// </summary>
        public void Exit() => _contextHandler.Exit();

        /// <summary>
        /// Creates a new instance of the <see cref="VideoGameBuilder"/>.
        /// </summary>
        /// <returns>A new <see cref="VideoGameBuilder"/> instance.</returns>
        public VideoGameBuilder Builder() => new VideoGameBuilder();

        /// <summary>
        /// Creates a new instance of the <see cref="VideoGameBuilder"/>.
        /// </summary>
        /// <returns>A new <see cref="VideoGameBuilder"/> instance.</returns>
        public static VideoGameBuilder Create() => new VideoGameBuilder();
    }
}