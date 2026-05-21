

namespace Alis.Core.Aspect.Fluent.Sample
{
    /// <summary>
    ///     Small fluent-builder scenario for sample reuse.
    /// </summary>
    internal static class QuickStartScenario
    {
        /// <summary>
        ///     Creates a configured sports car using fluent API.
        /// </summary>
        /// <returns>A configured <see cref="Car"/> instance.</returns>
        internal static Car CreateSportsCar()
        {
            return Car
                .Create()
                .WithName("Alis Racer")
                .WithModel("X1")
                .WithColor("Blue")
                .Build();
        }
    }
}
