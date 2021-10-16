using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Alis.Core
{
    public class TimeConfig : HasBuilder<TimeConfigBuilder>
    {
        private Stopwatch timer;

        // Tiempo total desde que comenzó el juego
        private double fixedTime;

        // Multiplicador de tiempo que muestra la velocidad del mundo
        // timeScale = 1.0f velocidad normal
        // timeScale = 0.5f a mitad de velocidad 
        private double timeScale;

        // Numero de frames desde que comenzó el juego:
        private double frameCount;

        // Frame actual del juego.
        private double currentFrame;

        // Intervalo en segundos en el que se relaiza fixedupdate
        private double fixedDeltaTime;

        // Numero de fps maximo que se lanza el juego.
        private double maximumFramesPerSecond;

        // intervalo de simulación de cada paso por cada frame
        private double timeStep;

        // Numero de pasos por cada frame (tiempo simulado)
        private double maximunAllowedTimeStep;

        public TimeConfig()
        {
            timer = new Stopwatch();
            timer.Start();

            fixedTime = 0.0f;
            timeScale = 1.0f;
            frameCount = 0.0f;
            currentFrame = 0.0f;
            
            fixedDeltaTime = 0.0f;
            maximumFramesPerSecond = 60.0;
            
            timeStep = 0.0f;
            maximunAllowedTimeStep = 30.0f;
        }

        public double FixedTime { get => fixedTime; set => fixedTime = value; }
                
        public double TimeScale { get => timeScale; set => timeScale = value; }
        
        public double FrameCount { get => frameCount;  }
        
        public double CurrentFrame { get => currentFrame;  }
        
        public double FixedDeltaTime { get => fixedDeltaTime; }
        
        public double MaximumFramesPerSecond
        {
            get => maximumFramesPerSecond; 
            set
            {
                maximumFramesPerSecond = value;
                if (maximumFramesPerSecond <= 0.0f) 
                {
                    maximumFramesPerSecond = 1.0f;
                }
            }
        }

        public double TimeStep { get => timeStep; }
        
        public double MaximunAllowedTimeStep
        {
            get => maximunAllowedTimeStep; set
            {
                maximunAllowedTimeStep = value;
                if (maximunAllowedTimeStep <= 0.0)
                {
                    maximunAllowedTimeStep = 1.0;
                }
            }
        }

        internal void UpdateFixedDeltaTime() => fixedDeltaTime = 1_000.0f / maximumFramesPerSecond;

        internal bool IsNewFrame() => ((fixedTime * timeScale) / frameCount) > fixedDeltaTime;

        internal void UpdateTimeStep() => timeStep = maximunAllowedTimeStep <= 0 ? 1 :  1 / maximunAllowedTimeStep;

        internal void CounterFrames() 
        {
            currentFrame = (frameCount < maximumFramesPerSecond ? frameCount : (frameCount % maximumFramesPerSecond)) + 1;
            frameCount += 1.0f;
        }

        internal void UpdateFixedTime() => fixedTime = timer.Elapsed.TotalMilliseconds;
    }
}