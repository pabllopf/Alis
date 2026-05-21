

using System;
using System.Threading;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Execution;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Manager.Time;

namespace Alis.Core.Ecs.Systems.Scope
{
    /// <summary>
    ///     The context handler class
    /// </summary>
    /// <seealso cref="IContextHandler{Context}" />
    public class ContextHandler : IContextHandler<Context>
    {
        /// <summary>
        ///     The context
        /// </summary>
        private readonly Context _context;

        /// <summary>
        ///     The accumulator
        /// </summary>
        private float accumulator;

        /// <summary>
        ///     The current time
        /// </summary>
        private double currentTime;

        /// <summary>
        ///     The last delta time
        /// </summary>
        private float lastDeltaTime;

        /// <summary>
        ///     The last time
        /// </summary>
        private double lastTime;

        /// <summary>
        ///     The smooth delta time count
        /// </summary>
        private int smoothDeltaTimeCount;

        /// <summary>
        ///     The smooth delta time sum
        /// </summary>
        private float smoothDeltaTimeSum;

        /// <summary>
        ///     The target frame duration
        /// </summary>
        private double targetFrameDuration;

        /// <summary>
        ///     The total time
        /// </summary>
        private double totalTime;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContextHandler" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public ContextHandler(Context context) => _context = context;

        /// <summary>
        ///     Gets the value of the context
        /// </summary>
        public Context Context => _context;

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            InternalRuntime<AManager> internalRuntime = _context.InternalRuntime;
            Setting setting = _context.Setting;
            TimeManager timeManager = _context.TimeManager;

            internalRuntime.OnInit();
            internalRuntime.OnAwake();
            internalRuntime.OnStart();

            targetFrameDuration = 1 / setting.Graphic.TargetFrames;
            currentTime = timeManager.Clock.Elapsed.TotalSeconds;
            accumulator = 0;
            lastTime = timeManager.Clock.Elapsed.TotalSeconds;

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

                if (newTime - lastTime >= timeManager.OneSecond)
                {
                    totalTime += newTime - lastTime;
                    timeManager.AverageFrames = (int) (timeManager.TotalFrames / totalTime);
                    timeManager.FrameCount = 0;
                    lastTime = newTime;
                }

                internalRuntime.OnDispatchEvents();
                internalRuntime.OnProcessPendingChanges();

                internalRuntime.OnPhysicUpdate();
                internalRuntime.OnBeforeUpdate();
                internalRuntime.OnUpdate();
                internalRuntime.OnAfterUpdate();

                while (accumulator >= timeManager.Setting.FixedTimeStep)
                {
                    timeManager.InFixedTimeStep = true;
                    timeManager.FixedTime += timeManager.Setting.FixedTimeStep;
                    timeManager.FixedTimeAsDouble += timeManager.Setting.FixedTimeStep;
                    timeManager.FixedDeltaTime = timeManager.Setting.FixedTimeStep;
                    timeManager.FixedUnscaledDeltaTime = timeManager.Setting.FixedTimeStep / timeManager.TimeScale;
                    timeManager.FixedUnscaledTime += timeManager.FixedUnscaledDeltaTime;
                    timeManager.FixedUnscaledTimeAsDouble += timeManager.FixedUnscaledDeltaTime;
                    internalRuntime.OnBeforeFixedUpdate();
                    internalRuntime.OnFixedUpdate();
                    internalRuntime.OnAfterFixedUpdate();
                    accumulator %= timeManager.Setting.FixedTimeStep;
                    timeManager.InFixedTimeStep = false;
                }

                internalRuntime.OnCalculate();

                internalRuntime.OnBeforeDraw();
                internalRuntime.OnDraw();
                internalRuntime.OnAfterDraw();
                internalRuntime.OnGui();
                internalRuntime.OnRenderPresent();


                smoothDeltaTimeSum += timeManager.DeltaTime - lastDeltaTime;
                smoothDeltaTimeCount++;
                timeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
                lastDeltaTime = timeManager.DeltaTime;

                double frameEndTime = timeManager.Clock.Elapsed.TotalSeconds;
                double frameDuration = frameEndTime - frameStartTime;
                if (frameDuration < targetFrameDuration)
                {
                    Thread.Sleep((int) ((targetFrameDuration - frameDuration) * timeManager.MillisecondsInSecond));
                }
            }

