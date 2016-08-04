using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    /// <summary>
    /// Rigidbody physics class.
    /// Rigidbody 2D or 3D simulation (velocity, gravity, etc.), collision callback and response.
    /// </summary>
    abstract class Rigidbody
    {
        public abstract void Simulate(double deltaTime);
        public abstract void OnCollide(Collision collision);
        public abstract void Response(List<Collision> collisions, Physics physics);
    }
}
