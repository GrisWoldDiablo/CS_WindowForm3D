using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_WindowsFormDraw
{
    public class Vector4f
    {
        private float[] matrix;
        public float x() { return matrix[0]; }
        public float y() { return matrix[1]; }
        public float z() { return matrix[2]; }
        public float w() { return matrix[3]; }

        public Vector4f()
        {
            matrix = new float[4];
        }
        public Vector4f(float[] values)
        {
            matrix = values;
        }

        public void SetValue(int m, float value)
        {
            matrix[m] = value;
        }

        //public float GetValue(int m)
        //{
        //    return matrix[m];
        //}

        public static Vector4f operator +(Vector4f left, Vector4f right)
        {
            Vector4f result = new Vector4f(new float[]
            {
                left.x() + right.x(),
                left.y() + right.y(),
                left.z() + right.z(),
                1
            });
            
            return result;
        }
        public static Vector4f operator -(Vector4f left, Vector4f right)
        {
            Vector4f result = new Vector4f(new float[]
            {
                left.x() - right.x(),
                left.y() - right.y(),
                left.z() - right.z(),
                1
            });

            return result;
        }

        public static Vector4f operator *(Vector4f left, Vector4f right)
        {
            Vector4f result = new Vector4f(new float[]
            {
                left.x() * right.x(),
                left.y() * right.y(),
                left.z() * right.z(),
                1
            });

            return result;
        }

        public static Vector4f operator *(Vector4f inV, float scalar)
        {
            Vector4f result = new Vector4f(new float[]
            {
                inV.x() * scalar,
                inV.y() * scalar,
                inV.z() * scalar,
                1
            });

            return result;
        }
    }
}
