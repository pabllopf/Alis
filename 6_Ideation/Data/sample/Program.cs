// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using System.Diagnostics;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            Music musicInfo2 = new Music
            {
                Name = "Prince Charming",
                Artist = "Metallica",
                Genre = "Rock and Metal",
                Album = "Reload",
                MusicId = Guid.NewGuid(),
                ReleaseDate = DateTime.Now
            };

            string json = JsonNativeAot.Serialize(musicInfo2);
            Console.WriteLine(json);

            Console.WriteLine("----------------------------------------");

            Music deserialized = JsonNativeAot.Deserialize<Music>(json);
            Console.WriteLine(deserialized.Name);
            Console.WriteLine(deserialized.Artist);
            Console.WriteLine(deserialized.Genre);
            Console.WriteLine(deserialized.Album);
            Console.WriteLine(deserialized.IsFavorite.ToString());
            Console.WriteLine(deserialized.Rating.ToString());
            Console.WriteLine(deserialized.TrackNumber.ToString());
            Console.WriteLine(deserialized.DiscNumber.ToString());
            Console.WriteLine(deserialized.Year.ToString());
            Console.WriteLine(deserialized.Week.ToString());
            Console.WriteLine(deserialized.PlayCount.ToString());
            Console.WriteLine(deserialized.Listeners.ToString());
            Console.WriteLine(deserialized.Duration.ToString());
            Console.WriteLine(deserialized.FileSize.ToString());
            Console.WriteLine(deserialized.Tempo.ToString());
            Console.WriteLine(deserialized.Loudness.ToString());
            Console.WriteLine(deserialized.Price.ToString());
            Console.WriteLine(deserialized.ReleaseDate.ToString());
            Console.WriteLine(deserialized.MusicId.ToString());

            Console.WriteLine("----------------------------------------");


            Singer singerInfo = new Singer
            {
                Name = "Freddie Mercury",
                Genre = "Rock",
                Age = 45,
                Country = "United Kingdom",
                IsActive = false,
                DebutDate = new DateTime(2021, 1, 1),
                SingerId = Guid.NewGuid()
            };

            Console.WriteLine("Singer Information:");
            string singerJson = JsonNativeAot.Serialize(singerInfo);
            Console.WriteLine(singerJson);
            Console.WriteLine("----------------------------------------");

            Singer deserializedSinger = JsonNativeAot.Deserialize<Singer>(singerJson);
            Console.WriteLine(deserializedSinger.Name);
            Console.WriteLine(deserializedSinger.Genre);
            Console.WriteLine(deserializedSinger.Age.ToString());
            Console.WriteLine(deserializedSinger.Country);
            Console.WriteLine(deserializedSinger.IsActive.ToString());
            Console.WriteLine(deserializedSinger.DebutDate.ToString());
            Console.WriteLine(deserializedSinger.SingerId.ToString());

            Console.WriteLine("----------------------------------------");
        }
    }
}