//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Info.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor
{
    using System.Diagnostics.CodeAnalysis;
    using Alis.Tools;

    /// <summary>Info context </summary>
    public class Info
    {
        /// <summary>The platform</summary>
        [NotNull]
        private Platform platform;

        /// <summary>The architecture</summary>
        [NotNull]
        private Architecture architecture;

        /// <summary>The graphics</summary>
        [NotNull]
        private Graphics graphics;

        /// <summary>Initializes a new instance of the <see cref="Info" /> class.</summary>
        /// <param name="platform">The platform.</param>
        /// <param name="architecture">The architecture.</param>
        /// <param name="graphics">The graphics.</param>
        public Info([NotNull] Platform platform, [NotNull] Architecture architecture, [NotNull] Graphics graphics)
        {
            this.platform = platform;
            this.architecture = architecture;
            this.graphics = graphics;
            Logger.Info();
        }

        /// <summary>Initializes a new instance of the <see cref="Info" /> class.</summary>
        public Info()
        {
            platform = Platform.Windows;
            architecture = Architecture.X64;
            graphics = Graphics.OpenGL;
            Logger.Info();
        }

        /// <summary>Gets or sets the platform.</summary>
        /// <value>The platform.</value>
        [NotNull]
        public Platform Platform { get => platform; set => platform = value; }

        /// <summary>Gets or sets the architecture.</summary>
        /// <value>The architecture.</value>
        [NotNull]
        public Architecture Architecture { get => architecture; set => architecture = value; }

        /// <summary>Gets or sets the graphics.</summary>
        /// <value>The graphics.</value>
        [NotNull]
        public Graphics Graphics { get => graphics; set => graphics = value; }
    }
}
