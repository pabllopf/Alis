//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Render.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    /// <summary>Render define</summary>
    public class Render
    {
        /// <summary>The current</summary>
        private static Render current;

        /// <summary>The configuration</summary>
        [NotNull]
        private readonly Config config;

        /// <summary>Initializes a new instance of the <see cref="Render" /> class.</summary>
        /// <param name="config">The configuration.</param>
        [JsonConstructor]
        public Render([NotNull] Config config)
        {
            this.config = config;
            current = this;
        }

        /// <summary>Gets or sets the current.</summary>
        /// <value>The current.</value>
        public static Render Current { get => current; set => current = value; }

        /// <summary>Frames the bytes.</summary>
        /// <returns>Return none</returns>
        public virtual byte[] FrameBytes() 
        {
            return default;
        }

        /// <summary>Awakes this instance.</summary>
        public virtual void Awake() { }

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        public virtual void Start() { }

        /// <summary>Updates this instance.</summary>
        /// <returns>Return none</returns>
        public virtual void Update() { }

        /// <summary>Stops this instance.</summary>
        public virtual void Stop() { }

        /// <summary>Exits this instance.</summary>
        public virtual void Exit() { }
    }
}