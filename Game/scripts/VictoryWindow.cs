using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    class VictoryWindow : GameObject
    {
        public VictoryWindow(Vector2 initialPosition, string texturePath, float angle, Vector2 size) :
            base(initialPosition, texturePath, angle, size)
        {

        }

        public override void Update()
        {
            if (Engine.GetKey(Keys.ESCAPE))
            {
                GameManager.Instance.currentState = State.Menu;
            }
        }
        public override void Render()
        {
            base.Render();
            // Engine.Draw(texture, position.x, position.y, scaleX, scaleY, angle, OffsetX, OffsetY);
        }
    }
}
