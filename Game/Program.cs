using Game.scripts;
using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        public static float deltaTime;
        static DateTime startTime;
        static float lastTime;
        static Player UserPlayer;
        public static float angle;

        static void Main(string[] args)
        {
            startTime = DateTime.Now;
           
            Engine.Initialize("BoxHead Reborn",1500,1000);
            Engine.Debug("Hola mundo");

            Init();

            while (true)
            {
                CalculateDeltaTime();
                P_Input();
                P_Update();
                P_Render();
            }
        }
        static void Init()
        {
            UserPlayer = new Player(500,500);
        }

        private static void P_Input()
        {

        }

        private static void P_Update()
        {
            angle += 90;
        }

        private static void P_Render()
        {
            //Engine.Debug("render");
            Engine.Clear();
            Engine.Draw("textures/assets/Map.png", 0, 0, 1, 1);
            UserPlayer.render();
            Engine.Show();
        }
        static void CalculateDeltaTime()
        {
            //TimeSpan currentTime = DateTime.Now - startTime;
            //float currentTimeInSeconds = (float) currentTime.TotalSeconds;
            float currentTime = (float)(DateTime.Now - startTime).TotalMilliseconds;
            deltaTime = currentTime - lastTime; //La diferencia de esto seria el delta time
            lastTime = currentTime;
            Engine.Debug("DeltaTime:" + deltaTime);
        }
    }
}