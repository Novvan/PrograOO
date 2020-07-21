using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    class WaveIndicator : GameObject
    {

        public WaveIndicator(Vector2 initialPosition, string texturePath, float angle, Vector2 size)
            : base(initialPosition, texturePath, angle, size)
        {
            transform.Position = initialPosition;
        }

        public override void Update()
        {
            var currentWave = GameManager.Instance.wave;
            switch (currentWave)
            {
                case 1:
                    renderer.Texture = new Texture("textures/assets/wave1.png");
                    break;
                case 2:
                    renderer.Texture = new Texture("textures/assets/wave2.png");
                    break;
                case 3:
                    renderer.Texture = new Texture("textures/assets/wave3.png");
                    break;
                case 4:
                    renderer.Texture = new Texture("textures/assets/wave4.png");
                    break;
                case 5:
                    renderer.Texture = new Texture("textures/assets/finalwave.png");
                    break;
            }
        }   
    }
}
