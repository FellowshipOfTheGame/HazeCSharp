using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    class SceneManager
    {
        /* Scenes
         * Holds only one scene and uses an auxiliar variable for the next scene.
         * You can use a list to store all scenes and play multiple if you want.
         * Using list can slow the game a lot, depending the number of entities.
         */
        private static Scene current;
        private static Scene next;
        private static bool exit = false;

        private SceneManager() { }

        /// <summary>
        /// Get current scene, update current scene if needed (change in scene).
        /// </summary>
        /// <returns> Current scene.</returns>
        public static Scene GetCurrent()
        {
            if (exit)
            {
                current.Destroy();
                current = null;
            }
            else if(next != null)
            {
                if(current != null)
                    current.Destroy();
                current = next;
                next = null;
                current.Start();
            }
            return current;
        }

        /// <summary>
        /// Set next scene (wait until GetCurrent is called).
        /// </summary>
        /// <param name="scene"> The next scene to play.</param>
        public static void SetScene(Scene scene)
        {
            if (scene == null)
                exit = true;
            else
                next = current;
        }
    }
}
