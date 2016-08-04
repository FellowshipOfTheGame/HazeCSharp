using System;
using System.Threading;

namespace Haze
{
    /// <summary>
    /// Base game class for every game.
    /// This can change based on game necessities and genre.
    /// </summary>
    class World
    {
        public World(Scene scene)
        {
            SceneManager.SetScene(scene);
        }
        // Frames per second and target delta time if fixed frame rated
        private int framesPerSecond = 30;
        private long targetDelay;
        private bool fixedFrameRate = false;

        // Frame per second property, so we can set the target delay while setting the fps
        public int FPS
        {
            get { return framesPerSecond; }
            set
            {
                this.framesPerSecond = value;
                this.targetDelay = World.secondsToMilliseconds / framesPerSecond;
            }
        }

        // Auxiliar constants
        private static readonly double milliToSeconds = 1 / 1000;
        private static readonly long secondsToMilliseconds = 1000L;


        /// <summary>
        /// Thread function, start the game and iterate loop.
        /// Delay thread if fixed framerate is true.
        /// </summary>
        public void Start()
        {
            double deltaTime = World.milliToSeconds;
            double inverseTicksPerMilli = 1 / TimeSpan.TicksPerMillisecond;
            Scene scene;

            while ((scene = SceneManager.GetCurrent()) != null)
            {
                long now = DateTime.Now.Ticks;

                // Simple Update-Draw game loop
                #region Game Loop

                scene.Update(deltaTime * World.milliToSeconds);
                scene.Draw();

                #endregion

                deltaTime = (DateTime.Now.Ticks - now) * inverseTicksPerMilli;

                if (fixedFrameRate && targetDelay > deltaTime)
                {
                    Thread.Sleep((int)(targetDelay - deltaTime));
                    deltaTime = targetDelay;
                }
            }
        }
    }
}
