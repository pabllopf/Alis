using System;
        using System.Runtime.InteropServices;
        
        namespace Alis.Core.Aspect.Data.Sample
        {
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
                public Music() : this(
                    string.Empty, string.Empty, string.Empty, string.Empty,
                    false, '\0', 0, 0, 0, 0, 0, 0, 0L, 0UL, 0f, 0d, 0m, default, Guid.Empty)
                {
                }
        
                public string Name { get; set; } = name;
                public string Artist { get; set; } = artist;
                public string Genre { get; set; } = genre;
                public string Album { get; set; } = album;
                public bool IsFavorite { get; set; } = isFavorite;
                public char Rating { get; set; } = rating;
                public byte TrackNumber { get; set; } = trackNumber;
                public sbyte DiscNumber { get; set; } = discNumber;
                public short Year { get; set; } = year;
                public ushort Week { get; set; } = week;
                public int PlayCount { get; set; } = playCount;
                public uint Listeners { get; set; } = listeners;
                public long Duration { get; set; } = duration;
                public ulong FileSize { get; set; } = fileSize;
                public float Tempo { get; set; } = tempo;
                public double Loudness { get; set; } = loudness;
                public decimal Price { get; set; } = price;
                public DateTime ReleaseDate { get; set; } = releaseDate;
                public Guid MusicId { get; set; } = musicId;
            }
        }