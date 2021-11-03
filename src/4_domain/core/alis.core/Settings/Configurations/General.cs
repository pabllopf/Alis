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

#region

using System;
using System.Text.Json.Serialization;

#endregion

namespace Alis.Core.Settings.Configurations
{
    /// <summary>Define a </summary>
    public class General
    {
        #region Reset()

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset()
        {
            Name = "Alis Game";
            Author = "Pablo Perdomo Falcón";
        }

        #endregion

        #region Fields

        /// <summary>The name</summary>
        private string name = "Alis Game";

        /// <summary>The author</summary>
        private string author = "Pablo Perdomo Falcón";

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="General" /> class
        /// </summary>
        public General()
        {
            OnChangeName += General_OnChangeName;
            OnChangeAuthor += General_OnChangeAuthor;

            Name = name;
            Author = author;
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
        }

        #endregion

        #region Events

        /// <summary>Occurs when [on change name].</summary>
        public event EventHandler<string> OnChangeName;

        /// <summary>Occurs when [on change author].</summary>
        public event EventHandler<string> OnChangeAuthor;

        #endregion

        #region Properties

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [JsonPropertyName("_Name")]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnChangeName.Invoke(this, name);
            }
        }

        /// <summary>Gets or sets the author.</summary>
        /// <value>The author.</value>
        [JsonPropertyName("_Author")]
        public string Author
        {
            get => author;
            set
            {
                author = value;
                OnChangeAuthor.Invoke(this, author);
            }
        }

        #endregion

        #region DefaultEvents

        /// <summary>
        ///     Generals the on change name using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void General_OnChangeName(object? sender, string e)
        {
            Console.WriteLine(e);
        }

        /// <summary>
        ///     Generals the on change author using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void General_OnChangeAuthor(object? sender, string e)
        {
        }

        #endregion
    }
}