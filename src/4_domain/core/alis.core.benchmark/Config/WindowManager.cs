//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="WindowManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using Newtonsoft.Json;
    using System.Diagnostics.CodeAnalysis;
    using System.Numerics;

    /// <summary>Window manager</summary>
    public class WindowManager
    {
        /// <summary>The current</summary>
        private static WindowManager current;

        /// <summary>Builders this instance.</summary>
        /// <returns>Window Manager Builder</returns>
        public static WindowManagerBuilder Builder() => new WindowManagerBuilder();

        /// <summary>The default window</summary>
        [NotNull]
        private WindowState windowState;

        /// <summary>The resolution</summary>
        [NotNull]
        private Vector2 resolution;

        /// <summary>Initializes a new instance of the <see cref="WindowManager" /> class.</summary>
        public WindowManager()
        {
            windowState = WindowState.Normal;
            resolution = new Vector2(1024, 640);
            current = this;
        }

        /// <summary>Initializes a new instance of the <see cref="WindowManager" /> class.</summary>
        /// <param name="windowState">State of the window.</param>
        /// <param name="resolution">The resolution.</param>
        [JsonConstructor]
        public WindowManager(WindowState windowState, Vector2 resolution)
        {
            this.windowState = windowState;
            this.resolution = resolution;
            current = this;
        }

        /// <summary>Gets or sets the state of the window.</summary>
        /// <value>The state of the window.</value>
        [NotNull]
        [JsonProperty("_WindowState")]
        public WindowState WindowState { get => windowState; set => windowState = value; }

        /// <summary>Gets or sets the resolution.</summary>
        /// <value>The resolution.</value>
        [NotNull]
        [JsonProperty("_Resolution")]
        public Vector2 Resolution { get => resolution; set => resolution = value; }

        /// <summary>Changes the resolution.</summary>
        /// <param name="resolution">The resolution.</param>
        public static void ChangeResolution(Vector2 resolution) => current.resolution = resolution;

        /// <summary>Sets the window.</summary>
        /// <param name="windowState">State of the window.</param>
        public static void SetWindow(WindowState windowState) => current.windowState = windowState;

        /// <summary>Window Manager Builder</summary>
        public class WindowManagerBuilder
        {
            /// <summary>The current</summary>
            private WindowManagerBuilder current;

            /// <summary>The state</summary>
            private WindowState windowState;

            /// <summary>The resolution</summary>
            private Vector2 resolution;

            /// <summary>Initializes a new instance of the <see cref="WindowManagerBuilder" /> class.</summary>
            public WindowManagerBuilder() => current ??= this;

            /// <summary>Resolutions the specified resolution.</summary>
            /// <param name="resolution">The resolution.</param>
            /// <returns>Window Manager Builder</returns>
            public WindowManagerBuilder Resolution(Vector2 resolution) 
            {
                current.resolution = resolution;
                return current;
            }

            /// <summary>Resolutions the specified x.</summary>
            /// <param name="x">The x.</param>
            /// <param name="y">The y.</param>
            /// <returns>Window Manager Builder</returns>
            public WindowManagerBuilder Resolution(int x, int y)
            {
                current.resolution = new Vector2(x, y);
                return current;
            }

            /// <summary>Resolutions the specified window state.</summary>
            /// <param name="windowState">State of the window.</param>
            /// <returns>Window Manager Builder</returns>
            public WindowManagerBuilder WindowState(WindowState windowState)
            {
                current.windowState = windowState;
                return current;
            }

            /// <summary>Builds this instance.</summary>
            /// <returns>Window Manager</returns>
            public WindowManager Build() => new WindowManager(current.windowState, current.resolution);
        }
    }
}