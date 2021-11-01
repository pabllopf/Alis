namespace Alis.Core.Settings.Configurations
{
    public class GameObject
    {
        public int MaxComponents { get; set; } = 64;

        public bool HasDuplicateComponents { get; set; }

        public void Reset()
        {
            MaxComponents = 64;
            HasDuplicateComponents = false;
        }
    }
}