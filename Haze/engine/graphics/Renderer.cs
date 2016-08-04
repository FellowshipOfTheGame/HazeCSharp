using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    /// <summary>
    /// Render base class.
    /// You should implement 2D or 3D rendering here, based on Graphic object.
    /// </summary>
    abstract class Renderer
    {
        // Draw function
        public abstract void Draw(Graphic graphics);
    }
}
