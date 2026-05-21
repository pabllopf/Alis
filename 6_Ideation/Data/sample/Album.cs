

using System;
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Sample
{
    /// <summary>
    ///     Represents a music album with tracks and metadata.
    /// </summary>
    /// <remarks>
    ///     This sample demonstrates serialization of complex types including
    ///     nested collections and custom objects.
    /// </remarks>
    [Serializable]
    public partial class Album : IJsonSerializable, IJsonDesSerializable<Album>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Album" /> class.
        /// </summary>
        public Album()
        {
            AlbumId = Guid.NewGuid();
            ReleaseDate = DateTime.Now;
            Genres = new List<string>();
        }

        /// <summary>
        ///     Gets or sets the unique identifier of the album.
        /// </summary>
        public Guid AlbumId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the album.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the release date of the album.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        ///     Gets or sets the total number of tracks in the album.
        /// </summary>
        public int TrackCount { get; set; }

        /// <summary>
        ///     Gets or sets the duration of the album in seconds.
        /// </summary>
        public int DurationSeconds { get; set; }

        /// <summary>
        ///     Gets or sets the list of genres for this album.
        /// </summary>
        public List<string> Genres { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the album is available.
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        ///     Gets the serializable properties of this album.
        /// </summary>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return ("AlbumId", AlbumId.ToString());
            yield return ("Name", Name);
            yield return ("ReleaseDate", ReleaseDate.ToString("O"));
            yield return ("TrackCount", TrackCount.ToString());
            yield return ("DurationSeconds", DurationSeconds.ToString());
            yield return ("Genres", SerializeGenres());
            yield return ("IsAvailable", IsAvailable.ToString());
        }

        /// <summary>
        ///     Creates an album instance from a property dictionary.
        /// </summary>
        public Album CreateFromProperties(Dictionary<string, string> properties)
        {
            Album album = new Album();

            if (properties.TryGetValue("AlbumId", out string albumId) &&
                Guid.TryParse(albumId, out Guid albumIdValue))
            {
                album.AlbumId = albumIdValue;
            }

            if (properties.TryGetValue("Name", out string name))
            {
                album.Name = name;
            }

            if (properties.TryGetValue("ReleaseDate", out string releaseDate) &&
                DateTime.TryParse(releaseDate, out DateTime releaseDateValue))
            {
                album.ReleaseDate = releaseDateValue;
            }

            if (properties.TryGetValue("TrackCount", out string trackCount) &&
                int.TryParse(trackCount, out int trackCountValue))
            {
                album.TrackCount = trackCountValue;
            }

            if (properties.TryGetValue("DurationSeconds", out string duration) &&
                int.TryParse(duration, out int durationValue))
            {
                album.DurationSeconds = durationValue;
            }

            if (properties.TryGetValue("Genres", out string genres))
            {
                album.Genres = DeserializeGenres(genres);
            }

            if (properties.TryGetValue("IsAvailable", out string available) &&
                bool.TryParse(available, out bool availableValue))
            {
                album.IsAvailable = availableValue;
            }

            return album;
        }

        /// <summary>
        ///     Serializes the genres list to JSON array format.
        /// </summary>
        private string SerializeGenres()
        {
            if (Genres == null || Genres.Count == 0)
            {
                return "[]";
            }

            string items = string.Join(",", Genres.Select(g => $"\"{g}\""));
            return $"[{items}]";
        }

        /// <summary>
        ///     Deserializes genres from JSON array format.
        /// </summary>
        private static List<string> DeserializeGenres(string json)
        {
            List<string> genres = new List<string>();
            if (string.IsNullOrEmpty(json) || json == "[]")
            {
                return genres;
            }

            string[] items = json.Trim('[', ']').Split(',');
            foreach (string item in items)
            {
                string genre = item.Trim().Trim('"');
                if (!string.IsNullOrEmpty(genre))
                {
                    genres.Add(genre);
                }
            }

            return genres;
        }
    }
}