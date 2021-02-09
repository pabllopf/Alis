//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="IComponent.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using Newtonsoft.Json;

    /// <summary>Define components.</summary>
    [JsonObject(MemberSerialization.OptIn)]
    public interface IComponent
    {
        /// <summary>Starts this instance.</summary>
        void Start();

        /// <summary>Starts the specified transform.</summary>
        /// <param name="transform">The transform.</param>
        void Start(ref Transform transform);

        /// <summary>Updates this instance.</summary>
        void Update();

        /// <summary>Updates the specified transform.</summary>
        /// <param name="transform">The transform.</param>
        void Update(ref Transform transform);
    }
}