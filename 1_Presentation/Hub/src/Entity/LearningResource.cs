// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LearningResource.cs
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

namespace Alis.App.Hub.Entity
{
    /// <summary>
    ///     The learning resource class
    /// </summary>
    public class LearningResource
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LearningResource" /> class
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="description">The description</param>
        /// <param name="url">The url</param>
        public LearningResource(string title, string description, string url)
        {
            Title = title;
            Description = description;
            Url = url;
        }

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title { get; }

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description { get; }

        /// <summary>
        ///     Gets the value of the url
        /// </summary>
        public string Url { get; }
    }
}