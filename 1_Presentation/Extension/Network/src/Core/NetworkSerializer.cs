

using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Network serializer implementation using ALIS Data
    /// </summary>
    public sealed class NetworkSerializer : INetworkSerializer
    {
        /// <summary>
        ///     Serializes object to JSON string
        /// </summary>
        public string Serialize<T>(T obj) where T : IJsonSerializable => JsonNativeAot.Serialize(obj);

        /// <summary>
        ///     Deserializes JSON string to object
        /// </summary>
        public T Deserialize<T>(string json) where T : IJsonSerializable, IJsonDesSerializable<T>, new() => JsonNativeAot.Deserialize<T>(json);

        /// <summary>
        ///     Serializes envelope
        /// </summary>
        public string SerializeEnvelope(NetworkMessageEnvelope envelope) => Serialize(envelope);

        /// <summary>
        ///     Deserializes envelope
        /// </summary>
        public NetworkMessageEnvelope DeserializeEnvelope(string json) => Deserialize<NetworkMessageEnvelope>(json);
    }
}