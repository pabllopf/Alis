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
        /// <summary>Starts the specified transform.</summary>
        /// <param name="gameObject"></param>
        void Start(GameObject gameObject);

        /// <summary>Updates the specified transform.</summary>
        /// <param name="gameObject"></param>
        void Update(GameObject gameObject);
    }
}