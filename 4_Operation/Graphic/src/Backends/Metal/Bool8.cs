namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The bool
    /// </summary>
    public struct Bool8
    {
        /// <summary>
        /// The value
        /// </summary>
        public readonly byte Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bool8"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public Bool8(byte value)
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bool8"/> class
        /// </summary>
        /// <param name="value">The value</param>
        public Bool8(bool value)
        {
            Value = value ? (byte)1 : (byte)0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static implicit operator bool(Bool8 b) => b.Value != 0;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static implicit operator byte(Bool8 b) => b.Value;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static implicit operator Bool8(bool b) => new Bool8(b);
    }
}