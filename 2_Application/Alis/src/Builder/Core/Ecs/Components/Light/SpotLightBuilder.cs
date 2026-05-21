

using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Components.Light;

namespace Alis.Builder.Core.Ecs.Components.Light
{
    /// <summary>
    ///     The spot light builder class
    /// </summary>
    public class SpotLightBuilder : IBuild<SpotLight>
    {
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The spot light</returns>
        public SpotLight Build() => new SpotLight();
    }
}