using Alis.Core.Ecs.Updating.Runners;

namespace Alis.Core.Ecs.Updating
{
    internal interface IComponentStorageBaseFactory<T>
    {
        internal ComponentStorage<T> CreateStronglyTyped(int capacity);
    }
}