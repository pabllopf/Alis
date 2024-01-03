// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ${File.FileName}
// 
//  Author: Pablo Perdomo Falcón
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


namespace Alis.Core.Aspect.Data.Sample
{
    /// <summary>
    /// The music class
    /// </summary>
    public class Music
    {
       
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the value of the artist
        /// </summary>
        public string Artist { get; set; }

   
        /// <summary>
        /// Gets or sets the value of the genre
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets the value of the album
        /// </summary>
        public string Album { get; set; }

        /// <summary>
        /// Gets or sets the value of the album image
        /// </summary>
        public string AlbumImage { get; set; }


        /// <summary>
        /// Gets or sets the value of the link
        /// </summary>
        public string Link { get; set; }


        /// <summary>
        /// Gets or sets the value of the other
        /// </summary>
        public int Other { get; set; } = 1;

    }
}