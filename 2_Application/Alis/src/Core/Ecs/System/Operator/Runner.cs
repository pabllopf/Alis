using System;
using System.Threading;
using Alis.Core.Ecs.System.Manager;
using Alis.Core.Ecs.System.Manager.Time;
using Alis.Core.Ecs.System.Setting;

namespace Alis.Core.Ecs.System.Operator
{
    /// <summary>
    /// The runner class
    /// </summary>
    /// <seealso cref="IRunner"/>
    internal class Runner : IRunner
    {
        /// <summary>
        /// The one second
        /// </summary>
        private const double OneSecond = 1.0;
        
        /// <summary>
        /// The milliseconds in second
        /// </summary>
        private const int MillisecondsInSecond = 1000;

        /// <summary>
        /// Runs the context
        /// </summary>
        /// <param name="context">The context</param>
        public void Run(Context context)
        {
            Runtime<AManager> runtime = context.Runtime;
            TimeManager timeManager = context.TimeManager;
            Settings settings = context.Settings;

            Initialize(runtime);

            double targetFrameDuration = 1 / settings.Graphic.TargetFrames;
            double currentTime = timeManager.Clock.Elapsed.TotalSeconds;
            float accumulator = 0;
            double lastTime = timeManager.Clock.Elapsed.TotalSeconds;
            double totalTime = 0;
            float lastDeltaTime = 0f;
            float smoothDeltaTimeSum = 0f;
            int smoothDeltaTimeCount = 0;

            while (timeManager.IsRunning)
            {
                double frameStartTime = timeManager.Clock.Elapsed.TotalSeconds;
                double newTime = frameStartTime;
                UpdateTimeManager(timeManager, newTime, ref currentTime, ref accumulator);

                if (newTime - lastTime >= OneSecond)
                {
                    totalTime += newTime - lastTime;
                    timeManager.AverageFrames = (int)(timeManager.TotalFrames / totalTime);
                    timeManager.FrameCount = 0;
                    lastTime = newTime;
                }

                ExecuteRuntimeUpdates(runtime, timeManager, ref accumulator);

                smoothDeltaTimeSum += timeManager.DeltaTime - lastDeltaTime;
                smoothDeltaTimeCount++;
                timeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
                lastDeltaTime = timeManager.DeltaTime;

                double frameEndTime = timeManager.Clock.Elapsed.TotalSeconds;
                double frameDuration = frameEndTime - frameStartTime;
                if (frameDuration < targetFrameDuration)
                {
                    Thread.Sleep((int)((targetFrameDuration - frameDuration) * MillisecondsInSecond));
                }
            }

            Terminate(runtime);
        }

        /// <summary>
        /// Runs the preview using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        public void RunPreview(Context context) => Console.WriteLine("Run preview");

        /// <summary>
        /// Initializes the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        private void Initialize(Runtime<AManager> runtime)
        {
            runtime.OnInit();
            runtime.OnAwake();
            runtime.OnStart();
        }

        /// <summary>
        /// Updates the time manager using the specified time manager
        /// </summary>
        /// <param name="timeManager">The time manager</param>
        /// <param name="newTime">The new time</param>
        /// <param name="currentTime">The current time</param>
        /// <param name="accumulator">The accumulator</param>
        private void UpdateTimeManager(TimeManager timeManager, double newTime, ref double currentTime, ref float accumulator)
        {
            timeManager.DeltaTime = (float)(newTime - currentTime);
            timeManager.UnscaledDeltaTime = (float)(newTime - currentTime);
            timeManager.UnscaledTime += timeManager.UnscaledDeltaTime;
            timeManager.UnscaledTimeAsDouble += timeManager.UnscaledDeltaTime;
            timeManager.Time = timeManager.UnscaledTime * timeManager.TimeScale;
            timeManager.TimeAsDouble = timeManager.UnscaledTimeAsDouble * timeManager.TimeScale;
            timeManager.MaximumDeltaTime = Math.Max(timeManager.MaximumDeltaTime, timeManager.DeltaTime);
            currentTime = newTime;
            accumulator += timeManager.DeltaTime;
            timeManager.FrameCount++;
            timeManager.TotalFrames++;
        }

        /// <summary>
        /// Executes the runtime updates using the specified runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        /// <param name="timeManager">The time manager</param>
        /// <param name="accumulator">The accumulator</param>
        private void ExecuteRuntimeUpdates(Runtime<AManager> runtime, TimeManager timeManager, ref float accumulator)
        {
            runtime.OnDispatchEvents();
            runtime.OnPhysicUpdate();
            runtime.OnBeforeUpdate();
            runtime.OnUpdate();
            runtime.OnAfterUpdate();

            while (accumulator >= timeManager.Configuration.FixedTimeStep)
            {
                timeManager.InFixedTimeStep = true;
                timeManager.FixedTime += timeManager.Configuration.FixedTimeStep;
                timeManager.FixedTimeAsDouble += timeManager.Configuration.FixedTimeStep;
                timeManager.FixedDeltaTime = timeManager.Configuration.FixedTimeStep;
                timeManager.FixedUnscaledDeltaTime = timeManager.Configuration.FixedTimeStep / timeManager.TimeScale;
                timeManager.FixedUnscaledTime += timeManager.FixedUnscaledDeltaTime;
                timeManager.FixedUnscaledTimeAsDouble += timeManager.FixedUnscaledDeltaTime;
                runtime.OnBeforeFixedUpdate();
                runtime.OnFixedUpdate();
                runtime.OnAfterFixedUpdate();
                accumulator %= timeManager.Configuration.FixedTimeStep;
                timeManager.InFixedTimeStep = false;
            }

            runtime.OnCalculate();
            runtime.OnDraw();
            runtime.OnGui();
        }

        /// <summary>
        /// Terminates the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        private void Terminate(Runtime<AManager> runtime)
        {
            runtime.OnStop();
            runtime.OnExit();
        }
    }
}