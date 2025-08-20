using System;
        using System.Runtime.InteropServices;
        using Alis.Core.Aspect.Data.Json;


        namespace Alis.Core.Aspect.Data.Sample
        {
            /// <summary>
            /// The music
            /// </summary>
            [Serializable]
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
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
                /// Initializes a new instance of the <see cref="Music"/> class
                /// </summary>
                public Music() : this(
                    string.Empty, string.Empty, string.Empty, string.Empty,
                    false, '\0', 0, 0, 0, 0, 0, 0, 0L, 0UL, 0f, 0d, 0m, default, Guid.Empty)
                {
                }
        
                /// <summary>
                /// Gets or sets the value of the name
                /// </summary>
                [JsonNativeIgnore]
                public string Name { get; set; } = name;
                
                /// <summary>
                /// Gets or sets the value of the artist
                /// </summary>
                [JsonNativePropertyName("Artist_name")]
                public string Artist { get; set; } = artist;
                /// <summary>
                /// Gets or sets the value of the genre
                /// </summary>
                public string Genre { get; set; } = genre;
                /// <summary>
                /// Gets or sets the value of the album
                /// </summary>
                public string Album { get; set; } = album;
                /// <summary>
                /// Gets or sets the value of the is favorite
                /// </summary>
                public bool IsFavorite { get; set; } = isFavorite;
                /// <summary>
                /// Gets or sets the value of the rating
                /// </summary>
                public char Rating { get; set; } = rating;
                /// <summary>
                /// Gets or sets the value of the track number
                /// </summary>
                public byte TrackNumber { get; set; } = trackNumber;
                /// <summary>
                /// Gets or sets the value of the disc number
                /// </summary>
                public sbyte DiscNumber { get; set; } = discNumber;
                /// <summary>
                /// Gets or sets the value of the year
                /// </summary>
                public short Year { get; set; } = year;
                /// <summary>
                /// Gets or sets the value of the week
                /// </summary>
                public ushort Week { get; set; } = week;
                /// <summary>
                /// Gets or sets the value of the play count
                /// </summary>
                public int PlayCount { get; set; } = playCount;
                /// <summary>
                /// Gets or sets the value of the listeners
                /// </summary>
                public uint Listeners { get; set; } = listeners;
                /// <summary>
                /// Gets or sets the value of the duration
                /// </summary>
                public long Duration { get; set; } = duration;
                /// <summary>
                /// Gets or sets the value of the file size
                /// </summary>
                public ulong FileSize { get; set; } = fileSize;
                /// <summary>
                /// Gets or sets the value of the tempo
                /// </summary>
                public float Tempo { get; set; } = tempo;
                /// <summary>
                /// Gets or sets the value of the loudness
                /// </summary>
                public double Loudness { get; set; } = loudness;
                /// <summary>
                /// Gets or sets the value of the price
                /// </summary>
                public decimal Price { get; set; } = price;
                /// <summary>
                /// Gets or sets the value of the release date
                /// </summary>
                public DateTime ReleaseDate { get; set; } = releaseDate;
                /// <summary>
                /// Gets or sets the value of the music id
                /// </summary>
                public Guid MusicId { get; set; } = musicId;
            }
        }