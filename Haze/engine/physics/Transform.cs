using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    /// <summary>
    /// Transform data, like position, rotation, scale, children and parent transform.
    /// </summary>
    class Transform
    {
        /* Private fields of properties
         * These are the private fields that holds the local position, rotation and scale
         */
        private Vector3f _localPosition;
        private Vector3f _localRotation;
        private Vector3f _localScale;
        
        /* Properties
         * You can try to cache the global position, so you don't need to recalculate everytime.
         * The problem is when a parent change it's local position, you need to notify all children.
         */

        // Local transform properties (getters and setters)
        public Vector3f Position
        {
            get
            {
                return _localPosition;
            }
            set
            {
                _localPosition = value;
            }
        }
        public Vector3f Rotation
        {
            get
            {
                return _localRotation;
            }
            set
            {
                _localRotation = value;
            }
        }
        public Vector3f Scale
        {
            get
            {
                return _localScale;
            }
            set
            {
                _localScale = value;
            }
        }

        // Global transform properties (getters)
        public Vector3f GlobalPosition
        {
            get
            {
                return GetGlobalPosition();
            }
        }
        public Vector3f GlobalRotation
        {
            get
            {
                return GetGlobalRotation();
            }
        }
        public Vector3f GlobalScale
        {
            get
            {
                return GetGlobalScale();
            }
        }

        /* Parent-child architecture
         * This architecture doesn't check for cycles, so please be careful
         */
        private List<Transform> children = new List<Transform>();
        private Transform parent = null;

        // Transform local position/rotation/scale into global position/rotation/scale

        #region Global transformation
        private Vector3f GetGlobalPosition()
        {
            Vector3f pos;
            if (parent == null)
                pos = _localPosition;
            else
                pos = _localPosition + parent.GetGlobalPosition();
            return pos;
        }
        
        private Vector3f GetGlobalRotation()
        {
            Vector3f rot;
            if (parent == null)
                rot = _localRotation;
            else
                rot = _localRotation + parent.GetGlobalRotation();
            return rot;
        }
        
        private Vector3f GetGlobalScale()
        {
            Vector3f scal;
            if (parent == null)
                scal = _localScale;
            else
            {
                Vector3f global = parent.GetGlobalScale();
                scal = _localScale;
                scal.x *= global.x;
                scal.y *= global.y;
                scal.z *= global.z;
            }
            return scal;
        }
        #endregion

        // Architecture functions: Add, Remove and Parent

        #region Children function
        private void RemoveChild(Transform child)
        {
            children.Remove(child);
        }

        private void AddChild(Transform child)
        {
            children.Add(child);
        }

        public void SetParent(Transform parent)
        {
            if (this.parent != null)
                this.parent.RemoveChild(this);

            this.parent = parent;
            this.parent.AddChild(this);
        }
        #endregion
    }
}
