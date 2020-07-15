using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{

    class PullGenerico<T> where T : IPooleable<T>, new()
    {
        private List<T> available = new List<T>();
        private List<T> inUse = new List<T>();

        public PullGenerico()
        {

        }

        public T GetBullet(float angle)
        {
            if (available.Count > 0)
            {
                T bullet = available[0];
                inUse.Add(bullet);
                available.RemoveAt(0);
                bullet.Reset();
                return bullet;
            }
            else
            {
                T bullet = new T();
                bullet.OnDeactivate += OnBulletDeactivateHandler;
                inUse.Add(bullet);
                return bullet;
            }
        }

        private void OnBulletDeactivateHandler(T bullet)
        {
            Recycle(bullet);

        }

        private void Recycle(T bullet)
        {
            if (inUse.Contains(bullet))
            {
                inUse.Remove(bullet);
                available.Add(bullet);
            }
        }
    }
}
