using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public interface IPooleable 
    {
 
    }
    class PullGenerico<T> where T : IPooleable, new()  
    {
        private List<Bullet> available = new List<Bullet>();
        private List<Bullet> inUse = new List<Bullet>();

        public PullGenerico()
        {

        }

        public Bullet GetBullet(float angle)
        {
            if (available.Count > 0)
            {
                Bullet bullet = available[0];
                inUse.Add(bullet);
                available.RemoveAt(0);
                bullet.Reset();
                return bullet;
            }
            else
            {
                Bullet bullet = new Bullet(new Vector2(0, 0), "Textures/bullet.png", angle, 1, 1, 200);
                bullet.OnDeactivate += OnBulletDeactivateHandler;
                inUse.Add(bullet);
                return bullet;
            }
        }

        private void OnBulletDeactivateHandler(Bullet bullet)
        {
            Recycle(bullet);

        }

        private void Recycle(Bullet bullet)
        {
            if (inUse.Contains(bullet))
            {
                inUse.Remove(bullet);
                available.Add(bullet);
            }
        }
    }
}
