

using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.Logic
{
    /// <summary>
    ///     Contains filter data that can determine whether an object should be processed or not.
    /// </summary>
    public abstract class FilterData
    {
        /// <summary>
        ///     Disable the logic on specific categories.
        ///     Category.None by default.
        /// </summary>
        public Category DisabledOnCategories = Category.None;

        /// <summary>
        ///     Disable the logic on specific groups
        /// </summary>
        public int DisabledOnGroup;

        /// <summary>
        ///     Enable the logic on specific categories
        ///     Category.All by default.
        /// </summary>
        public Category EnabledOnCategories = Category.All;

        /// <summary>
        ///     Enable the logic on specific groups.
        /// </summary>
        public int EnabledOnGroup;

        /// <summary>
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public virtual bool IsActiveOn(Body body)
        {
            if (body == null || !body.Enabled || body.GetBodyType == BodyType.Static)
            {
                return false;
            }

            foreach (Fixture fixture in body.FixtureList)
            {
                if ((fixture.GetCollisionGroup == DisabledOnGroup) && (fixture.GetCollisionGroup != 0) && (DisabledOnGroup != 0))
                {
                    return false;
                }

                if ((fixture.GetCollisionCategories & DisabledOnCategories) != Category.None)
                {
                    return false;
                }

                if (EnabledOnGroup != 0 || EnabledOnCategories != Category.All)
                {
                    if ((fixture.GetCollisionGroup == EnabledOnGroup) && (fixture.GetCollisionGroup != 0) && (EnabledOnGroup != 0))
                    {
                        return true;
                    }

                    if (((fixture.GetCollisionCategories & EnabledOnCategories) != Category.None) &&
                        (EnabledOnCategories != Category.All))
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Adds the category.
        /// </summary>
        /// <param name="category">The category.</param>
        public void AddDisabledCategory(Category category)
        {
            DisabledOnCategories |= category;
        }

        /// <summary>
        ///     Removes the category.
        /// </summary>
        /// <param name="category">The category.</param>
        public void RemoveDisabledCategory(Category category)
        {
            DisabledOnCategories &= ~category;
        }

        /// <summary>
        ///     Determines whether this body ignores the the specified controller.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>
        ///     <c>true</c> if the object has the specified category; otherwise, <c>false</c>.
        /// </returns>
        public bool IsInDisabledCategory(Category category) => (DisabledOnCategories & category) == category;

        /// <summary>
        ///     Adds the category.
        /// </summary>
        /// <param name="category">The category.</param>
        public void AddEnabledCategory(Category category)
        {
            EnabledOnCategories |= category;
        }

        /// <summary>
        ///     Removes the category.
        /// </summary>
        /// <param name="category">The category.</param>
        public void RemoveEnabledCategory(Category category)
        {
            EnabledOnCategories &= ~category;
        }

        /// <summary>
        ///     Determines whether this body ignores the the specified controller.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>
        ///     <c>true</c> if the object has the specified category; otherwise, <c>false</c>.
        /// </returns>
        public bool IsInEnabledInCategory(Category category) => (EnabledOnCategories & category) == category;
    }
}