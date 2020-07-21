using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class GameObject
    {
        //Clase padre de todos los gameobjects
        protected Transform transform;
        protected Renderer renderer;

        public Vector2 Position
        {
            get => transform.Position;
        }

        public GameObject()
        {
            
        }

        public GameObject(Vector2 initialPosition, string texturePath, float angle, Vector2 size)
        {
            transform = new Transform(initialPosition, size, angle);
            renderer = new Renderer(transform, texturePath);
        }
        public virtual void Update()
        {

        }

        public virtual void Render()
        {
            renderer.Render(transform);
        }

    }

}

