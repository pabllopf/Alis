

namespace Alis.Core.Aspect.Data.Sample
{
    /// <summary>
    ///     Small helper scenario used by sample applications.
    /// </summary>
    internal static class QuickStartScenario
    {
        /// <summary>
        ///     Creates a sample music album payload.
        /// </summary>
        /// <returns>A ready-to-serialize album instance.</returns>
        internal static Album CreateAlbum()
        {
            return new Album
            {
                Name = "Alis Demo Album",
                TrackCount = 12,
                DurationSeconds = 2640,
                IsAvailable = true
            };
        }
    }
}
