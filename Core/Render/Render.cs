//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Render.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Render define</summary>
    public class Render
    {
        /// <summary>The current</summary>
        [AllowNull]
        private static Render current;

        /// <summary>The configuration</summary>
        [NotNull]
        private readonly Config config;

        /// <summary>Initializes a new instance of the <see cref="Render" /> class.</summary>
        /// <param name="config">The configuration.</param>
        public Render(Config config) => this.config = config;

        /// <summary>Gets or sets the current.</summary>
        /// <value>The current.</value>
        public static Render Current { get => current; set => current = value; }

        /// <summary>Gets the configuration.</summary>
        /// <value>The configuration.</value>
        [NotNull]
        [JsonIgnore]
        public Config Config => config;

        /// <summary>Frames the bytes.</summary>
        /// <returns>Return the frame in bytes.</returns>
        public virtual byte[] FrameBytes() => throw Logger.Error(GetType().FullName);

        /// <summary>Awakes this instance.</summary>
        public virtual void Awake() => throw Logger.Error(GetType().FullName);

        /// <summary>Starts this instance.</summary>
        public virtual void Start() => throw Logger.Error(GetType().FullName);

        /// <summary>Updates this instance.</summary>
        public virtual void Update() => throw Logger.Error(GetType().FullName);

        /// <summary>Fixed the update.</summary>
        public virtual void FixedUpdate() => throw Logger.Error(GetType().FullName);

        /// <summary>Stops this instance.</summary>
        public virtual void Stop() => throw Logger.Error(GetType().FullName);

        /// <summary>Exits this instance.</summary>
        public virtual void Exit() => throw Logger.Error(GetType().FullName);

        /// <summary>Gets the draws.</summary>
        /// <typeparam name="T">type list</typeparam>
        /// <returns>Return a list</returns>
        public virtual List<T> GetDraws<T>() => throw Logger.Error("GetDraws");

        /// <summary>Adds the draw.</summary>
        /// <param name="draw">The draw.</param>
        public virtual void AddDraw([NotNull] Component draw) => throw Logger.Error("AddDraw");

        /// <summary>Removes the specified draw.</summary>
        /// <param name="draw">The draw.</param>
        public virtual void Remove([NotNull] Component draw) => throw Logger.Error("Remove");

        /// <summary>Clears this instance.</summary>
        public virtual void Clear() => throw Logger.Error("Clear");
    }
}