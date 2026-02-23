// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Playlist.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Sample
{
    /// <summary>
    ///     Represents a music playlist with multiple songs.
    /// </summary>
    [Serializable]
    public partial class Playlist : IJsonSerializable, IJsonDesSerializable<Playlist>
    {
        /// <summary>
        ///     Gets or sets the unique identifier of the playlist.
        /// </summary>
        public Guid PlaylistId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the playlist.
        /// </summary>
        public string PlaylistName { get; set; }

        /// <summary>
        ///     Gets or sets the creator's name.
        /// </summary>
        public string CreatorName { get; set; }

        /// <summary>
        ///     Gets or sets the creation date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        ///     Gets or sets the list of song titles.
        /// </summary>
        public List<string> SongTitles { get; set; }

        /// <summary>
        ///     Gets or sets the total number of songs.
        /// </summary>
        public int SongCount { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the playlist is public.
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Playlist" /> class.
        /// </summary>
        public Playlist()
        {
            PlaylistId = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            SongTitles = new List<string>();
        }

        /// <summary>
        ///     Gets the serializable properties of this playlist.
        /// </summary>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return ("PlaylistId", PlaylistId.ToString());
            yield return ("PlaylistName", PlaylistName);
            yield return ("CreatorName", CreatorName);
            yield return ("CreatedDate", CreatedDate.ToString("O"));
            yield return ("SongTitles", SerializeSongs());
            yield return ("SongCount", SongCount.ToString());
            yield return ("IsPublic", IsPublic.ToString());
        }

        /// <summary>
        ///     Creates a playlist instance from a property dictionary.
        /// </summary>
        public Playlist CreateFromProperties(Dictionary<string, string> properties)
        {
            var playlist = new Playlist();

            if (properties.TryGetValue("PlaylistId", out var playlistId) && 
                Guid.TryParse(playlistId, out var playlistIdValue))
                playlist.PlaylistId = playlistIdValue;

            if (properties.TryGetValue("PlaylistName", out var name))
                playlist.PlaylistName = name;

            if (properties.TryGetValue("CreatorName", out var creator))
                playlist.CreatorName = creator;

            if (properties.TryGetValue("CreatedDate", out var created) && 
                DateTime.TryParse(created, out var createdValue))
                playlist.CreatedDate = createdValue;

            if (properties.TryGetValue("SongTitles", out var songs))
                playlist.SongTitles = DeserializeSongs(songs);

            if (properties.TryGetValue("SongCount", out var count) && 
                int.TryParse(count, out var countValue))
                playlist.SongCount = countValue;

            if (properties.TryGetValue("IsPublic", out var isPublic) && 
                bool.TryParse(isPublic, out var isPublicValue))
                playlist.IsPublic = isPublicValue;

            return playlist;
        }

        /// <summary>
        ///     Serializes songs to JSON array format.
        /// </summary>
        private string SerializeSongs()
        {
            if (SongTitles == null || SongTitles.Count == 0)
                return "[]";

            var items = string.Join(",", SongTitles.Select(s => $"\"{s}\""));
            return $"[{items}]";
        }

        /// <summary>
        ///     Deserializes songs from JSON array format.
        /// </summary>
        private static List<string> DeserializeSongs(string json)
        {
            var songs = new List<string>();
            if (string.IsNullOrEmpty(json) || json == "[]")
                return songs;

            var items = json.Trim('[', ']').Split(',');
            foreach (var item in items)
            {
                var song = item.Trim().Trim('"');
                if (!string.IsNullOrEmpty(song))
                    songs.Add(song);
            }

            return songs;
        }
    }
}

