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
        static int width = 1600;
        static int height = 900;
        private static SpawnPoint spawnPoint;

        static void Main(string[] args)
        {
            Init();

            while (true)
            {
                CalculateDeltaTime();
                Input();
                Update();
                Render();
            }
        }

        static void Init()
        {
            Engine.Initialize("BoxHead", width, height, false);


            spawnPoint = new SpawnPoint(new Vector2(5, 5));
            player = new Player(width / 2, height / 2, 0);
            startTime = DateTime.Now;
        }

        private static void Input()
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

        private static void Update()
        {
            player.Update();
            if (Engine.GetKey(Keys.P))
            {
                GameManager.Instance.NewKill(1);
            }

            Engine.Debug(GameManager.Instance.Kills);
        }

        private static void Render()
        {
            Engine.Clear();
            Engine.Draw("textures/assets/Map.png");
            player.Render();

            Engine.Show();
        }

        static void CalculateDeltaTime()
        {
            float currentTime = (float) (DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
            //Engine.Debug("DeltaTime:" + deltaTime);
        }
    }
}