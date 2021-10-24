namespace Alis.Core
{
    public class SceneSystem : ISystem
    {
        [System.Text.Json.Serialization.JsonConstructor()]
        public SceneSystem(Configuration configuration) => Configuration = configuration;

        [System.Text.Json.Serialization.JsonIgnore]
        public Configuration Configuration { get; set; }

        public virtual void AfterUpdate()
        {
            
        }

        public virtual void Awake()
        {
            
        }

        public virtual void BeforeUpdate()
        {
            
        }

        public virtual void DispatchEvents()
        {
            
        }

        public virtual void Exit()
        {
            
        }

        public virtual void FixedUpdate()
        {
            
        }

        public virtual void Reset()
        {
            
        }

        public virtual void Start()
        {
            
        }

        public virtual void Stop()
        {
            
        }

        public virtual void Update()
        {
            
        }
    }
}