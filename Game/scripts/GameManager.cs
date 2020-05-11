using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game.scripts
{
    public class GameManager
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }

                return _instance;
            }
        }

        private float _kills;

        public float Kills
        {
            get => _kills;
        }


        public void NewKill(float kill)
        {
            _kills += kill;
        }
    }
}