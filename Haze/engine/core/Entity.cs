using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    /// <summary>
    /// Entity class for all game objects from the scene.
    /// This class is the one of the base class of the Entity-Component architecture.
    /// </summary>
    abstract class Entity
    {
        public string name;
        // Components or behaviours
        public List<Behaviour> components = new List<Behaviour>();
        // List of colliders (an object can have multiple colliders)
        public List<Collider> colliders = new List<Collider>();
        // Transform (position, rotation, scale, parent)
        public Transform transform = new Transform();
        // Audio source
        public Audio source;
        // Renderer 2D or 3D
        public Renderer renderer;
        // Rigidbody physics (2D or 3D)
        public Rigidbody rigidbody;

        public Entity(string name)
        {
            this.name = name;
        }


        #region Behaviours and Colliders
        public void AddBehaviour(Behaviour behaviour)
        {
            components.Add(behaviour);
        }

        public void AddCollider(Collider collider)
        {
            colliders.Add(collider);
        }
        #endregion

        #region Physics
        // Physics' simulation step
        public virtual void Simulate(double deltaTime)
        {
            Console.WriteLine(name + " simulate");
            if (rigidbody != null)
                rigidbody.Simulate(deltaTime);
        }

        // Physics' collision response step
        public virtual void Response(List<Collision> collisions, Physics physics)
        {
            Console.WriteLine(name + " response");
            if (rigidbody != null)
                rigidbody.Response(collisions, physics);
        }

        // On collision callback
        public virtual void OnCollide(Collision collision)
        {
            Console.WriteLine(name + " collide");
            foreach (Behaviour component in components)
                component.OnCollide(collision);
        }
        #endregion

        #region Basic functions calls (game loop)

        /// <summary>
        /// Called once when Scene is loaded.
        /// </summary>
        public virtual void Start()
        {
            foreach (Behaviour component in components)
                component.Start();
        }

        /// <summary>
        /// Update function.
        /// Called every frame by game loop controller.
        /// </summary>
        /// <param name="deltaTime">Delta time since last update</param>
        public virtual void Update(double deltaTime)
        {
            foreach (Behaviour component in components)
                component.Update(deltaTime);
        }

        /// <summary>
        /// Draw function.
        /// Called every frame by game loop controller.
        /// </summary>
        /// <param name="graphics">Graphic device specification, functions, etc.</param>
        public virtual void Draw(Graphic graphics)
        {
            if(renderer != null)
                renderer.Draw(graphics);
        }

        /// <summary>
        /// Called once when Scene is unloaded.
        /// </summary>
        public virtual void Destroy()
        {
            foreach (Behaviour component in components)
                component.Destroy();
        }
        #endregion
    }
}
