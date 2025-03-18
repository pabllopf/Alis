using Frent.Collections;
using Frent.Core;

namespace Frent.Updating
{
    /// <summary>
    /// The world update filter class
    /// </summary>
    internal class WorldUpdateFilter
    {
        /// <summary>
        /// The create
        /// </summary>
        internal FastStack<ComponentID> Stack = FastStack<ComponentID>.Create(8);
        /// <summary>
        /// The next component index
        /// </summary>
        internal int NextComponentIndex;
    }
}
