using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Enemy
    {
        string image = "";
        private float x;
        private float y;
        private float scaleX;
        private float scaleY;
        private float angle;
        private float offsetX;
        private float offsetY;
        public Enemy(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public void render()
        {
            Engine.Clear();

            Engine.Draw(image, x, y, scaleX, scaleY, angle, offsetX, offsetY);

            Engine.Show();
        }
    }
}
