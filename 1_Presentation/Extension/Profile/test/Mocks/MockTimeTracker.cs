

using System;
using Alis.Extension.Profile.Interfaces;

namespace Alis.Extension.Profile.Test.Mocks
{
    /// <summary>
    ///     Mock implementation of <see cref="ITimeTracker" /> for testing purposes.
    ///     This class allows tests to control time tracking behavior and verify method calls.
    /// </summary>
    public class MockTimeTracker : ITimeTracker
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MockTimeTracker" /> class.
        /// </summary>
        public MockTimeTracker()
        {
            IsRunning = false;
            StartTime = DateTime.MinValue;
            ElapsedTime = TimeSpan.Zero;
        }

        /// <summary>
        ///     Gets or sets the start time to return.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        ///     Gets or sets the elapsed time to return.
        /// </summary>
        public TimeSpan ElapsedTime { get; set; }

        /// <summary>
        ///     Gets a value indicating whether Start was called.
        /// </summary>
        public bool StartCalled { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether Stop was called.
        /// </summary>
        public bool StopCalled { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether Reset was called.
        /// </summary>
        public bool ResetCalled { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether GetElapsedTime was called.
        /// </summary>
        public bool GetElapsedTimeCalled { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether GetStartTime was called.
        /// </summary>
        public bool GetStartTimeCalled { get; private set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the tracker is running.
        /// </summary>
        public bool IsRunning { get; set; }

        /// <summary>
        ///     Simulates starting the tracker.
        /// </summary>
        public void Start()
        {
            StartCalled = true;
            IsRunning = true;
            StartTime = DateTime.Now;
        }

        /// <summary>
        ///     Simulates stopping the tracker.
        /// </summary>
        public void Stop()
        {
            StopCalled = true;
            IsRunning = false;
        }

        /// <summary>
        ///     Simulates resetting the tracker.
        /// </summary>
        public void Reset()
        {
            ResetCalled = true;
            IsRunning = false;
            StartTime = DateTime.MinValue;
            ElapsedTime = TimeSpan.Zero;
        }

        /// <summary>
        ///     Gets the configured elapsed time and marks the method as called.
        /// </summary>
        /// <returns>The configured elapsed time.</returns>
        public TimeSpan GetElapsedTime()
        {
            GetElapsedTimeCalled = true;
            return ElapsedTime;
        }

        /// <summary>
        ///     Gets the configured start time and marks the method as called.
        /// </summary>
        /// <returns>The configured start time.</returns>
        public DateTime GetStartTime()
        {
            GetStartTimeCalled = true;
            return StartTime;
        }

        /// <summary>
        ///     Resets all call tracking flags.
        /// </summary>
        public void ResetCallTracking()
        {
            StartCalled = false;
            StopCalled = false;
            ResetCalled = false;
            GetElapsedTimeCalled = false;
            GetStartTimeCalled = false;
        }
    }
}