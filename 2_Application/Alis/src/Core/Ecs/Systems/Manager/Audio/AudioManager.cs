

using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Systems.Manager.Audio
{
    /// <summary>
    ///     The audio manager base class
    /// </summary>
    /// <seealso cref="AManager" />
    public class AudioManager : AManager
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public AudioManager(Context context) : base(context)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioManager" /> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        /// <param name="tag">The tag</param>
        /// <param name="isEnable">The is enable</param>
        /// <param name="context">The context</param>
        public AudioManager(string id, string name, string tag, bool isEnable, Context context) : base(id, name, tag, isEnable, context)
        {
        }
    }
}