using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    /// <summary>
    /// This class contains the audio data from an audio file, like WAVE or OGG.
    /// You should implement the static functions that load data from an specific file and format.
    /// </summary>
    class Clip
    {
        // Member example, data from the audio file.
        public float[] data;
        /// <summary>
        /// Example from static function. It creates a clip from an audio file.
        /// </summary>
        /// <param name="filePath">Audio file path</param>
        /// <returns>A new audio clip</returns>
        public static Clip OpenWave(string filePath)
        {
            return new Clip();
        }
    }
}
