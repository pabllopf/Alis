

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