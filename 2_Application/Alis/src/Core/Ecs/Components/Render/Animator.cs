using System.Collections.Generic;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.Components.Render;

public struct Animator : IAnimator
{
    public List<Animation> Animations { get; set; }
    public int CurrentAnimationIndex { get; set; }
    public int CurrentFrameIndex { get; set; }
    
    private Clock _clock;
    private float _elapsedTime;

    public Animator()
    {
        Animations = new List<Animation>();
        CurrentAnimationIndex = 0;
        CurrentFrameIndex = 0;
    }

    public Animator(List<Animation> animations)
    {
        Animations = animations;
        CurrentAnimationIndex = 0;
        CurrentFrameIndex = 0;
    }

    public Animation CurrentAnimation =>
        Animations.Count > 0 ? Animations[CurrentAnimationIndex] : default;

    public void AddAnimation(Animation animation)
    {
        Animations.Add(animation);
    }

    public void Play(string animationName)
    {
        int index = Animations.FindIndex(a => a.Name == animationName);
        if (index >= 0)
        {
            CurrentAnimationIndex = index;
            CurrentFrameIndex = 0;
        }
    }

    public void NextFrame()
    {
        List<Frame> frames = CurrentAnimation.Frames;
        if (frames != null && frames.Count > 0)
        {
            CurrentFrameIndex = (CurrentFrameIndex + 1) % frames.Count;
        }
    }

    public Frame GetCurrentFrame()
    {
        List<Frame> frames = CurrentAnimation.Frames;
        if (frames != null && frames.Count > 0)
        {
            return frames[CurrentFrameIndex];
        }

        return default;
    }

    public void Init(IGameObject self)
    {
        _clock = new Clock();
        _clock.Start();
        _elapsedTime = 0f;
    }

    public void Update(IGameObject self)
    {
        if (_clock == null)
            return;
    
        float deltaTime = _clock.ElapsedMilliseconds / 1000f;
        _clock.Restart();
    
        _elapsedTime += deltaTime;
    
        // Suponiendo que el target de fps es 60
        float targetFps = 60f;
        float frameDuration = CurrentAnimation.Speed > 0 ? 1f / (CurrentAnimation.Speed * targetFps) : float.MaxValue;
    
        if (_elapsedTime >= frameDuration)
        {
            NextFrame();
            _elapsedTime -= frameDuration;
        }
    }

    public void DrawAnimation(ref Sprite sprite)
    {
        string textureName = GetCurrentFrame().NameFile;
        
        if (sprite.NameFile != textureName)
        {
            sprite.LoadTexture(AssetManager.Find(textureName));
        }
    }
}