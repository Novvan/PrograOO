using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Player : GameObject
    {
        //private float angle = 0;
        //private float scale = 0.5f;
        // private string texturePath = "textures/assets/Player/player.png";
        private float x;
        private float y;           
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
           position . x += speed * Program.deltaTime;
            
            //Engine.Debug(angle);
        }

        public void MoveLeft()
        {
            position . x -= speed * Program.deltaTime;
           
            //Engine.Debug(angle);
        }

        public void MoveUp()
        {
            position . y -= speed * Program.deltaTime;
           
            //Engine.Debug(angle);
        }

        public void MoveDown()
        {
            position . y += speed * Program.deltaTime;
            
            //Engine.Debug(angle);
        }

        //Override es para tener algo propio del player (clase hijo)
        public override void Update()
        {
        }

        public override void Render()
        {
            //Base.Render es para heredar el render de la clase padre
            base.Render();    
        }
    }
}    