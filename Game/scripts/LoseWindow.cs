using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class LoseWindow
    {
        private Texture texture;
        private string texturePath = "textures/game over.png";
        private float scaleX = 1f;
        private float scaleY = 1f;
        private Vector2 position;
        private float angle;

        public float Width => texture.Width * scaleX;
        public float Height => texture.Height * scaleY;
        public float OffsetX => Width / 2f;
        public float OffsetY => Height / 2f;

        public LoseWindow()
        {
            position = new Vector2(0, 0);
            texture = Engine.GetTexture(texturePath);
        }

        public void Update()
        {
            
        }
        public void Render()
        {
            Engine.Draw(texture, position.x, position.y, scaleX, scaleY, angle, OffsetX, OffsetY);
        }
    }
}