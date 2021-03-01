namespace Alis.Core
{
    using System.Diagnostics;

    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public abstract class Component
    {
      

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
