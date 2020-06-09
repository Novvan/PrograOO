using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private bool _tPressed;
        private bool _uPressed;
        private bool _started = false;
        private GameObject background;
        private List<Enemy> Enemies;
        

        private List<GameObject> gameObjects;
        public List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }
        public List<Bullet> Bullets { get => bullets; set => bullets = value; }

        //en el constructor inicializamos todos los objetos del nivel
        public Level()
        {
            gameObjects = new List<GameObject>();
            bullets = new List<Bullet>(); 

            Enemies = GameManager.Instance.Enemies;
            

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
            if (Engine.GetKey(Keys.T)&& !_tPressed)
            {
                if (!_started) {
                    _tPressed = true;
                    Engine.Debug("Spawn");
                    GameManager.Instance.NewWave();
                    _started = true;
                }
                Engine.Debug("Round has started");
            }
            
            if (!Engine.GetKey(Keys.T))
            {
                _tPressed = false;
            }
            
            if (Engine.GetKey(Keys.U)&& !_uPressed)
            {
                _uPressed = true;

                if(Enemies.Count() != 0) { 
                Engine.Debug("Enemy killed");
                GameManager.Instance.KillEnemy();
                }
            }
            
            if (!Engine.GetKey(Keys.U))
            {
                _uPressed = false;
            }

            if (_started)
            {
                GameManager.Instance.CheckEnemies();
            }

            if (gameObjects.Count > 0)
            {
                foreach (GameObject go in gameObjects)
                {
                    //Engine.Debug(" render ");
                    go.Update();
                }
            }
            if (Bullets.Count >= 0)
            {
                foreach (Bullet bl in Bullets)
                {
                    bl.Update();
                }
            }
        }


        public void Render()
        {
            if (gameObjects.Count > 0)
             {
                 foreach (GameObject go in gameObjects)
                 {
                     //Engine.Debug(" render ");
                     go.Render();
                 }
                
                if (Enemies.Count > 0)
                {
                    foreach(Enemy en in Enemies)
                    {
                        en.Render();
                    }
                }
                
                if(Bullets.Count >= 0)
                {
                    foreach (Bullet bl in Bullets)
                    {
                        bl.Render();
                    }
                }
             }
        }

       

    }


}
    

