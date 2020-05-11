using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public static class Time
    {
        private static float deltaTime;
        public static float DeltaTime => deltaTime;

        private static DateTime startDate;
        private static float lastFrameTime;

        public static void Initialize()
        {
            startDate = DateTime.Now;
        }

        public static void Update()
        {
            float currentTime = (float)(DateTime.Now - startDate).TotalSeconds;
            deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
        }
    }
}
