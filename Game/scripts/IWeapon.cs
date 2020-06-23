using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public interface IWeapon
    {
        void StartAttack();
        void StopAttack();
    }
}
