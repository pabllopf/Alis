namespace Alis.Editor
{
    public abstract class Widget
    {
        public abstract string GetName();

        public abstract void Open();

        public abstract void Close();

        public abstract void OnLoad();

        public abstract void Draw();
    }
}
