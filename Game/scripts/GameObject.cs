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
        protected Vector2 position;
        protected float angle;
        protected float scaleX;
        protected float scaleY;
        protected Texture texture;
        protected Transform transform;
        protected Renderer renderer;


        public float Width => texture.Width * scaleX;
        public float Height => texture.Height * scaleY;
        public float OffsetX => Width / 2;
        public float OffsetY => Height / 2;

        public GameObject()
        {
            transform = new Transform(new Vector2(), new Vector2(), angle);
            renderer = new Renderer(transform, "textures/bullet.png");
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

