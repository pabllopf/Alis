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
                ReleaseDate = DateTime.Now,
            };
            
            string json = JsonNativeAot.Serialize(musicInfo2);
            Debug.Print(json);
            
            Debug.Print("----------------------------------------");
            
            Music deserialized = JsonNativeAot.Deserialize<Music>(json);
            Debug.Print(deserialized.Name);
            Debug.Print(deserialized.Artist);
            Debug.Print(deserialized.Genre);
            Debug.Print(deserialized.Album);
            Debug.Print(deserialized.IsFavorite.ToString());
            Debug.Print(deserialized.Rating.ToString());
            Debug.Print(deserialized.TrackNumber.ToString());
            Debug.Print(deserialized.DiscNumber.ToString());
            Debug.Print(deserialized.Year.ToString());
            Debug.Print(deserialized.Week.ToString());
            Debug.Print(deserialized.PlayCount.ToString());
            Debug.Print(deserialized.Listeners.ToString());
            Debug.Print(deserialized.Duration.ToString());
            Debug.Print(deserialized.FileSize.ToString());
            Debug.Print(deserialized.Tempo.ToString());
            Debug.Print(deserialized.Loudness.ToString());
            Debug.Print(deserialized.Price.ToString());
            Debug.Print(deserialized.ReleaseDate.ToString());
            Debug.Print(deserialized.MusicId.ToString());
            
            Debug.Print("----------------------------------------");
            
            
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
            
            Debug.Print("Singer Information:");
            string singerJson = JsonNativeAot.Serialize<Singer>(singerInfo);
            Debug.Print(singerJson);
            Debug.Print("----------------------------------------");
            
            Singer deserializedSinger = JsonNativeAot.Deserialize<Singer>(singerJson);
            Debug.Print(deserializedSinger.Name);
            Debug.Print(deserializedSinger.Genre);
            Debug.Print(deserializedSinger.Age.ToString());
            Debug.Print(deserializedSinger.Country);
            Debug.Print(deserializedSinger.IsActive.ToString());
            Debug.Print(deserializedSinger.DebutDate.ToString());
            Debug.Print(deserializedSinger.SingerId.ToString());
            
            Debug.Print("----------------------------------------");
            
        }
    }
}