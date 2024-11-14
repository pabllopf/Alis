namespace Alis.App.Engine.Hub
{
    public class LearningResource
    {
        public string Title { get; }
        public string Description { get; }
        public string Url { get; }

        public LearningResource(string title, string description, string url)
        {
            Title = title;
            Description = description;
            Url = url;
        }
    }
}