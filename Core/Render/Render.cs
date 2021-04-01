//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Render.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    /// <summary>Render define</summary>
    public class Render
    {
        /// <summary>The configuration</summary>
        [NotNull]
        private Config config;

        /// <summary>The current</summary>
        private static Render current;

        /// <summary>Gets or sets the current.</summary>
        /// <value>The current.</value>
        public static Render Current { get => current; set => current = value; }

        /// <summary>Initializes a new instance of the <see cref="Render" /> class.</summary>
        /// <param name="config">The configuration.</param>
        public Render(Config config) => this.config = config;

        /// <summary>Frames the bytes.</summary>
        /// <returns>Return the frame in bytes.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual byte[] FrameBytes() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Awakes this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        public virtual void Awake() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        public virtual void Start() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Updates this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        public virtual void Update() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Fixed the update.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        public virtual void FixedUpdate() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Stops this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        public virtual void Stop() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Exits this instance.</summary>
        /// <returns>Return none</returns>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        public virtual void Exit() => throw new NotImplementedException(GetType().FullName);

        /// <summary>Gets the draws.</summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return a list</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual List<T> GetDraws<T>() => throw new NotImplementedException("GetDraws");

        /// <summary>Adds the draw.</summary>
        /// <param name="draw">The draw.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void AddDraw([NotNull] Component draw) => throw new NotImplementedException("AddDraw");

        /// <summary>Removes the specified draw.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="draw">The draw.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void Remove([NotNull] Component draw) => throw new NotImplementedException("Remove");
    }
}