using System;
using System.Threading;
using Alis.Core.Ecs.System.Configuration;
using Alis.Core.Ecs.System.Execution;
using Alis.Core.Ecs.System.Manager;
using Alis.Core.Ecs.System.Manager.Time;

namespace Alis.Core.Ecs.System.Scope
{
    /// <summary>
    /// The context handler class
    /// </summary>
    /// <seealso cref="IContextHandler{Context}"/>
    public class ContextHandler : IContextHandler<Context>
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextHandler"/> class
        /// </summary>
        /// <param name="context">The context</param>
        public ContextHandler(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the value of the context
        /// </summary>
        public Context Context => _context;

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            Runtime<AManager> runtime = _context.Runtime;
            TimeManager timeManager = _context.TimeManager;
            Setting setting = _context.Setting;

            runtime.OnInit();
            runtime.OnAwake();
            runtime.OnStart();

            double targetFrameDuration = 1 / setting.Graphic.TargetFrames;
            double currentTime = timeManager.Clock.Elapsed.TotalSeconds;
            float accumulator = 0;
            double lastTime = timeManager.Clock.Elapsed.TotalSeconds;
            double totalTime = 0;
            float lastDeltaTime = 0f;
            float smoothDeltaTimeSum = 0f;
            int smoothDeltaTimeCount = 0;

            while (_context.IsRunning)
            {
                double frameStartTime = timeManager.Clock.Elapsed.TotalSeconds;
                double newTime = frameStartTime;

                timeManager.DeltaTime = (float) (newTime - currentTime);
                timeManager.UnscaledDeltaTime = (float) (newTime - currentTime);
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
                    timeManager.AverageFrames = (int) (timeManager.TotalFrames / totalTime);
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
                
                // Render game:
                runtime.OnBeforeDraw();
                runtime.OnDraw();
                runtime.OnAfterDraw();
                runtime.OnGui();
                runtime.OnRenderPresent();
                
                

                smoothDeltaTimeSum += timeManager.DeltaTime - lastDeltaTime;
                smoothDeltaTimeCount++;
                timeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
                lastDeltaTime = timeManager.DeltaTime;

                double frameEndTime = timeManager.Clock.Elapsed.TotalSeconds;
                double frameDuration = frameEndTime - frameStartTime;
                if (frameDuration < targetFrameDuration)
                {
                    Thread.Sleep((int) ((targetFrameDuration - frameDuration) * TimeManager.MillisecondsInSecond));
                }
            }

            runtime.OnStop();
            runtime.OnExit();
        }

        /// <summary>
        /// Runs the preview
        /// </summary>
        public void RunPreview() => Console.WriteLine("Run preview");

        /// <summary>
        /// Exits this instance
        /// </summary>
        public void Exit() => _context.IsRunning = false;
    }
}