            internalRuntime.OnStop();
            internalRuntime.OnExit();
        }


        /// <summary>
        ///     Exits this instance
        /// </summary>
        public void Exit() => _context.IsRunning = false;

        /// <summary>
        ///     Saves this instance
        /// </summary>
        public void Save()
        {
            _context.Setting.OnSave();
            _context.InternalRuntime.OnSave();
        }

        /// <summary>
        ///     Loads this instance
        /// </summary>
        public void Load()
        {
            _context.Setting.OnLoad();
            _context.InternalRuntime.OnLoad();
        }

        /// <summary>
        ///     Loads the and run
        /// </summary>
        public void LoadAndRun()
        {
            _context.Setting.OnLoad();
            _context.InternalRuntime.OnLoad();
            Run();
        }

        /// <summary>
        ///     Inits the preview
        /// </summary>
        public void InitPreview()
        {
            InternalRuntime<AManager> internalRuntime = _context.InternalRuntime;
            Setting setting = _context.Setting;
            TimeManager timeManager = _context.TimeManager;

            _context.Setting.Graphic = _context.Setting.Graphic with {PreviewMode = true};

            internalRuntime.OnInit();
            internalRuntime.OnAwake();
            internalRuntime.OnStart();

            targetFrameDuration = 1 / setting.Graphic.TargetFrames;
            currentTime = timeManager.Clock.Elapsed.TotalSeconds;
            accumulator = 0;
            lastTime = timeManager.Clock.Elapsed.TotalSeconds;
        }

        /// <summary>
        ///     Previews this instance
        /// </summary>
        public void Preview()
        {
            InternalRuntime<AManager> internalRuntime = _context.InternalRuntime;
            TimeManager timeManager = _context.TimeManager;

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

            if (newTime - lastTime >= timeManager.OneSecond)
            {
                totalTime += newTime - lastTime;
                timeManager.AverageFrames = (int) (timeManager.TotalFrames / totalTime);
                timeManager.FrameCount = 0;
                lastTime = newTime;
            }

            internalRuntime.OnDispatchEvents();
            internalRuntime.OnProcessPendingChanges();

            internalRuntime.OnPhysicUpdate();
            internalRuntime.OnBeforeUpdate();
            internalRuntime.OnUpdate();
            internalRuntime.OnAfterUpdate();

            while (accumulator >= timeManager.Setting.FixedTimeStep)
            {
                timeManager.InFixedTimeStep = true;
                timeManager.FixedTime += timeManager.Setting.FixedTimeStep;
                timeManager.FixedTimeAsDouble += timeManager.Setting.FixedTimeStep;
                timeManager.FixedDeltaTime = timeManager.Setting.FixedTimeStep;
                timeManager.FixedUnscaledDeltaTime = timeManager.Setting.FixedTimeStep / timeManager.TimeScale;
                timeManager.FixedUnscaledTime += timeManager.FixedUnscaledDeltaTime;
                timeManager.FixedUnscaledTimeAsDouble += timeManager.FixedUnscaledDeltaTime;
                internalRuntime.OnBeforeFixedUpdate();
                internalRuntime.OnFixedUpdate();
                internalRuntime.OnAfterFixedUpdate();
                accumulator %= timeManager.Setting.FixedTimeStep;
                timeManager.InFixedTimeStep = false;
            }

            internalRuntime.OnCalculate();

            internalRuntime.OnBeforeDraw();
            internalRuntime.OnDraw();
            internalRuntime.OnAfterDraw();
            internalRuntime.OnGui();
            internalRuntime.OnRenderPresent();


            smoothDeltaTimeSum += timeManager.DeltaTime - lastDeltaTime;
            smoothDeltaTimeCount++;
            timeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
            lastDeltaTime = timeManager.DeltaTime;

            double frameEndTime = timeManager.Clock.Elapsed.TotalSeconds;
            double frameDuration = frameEndTime - frameStartTime;
            if (frameDuration < targetFrameDuration)
            {
                Thread.Sleep((int) ((targetFrameDuration - frameDuration) * timeManager.MillisecondsInSecond));
            }
        }

        /// <summary>
        ///     Saves the path
        /// </summary>
        /// <param name="path">The path</param>
        public void Save(string path)
        {
            _context.Setting.OnSave();
            _context.InternalRuntime.OnSave(path);
        }
    }
}