

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The camera
    /// </summary>
    public struct Camera(Context context, Vector2F position, Vector2F resolution) : ICamera
    {
        /// <summary>
        ///     The position
        /// </summary>
        private readonly Vector2F positionOriginal = position;

        /// <summary>
        ///     The resolution
        /// </summary>
        private readonly Vector2F resolutionOriginal = resolution;

        /// <summary>
        ///     The position
        /// </summary>
        public Vector2F Position { get; set; } = position;

        /// <summary>
        ///     Gets or sets the value of the resolution
        /// </summary>
        public Vector2F Resolution { get; set; } = resolution;

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
            Logger.Info($"[{nameof(Camera)}] Initialized with position: ({Position.X},{Position.Y}) and resolution: ({Resolution.X},{Resolution.Y})");
        }

        /// <summary>
        ///     Ons the exit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnExit(IGameObject self)
        {
            Position = new Vector2F(positionOriginal.X, positionOriginal.Y);
            Resolution = new Vector2F(resolutionOriginal.X, resolutionOriginal.Y);
            Logger.Info($"[{nameof(Camera)}] Reset position: ({Position.X},{Position.Y}) and resolution: ({Resolution.X},{Resolution.Y})");
        }

        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        public Context Context { get; set; } = context;
    }
}