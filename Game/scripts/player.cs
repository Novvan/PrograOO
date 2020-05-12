using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Player : GameObject
    {
       
        // private float angle = 0;
        // private float scale = 0.5f;
        //private string texturePath = "textures/assets/Player/player.png";

        private LifeController lifeController;
        private float speed;      
        private SpawnPoint spawnPoint;


  
        public LifeController LifeController
        {
            get => lifeController;
            set => lifeController = value;
        }
      
        
        public Player(Vector2 initialPosition, string texturePath, float angle, float scaleX, float scaleY, float speed) : base(initialPosition, texturePath, angle, scaleX, scaleY)
        {
            lifeController = new LifeController(100);
            this.speed = speed;
        }

        public void AssignSpawnpoint(SpawnPoint newSpawnpoint)
        {
            spawnPoint = newSpawnpoint;
        }

        public void MoveRight()
        {
            position.x += speed * Program.deltaTime;
            angle = 0f;
           Engine.Debug(angle);
        }

        public void MoveLeft()
        {
            position.x -= speed * Program.deltaTime;
            angle = 180f;
            //Engine.Debug(angle);
        }

        public void MoveUp()
        {
           position.y -= speed * Program.deltaTime;
            angle = 270f;
            //Engine.Debug(angle);
        }

        public void MoveDown()
        {
           position.y += speed * Program.deltaTime;
            angle = 90f;
            //Engine.Debug(angle);
        }

        public override void Update()
        {
            if (Engine.GetKey(Keys.D))
            {
                MoveRight();
            }

            if (Engine.GetKey(Keys.A))
            {
                MoveLeft();
            }

            if (Engine.GetKey(Keys.S))
            {
                MoveDown();
            }

            if (Engine.GetKey(Keys.W))
            {
                MoveUp();
            }

            if (Engine.GetKey(Keys.Q))
            {
                LifeController.GetDamage(100);
                Engine.Debug(LifeController.CurrentLife);
            }
        }

        public override void Render()
        {
            base.Render();
        }
    }
}