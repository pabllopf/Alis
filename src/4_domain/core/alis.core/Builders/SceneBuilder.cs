using Alis.Core.Entities;
using Alis.FluentApi;

namespace Alis.Core.Builders
{
    public class SceneBuilder :
        IBuild<Scene>,
        IName<SceneBuilder, string>
    {
        public Scene Scene { get; set; } = new();

        public Scene Build()
        {
            return Scene;
        }

        public SceneBuilder Name(string value)
        {
            Scene.Name = value;
            return this;
        }
    }
}