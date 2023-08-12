namespace Alis.Core.Graphic.Backends.Metal
{
    // TODO: Technically this should be "pointer-sized",
    // but there are no non-64-bit platforms that anyone cares about.
    /// <summary>
    /// The cg float
    /// </summary>
    public unsafe struct CGFloat
    {
        /// <summary>
        /// The value
        /// </summary>
        private readonly double _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CGFloat"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public CGFloat(double value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets the value of the value
        /// </summary>
        public double Value
        {
            get => _value;
        }

        public static implicit operator CGFloat(double value) => new CGFloat(value);
        public static implicit operator double(CGFloat cgf) => cgf.Value;

        /// <summary>
        /// Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => _value.ToString();
    }
}