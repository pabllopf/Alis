namespace Alis.FluentApi
{
    public class TimeStep
    {
        private double value;

        public TimeStep() => value = 60.0f;

        public TimeStep(double value) => this.value = value;

        public double Value { get => value; set => this.value = value; }
    }
}