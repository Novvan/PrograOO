using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Player : GameObject
    {
        private float x;
        private float y;
        // private float angle = 0;
        // private float scale = 0.5f;
        //private string texturePath = "textures/assets/Player/player.png";

        private LifeController lifeController;
        private float speed = 300f;      
        private SpawnPoint spawnPoint;


  
        public LifeController LifeController
        {
            get => lifeController;
            set => lifeController = value;
        }

        public float X
        {
            get => x;
            set => x = value;
        }

        public float Y
        {
            get => y;
            set => y = value;
        }

      
        
        public Player(Vector2 initialPosition, string texturePath, float angle, float scaleX, float scaleY, float speed) : base(initialPosition, texturePath, angle, scaleX, scaleY)
        {
            lifeController = new LifeController(100);
        }

        public void AssignSpawnpoint(SpawnPoint newSpawnpoint)
        {
            spawnPoint = newSpawnpoint;
        }

        public void MoveRight()
        {
            x += speed * Program.deltaTime;
            angle = 0f;
            //Engine.Debug(angle);
        }

        public void MoveLeft()
        {
            x -= speed * Program.deltaTime;
            angle = 180f;
            //Engine.Debug(angle);
        }

        public void MoveUp()
        {
            y -= speed * Program.deltaTime;
            angle = 270f;
            //Engine.Debug(angle);
        }

        public void MoveDown()
        {
            y += speed * Program.deltaTime;
            angle = 90f;
            //Engine.Debug(angle);
        }

        public override void Update()
        {
        }

        public override void Render()
        {
            base.Render();
        }
    }
}