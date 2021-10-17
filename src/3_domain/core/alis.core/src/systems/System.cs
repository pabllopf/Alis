namespace Alis.Core
{
    public abstract class System
    {
        public virtual void AfterUpdate() { }
        public virtual void Awake() { }
        public virtual void BeforeUpdate() { }
        public virtual void Exit() { }
        public virtual void FixedUpdate() { }
        public virtual void Reset() { }
        public virtual void Start() { }
        public virtual void Stop() { }
        public virtual void Update() { }
    }
}
