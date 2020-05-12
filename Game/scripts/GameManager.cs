using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game.scripts
{
    public enum State
    {
        Menu,
        Level,
        Lose
       
    }
    public class GameManager
    {

        private List<Enemy> _enemies = new List<Enemy>();
        private static GameManager instance;
        private float _gameModifier;
        private float _wave = 0;
        private float _maxEnemies = 5f;
        private LoseWindow looseWindow;
        private Menu menuWindow;
        private Level levelWindow;
        public State currentState;
        public Vector2 SpawnPoint;




        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }

                return instance;
            }
        }

        public void Initialize()
        {
            looseWindow = new LoseWindow(new Vector2(Program.Width/2, Program.Height /2), "textures/gameover.png",0f,1,1);
            menuWindow = new Menu(new Vector2(Program.Width / 2, Program.Height / 2), "textures/assets/Menu/menubkg.png", 0f, 1, 1);
            levelWindow = new Level();            
            currentState = State.Menu;
            SpawnPoint = new Vector2(50, 50);
            //player = new Player(SpawnPoint, "textures/assets/Player/player.png", 0, 0.5f, 0.5f, 300f);
        }
        public void ChangeCurrentState(State newState)
        {
            currentState = newState;
        }

        public float GameModifier
        {
            get => _gameModifier;
            set => _gameModifier = value;
        }

        public float Wave
        {
            get => _wave;
        }

        public void SpawnEnemies()
        {
            while (_enemies.Count <= _maxEnemies * _wave)
            {
                Random rnd = new Random();
                int _randomY = rnd.Next(0, 900);
                int _randomX = rnd.Next(0, 1600);
                float _scale = 0.5f;
                Vector2 position = new Vector2(_randomX, _randomY);
                
                for (int i = 0; i <= _maxEnemies*_wave; i++ )
                {
                    _enemies.Add( new Enemy(position,"Game/textures/assets/Zombie Normal/attack01_0019.png",0,_scale,_scale,100));
                }
            }
        }

        public void NewWave()
        {
            if (_enemies.Count == 0)
            {
                _wave++;
                SpawnEnemies();
            }
        }
        public void Update()
        {
          switch (currentState)
            {
                case State.Menu:
                    menuWindow.Update();
                    break;
                case State.Level:
                    levelWindow.Update();
                    break;
                case State.Lose:
                    looseWindow.Update();
                    break;
                default:
                    break;
            }           
        }
        public void Render()
        {
            switch (currentState)
            {
                case State.Menu:
                    menuWindow.Render();
                    break;
                case State.Level:
                    levelWindow.Render();
                    break;
                case State.Lose:
                    looseWindow.Render();
                    break;
                default:
                    break;
            }
        }
        public void GameOver()
        {
            currentState = State.Lose;
        }
    }

}