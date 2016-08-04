using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haze
{
    struct Vector3f
    {
        public float x, y, z;

        public Vector3f(float x = 0, float y = 0, float z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3f operator +(Vector3f v1, Vector3f v2)
        {
            return new Vector3f(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3f operator -(Vector3f v1, Vector3f v2)
        {
            return new Vector3f(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3f operator *(float a, Vector3f v)
        {
            return new Vector3f(a * v.x, a * v.y, a * v.z);
        }

        public static float operator *(Vector3f v1, Vector3f v2)
        {
            return v1.x*v2.x + v1.y*v2.y + v1.z*v2.z;
        }
    }
}
