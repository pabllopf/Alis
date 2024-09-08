namespace Alis.Core.Physic.Common.TextureTools
{
    /// <summary>
    ///     The cx fast list node class
    /// </summary>
    internal class CxFastListNode<T>
    {
        /// <summary>
        ///     The elt
        /// </summary>
        internal T _elt;

        /// <summary>
        ///     The next
        /// </summary>
        internal CxFastListNode<T> _next;

        /// <summary>
        ///     Initializes a new instance of the class
        /// </summary>
        /// <param name="obj">The obj</param>
        public CxFastListNode(T obj) => _elt = obj;

        /// <summary>
        ///     Elems this instance
        /// </summary>
        /// <returns>The</returns>
        public T Elem() => _elt;

        /// <summary>
        ///     Nexts this instance
        /// </summary>
        /// <returns>A cx fast list node of t</returns>
        public CxFastListNode<T> Next() => _next;
    }
}