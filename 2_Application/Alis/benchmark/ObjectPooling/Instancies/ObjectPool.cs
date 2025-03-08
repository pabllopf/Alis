using System.Collections.Generic;

namespace Alis.Benchmark.ObjectPooling.Instancies
{
    /// <summary>
    /// The object pool class
    /// </summary>
    public class ObjectPool<T> where T : new()
    {
        /// <summary>
        /// The 
        /// </summary>
        private Stack<T> pool = new Stack<T>();
    
        /// <summary>
        /// Gets this instance
        /// </summary>
        /// <returns>The</returns>
        public T Get()
        {
            return pool.Count > 0 ? pool.Pop() : new T();
        }
    
        /// <summary>
        /// Returns the obj
        /// </summary>
        /// <param name="obj">The obj</param>
        public void Return(T obj)
        {
            pool.Push(obj);
        }
    }
}