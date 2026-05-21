

using System;
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Filters
{
    /// <summary>
    ///     Samples log entries to reduce volume while maintaining representative coverage.
    ///     Useful for high-frequency logging scenarios like render loops.
    ///     AOT-compatible: Uses atomic counters for sampling.
    /// </summary>
    public sealed class SamplingLogFilter : ILogFilter
    {
        /// <summary>
        ///     The sample rate
        /// </summary>
        private readonly int _sampleRate; // 1 in N entries pass through

        /// <summary>
        ///     The counter
        /// </summary>
        private long _counter;

        /// <summary>
        ///     Initializes a new instance of the SamplingLogFilter class.
        /// </summary>
        /// <param name="sampleRate">1 out of every N entries will pass. Must be >= 1.</param>
        public SamplingLogFilter(int sampleRate = 10)
        {
            if (sampleRate < 1)
            {
                throw new ArgumentException("Sample rate must be >= 1", nameof(sampleRate));
            }

            _sampleRate = sampleRate;
            _counter = 0;
        }


        /// <summary>
        ///     Gets a human-readable name for this filter.
        /// </summary>
        public string Name => $"SamplingFilter[1:{_sampleRate}]";


        /// <summary>
        ///     Determines whether the specified entry should be logged based on sampling rate.
        /// </summary>
        /// <param name="entry">The log entry to evaluate.</param>
        /// <returns>True if the entry passes the sampling filter; false otherwise.</returns>
        public bool ShouldLog(ILogEntry entry)
        {
            if (entry == null)
            {
                return false;
            }

            unchecked
            {
                _counter++;
            }

            return _counter % _sampleRate == 0;
        }
    }
}