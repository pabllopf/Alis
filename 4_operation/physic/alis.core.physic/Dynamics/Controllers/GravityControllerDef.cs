namespace Alis.Core.Physic.Dynamics.Controllers
{
    /// This class is used to build gravity controllers
    public class GravityControllerDef
    {
        /// <summary>
        /// Specifies the strength of the gravitiation force
        /// </summary>
        public float G;

        /// <summary>
        /// If true, gravity is proportional to r^-2, otherwise r^-1
        /// </summary>
        public bool InvSqr;
    }
}