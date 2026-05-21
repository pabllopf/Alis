

using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Systems.Manager.Network
{
    /// <summary>
    ///     The network manager class
    /// </summary>
    /// <seealso cref="AManager" />
    public class NetworkManager : AManager
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NetworkManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public NetworkManager(Context context) : base(context)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NetworkManager" /> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        /// <param name="tag">The tag</param>
        /// <param name="isEnable">The is enable</param>
        /// <param name="context">The context</param>
        public NetworkManager(string id, string name, string tag, bool isEnable, Context context) : base(id, name, tag, isEnable, context)
        {
        }
    }
}