namespace Alis.Core.Ecs.Core
{
    /// <summary>
    ///     Used only in source generation
    /// </summary>
    public static class ComponentDelegates<T>
    {
        /// <summary>
        ///     Used only in source generation
        /// </summary>
        public delegate void DestroyDelegate(ref T component);

        /// <summary>
        ///     Used only in source generation
        /// </summary>
        public delegate void InitDelegate(GameObject gameObject, ref T component);
    }
}