using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
       public class Player
    {


        private float x;
        private float y;
        private LifeController lifeController;
        private float speed = 300f;
        private float angle = 0f;
        private float scale = 0.5f;
        private Texture texture;
        private string texturePath = "textures/assets/Player/player (1).png";

        public float Width => texture.Width * scale;
        public float Height => texture.Height * scale;
        public float OffsetX => Width / 2;
        public float OffsetY => Height / 2;

        public LifeController LifeController { get => lifeController; set => lifeController = value; }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }

        public Player(float initialX, float initialY, float angle)
        {
            x = initialX;
            y = initialY;

            texture = Engine.GetTexture(texturePath);

            lifeController = new LifeController(100);
        }
        public void MoveRight()
        {
            x += speed * Program.deltaTime;
            angle = 0f;
            
        }
        public void MoveLeft()
        {
            x -= speed * Program.deltaTime;
            angle = 180f;
                       
            
        }
        public void MoveUp()
        {
            y -= speed * Program.deltaTime;
            angle = 90f;
            
            
        }
        public void MoveDown()
        {
            y += speed * Program.deltaTime;
            angle = 270f;
        }
        public void Update()
        {

        }

        public void Render()
        {
<<<<<<< HEAD
            Engine.Draw(texture, x, y, scale, scale, angle, OffsetX, OffsetY);
=======
            Engine.Draw(texture, x, y, scale, scale, angle, OffsetX,OffsetY);
>>>>>>> 3f0725abdbb5e0e6e20a8b1d65f882fb21ecf643
        }
    }
}


