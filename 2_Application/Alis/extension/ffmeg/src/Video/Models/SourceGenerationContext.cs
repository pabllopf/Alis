using System.Text.Json.Serialization;
using Alis.Extension.FFMeg.Audio.Models;

namespace Alis.Extension.FFMeg.Video.Models
{
    /// <summary>
    /// The source generation context class
    /// </summary>
    /// <seealso cref="JsonSerializerContext"/>
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(VideoMetadata))]
    [JsonSerializable(typeof(AudioMetadata))]
    internal partial class SourceGenerationContext : JsonSerializerContext 
    {
    }
}