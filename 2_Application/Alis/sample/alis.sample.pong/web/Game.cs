using Alis.Core.Ecs.Systems;

namespace Alis.Sample.Pong.Web
{
    public static class Game
    {
        public static VideoGame Create()
        {
             return VideoGame.Create().Build();
        }
    }
}