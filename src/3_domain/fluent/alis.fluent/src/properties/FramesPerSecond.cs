namespace Alis.FluentApi
{
    public class FramesPerSecond
    {
        private double value;

        public FramesPerSecond() => value = 60.0f;

        public FramesPerSecond(double value) => this.value = value;

        public double Value { get => value; set => this.value = value; }
    }
}