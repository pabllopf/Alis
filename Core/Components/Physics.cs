namespace Alis.Core
{
    using Alis.Tools;
    using System.Diagnostics;
    public class Physics : Component
    {
        public Physics() 
        {
        
        }

        public override void Start()
        {

        }

        public override void Update()
        {
            Logger.Log("Update Physics " + this.GetHashCode());
        }
    }
}
