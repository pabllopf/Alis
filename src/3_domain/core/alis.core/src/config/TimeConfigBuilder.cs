using Alis.Fluent;
using System;

namespace Alis.Core
{
    public class TimeConfigBuilder :
        IBuild<TimeConfig>,
        ISetMax<TimeConfigBuilder, FramesPerSecond, Func<FramesPerSecond, double>>,
        ISetMax<TimeConfigBuilder, TimeStep, Func<TimeStep, double>>
    {
        private TimeConfig timeConfig;

        public TimeConfigBuilder() => timeConfig = new TimeConfig();

        public TimeConfigBuilder SetMax<T>(Func<FramesPerSecond, double> value) where T : FramesPerSecond
        {
            timeConfig.MaximumFramesPerSecond = value.Invoke(new FramesPerSecond());
            return this;
        }

        public TimeConfigBuilder SetMax<T>(Func<TimeStep, double> value) where T : TimeStep
        {
            timeConfig.MaximunAllowedTimeStep = value.Invoke(new TimeStep());
            return this;
        }

        public TimeConfig Build() => timeConfig;
    }
}
