using Game.scripts;
using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        public static float deltaTime;
        static DateTime startTime;
        public static float lastFrameTime;
        public static int Width = 1920;
        public static int Height = 1080;


        static void Main(string[] args)
        {
            startTime = DateTime.Now;
            Init();
            
            while (true)
            {
                
                Update();
                Render();
            }
        }

        static void Init()
        {
            Engine.Initialize("Zombie Apocalypse", Width,Height,false);
            Time.Initialize();
            GameManager.Instance.Initialize();             
        }

   

        private static void Update()
        {
            CalculateDeltaTime();
            Time.Update();
            GameManager.Instance.Update();
        }
        private static void Render()
        {
            Engine.Clear();
            GameManager.Instance.Render();
            Engine.Show();
        }
        public static void CalculateDeltaTime()
        {
            float currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
            //Engine.Debug("DeltaTime:" + deltaTime);
        }

    }
}