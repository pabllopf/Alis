namespace Alis.Core.Systems
{
    public abstract class System
    {
        public abstract void AfterUpdate();
        public abstract void Awake();
        public abstract void BeforeUpdate();
        public abstract void Exit();
        public abstract void FixedUpdate();
        public abstract void DispatchEvents();
        public abstract void Reset();
        public abstract void Start();
        public abstract void Stop();
        public abstract void Update();
    }
}
