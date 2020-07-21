using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class LifeController
    {
        private float maxLife;
        private float currentLife;

        public float CurrentLife => currentLife;

        public LifeController(float initialMaxLife)
        {
            maxLife = initialMaxLife;
            currentLife = maxLife;

        }

        public void GetDamage(float damage)
        {
            currentLife -= damage;
        }

        public void Heal(float heal)
        {
            currentLife += heal;

            if (currentLife > maxLife)
            {
                currentLife = maxLife;
            }
        }

        public virtual void Die()
        {

        }
    }
}