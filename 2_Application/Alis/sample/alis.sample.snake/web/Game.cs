using Alis.Core.Ecs.Systems;

namespace Alis.Sample.Snake.Web
{
    public static class Game
    {
        public static VideoGame Create()
        {
             return VideoGame.Create().Build();
        }
    }
}
