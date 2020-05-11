using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public abstract class GameObject
{
    //Clase padre de todos los gameobjects
    protected Vector2 position;
    protected float angle;
    protected float scaleX;
    protected float scaleY;
    protected Texture texture;



    public float Width => texture.Width * scaleX;
    public float Height => texture.Height * scaleY;
    public float OffsetX => Width / 2;
    public float OffsetY => Height / 2;

    public Vector2 Position { get => position; set => position = value; }

    public GameObject(Vector2 initialPosition, string texturePath, float angle, float scaleX, float scaleY)
    {
        position = initialPosition;
        texture = Engine.GetTexture(texturePath);
    }
    public virtual void Update()
    {

    }
    public virtual void Render()
    {
        Engine.Draw(texture, position.x, position.y, scaleX, scaleY, angle, OffsetX, OffsetY);
    }
}
}

