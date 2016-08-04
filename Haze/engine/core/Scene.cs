using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    /// <summary>
    /// Scene class, containing all game objects (entities), graphic specification, etc..
    /// This class will call every entity base function, like Update and Draw.
    /// </summary>
    class Scene
    {
        // All object/entity list
        protected List<Entity> objects = new List<Entity>();
        // Graphic instance
        protected Graphic graphics = new Graphic();

        public void AddEntity(Entity entity)
        {
            objects.Add(entity);
        }

        // See ENTITY class for similar behaviour of functions below

        #region Physics
        public virtual void Simulate(double deltaTime)
        {
            foreach (Entity entity in objects)
                entity.Simulate(deltaTime);
        }

        public void Response(List<Collision> collisions, Physics physics)
        {
            foreach (Entity entity in objects)
                // Find all collision related to the specific entity
                entity.Response(collisions.FindAll(collision => collision.a == entity || collision.b == entity), physics);
        }

        public virtual List<Collision> GetCollisions(Physics physics)
        {
            return physics.GetCollisions(objects);
        }
        #endregion

        #region Basic functions
        public virtual void Start()
        {
            foreach (Entity obj in objects)
                obj.Start();
        }

        public virtual void Update(double deltaTime)
        {
            foreach (Entity obj in objects)
                obj.Update(deltaTime);
        }

        public virtual void Draw()
        {
            foreach (Entity obj in objects)
                obj.Draw(graphics);
        }

        public virtual void Destroy()
        {
            foreach (Entity obj in objects)
                obj.Destroy();
        }
        #endregion
    }
}
