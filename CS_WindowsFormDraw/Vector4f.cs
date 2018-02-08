using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_WindowsFormDraw
{
    public class Vector4f
    {
        private float[] matrix = new float[4];

        public Vector4f()
        {

        }

        public Vector4f(float[] values)
        {
            matrix = values;
        }

        public void SetValue(int m, float value)
        {
            matrix[m] = value;
        }

        public float GetValue(int m)
        {
            return matrix[m];
        }

        public static Vector4f operator +(Vector4f left, Vector4f right)
        {
            Vector4f result = new Vector4f(new float[] 
            {
                left.GetValue(0) + right.GetValue(0),
                left.GetValue(1) + right.GetValue(1),
                left.GetValue(2) + right.GetValue(2),
                1
            });
            
            return result;
        }
        public static Vector4f operator -(Vector4f left, Vector4f right)
        {
            Vector4f result = new Vector4f(new float[]
            {
                left.GetValue(0) - right.GetValue(0),
                left.GetValue(1) - right.GetValue(1),
                left.GetValue(2) - right.GetValue(2),
                1
            });

            return result;
        }

        public static Vector4f operator *(Vector4f left, Vector4f right)
        {
            Vector4f result = new Vector4f(new float[]
            {
                left.GetValue(0) * right.GetValue(0),
                left.GetValue(1) * right.GetValue(1),
                left.GetValue(2) * right.GetValue(2),
                1
            });

            return result;
        }

        public static Vector4f operator *(Vector4f inV, float scalar)
        {
            Vector4f result = new Vector4f(new float[]
            {
                inV.GetValue(0) * scalar,
                inV.GetValue(1) * scalar,
                inV.GetValue(2) * scalar,
                1
            });

            return result;
        }
    }
}
