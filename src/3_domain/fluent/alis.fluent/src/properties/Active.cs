namespace Alis.Fluent
{
    public class Active 
    {
        private bool value;

        public Active() => value = true;

        public Active(bool value) => this.value = value;

        public bool Value { get => value; set => this.value = value; }
    }
}