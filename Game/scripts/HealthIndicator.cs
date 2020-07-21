using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Game.scripts
    {
        class HealthIndicator : GameObject
        {

            public HealthIndicator (Vector2 initialPosition, string texturePath, float angle, Vector2 size)
                : base(initialPosition, texturePath, angle, size)
            {
                transform.Position = initialPosition;
            }

            public override void Update()
            {
                var currenthealth = GameManager.Instance.LevelWindow.player.LifeController.CurrentLife;
                switch (currenthealth)
                {
                    case 1:
                        renderer.Texture = new Texture("textures/assets/Healthbar/1heart.png");
                        break;
                    case 2:
                        renderer.Texture = new Texture("textures/assets/Healthbar/2hearts.png");
                        break;
                    case 3:
                        renderer.Texture = new Texture("textures/assets/Healthbar/3hearts.png");
                        break;
                }
            }
        }
    }

}
