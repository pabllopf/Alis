

using System;
using Alis.Extension.Profile.Interfaces;
using Alis.Extension.Profile.Models;

namespace Alis.Extension.Profile.Utilities
{
    /// <summary>
    ///     Provides an automatic profiling scope using the RAII (Resource Acquisition Is Initialization) pattern.
    ///     When created, profiling starts automatically. When disposed, profiling stops and the snapshot
    ///     is captured. This enables convenient profiling using the 'using' statement.
    /// </summary>
    /// <example>
    ///     <code>
    /// using (var scope = new ProfilerScope(profilerService, snapshot => Console.WriteLine(snapshot)))
    /// {
    ///     // Code to profile
    /// }
    /// </code>
    /// </example>
    public sealed class ProfilerScope : IDisposable
    {
        /// <summary>
        ///     Optional callback to invoke when the scope is disposed with the resulting snapshot.
        /// </summary>
        private readonly Action<ProfileSnapshot> onCompleted;

        /// <summary>
        ///     The profiler service used for profiling operations.
        /// </summary>
        private readonly IProfilerService profilerService;

        /// <summary>
        ///     Indicates whether the scope has been disposed.
        /// </summary>
        private bool isDisposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProfilerScope" /> class and starts profiling.
        /// </summary>
        /// <param name="profilerService">The profiler service to use.</param>
        /// <param name="onCompleted">Optional callback to invoke with the snapshot when disposed.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when profilerService is null.
        /// </exception>
        public ProfilerScope(IProfilerService profilerService, Action<ProfileSnapshot> onCompleted = null)
        {
            this.profilerService = profilerService ?? throw new ArgumentNullException(nameof(profilerService));
            this.onCompleted = onCompleted;
            isDisposed = false;

            profilerService.StartProfiling();
        }

        /// <summary>
        ///     Stops profiling and captures the final snapshot.
        ///     If an onCompleted callback was provided, it will be invoked with the snapshot.
        /// </summary>
        public void Dispose()
        {
            if (isDisposed)
            {
                return;
            }

            isDisposed = true;

            if (profilerService.IsActive)
            {
                ProfileSnapshot snapshot = profilerService.StopProfiling();
                onCompleted?.Invoke(snapshot);
            }
        }
    }
}