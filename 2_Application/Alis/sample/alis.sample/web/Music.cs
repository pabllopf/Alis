// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Music.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Sample.Web
{
    /// <summary>
    ///     The music
    /// </summary>
    [Serializable, StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Music(
        string name,
        string artist,
        string genre,
        string album,
        bool isFavorite,
        char rating,
        byte trackNumber,
        sbyte discNumber,
        short year,
        ushort week,
        int playCount,
        uint listeners,
        long duration,
        ulong fileSize,
        float tempo,
        double loudness,
        decimal price,
        DateTime releaseDate,
        Guid musicId
    )
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Music" /> class
        /// </summary>
        public Music() : this(
            string.Empty, string.Empty, string.Empty, string.Empty,
            false, '\0', 0, 0, 0, 0, 0, 0, 0L, 0UL, 0f, 0d, 0m, default(DateTime), Guid.Empty)
        {
        }

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        [JsonNativeIgnore]
        public string Name { get; set; } = name;

        /// <summary>
        ///     Gets or sets the value of the artist
        /// </summary>
        [JsonNativePropertyName("Artist_name")]
        public string Artist { get; set; } = artist;

        /// <summary>
        ///     Gets or sets the value of the genre
        /// </summary>
        public string Genre { get; set; } = genre;

        /// <summary>
        ///     Gets or sets the value of the album
        /// </summary>
        public string Album { get; set; } = album;

        /// <summary>
        ///     Gets or sets the value of the is favorite
        /// </summary>
        public bool IsFavorite { get; set; } = isFavorite;

        /// <summary>
        ///     Gets or sets the value of the rating
        /// </summary>
        public char Rating { get; set; } = rating;

        /// <summary>
        ///     Gets or sets the value of the track number
        /// </summary>
        public byte TrackNumber { get; set; } = trackNumber;

        /// <summary>
        ///     Gets or sets the value of the disc number
        /// </summary>
        public sbyte DiscNumber { get; set; } = discNumber;

        /// <summary>
        ///     Gets or sets the value of the year
        /// </summary>
        public short Year { get; set; } = year;

        /// <summary>
        ///     Gets or sets the value of the week
        /// </summary>
        public ushort Week { get; set; } = week;

        /// <summary>
        ///     Gets or sets the value of the play count
        /// </summary>
        public int PlayCount { get; set; } = playCount;

        /// <summary>
        ///     Gets or sets the value of the listeners
        /// </summary>
        public uint Listeners { get; set; } = listeners;

        /// <summary>
        ///     Gets or sets the value of the duration
        /// </summary>
        public long Duration { get; set; } = duration;

        /// <summary>
        ///     Gets or sets the value of the file size
        /// </summary>
        public ulong FileSize { get; set; } = fileSize;

        /// <summary>
        ///     Gets or sets the value of the tempo
        /// </summary>
        public float Tempo { get; set; } = tempo;

        /// <summary>
        ///     Gets or sets the value of the loudness
        /// </summary>
        public double Loudness { get; set; } = loudness;

        /// <summary>
        ///     Gets or sets the value of the price
        /// </summary>
        public decimal Price { get; set; } = price;

        /// <summary>
        ///     Gets or sets the value of the release date
        /// </summary>
        public DateTime ReleaseDate { get; set; } = releaseDate;

        /// <summary>
        ///     Gets or sets the value of the music id
        /// </summary>
        public Guid MusicId { get; set; } = musicId;
    }
}