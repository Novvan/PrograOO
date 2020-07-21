using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Healthup : GameObject, Powerup
    {
        public Healthup(Vector2 initialPosition) : base(initialPosition, "textures/assets/Powerup/healthpowerup.png", 0, new Vector2(0.3f, 0.3f))
        { }

        public void OnOverlap(Player player)
        {
            player.LifeController.Heal(1);
            GameManager.Instance.LevelWindow.Heals.Remove(this);
        }
    }
}
