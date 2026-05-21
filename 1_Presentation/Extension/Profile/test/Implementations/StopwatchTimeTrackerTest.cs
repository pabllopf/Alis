

using System;
using System.Threading;
using Alis.Extension.Profile.Implementations;
using Xunit;

namespace Alis.Extension.Profile.Test.Implementations
{
    /// <summary>
    ///     The stopwatch time tracker test class
    /// </summary>
    public class StopwatchTimeTrackerTest
    {
        /// <summary>
        ///     Tests that constructor initializes tracker correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesTracker_Correctly()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            Assert.False(tracker.IsRunning);
            Assert.Equal(DateTime.MinValue, tracker.GetStartTime());
            Assert.Equal(TimeSpan.Zero, tracker.GetElapsedTime());
        }

        /// <summary>
        ///     Tests that start begins tracking
        /// </summary>
        [Fact]
        public void Start_BeginsTracking()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            tracker.Start();

            Assert.True(tracker.IsRunning);
            Assert.NotEqual(DateTime.MinValue, tracker.GetStartTime());
        }

        /// <summary>
        ///     Tests that start sets start time to current time
        /// </summary>
        [Fact]
        public void Start_SetsStartTime_ToCurrentTime()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            DateTime beforeStart = DateTime.Now;

            tracker.Start();

            DateTime afterStart = DateTime.Now;
            Assert.True(tracker.GetStartTime() >= beforeStart);
            Assert.True(tracker.GetStartTime() <= afterStart);
        }

        /// <summary>
        ///     Tests that stop ends tracking
        /// </summary>
        [Fact]
        public void Stop_EndsTracking()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();

            tracker.Stop();

            Assert.False(tracker.IsRunning);
        }

        /// <summary>
        ///     Tests that stop does nothing when not running
        /// </summary>
        [Fact]
        public void Stop_DoesNothing_WhenNotRunning()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            tracker.Stop(); // Should not throw

            Assert.False(tracker.IsRunning);
        }


        /// <summary>
        ///     Tests that reset clears all tracking data
        /// </summary>
        [Fact]
        public void Reset_ClearsAllTrackingData()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();
            Thread.Sleep(50);
            tracker.Stop();

            tracker.Reset();

            Assert.False(tracker.IsRunning);
            Assert.Equal(DateTime.MinValue, tracker.GetStartTime());
            Assert.Equal(TimeSpan.Zero, tracker.GetElapsedTime());
        }

        /// <summary>
        ///     Tests that start restarts tracking when already running
        /// </summary>
        [Fact]
        public void Start_RestartsTracking_WhenAlreadyRunning()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();
            Thread.Sleep(50);
            TimeSpan firstElapsed = tracker.GetElapsedTime();

            tracker.Start(); // Restart
            TimeSpan secondElapsed = tracker.GetElapsedTime();

            Assert.True(tracker.IsRunning);
            Assert.True(secondElapsed < firstElapsed); // Should be reset
        }

        /// <summary>
        ///     Tests that get elapsed time returns zero before starting
        /// </summary>
        [Fact]
        public void GetElapsedTime_ReturnsZero_BeforeStarting()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            TimeSpan elapsed = tracker.GetElapsedTime();

            Assert.Equal(TimeSpan.Zero, elapsed);
        }

        /// <summary>
        ///     Tests that get start time returns min value before starting
        /// </summary>
        [Fact]
        public void GetStartTime_ReturnsMinValue_BeforeStarting()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            DateTime startTime = tracker.GetStartTime();

            Assert.Equal(DateTime.MinValue, startTime);
        }

        /// <summary>
        ///     Tests that elapsed time continues while running
        /// </summary>
        [Fact]
        public void ElapsedTime_ContinuesWhileRunning()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();
            Thread.Sleep(50);

            TimeSpan firstElapsed = tracker.GetElapsedTime();
            Thread.Sleep(50);
            TimeSpan secondElapsed = tracker.GetElapsedTime();

            Assert.True(secondElapsed > firstElapsed);
        }

        /// <summary>
        ///     Tests that elapsed time does not change after stopping
        /// </summary>
        [Fact]
        public void ElapsedTime_DoesNotChange_AfterStopping()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();
            Thread.Sleep(50);
            tracker.Stop();

            TimeSpan firstElapsed = tracker.GetElapsedTime();
            Thread.Sleep(50);
            TimeSpan secondElapsed = tracker.GetElapsedTime();

            Assert.Equal(firstElapsed, secondElapsed);
        }
    }
}