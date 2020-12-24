//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Engine.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor
{
    using System.Reflection;
    using System.Threading;

    /// <summary>Manage the engine</summary>
    internal class Engine
    {
        /// <summary>The arguments</summary>
        private string[] args;

        /// <summary>Initializes a new instance of the <see cref="Engine" /> class.</summary>
        /// <param name="args">The arguments.</param>
        public Engine(string[] args)
        {
            this.args = args;
        }

        /// <summary>Gets a value indicating whether [first instance].</summary>
        /// <value>
        /// <c>true</c> if [first instance]; otherwise, <c>false</c>.</value>
        private static bool FirstInstance
        {
            get
            {
                _ = new Mutex(true, Assembly.GetEntryAssembly().FullName, out bool created);
                return created;
            }
        }

        /// <summary>Starts this instance.</summary>
        /// <returns>Return 0 or -1 to indicate the exit value</returns>
        public int Start()
        {
            if (!FirstInstance)
            {
                return -1;
            }
            
            
            return 0;
        }
    }
}
