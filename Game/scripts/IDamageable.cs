using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public interface IDamageable
    {
        int HitPoints { get ; }
        bool IsDestroyed { get ; set ; }

        event Action<IDamageable> OnDestroy;

        void GetDamage(int damage);
        void Destroy();

    }
}
