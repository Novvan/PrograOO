using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Level
    {
        public float deltaTime;
        DateTime startTime;
        float lastFrameTime;
        Player player;
        int width = 1600;
        int height = 900;
        private Vector2 SpawnPoint;

        //en el constructor inicializamos todos los objetos del nivel
        public Level()
        {
            SpawnPoint = new Vector2(5, 5);
            player = new Player(SpawnPoint, "textures/assets/Player/player.png",0,0.5f,0.5f,300f);
            startTime = DateTime.Now;
        }

        private void Input()
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
        public void Update()
        {

        }
        public void Render()
        {
            Engine.Clear();
            Engine.Draw("textures/assets/Map.png");
            player.Render();

            Engine.Show();
        }

         void CalculateDeltaTime()
        {
            float currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
            //Engine.Debug("DeltaTime:" + deltaTime);
        }

    }


}
    

