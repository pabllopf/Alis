using Alis.Core.Entities;
using Alis.FluentApi;

namespace Alis.Core.Builders
{
    /// <summary>
    /// The scene builder class
    /// </summary>
    /// <seealso cref="IBuild{Scene}"/>
    /// <seealso cref="IName{SceneBuilder, string}"/>
    public class SceneBuilder :
        IBuild<Scene>,
        IName<SceneBuilder, string>
    {
        /// <summary>
        /// Gets or sets the value of the scene
        /// </summary>
        public Scene Scene { get; set; } = new();

        /// <summary>
        /// Builds this instance
        /// </summary>
        /// <returns>The scene</returns>
        public Scene Build()
        {
            return Scene;
        }

        /// <summary>
        /// Names the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The scene builder</returns>
        public SceneBuilder Name(string value)
        {
            Scene.Name = value;
            return this;
        }
    }
}