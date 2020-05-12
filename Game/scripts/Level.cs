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
        
        public Player player;
        int width = 1600;
        int height = 900;
        
        private GameObject background;
        private List<GameObject> gameObjects;
        public List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }
        public List<Bullet> Bullets { get => bullets; set => bullets = value; }

        //en el constructor inicializamos todos los objetos del nivel
        public Level()
        {
            player = new Player(GameManager.Instance.SpawnPoint, "textures/assets/Player/player.png", 0, 0.5f, 0.5f, 300f);
            gameObjects = new List<GameObject>();
            background = new GameObject(new Vector2(width/2, height/2),"textures/assets/Map.png", 0, 1, 1);
            gameObjects.Add(background);
            gameObjects.Add(player);
            

        }

      
        public void Initialize()
        {
            loseWindow = new LoseWindow();
           
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
    

