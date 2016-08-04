using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    /// <summary>
    /// Abstract collider. You must implement the collision check.
    /// </summary>
    abstract class Collider
    {
        /// <summary>
        /// Collision check implementation with other collider.
        /// </summary>
        /// <param name="other">The other collider. It can be any collider type</param>
        /// <returns>Collision data if it collides</returns>
        public abstract Collision CheckCollision(Collider other);
    }
}
