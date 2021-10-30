namespace Alis.FluentApi
{
    public class Static 
    {
        private bool value;

        public Static() => value = false;

        public Static(bool value) => this.value = value;

        public bool Value { get => value; set => this.value = value; }
    }
}