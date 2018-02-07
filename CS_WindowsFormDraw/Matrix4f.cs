using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CS_WindowsFormDraw
{
    public class Matrix4f
    {
        private float[,] matrix = new float[4, 4];
        
        public Matrix4f()
        {

        }

        public Matrix4f(float value)
        {
            matrix[0, 0] = value;
            matrix[1, 1] = value;
            matrix[2, 2] = value;
            matrix[3, 3] = value;
        }

        public Matrix4f(float[,] values)
        {
            matrix = values; 
        }

        public void SetValue(int m, int n, float value)
        {
            matrix[m, n] = value;
        }

        public float GetValue(int m, int n)
        {
            return matrix[m, n];
        }

        public static Matrix4f operator *(Matrix4f left, Matrix4f right)
        {
            Matrix4f result = new Matrix4f();

            for (int i = 0; i < 4; i++)//0
            {
                for (int j = 0; j < 4; j++)//0
                {
                    for (int k = 0; k < 4; k++)//0
                    {
                        result.matrix[i, j] += left.matrix[i, k] * right.matrix[k, j];
                    }
                }
            }

            return result;
        }

        public static Vector4f operator *(Matrix4f left, Vector4f right)
        {
            Vector4f result = new Vector4f();

            

            for (int i = 0; i < 4; i++)//0
            {
                for (int j = 0; j < 1; j++)//0
                {
                    float temp = 0;
                    for (int k = 0; k < 4; k++)//0
                    {
                        temp += left.matrix[i, k] * right.GetValue(k);
                    }
                    result.SetValue(i, temp);
                }
            }

            return result;
        }

    }
    
}
