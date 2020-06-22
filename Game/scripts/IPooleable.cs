using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public interface IPooleable<T> where T : IPooleable<T>, new()
    {
        event Action<T> OnDeactivate;
        void Reset();
    }
}
