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

        public static Vector2 up()
        {
            return new Vector2(0, 1);
        }

        public static Vector2 right()
        {
            return new Vector2(1, 0);
        }

        public static Vector2 one()
        {
            return new Vector2(1, 1);
        }

        public static Vector2 left()
        {
            return new Vector2(-1, 0);
        }

        public static Vector2 down()
        {
            return new Vector2(0, -1);
        }
    }
}
