using System;
using System.Text.Json.Serialization;

namespace Alis.Core.Settings.Configurations
{
    /// <summary>Define a </summary>
    public class General
    {
        #region Reset()

        /// <summary>
        /// Resets this instance
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
        /// Initializes a new instance of the <see cref="General"/> class
        /// </summary>
        public General()
        {
            OnChangeName += General_OnChangeName;
            OnChangeAuthor += General_OnChangeAuthor;

            Name = name;
            Author = author;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="General"/> class
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
                OnChangeName?.Invoke(this, name);
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
                OnChangeAuthor?.Invoke(this, author);
            }
        }

        #endregion

        #region DefaultEvents

        /// <summary>
        /// Generals the on change name using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="name">The name</param>
        private void General_OnChangeName(object? sender, string name)
        {
        }

        /// <summary>
        /// Generals the on change author using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void General_OnChangeAuthor(object? sender, string e)
        {
        }

        #endregion
    }
}