using Alis.Core.Ecs.Systems;

namespace Alis.Sample.Dino.Web
{
    public static class Game
    {
        public static VideoGame Create()
        {
             return VideoGame.Create().Build();
        }
    }
}
