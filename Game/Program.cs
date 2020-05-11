using Game.scripts;
using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
      

        static void Main(string[] args)
        {
            Init();

            while (true)
            {
                
                Update();
                Render();
            }
        }

        static void Init()
        {
            Engine.Initialize();
            Time.Initialize();
            GameManager.Instance.Initialize();             
        }

   

        private static void Update()
        {
            /*if (GameManager.Instance.Enemies.Length == 0)
            {
                GameManager.Instance.NewWave();
            }*/
            Time.Update();
            GameManager.Instance.Update();
        }
        private static void Render()
        {
            Engine.Clear();
            GameManager.Instance.Render();
            Engine.Show();
        }
        
    }
}