namespace Alis.Core.Graphic.Backends.Vk
{
    // Fixed-size "array" types, useful for constructing inputs
    // to some Vulkan functions without allocating and pinning a real array.

    /// <summary>
    /// The fixed array
    /// </summary>
    internal struct FixedArray2<T> where T : struct
    {
        /// <summary>
        /// The first
        /// </summary>
        public T First;
        /// <summary>
        /// The second
        /// </summary>
        public T Second;

        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        /// <param name="first">The first</param>
        /// <param name="second">The second</param>
        public FixedArray2(T first, T second) { First = first; Second = second; }

        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public uint Count => 2;
    }

    /// <summary>
    /// The fixed array
    /// </summary>
    internal struct FixedArray3<T> where T : struct
    {
        /// <summary>
        /// The first
        /// </summary>
        public T First;
        /// <summary>
        /// The second
        /// </summary>
        public T Second;
        /// <summary>
        /// The third
        /// </summary>
        public T Third;

        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        /// <param name="first">The first</param>
        /// <param name="second">The second</param>
        /// <param name="third">The third</param>
        public FixedArray3(T first, T second, T third) { First = first; Second = second; Third = third; }

        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public uint Count => 3;
    }

    /// <summary>
    /// The fixed array
    /// </summary>
    internal struct FixedArray4<T> where T : struct
    {
        /// <summary>
        /// The first
        /// </summary>
        public T First;
        /// <summary>
        /// The second
        /// </summary>
        public T Second;
        /// <summary>
        /// The third
        /// </summary>
        public T Third;
        /// <summary>
        /// The fourth
        /// </summary>
        public T Fourth;

        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        /// <param name="first">The first</param>
        /// <param name="second">The second</param>
        /// <param name="third">The third</param>
        /// <param name="fourth">The fourth</param>
        public FixedArray4(T first, T second, T third, T fourth) { First = first; Second = second; Third = third; Fourth = fourth; }

        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public uint Count => 4;
    }

    /// <summary>
    /// The fixed array
    /// </summary>
    internal struct FixedArray5<T> where T : struct
    {
        /// <summary>
        /// The first
        /// </summary>
        public T First;
        /// <summary>
        /// The second
        /// </summary>
        public T Second;
        /// <summary>
        /// The third
        /// </summary>
        public T Third;
        /// <summary>
        /// The fourth
        /// </summary>
        public T Fourth;
        /// <summary>
        /// The fifth
        /// </summary>
        public T Fifth;

        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        /// <param name="first">The first</param>
        /// <param name="second">The second</param>
        /// <param name="third">The third</param>
        /// <param name="fourth">The fourth</param>
        /// <param name="fifth">The fifth</param>
        public FixedArray5(T first, T second, T third, T fourth, T fifth) { First = first; Second = second; Third = third; Fourth = fourth; Fifth = fifth; }

        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public uint Count => 5;
    }

    /// <summary>
    /// The fixed array
    /// </summary>
    internal struct FixedArray6<T> where T : struct
    {
        /// <summary>
        /// The first
        /// </summary>
        public T First;
        /// <summary>
        /// The second
        /// </summary>
        public T Second;
        /// <summary>
        /// The third
        /// </summary>
        public T Third;
        /// <summary>
        /// The fourth
        /// </summary>
        public T Fourth;
        /// <summary>
        /// The fifth
        /// </summary>
        public T Fifth;
        /// <summary>
        /// The sixth
        /// </summary>
        public T Sixth;

        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        /// <param name="first">The first</param>
        /// <param name="second">The second</param>
        /// <param name="third">The third</param>
        /// <param name="fourth">The fourth</param>
        /// <param name="fifth">The fifth</param>
        /// <param name="sixth">The sixth</param>
        public FixedArray6(T first, T second, T third, T fourth, T fifth, T sixth) { First = first; Second = second; Third = third; Fourth = fourth; Fifth = fifth; Sixth = sixth; }

        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public uint Count => 6;
    }
}
