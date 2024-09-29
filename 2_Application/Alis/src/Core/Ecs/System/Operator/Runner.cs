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
    /// <seealso cref="IRunner{Context}"/>
    internal class Runner : IRunner<Context>
    {
        /// <summary>
        /// Runs the context
        /// </summary>
        /// <param name="context">The context</param>
        public void Run(Context context)
        {
            Runtime<AManager> runtime = context.Runtime;
            TimeManager timeManager = context.TimeManager;
            Settings settings = context.Settings;

            runtime.OnInit();
            runtime.OnAwake();
            runtime.OnStart();

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

                if (newTime - lastTime >= TimeManager.OneSecond)
                {
                    totalTime += newTime - lastTime;
                    timeManager.AverageFrames = (int)(timeManager.TotalFrames / totalTime);
                    timeManager.FrameCount = 0;
                    lastTime = newTime;
                }

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

                smoothDeltaTimeSum += timeManager.DeltaTime - lastDeltaTime;
                smoothDeltaTimeCount++;
                timeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
                lastDeltaTime = timeManager.DeltaTime;

                double frameEndTime = timeManager.Clock.Elapsed.TotalSeconds;
                double frameDuration = frameEndTime - frameStartTime;
                if (frameDuration < targetFrameDuration)
                {
                    Thread.Sleep((int)((targetFrameDuration - frameDuration) * TimeManager.MillisecondsInSecond));
                }
            }

            runtime.OnStop();
            runtime.OnExit();
        }

        /// <summary>
        /// Runs the preview using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        public void RunPreview(Context context) => Console.WriteLine("Run preview");
    }
}