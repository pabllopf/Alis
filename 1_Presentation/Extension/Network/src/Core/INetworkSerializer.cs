

using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Network serializer using ALIS Data JSON
    /// </summary>
    public interface INetworkSerializer
    {
        /// <summary>
        ///     Serializes object to JSON string
        /// </summary>
        string Serialize<T>(T obj) where T : IJsonSerializable;

        /// <summary>
        ///     Deserializes JSON string to object
        /// </summary>
        T Deserialize<T>(string json) where T : IJsonSerializable, IJsonDesSerializable<T>, new();

        /// <summary>
        ///     Serializes envelope
        /// </summary>
        string SerializeEnvelope(NetworkMessageEnvelope envelope);

        /// <summary>
        ///     Deserializes envelope
        /// </summary>
        NetworkMessageEnvelope DeserializeEnvelope(string json);
    }
}