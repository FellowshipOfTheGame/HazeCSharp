using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    /// <summary>
    /// This class must implement the audio driver callback function.
    /// It processes the data form all sources and pass the audio card information.
    /// </summary>
    class AudioDevice
    {
        /// <summary>
        /// Audio card information.
        /// It may contain the number of channels, the samples per second, etc..
        /// </summary>
        public class AudioData
        {
            public int channels;
            public int samplesPerSecond;
        }

        public List<Audio> sources;

        /// <summary>
        /// The function which is going to be called every time the audio card requests a new buffer.
        /// </summary>
        /// <param name="info">Audio card information</param>
        /// <param name="data">Buffer data pointer</param>
        /// <param name="size">Buffer size</param>
        public void Callback(AudioData info, float[] data, int size)
        {
            // Process all sources
            foreach (Audio source in sources)
            {
                float[] audioData = source.GetBuffer(info, size);
                for (int i = 0; i < size; i++)
                    data[i] += audioData[i];
            }
        }
    }
}
