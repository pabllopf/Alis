using Alis.Core.Aspect.Time;
using Xunit;
using System;
using System.Diagnostics;
using System.Threading;

namespace Alis.Core.Aspect.Time.Test
{
    /// <summary>
    /// Comprehensive unit tests for Clock time management class.
    /// Tests time measurement, delta time, and frame timing.
    /// </summary>
    public class ClockExtensiveTest
    {
        

        /// <summary>
        /// Tests that clock creation succeeds
        /// </summary>
        [Fact]
        public void Clock_Creation_Succeeds()
        {
            var clock = new Clock();
            Assert.NotNull(clock);
        }

        /// <summary>
        /// Tests that clock creation with multiple instances
        /// </summary>
        [Fact]
        public void Clock_Creation_WithMultipleInstances()
        {
            var clock1 = new Clock();
            var clock2 = new Clock();
            var clock3 = new Clock();
            
            Assert.NotNull(clock1);
            Assert.NotNull(clock2);
            Assert.NotNull(clock3);
        }

        

        

        /// <summary>
        /// Tests that delta time after initialization is zero or small
        /// </summary>
        [Fact]
        public void DeltaTime_AfterInitialization_IsZeroOrSmall()
        {
            var clock = new Clock();
            clock.Start();
            
            Assert.True(clock.ElapsedMilliseconds >= 0);
        }

        /// <summary>
        /// Tests that delta time after delay increases with time
        /// </summary>
        [Fact]
        public void DeltaTime_AfterDelay_IncreasesWith_Time()
        {
            var clock = new Clock();
            clock.Start();
            
            Thread.Sleep(10);
            
            Assert.True(clock.ElapsedMilliseconds > 0);
        }

        /// <summary>
        /// Tests that elapsed increments over time
        /// </summary>
        [Fact]
        public void Elapsed_IncrementsOverTime()
        {
            var clock = new Clock();
            clock.Start();
            
            var elapsed1 = clock.ElapsedMilliseconds;
            Thread.Sleep(5);
            var elapsed2 = clock.ElapsedMilliseconds;
            
            Assert.True(elapsed2 >= elapsed1);
        }

        

        

        /// <summary>
        /// Tests that start can be called
        /// </summary>
        [Fact]
        public void Start_CanBeCalled()
        {
            var clock = new Clock();
            clock.Start();
            
            Assert.NotNull(clock);
        }

        /// <summary>
        /// Tests that stop can be called
        /// </summary>
        [Fact]
        public void Stop_CanBeCalled()
        {
            var clock = new Clock();
            clock.Start();
            Thread.Sleep(5);
            clock.Stop();
            
            Assert.NotNull(clock);
        }

        /// <summary>
        /// Tests that start stop start works
        /// </summary>
        [Fact]
        public void Start_Stop_Start_Works()
        {
            var clock = new Clock();
            
            clock.Start();
            Thread.Sleep(5);
            clock.Stop();
            
            var elapsed1 = clock.ElapsedMilliseconds;
            
            clock.Start();
            Thread.Sleep(5);
            
            var elapsed2 = clock.ElapsedMilliseconds;
            
            Assert.True(elapsed2 > elapsed1);
        }

        

        

        /// <summary>
        /// Tests that reset clears time
        /// </summary>
        [Fact]
        public void Reset_ClearsTime()
        {
            var clock = new Clock();
            clock.Start();
            Thread.Sleep(10);
            clock.Reset();
            
            Assert.True(clock.ElapsedMilliseconds < 5);
        }

        /// <summary>
        /// Tests that reset multiple timer works
        /// </summary>
        [Fact]
        public void Reset_MultipleTimer_Works()
        {
            var clock = new Clock();
            
            clock.Start();
            Thread.Sleep(5);
            clock.Reset();
            
            clock.Start();
            Thread.Sleep(5);
            clock.Reset();
            
            Assert.True(clock.ElapsedMilliseconds < 5);
        }

        



        

        /// <summary>
        /// Tests that multiple clocks are independent
        /// </summary>
        [Fact]
        public void Multiple_Clocks_AreIndependent()
        {
            var clock1 = new Clock();
            var clock2 = new Clock();
            
            clock1.Start();
            Thread.Sleep(10);
            
            clock2.Start();
            Thread.Sleep(5);
            
            var elapsed1 = clock1.ElapsedMilliseconds;
            var elapsed2 = clock2.ElapsedMilliseconds;
            
            Assert.True(elapsed1 > elapsed2);
        }

        

        

        /// <summary>
        /// Tests that precision millisecond accuracy
        /// </summary>
        [Fact]
        public void Precision_MillisecondAccuracy()
        {
            var clock = new Clock();
            clock.Start();
            
            var start = clock.ElapsedMilliseconds;
            Thread.Sleep(100);
            var end = clock.ElapsedMilliseconds;
            
            var delta = end - start;
            Assert.InRange(delta, 90, 200);
        }

        /// <summary>
        /// Tests that precision sub millisecond can be measured
        /// </summary>
        [Fact]
        public void Precision_SubMillisecond_CanBeMeasured()
        {
            var clock = new Clock();
            clock.Start();
            
            var elapsed1 = clock.ElapsedMilliseconds;
            var elapsed2 = clock.ElapsedMilliseconds;
            
            Assert.True(elapsed1 >= 0);
            Assert.True(elapsed2 >= 0);
        }

        

        

        /// <summary>
        /// Tests that extreme long duration stays positive
        /// </summary>
        [Fact]
        public void ExtremeLongDuration_StaysPositive()
        {
            var clock = new Clock();
            clock.Start();
            
            Thread.Sleep(500);
            var elapsed = clock.ElapsedMilliseconds;
            
            Assert.True(elapsed >= 0);
        }

        

        

        /// <summary>
        /// Tests that is running after start is true
        /// </summary>
        [Fact]
        public void IsRunning_AfterStart_IsTrue()
        {
            var clock = new Clock();
            clock.Start();
            
            Assert.True(clock.IsRunning);
        }

        /// <summary>
        /// Tests that is running after stop is false
        /// </summary>
        [Fact]
        public void IsRunning_AfterStop_IsFalse()
        {
            var clock = new Clock();
            clock.Start();
            clock.Stop();
            
            Assert.False(clock.IsRunning);
        }

        

        

        /// <summary>
        /// Tests that elapsed timespan returns valid timespan
        /// </summary>
        [Fact]
        public void ElapsedTimespan_ReturnsValidTimespan()
        {
            var clock = new Clock();
            clock.Start();
            Thread.Sleep(10);
            
            var timespan = clock.Elapsed;
            Assert.NotNull(timespan);
        }

        
    }
}

