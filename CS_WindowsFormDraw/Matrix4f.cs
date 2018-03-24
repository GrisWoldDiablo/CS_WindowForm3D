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

        public float[,] Matrix { get => matrix; set => matrix = value; }

        public float this[int i, int j]
        {
            get { return Matrix[i,j]; }
            set { Matrix[i,j] = value;}
        }

        public Matrix4f()
        {
            Matrix = new float[4, 4];
        }

        public Matrix4f(float value)
        {
            Matrix = new float[4, 4];
            Matrix[0, 0] = value;
            Matrix[1, 1] = value;
            Matrix[2, 2] = value;
            Matrix[3, 3] = value;
        }

        public Matrix4f(float[,] values)
        {
            Matrix = values; 
        }


        public static Matrix4f operator *(Matrix4f left, Matrix4f right)
        {

            //Matrix4f result = new Matrix4f(new float[,]
            //{
            //    {
            //        (left[0,0] * right[0,0]) + (left[0,1] * right[1,0]) + (left[0,2] * right[2,0]) + (left[0,3] * right[3,0]),
            //        (left[0,0] * right[0,1]) + (left[0,1] * right[1,1]) + (left[0,2] * right[2,1]) + (left[0,3] * right[3,1]),
            //        (left[0,0] * right[0,2]) + (left[0,1] * right[1,2]) + (left[0,2] * right[2,2]) + (left[0,3] * right[3,2]),
            //        (left[0,0] * right[0,3]) + (left[0,1] * right[1,3]) + (left[0,2] * right[2,3]) + (left[0,3] * right[3,3])},                                                                                                                                                                                                                                                                                                                                   
            //    {
            //        (left[1,0] * right[0,0]) + (left[1,1] * right[1,0]) + (left[1,2] * right[2,0]) + (left[1,3] * right[3,0]),
            //        (left[1,0] * right[0,1]) + (left[1,1] * right[1,1]) + (left[1,2] * right[2,1]) + (left[1,3] * right[3,1]),
            //        (left[1,0] * right[0,2]) + (left[1,1] * right[1,2]) + (left[1,2] * right[2,2]) + (left[1,3] * right[3,2]),
            //        (left[1,0] * right[0,3]) + (left[1,1] * right[1,3]) + (left[1,2] * right[2,3]) + (left[1,3] * right[3,3])},                                                                                                                                                                                                                                                                                                                                   
            //    {
            //        (left[2,0] * right[0,0]) + (left[2,1] * right[1,0]) + (left[2,2] * right[2,0]) + (left[2,3] * right[3,0]),
            //        (left[2,0] * right[0,1]) + (left[2,1] * right[1,1]) + (left[2,2] * right[2,1]) + (left[2,3] * right[3,1]),
            //        (left[2,0] * right[0,2]) + (left[2,1] * right[1,2]) + (left[2,2] * right[2,2]) + (left[2,3] * right[3,2]),
            //        (left[2,0] * right[0,3]) + (left[2,1] * right[1,3]) + (left[2,2] * right[2,3]) + (left[2,3] * right[3,3])},                                                                                                                                                                                                                                                                                                                                   
            //    {
            //        (left[3,0] * right[0,0]) + (left[3,1] * right[1,0]) + (left[3,2] * right[2,0]) + (left[3,3] * right[3,0]),
            //        (left[3,0] * right[0,1]) + (left[3,1] * right[1,1]) + (left[3,2] * right[2,1]) + (left[3,3] * right[3,1]),
            //        (left[3,0] * right[0,2]) + (left[3,1] * right[1,2]) + (left[3,2] * right[2,2]) + (left[3,3] * right[3,2]),
            //        (left[3,0] * right[0,3]) + (left[3,1] * right[1,3]) + (left[3,2] * right[2,3]) + (left[3,3] * right[3,3])}
            //}
            //);

            Matrix4f result = new Matrix4f();
            for (int i = 0; i < 4; i++)//0
            {
                for (int j = 0; j < 4; j++)//0
                {
                    for (int k = 0; k < 4; k++)//0
                    {
                        result[i, j] += left[i, k] * right[k, j];
                    }
                }
            }

            return result;
        }

        public static Vector4f operator *(Matrix4f left, Vector4f right)
        {
            Vector4f result = new Vector4f(new float[]
            {
                (left[0,0] * right[0]) + (left[0,1] * right[1]) + (left[0,2] * right[2]) + (left[0,3] * right[3]),
                (left[1,0] * right[0]) + (left[1,1] * right[1]) + (left[1,2] * right[2]) + (left[1,3] * right[3]),
                (left[2,0] * right[0]) + (left[2,1] * right[1]) + (left[2,2] * right[2]) + (left[2,3] * right[3]),
                (left[3,0] * right[0]) + (left[3,1] * right[1]) + (left[3,2] * right[2]) + (left[3,3] * right[3])
            });

            //Vector4f result = new Vector4f();
            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        result[i] += (left[i, j] * right[j]);
            //    }
            //}
            return result;
        }

        public static Matrix4f Identify()
        {
            return new Matrix4f(new float[,] 
            { 
                { 1, 0, 0, 0 }, 
                { 0, 1, 0, 0 }, 
                { 0, 0, 1, 0 }, 
                { 0, 0, 0, 1 }
            });
        }

        public static Matrix4f Translation(float x,float y,float z)
        {
            return new Matrix4f(new float[,]
            {
                { 1, 0, 0, x },
                { 0, 1, 0, y },
                { 0, 0, 1, z },
                { 0, 0, 0, 1 }
            });
        }

        public static Matrix4f Scalar(float x, float y, float z)
        {
            return new Matrix4f(new float[,]
            {
                { x, 0, 0, 0 },
                { 0, y, 0, 0 },
                { 0, 0, z, 0 },
                { 0, 0, 0, 1 }
            });
        }

        public float Det2x2(float[,] m)
        {
            return (m[0, 0] * m[1, 1]) - (m[0, 1] * m[1, 0]);
        }

    }
    
}
