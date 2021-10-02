namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using Newtonsoft;

    public class Game
    {
        [NotNull]
        private bool isRunning;

        [NotNull]
        private bool isStopped;

        public Game() 
        {
        
        }

        public void Run() 
        {
            Awake();
            Start();

            while (isRunning) 
            {
                BeforeUpdate();
                Update();
                AfterUpdate();
            }

            Exit();
        }

        private void Awake() 
        {
        
        }

        private void Start() 
        {
        
        }

        private void Stop() => isStopped = !isStopped;

        private void Reset() 
        {
            isRunning = false;
            Exit();

            Run();
        }

        private void BeforeUpdate() 
        {
        
        }

        private void Update() 
        {
        
        }

        private void AfterUpdate() 
        {
        
        }

        private void FixedUpdate() 
        {
        
        }
           
        private void Exit() 
        {
        
        }
    }
}
