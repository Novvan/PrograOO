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
        Lose,
        Victory

    }
    public class GameManager
    {

        private List<Enemy> _enemies = new List<Enemy>();
        private static GameManager instance;
        private float _gameModifier;
        private float _wave = 0;
        private float _maxEnemies = 4f;
        private LoseWindow looseWindow;
        private VictoryWindow victoryWindow;
        private Menu menuWindow;
        private Level levelWindow;
        public State currentState;
        public Vector2 SpawnPoint;      
        private int _killGO;
        public Level LevelWindow => levelWindow;

        private Random _random = new Random();


        public float maxEnemies => _maxEnemies;
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
            victoryWindow = new VictoryWindow(new Vector2(Program.Width / 2, Program.Height / 2),
                "textures/victory.png", 0f, new Vector2(1, 1));
            looseWindow = new LoseWindow(new Vector2(Program.Width / 2, Program.Height / 2), "textures/gameover.png",
                0f, new Vector2(1, 1));
            menuWindow = new Menu(new Vector2(Program.Width / 2, Program.Height / 2),
                "textures/assets/Menu/menubkg.png", 0f, new Vector2(1, 1));
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

        public float wave
        {
            get => _wave;
        }
        public List<Enemy> Enemies { get => _enemies; set => _enemies = value; }

        

        public void NewWave()
        {
            _wave++;
            EnemyFactory.Spawn();
        }

        public void CheckEnemies()
        {
            if (_enemies.Count == 0)
            {
                _wave++;
                EnemyFactory.Spawn();
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
                case State.Victory:
                    victoryWindow.Update();
                    break;
                default:
                    break;
            }
            if(_wave == 5)
            {
                currentState = State.Victory;
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
                case State.Victory:
                    victoryWindow.Render();
                    break;
                default:
                    break;
            }
        }
        public void GameOver()
        {
            currentState = State.Lose;
        }

        public void KillEnemy()
        {
            _killGO = _enemies.Count()-1;
            _enemies.RemoveAt(_killGO);
        }
    }

}