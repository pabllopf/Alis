// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Program.cs
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
    ///     Sample program demonstrating all features of the Alis.Core.Aspect.Data module.
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main entry point demonstrating various serialization scenarios.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Alis.Core.Aspect.Data Module - Comprehensive Samples ===\n");

            Example1_SimpleSingerSerialization();
            Example2_SingerDeserialization();
            Example3_AlbumWithCollections();
            Example4_PlaylistRoundTrip();
            Example5_FileOperations();
            Example6_JsonParsing();
            Example7_ErrorHandling();
            Example8_ComplexNesting();
            Example9_MusicSerialization();
            Example10_TypeConversion();

            Console.WriteLine("\n=== All Examples Completed Successfully ===");
        }

        /// <summary>
        ///     Example 1: Simple object serialization.
        /// </summary>
        private static void Example1_SimpleSingerSerialization()
        {
            Console.WriteLine("Example 1: Simple Singer Serialization");
            Console.WriteLine("---------------------------------------");
            
            var singer = new Singer(
                name: "Taylor Swift",
                genre: "Pop",
                age: 34,
                country: "USA",
                isActive: true,
                debutDate: new DateTime(2006, 6, 19),
                singerId: Guid.NewGuid()
            );

            string json = JsonNativeAot.Serialize(singer);
            Console.WriteLine($"JSON: {json}\n");
        }

        /// <summary>
        ///     Example 2: Deserialization with automatic type conversion.
        /// </summary>
        private static void Example2_SingerDeserialization()
        {
            Console.WriteLine("Example 2: Singer Deserialization");
            Console.WriteLine("----------------------------------");
            
            string json = "{\"Name\":\"Billie Eilish\",\"Genre\":\"Alternative\",\"Age\":\"22\"," +
                         "\"Country\":\"USA\",\"IsActive\":\"true\",\"DebutDate\":\"2016-01-01\"," +
                         "\"SingerId\":\"a1b2c3d4-e5f6-4g7h-8i9j-0k1l2m3n4o5p\"}";

            var singer = JsonNativeAot.Deserialize<Singer>(json);
            Console.WriteLine($"Name: {singer.Name}, Age: {singer.Age}, Active: {singer.IsActive}\n");
        }

        /// <summary>
        ///     Example 3: Complex type with collections.
        /// </summary>
        private static void Example3_AlbumWithCollections()
        {
            Console.WriteLine("Example 3: Album Serialization (Complex Type)");
            Console.WriteLine("----------------------------------------------");
            
            var album = new Album
            {
                AlbumId = Guid.NewGuid(),
                Name = "Midnights",
                ReleaseDate = new DateTime(2022, 10, 21),
                TrackCount = 13,
                DurationSeconds = 2700,
                Genres = new List<string> { "Pop", "Synth-pop", "Alternative" },
                IsAvailable = true
            };

            string json = JsonNativeAot.Serialize(album);
            Console.WriteLine($"JSON: {json}\n");
        }

        /// <summary>
        ///     Example 4: Round-trip serialization and deserialization.
        /// </summary>
        private static void Example4_PlaylistRoundTrip()
        {
            Console.WriteLine("Example 4: Playlist Round-Trip");
            Console.WriteLine("-------------------------------");
            
            var playlist = new Playlist
            {
                PlaylistId = Guid.NewGuid(),
                PlaylistName = "My Favorites",
                CreatorName = "Music Lover",
                CreatedDate = DateTime.Now,
                SongTitles = new List<string> { "Song A", "Song B", "Song C" },
                SongCount = 3,
                IsPublic = true
            };

            string json = JsonNativeAot.Serialize(playlist);
            var restored = JsonNativeAot.Deserialize<Playlist>(json);
            
            Console.WriteLine($"Original ID: {playlist.PlaylistId}");
            Console.WriteLine($"Restored ID: {restored.PlaylistId}");
            Console.WriteLine($"IDs Match: {playlist.PlaylistId == restored.PlaylistId}\n");
        }

        /// <summary>
        ///     Example 5: File serialization and deserialization.
        /// </summary>
        private static void Example5_FileOperations()
        {
            Console.WriteLine("Example 5: File Operations");
            Console.WriteLine("--------------------------");
            
            try
            {
                var singer = new Singer(
                    name: "File Test Singer",
                    genre: "Rock",
                    age: 45,
                    country: "UK",
                    isActive: true,
                    debutDate: DateTime.Now.AddYears(-20),
                    singerId: Guid.NewGuid()
                );

                JsonNativeAot.SerializeToFile(singer, "test_singer", "Config");
                Console.WriteLine("✓ Saved to Config/test_singer.json");

                var loaded = JsonNativeAot.DeserializeFromFile<Singer>("test_singer", "Config");
                Console.WriteLine($"✓ Loaded: {loaded.Name} from {loaded.Country}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n");
            }
        }

        /// <summary>
        ///     Example 6: Low-level JSON parsing to dictionary.
        /// </summary>
        private static void Example6_JsonParsing()
        {
            Console.WriteLine("Example 6: JSON Parsing");
            Console.WriteLine("----------------------");
            
            string json = "{\"Name\":\"Test\",\"Age\":\"30\",\"Tags\":[\"tag1\",\"tag2\"]}";
            var props = JsonNativeAot.ParseJsonToDictionary(json);
            
            foreach (var prop in props)
            {
                Console.WriteLine($"  {prop.Key} = {prop.Value}");
            }
            Console.WriteLine();
        }

        /// <summary>
        ///     Example 7: Error handling scenarios.
        /// </summary>
        private static void Example7_ErrorHandling()
        {
            Console.WriteLine("Example 7: Error Handling");
            Console.WriteLine("-------------------------");
            
            // Null handling
            try
            {
                JsonNativeAot.ParseJsonToDictionary(null);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("✓ Caught ArgumentNullException for null JSON");
            }

            // Malformed JSON
            try
            {
                JsonNativeAot.ParseJsonToDictionary("{invalid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✓ Caught {ex.GetType().Name} for malformed JSON");
            }

            Console.WriteLine();
        }

        /// <summary>
        ///     Example 8: Nested complex objects.
        /// </summary>
        private static void Example8_ComplexNesting()
        {
            Console.WriteLine("Example 8: Complex Nesting");
            Console.WriteLine("--------------------------");
            
            var album = new Album
            {
                Name = "Complex Album",
                Genres = new List<string> { "Rock", "Pop", "Electronic", "Jazz" },
                IsAvailable = true
            };

            string json = JsonNativeAot.Serialize(album);
            var restored = JsonNativeAot.Deserialize<Album>(json);
            
            Console.WriteLine($"Genres: {string.Join(", ", restored.Genres)}");
            Console.WriteLine($"Available: {restored.IsAvailable}\n");
        }

        /// <summary>
        ///     Example 9: Music serialization using existing Music class.
        /// </summary>
        private static void Example9_MusicSerialization()
        {
            Console.WriteLine("Example 9: Music Serialization");
            Console.WriteLine("-------------------------------");
            
            var music = new Music
            {
                Name = "Bohemian Rhapsody",
                Artist = "Queen",
                Genre = "Rock",
                Album = "A Night at the Opera",
                MusicId = Guid.NewGuid(),
                ReleaseDate = new DateTime(1975, 10, 31)
            };

            string json = JsonNativeAot.Serialize(music);
            var deserialized = JsonNativeAot.Deserialize<Music>(json);
            
            Console.WriteLine($"Artist: {deserialized.Artist}");
            Console.WriteLine($"Album: {deserialized.Album}\n");
        }

        /// <summary>
        ///     Example 10: Type conversion demonstration.
        /// </summary>
        private static void Example10_TypeConversion()
        {
            Console.WriteLine("Example 10: Type Conversion");
            Console.WriteLine("---------------------------");
            
            // JSON with string values
            string json = "{\"Age\":\"42\",\"IsActive\":\"true\",\"SingerId\":\"" + Guid.NewGuid() + "\"}";
            
            var props = JsonNativeAot.ParseJsonToDictionary(json);
            
            if (props.TryGetValue("Age", out var ageStr) && int.TryParse(ageStr, out var age))
                Console.WriteLine($"✓ Age converted: {ageStr} -> {age} (int)");
            
            if (props.TryGetValue("IsActive", out var activeStr) && bool.TryParse(activeStr, out var active))
                Console.WriteLine($"✓ IsActive converted: {activeStr} -> {active} (bool)");
            
            if (props.TryGetValue("SingerId", out var idStr) && Guid.TryParse(idStr, out var id))
                Console.WriteLine($"✓ SingerId converted: {idStr.Substring(0, 8)}... -> Guid\n");
        }
    }
}