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
        private float life;
        private float speed = 300f;
        private float angle = 0f;
        private float scale = 0.5f;
        private Texture texture;
        private string texturePath = "textures/assets/Player/player (1).png";

        public float Width => texture.Width * scale;
        public float Height => texture.Height * scale;
        public float OffsetX => Width / 2;
        public float OffsetY => Height / 2;



        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Life { get => life; set => life = value; }

        public Player(float initialX, float initialY, float angle)
        {
            x = initialX;
            y = initialY;

            texture = Engine.GetTexture(texturePath);
        }
        public void MoveRight()
        {
            x += speed * Program.deltaTime;
        }
        public void MoveLeft()
        {
            x -= speed * Program.deltaTime;
            
            
        }
        public void MoveUp()
        {
            y -= speed * Program.deltaTime;
        }
        public void MoveDown()
        {
            y += speed * Program.deltaTime;
        }
        public void Update()
        {

        }

        public void Render()
        {
            Engine.Draw(texture, x, y, scale, scale, OffsetX, OffsetY);
        }
    }
}


