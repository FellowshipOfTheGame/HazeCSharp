using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    /// <summary>
    /// The component base class which holds the functions that the parent Entity will call.
    /// You can add new methods like Start, OnTrigger, etc..
    /// </summary>
    abstract class Behaviour
    {
        public virtual void Start() { }
        public virtual void Destroy() { }
        public virtual void Update(double deltaTime) { }
        public virtual void OnCollide(Collision collision) { }
    }
}
