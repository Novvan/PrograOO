using Game.scripts;
using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        public static float deltaTime;
        static DateTime startTime;
        static float lastFrameTime;
        static Player player;
       
        
        

        static void Main(string[] args)
        {
                 
           
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
            Engine.Initialize();
            player = new Player(100, 200, 0);
            startTime = DateTime.Now;
        }

        private static void P_Input()
        {
            if (Engine.GetKey(Keys.D))
            {
                player.MoveRight();
            }

            if (Engine.GetKey(Keys.A))
            {
                player.MoveLeft();
                
            }

            if (Engine.GetKey(Keys.S))
            {
                player.MoveDown();
            }

            if (Engine.GetKey(Keys.W))
            {
                player.MoveUp();
            }

            if (Engine.GetKey(Keys.Q))
            {
                player.LifeController.GetDamage(1);
                Engine.Debug(player.LifeController.CurrentLife);
            }
        }

        private static void P_Update()
        {
<<<<<<< HEAD
            player.Update();
=======
            if (Engine.GetKey(Keys.P))
            {
                GameManager.Instance.NewKill(1);
            }
            Engine.Debug(GameManager.Instance.Kills);
>>>>>>> a8087509e84c68998f55b6b5265f2918f0127125
        }

        private static void P_Render()
        {
            //Engine.Debug("render");
            Engine.Clear();
            Engine.Draw("textures/assets/Map.png", 0, 0, 1, 1);
            player.Render();
            
            Engine.Show();
        }
        static void CalculateDeltaTime()
        {
<<<<<<< HEAD
            
            float currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - lastFrameTime; 
            lastFrameTime = currentTime;
            Engine.Debug("DeltaTime:" + deltaTime);
=======
            float currentTime = (float)(DateTime.Now - startTime).TotalMilliseconds;
            deltaTime = currentTime - lastTime; //La diferencia de esto seria el delta time
            lastTime = currentTime;
            //Engine.Debug("DeltaTime:" + deltaTime);
>>>>>>> a8087509e84c68998f55b6b5265f2918f0127125
        }
    }
}