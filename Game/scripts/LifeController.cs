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

            if (currentLife <= 0)
            {
                Die();
            }
        }
        
        public void Heal(float heal)
        {
            currentLife += heal;

            if (currentLife > maxLife)
            {
                currentLife = maxLife;
            }
        }

        private void Die()
        {
            currentLife = 0;
            // Aca iria el comportamiento de muerte
        }
    }
}
