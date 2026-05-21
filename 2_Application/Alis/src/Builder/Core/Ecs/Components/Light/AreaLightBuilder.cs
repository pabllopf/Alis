

using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Components.Light;

namespace Alis.Builder.Core.Ecs.Components.Light
{
    /// <summary>
    ///     The area light builder class
    /// </summary>
    public class AreaLightBuilder :
        IBuild<AreaLight>
    {
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The area light</returns>
        public AreaLight Build() => new AreaLight();
    }
}