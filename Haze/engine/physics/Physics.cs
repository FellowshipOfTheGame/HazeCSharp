using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    /// <summary>
    /// Physics class.
    /// You should implement collision detection, raycasting and all physics stuffs here.
    /// </summary>
    class Physics
    {
        /// <summary>
        /// Collision detection.
        /// For each entities check collision for all colliders
        /// </summary>
        /// <param name="objects">All objects from scene</param>
        /// <returns>List of collisions if any</returns>
        public virtual List<Collision> GetCollisions(List<Entity> objects)
        {
            List<Collision> collisions = null;

            for (int i = 0; i < objects.Count; i++)
            {
                Entity entityA = objects[i];
                // Start j from i + 1, for unique entity-entity pair
                for (int j = i + 1; j < objects.Count; j++)
                {
                    Entity entityB = objects[j];

                    if(entityA.colliders.Count > 0 && entityB.colliders.Count > 0)
                    {
                        // For all colliders, check collision
                        foreach (Collider colliderA in entityA.colliders)
                        {
                            foreach (Collider colliderB in entityB.colliders)
                            {
                                Collision collision = colliderA.CheckCollision(colliderB);
                                // Add collision if collision data is different from null
                                if(collision != null)
                                {
                                    if (collisions == null)
                                        collisions = new List<Collision>();

                                    collision.a = entityA;
                                    collision.b = entityB;

                                    collisions.Add(collision);
                                }
                            }
                        }
                    }
                }
            }
            return collisions;
        }
    }
}
