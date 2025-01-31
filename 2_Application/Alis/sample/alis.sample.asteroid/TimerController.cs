using Alis.Core.Aspect.Data.Resource;
        using Alis.Core.Aspect.Math.Definition;
        using Alis.Core.Ecs.Component;
        using Alis.Core.Graphic.Fonts;
        
        namespace Alis.Sample.Asteroid
        {
            public class TimerController : AComponent
            {
                private FontManager fontManager;
                private double lastUpdateTime;
                    
                public override void OnStart()
                {
                    fontManager = Context.GraphicManager.FontManager;
                    fontManager.LoadFont("MONO", 14, AssetManager.Find("mono.bmp"));
                    lastUpdateTime = Context.TimeManager.RealtimeSinceStartupAsDouble;
                }
                    
                public override void OnUpdate()
                {
                    double currentTime = GameObject.Context.TimeManager.RealtimeSinceStartupAsDouble;
                    if (currentTime - lastUpdateTime >= 1.0)
                    {
                        lastUpdateTime = currentTime;
                        OnGui();
                    }
                }
                    
                public override void OnGui()
                {
                    float time = (float)(Context.TimeManager.RealtimeSinceStartupAsDouble / 1000.0);
                    fontManager.RenderText("MONO", $"{time:F2}", 512, 0, Color.White, 32);
                }
            }
        }