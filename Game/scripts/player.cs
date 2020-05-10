using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Player
    {
        string image = "textures/assets/Player/player (1).png";
        private float x;
        private float y;
        private float scaleX = 0.5f;
        private float scaleY = 0.5f;
        private float angle;
        private float offsetX;
        private float offsetY;

        public Player(float x, float y)
        {
            this.x = x;
            this.y = y;
        } 
        
       
        public void render()
        { 
            Engine.Draw(image,x,y,scaleX,scaleY,angle,offsetX,offsetY);
        }
        
    }
}
