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

        public float this[int i]
        {
            get { return matrix[i]; }
            set { matrix[i] = value;}
        }

        public Vector4f()
        {
            matrix = new float[4];
        }

        public Vector4f(float x, float y, float z, float w)
        {
            matrix = new float[4] { x, y, z, w };
        }

        public Vector4f(float[] values)
        {
            matrix = values;
        }

        //public void SetValue(int i, float value)
        //{
        //    matrix[i] = value;
        //}

        public float Dot(Vector4f other)
        {
            return (this[0] * other[0]) + (this[1] * other[1]) + (this[2] * other[2]) + (this[3] * other[3]);
        }

        public static Vector4f Cross(Vector4f left, Vector4f right)
        {
            Vector4f result = new Vector4f(new float[]
            {
                (left[1] * right[2]) - (right[1]  * left[2]),
                (left[2] * right[0]) - (right[2]  * left[0]),
                (left[0] * right[1]) - (right[0]  * left[1]),
                1.0f
            });

            return result;
        }

        public Vector4f Normalized()
        {
            float length = this.GetLength(); 

            return this * (1.0f / length);
            return new Vector4f(this[0] / length, this[1] / length, this[2] / length, 1);
        }

        public float GetLength()
        {
            return (float)Math.Sqrt(Math.Pow(this[0], 2) + Math.Pow(this[1], 2) + Math.Pow(this[2], 2));
        }

        public double GetAngle(Vector4f other)
        {
            double multi = this.GetLength() * other.GetLength();
            double result = (this[0] * other[0]) + (this[1] * other[1]) + (this[2] * other[2]);
            return ToDegree(Math.Acos(result / multi));
        }

        public double GetDistanceTo(Vector4f other)
        {
            return Math.Sqrt(Math.Pow(this[0] - other[0], 2) + Math.Pow(this[1] - other[1], 2) + Math.Pow(this[2] - other[2], 2));
        }

        public static double Distance(Vector4f v1, Vector4f v2)
        {
            return Math.Sqrt(Math.Pow(v1[0] - v2[0], 2) + Math.Pow(v1[1] - v2[1], 2) + Math.Pow(v1[2] - v2[2], 2));
        }

        public static Vector4f operator +(Vector4f left, Vector4f right)
        {
            return new Vector4f(new float[]
            {
                left[0] + right[0],
                left[1] + right[1],
                left[2] + right[2],
                1
            });
        }
        public static Vector4f operator -(Vector4f left, Vector4f right)
        {
            return new Vector4f(new float[]
            {
                left[0] - right[0],
                left[1] - right[1],
                left[2] - right[2],
                1
            });
        }

        public static Vector4f operator *(Vector4f left, Vector4f right)
        {
            return new Vector4f(new float[]
            {
                left[0] * right[0],
                left[1] * right[1],
                left[2] * right[2],
                1
            });
        }

        public static Vector4f operator /(Vector4f left, Vector4f right)
        {
            return new Vector4f(new float[]
            {
                left[0] / right[0],
                left[1] / right[1],
                left[2] / right[2],
                1
            });
        }

        public static Vector4f operator *(Vector4f v, float scalar)
        {
            return new Vector4f(new float[]
            {
                v[0] * scalar,
                v[1] * scalar,
                v[2] * scalar,
                1
            });
        }

        private double ToRadian(double angle)
        {
            return (Math.PI * angle) / 180;
        }

        private double ToDegree(double radian)
        {
            return radian * (180 / Math.PI);
        }

    }
}
