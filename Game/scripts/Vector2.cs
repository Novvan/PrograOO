using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public struct Vector2
    {
        public float x { get; set; }

        public float y { get; set; }

        public Vector2(float posX, float posY)

        {
            x = posX;
            y = posY;
        }

        public Vector2 zero()
        {
            return new Vector2(0, 0);
        }
    }
}

