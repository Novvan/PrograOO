using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Level
    {
        private  LoseWindow loseWindow;
        private List<Bullet> bullets = new List<Bullet>();
        private float _width = Program.Width;
        private float _height = Program.Height;


        public Player player;
        private Vector2 _spawnPoint;
        
        private GameObject background;
        private List<GameObject> gameObjects;
        public List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }
        public List<Bullet> Bullets { get => bullets; set => bullets = value; }

        //en el constructor inicializamos todos los objetos del nivel
        public Level()
        {
            gameObjects = new List<GameObject>();
            
            _spawnPoint = new Vector2(_width / 2, _height / 2);
            player = new Player(_spawnPoint, "textures/assets/Player/player.png", 0, 0.5f, 0.5f, 300f);

            background = new GameObject(new Vector2(_width/2, _height/2),"textures/assets/Map.png", 0, 1, 1);
            
            gameObjects.Add(background);
            gameObjects.Add(player);
            

        }

      
        public void Initialize()
        {
                       
        }
        public void Update()
        {
            if (gameObjects.Count > 0)
            {
                foreach (GameObject go in gameObjects)
                {
                    Engine.Debug(" render ");
                    go.Update();
                }
            }
        }
        public void Render()
        {
             if (gameObjects.Count > 0)
             {
                 foreach (GameObject go in gameObjects)
                 {
                        Engine.Debug(" render ");
                     go.Render();
                 }
             }
            
        }

       

    }


}
    

