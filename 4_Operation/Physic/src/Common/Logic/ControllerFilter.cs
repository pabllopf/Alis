

namespace Alis.Core.Physic.Common.Logic
{
    /// <summary>
    ///     The controller filter
    /// </summary>
    public struct ControllerFilter
    {
        /// <summary>
        ///     The controller categories
        /// </summary>
        public ControllerCategory ControllerCategories;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ControllerFilter" /> class
        /// </summary>
        /// <param name="controllerCategory">The controller category</param>
        public ControllerFilter(ControllerCategory controllerCategory) => ControllerCategories = controllerCategory;

        /// <summary>
        ///     Ignores the controller. The controller has no effect on this body.
        /// </summary>
        /// <param name="category"></param>
        public void IgnoreController(ControllerCategory category)
        {
            ControllerCategories &= ~category;
        }

        /// <summary>
        ///     Restore the controller. The controller affects this body.
        /// </summary>
        /// <param name="category">The logic type.</param>
        public void RestoreController(ControllerCategory category)
        {
            ControllerCategories |= category;
        }

        /// <summary>
        ///     Determines whether this body ignores the the specified controller.
        /// </summary>
        /// <param name="category">The logic type.</param>
        /// <returns>
        ///     <c>true</c> if the body has the specified flag; otherwise, <c>false</c>.
        /// </returns>
        public bool IsControllerIgnored(ControllerCategory category) => (ControllerCategories & category) != category;
    }
}