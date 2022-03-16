// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   General.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
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
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Text.Json.Serialization;
using Alis.Tools;

namespace Alis.Core.Settings.Configurations
{
    /// <summary>Define a </summary>
    public class General
    {
        /// <summary>The author</summary>
        private string author = "Pablo Perdomo Falcón";

        /// <summary>The name</summary>
        private string name = "Alis Game";

        /// <summary>
        /// The description
        /// </summary>
        private string description = "Develop the video games with Alis";

        

        /// <summary>
        ///     Initializes a new instance of the <see cref="General" /> class
        /// </summary>
        public General()
        {
            OnChangeName += General_OnChangeName;
            OnChangeAuthor += General_OnChangeAuthor;

            Name = name;
            Author = author;

            Logger.Trace();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="General" /> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="author">The author</param>
        [JsonConstructor]
        public General(string name, string author)
        {
            OnChangeName += General_OnChangeName;
            OnChangeAuthor += General_OnChangeAuthor;

            Name = name;
            Author = author;

            Logger.Trace(name, author);
        }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [JsonPropertyName("_Name")]
        public string Name
        {
            get
            {
                Logger.Trace($"General.Name '{name}'");
                return name;
            }
            set
            {
                Logger.Trace($"General.Name from '{name}' to '{value}'");
                name = value;
                OnChangeName.Invoke(this, name);
            }
        }

        /// <summary>
        /// Gets or sets the value of the description
        /// </summary>
        [JsonPropertyName("_Description")]
        public string Description
        {
            get
            {
                Logger.Trace($"General.Description '{description}'");
                return description;
            }
            set
            {
                Logger.Trace($"General.Description from '{description}' to '{value}'");
                description = value;
            }
        }

        /// <summary>Gets or sets the author.</summary>
        /// <value>The author.</value>
        [JsonPropertyName("_Author")]
        public string Author
        {
            get
            {
                Logger.Trace($"General.Author '{author}'");
                return author;
            }
            set
            {
                Logger.Trace($"General.Author from '{author}' to '{value}'");
                author = value;
                OnChangeAuthor.Invoke(this, author);
            }
        }

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset()
        {
            Name = "Alis Game";
            Author = "Pablo Perdomo Falcón";
            Logger.Trace();
        }


        /// <summary>Occurs when [on change name].</summary>
        public event EventHandler<string> OnChangeName;

        /// <summary>Occurs when [on change author].</summary>
        public event EventHandler<string> OnChangeAuthor;


        /// <summary>
        ///     Generals the on change name using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void General_OnChangeName(object? sender, string e)
        {
            Logger.Trace(e);
        }

        /// <summary>
        ///     Generals the on change author using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void General_OnChangeAuthor(object? sender, string e)
        {
            Logger.Trace(e);
        }
    }
}