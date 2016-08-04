using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    /// <summary>
    /// Collision data and information, like entities colliding, penetration depth and normal vector
    /// </summary>
    class Collision
    {
        public Entity a;
        public Entity b;
        public Vector3f normal;
        public double depth;
    }
}
