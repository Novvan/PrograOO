using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
  public interface ITransform
    {
        void MoveRight(Vector2 position, float speed);

        void MoveLeft(Vector2 position, float speed);

        void MoveUp(Vector2 position, float speed);        

        void MoveDown(Vector2 position, float speed);
        
    }
}
