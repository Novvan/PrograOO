using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    class PlayerAlt : GameObject
    {
        private float _speed;




        public PlayerAlt(Vector2 initialPosition, string texturePath, float angle, Vector2 size, float speed) : base(initialPosition, texturePath, angle, size)
        {
            this._speed = speed;
            
        }
    }
}
