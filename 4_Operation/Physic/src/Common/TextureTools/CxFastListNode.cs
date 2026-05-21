

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
        internal readonly T Elt;

        /// <summary>
        ///     The next
        /// </summary>
        internal CxFastListNode<T> Next;

        /// <summary>
        ///     Initializes a new instance of the class
        /// </summary>
        /// <param name="obj">The obj</param>
        public CxFastListNode(T obj) => Elt = obj;

        /// <summary>
        ///     Elems this instance
        /// </summary>
        /// <returns>The</returns>
        public T GetElem() => Elt;

        /// <summary>
        ///     Nexts this instance
        /// </summary>
        /// <returns>A cx fast list node of t</returns>
        public CxFastListNode<T> NextPos() => Next;
    }
}