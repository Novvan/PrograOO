using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class SpawnPoint
    {
        private Vector2 position;

        public Vector2 Position => position;

        public SpawnPoint(Vector2 initialPosition)
        {
            position = initialPosition;
        }
    }
}