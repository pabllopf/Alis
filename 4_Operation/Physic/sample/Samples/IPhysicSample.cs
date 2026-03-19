
namespace Alis.Core.Physic.Sample.Samples
{
    internal interface IPhysicSample
    {
        string Key { get; }

        string Title { get; }

        string Description { get; }

        void Run(SampleRuntime runtime);
    }
}

