using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    /// <summary>
    /// This class is responsible for the audio processing (2D or 3D).
    /// It should return the buffer data that will be passed to the audio card.
    /// This class can also implement functionalities like reverb, filters, play, stop, etc..
    /// </summary>
    abstract class Audio
    {
        // Audio clip, contaning the audio data from the audio file.
        public Clip clip;
        // Possible attribute position for 3D or 2D audio render.
        public Vector3f position;

        // You could implement the audio player functionalities
        public virtual void Play() { }
        public virtual void Stop() { }

        /// <summary>
        /// You must implement this function, it will be called every time the audio card request the buffer data.
        /// The function receives an information based on audio driver and the buffer size.
        /// </summary>
        /// <param name="info">Audio card information</param>
        /// <param name="size">Buffer size</param>
        /// <returns>Buffer data</returns>
        public abstract float[] GetBuffer(AudioDevice.AudioData info, int size);
    }
}
