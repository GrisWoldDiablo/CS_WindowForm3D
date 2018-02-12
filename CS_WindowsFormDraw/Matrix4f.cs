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
        private float[,] matrix;

        //public static float[,] operator[](int x,int y)
        //{
        //    return matrix[x,y];
        //}
        public float m00() { return matrix[0, 0]; }
        public float m01() { return matrix[0, 1]; }
        public float m02() { return matrix[0, 2]; }
        public float m03() { return matrix[0, 3]; }
        public float m10() { return matrix[1, 0]; }
        public float m11() { return matrix[1, 1]; }
        public float m12() { return matrix[1, 2]; }
        public float m13() { return matrix[1, 3]; }
        public float m20() { return matrix[2, 0]; }
        public float m21() { return matrix[2, 1]; }
        public float m22() { return matrix[2, 2]; }
        public float m23() { return matrix[2, 3]; }
        public float m30() { return matrix[3, 0]; }
        public float m31() { return matrix[3, 1]; }
        public float m32() { return matrix[3, 2]; }
        public float m33() { return matrix[3, 3]; }


        public Matrix4f()
        {
            matrix = new float[4, 4];
        }

        public Matrix4f(float value)
        {
            matrix = new float[4, 4];
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
            Vector4f result = new Vector4f(new float[]
            {
                left.matrix[0,0] * right.x() + left.matrix[0,1] * right.y() + left.matrix[0,2] * right.z() + left.matrix[0,3] * right.w(),
                left.matrix[1,0] * right.x() + left.matrix[1,1] * right.y() + left.matrix[1,2] * right.z() + left.matrix[1,3] * right.w(),
                left.matrix[2,0] * right.x() + left.matrix[2,1] * right.y() + left.matrix[2,2] * right.z() + left.matrix[2,3] * right.w(),
                left.matrix[3,0] * right.x() + left.matrix[3,1] * right.y() + left.matrix[3,2] * right.z() + left.matrix[3,3] * right.w()
            });



            //for (int i = 0; i < 4; i++)//0
            //{
            //    for (int j = 0; j < 1; j++)//0
            //    {
            //        float temp = 0;
            //        for (int k = 0; k < 4; k++)//0
            //        {
            //            temp += left.matrix[i, k] * right.GetValue(k);
            //        }
            //        result.SetValue(i, temp);
            //    }
            //}

            return result;
        }

    }
    
}
