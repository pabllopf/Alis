namespace Alis.Core.Settings.Configurations
{
    public class Graphic
    {
        public int MaxElementsRender { get; set; } = 128;

        public void Reset() 
        {
            MaxElementsRender = 128;
        }
    }
}
