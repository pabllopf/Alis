namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    /// The contact register
    /// </summary>
    public struct ContactRegister
    {
        /// <summary>
        /// The create fcn
        /// </summary>
        public ContactCreateFcn CreateFcn;
        /// <summary>
        /// The destroy fcn
        /// </summary>
        public ContactDestroyFcn DestroyFcn;
        /// <summary>
        /// The primary
        /// </summary>
        public bool Primary;
    }
}