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
            
            Console.WriteLine("Music Information:");
            
            string json = musicInfo2.ToJson();
            Console.WriteLine(json);
            
            Console.WriteLine("----------------------------------------");
            
            Music deserialized = Music.FromJson(json);
            Console.WriteLine(deserialized.Name);
            Console.WriteLine(deserialized.Artist);
            Console.WriteLine(deserialized.Genre);
            Console.WriteLine(deserialized.Album);
            Console.WriteLine(deserialized.IsFavorite);
            Console.WriteLine(deserialized.Rating);
            Console.WriteLine(deserialized.TrackNumber);
            Console.WriteLine(deserialized.DiscNumber);
            Console.WriteLine(deserialized.Year);
            Console.WriteLine(deserialized.Week);
            Console.WriteLine(deserialized.PlayCount);
            Console.WriteLine(deserialized.Listeners);
            Console.WriteLine(deserialized.Duration);
            Console.WriteLine(deserialized.FileSize);
            Console.WriteLine(deserialized.Tempo);
            Console.WriteLine(deserialized.Loudness);
            Console.WriteLine(deserialized.Price);
            Console.WriteLine(deserialized.ReleaseDate);
            Console.WriteLine(deserialized.MusicId);
            
            Console.WriteLine("----------------------------------------");
        }
    }
}