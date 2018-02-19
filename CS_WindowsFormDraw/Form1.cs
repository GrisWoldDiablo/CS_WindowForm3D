using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace CS_WindowsFormDraw
{
    public partial class Form1 : Form
    {

        int mPosX, mPosY;
        double angleAlpha = 90;
        Graphics gra = null;
        private Point pS, pE;
        private int penWitdh = 5;
        static float theta = 0, phi = 0;

        static double[]
            point1 = { 1, 1, 0 },
            point2 = { 1, 6, 0 },
            point3 = { 6, 6, 0 },
            point4 = { 6, 1, 0 },
            point5 = { 1, 1, 5 },
            point6 = { 1, 6, 5 },
            point7 = { 6, 6, 5 },
            point8 = { 6, 1, 5 },
            zAxisU = { 0, 0, 15 },
            zAxisD = { 0, 0, -15 },
            xAxisU = { 15, 0, 0 },
            xAxisD = { -15, 0, 0 },
            yAxisU = { 0, 15, 0 },
            yAxisD = { 0, -15, 0 },
            origin = { 0, 0, 0 },
            camera = { 0, 0, 0 },//0,0,-100
            camV = { -2, 0, 0 },//1,-3.14,-2.6
            viewerV = { 10, 10, 0, 6.0 },//0,0,-1000
            textXp = {30,0,0 },
            textYp = {0,30,0 },
            textZp = {0,0,30 }, 
            textXm = { -50, 0, 0 },
            textYm = { 0, -50, 0 },
            textZm = { 0, 0, -50 },
            camOri = { 0.1f, 1000, 0 }; //{ 0.1, -1000, 0 }

        double scaleFactor = 2.0;
        double translateX = 0, translateY = 0, translateZ = 0;

        static PointF point21;
        static PointF point22;
        static PointF point23;
        static PointF point24;
        static PointF point25;
        static PointF point26;
        static PointF point27;
        static PointF point28;
        static PointF zAxis2U;
        static PointF zAxis2D;
        static PointF xAxis2U;
        static PointF xAxis2D;
        static PointF yAxis2U;
        static PointF origin2;
        static PointF cameraF;
        static PointF viewerF;
        static PointF textXXp;
        static PointF textYYp;
        static PointF textZZp;
        static PointF textXXm;
        static PointF textYYm;
        static PointF textZZm;


        Vector4f cameraPosition = new Vector4f(new float[] { (float)viewerV[0], (float)viewerV[1], (float)viewerV[2], 1 });


        bool changed18 = false, changed19 = false, changed20 = false, changed21 = false, changed22 = false, changed23 = false, changed28 = false;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            theta = float.Parse(textBox1.Text);
            trackBar1.Value = (int)(float.Parse(textBox1.Text) * 1000);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            //    // point1 = { 50, 50, 0 },
            //    // point2 = { 50, 200, 0 },
            //    // point3 = { 200, 200, 0 },
            //    // point4 = { 200, 50, 0 },
            //    // point5 = { 50, 50, -150 },
            //    // point6 = { 50, 200, -150 },
            //    // point7 = { 200, 200, -150 },
            //    // point8 = { 200, 50, -150 },
            double valueRot;
            if (trackBar3.Value > 0)
            {
                valueRot = 0.1f;
            }
            else
            {
                valueRot = -0.1f;
            }

            rotateOn(point1,valueRot);
            rotateOn(point2,valueRot);
            rotateOn(point3,valueRot);
            rotateOn(point4,valueRot);
            rotateOn(point5,valueRot);
            rotateOn(point6,valueRot);
            rotateOn(point7,valueRot);
            rotateOn(point8,valueRot);
            trackBar3.Value = 0;
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);

            

            //    // point1
            //    point1[c1] = (int)Math.Round((Math.Cos(valueRot) * point1[c1]) - ((Math.Sin(valueRot)) * point1[c2]));
            //    point1[c2] = (int)Math.Round((Math.Sin(valueRot) * point1[c1]) + (Math.Cos(valueRot) * point1[c2]));
            //    // point2
            //    point2[c1] = (int)Math.Round((Math.Cos(valueRot) * point2[c1]) - ((Math.Sin(valueRot)) * point2[c2]));
            //    point2[c2] = (int)Math.Round((Math.Sin(valueRot) * point2[c1]) + (Math.Cos(valueRot) * point2[c2]));
            //    // point3
            //    point3[c1] = (int)Math.Round((Math.Cos(valueRot) * point3[c1]) - ((Math.Sin(valueRot)) * point3[c2]));
            //    point3[c2] = (int)Math.Round((Math.Sin(valueRot) * point3[c1]) + (Math.Cos(valueRot) * point3[c2]));
            //    // point4
            //    point4[c1] = (int)Math.Round((Math.Cos(valueRot) * point4[c1]) - ((Math.Sin(valueRot)) * point4[c2]));
            //    point4[c2] = (int)Math.Round((Math.Sin(valueRot) * point4[c1]) + (Math.Cos(valueRot) * point4[c2]));
            //    // point5
            //    point5[c1] = (int)Math.Round((Math.Cos(valueRot) * point5[c1]) - ((Math.Sin(valueRot)) * point5[c2]));
            //    point5[c2] = (int)Math.Round((Math.Sin(valueRot) * point5[c1]) + (Math.Cos(valueRot) * point5[c2]));
            //    // point6
            //    point6[c1] = (int)Math.Round((Math.Cos(valueRot) * point6[c1]) - ((Math.Sin(valueRot)) * point6[c2]));
            //    point6[c2] = (int)Math.Round((Math.Sin(valueRot) * point6[c1]) + (Math.Cos(valueRot) * point6[c2]));
            //    // point7
            //    point7[c1] = (int)Math.Round((Math.Cos(valueRot) * point7[c1]) - ((Math.Sin(valueRot)) * point7[c2]));
            //    point7[c2] = (int)Math.Round((Math.Sin(valueRot) * point7[c1]) + (Math.Cos(valueRot) * point7[c2]));
            //    // point8
            //    point8[c1] = (int)Math.Round((Math.Cos(valueRot) * point8[c1]) - ((Math.Sin(valueRot)) * point8[c2]));
            //    point8[c2] = (int)Math.Round((Math.Sin(valueRot) * point8[c1]) + (Math.Cos(valueRot) * point8[c2]));

                
            //    /*
            //    var rotateX3D = function(theta) {
            //        var sin_t = sin(theta);
            //        var cos_t = cos(theta);

            //        for (var n = 0; n < nodes.length; n++)
            //        {
            //            var node = nodes[n];
            //            var y = node[1];
            //            var z = node[2];
            //            node[1] = y * cos_t - z * sin_t;
            //            node[2] = z * cos_t + y * sin_t;
            //        }
            //    };*/

            //    updateSquare();

            //    this.Refresh();
            //    DrawSquare(myPoints);
        }

        private void checkBox3_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox4.Checked = false;
            checkBox5.Checked = false;
        }

        private void checkBox4_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox3.Checked = false;
            checkBox5.Checked = false;
        }

        private void checkBox5_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            phi = float.Parse(textBox2.Text);
            trackBar2.Value = (int)(float.Parse(textBox2.Text) * 1000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rotateOnX(point1);
            rotateOnX(point2);
            rotateOnX(point3);
            rotateOnX(point4);
            rotateOnX(point5);
            rotateOnX(point6);
            rotateOnX(point7);
            rotateOnX(point8);

            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void rotateOnX(double[] pointToRotate) {

            double[,] matrix =
                {
                    { 1, 0, 0 }, // x
                    { 0, 0,-1 }, // y
                    { 0, 1, 0 }  // z
                };

            double[,] matrix1 =
                {
                    { 1, 0, 0 },
                    { 0, 0, 1 },
                    { 0, -1, 0 }
                };

            double x, y, z;

            if (checkBox6.Checked)
            {
                x = (matrix[0, 0] * pointToRotate[0]) + (matrix[0, 1] * pointToRotate[1]) + (matrix[0, 2] * pointToRotate[2]);
                y = (matrix[1, 0] * pointToRotate[0]) + (matrix[1, 1] * pointToRotate[1]) + (matrix[1, 2] * pointToRotate[2]);
                z = (matrix[2, 0] * pointToRotate[0]) + (matrix[2, 1] * pointToRotate[1]) + (matrix[2, 2] * pointToRotate[2]);

            }
            else
            {
                x = (matrix1[0, 0] * pointToRotate[0]) + (matrix1[0, 1] * pointToRotate[1]) + (matrix1[0, 2] * pointToRotate[2]);
                y = (matrix1[1, 0] * pointToRotate[0]) + (matrix1[1, 1] * pointToRotate[1]) + (matrix1[1, 2] * pointToRotate[2]);
                z = (matrix1[2, 0] * pointToRotate[0]) + (matrix1[2, 1] * pointToRotate[1]) + (matrix1[2, 2] * pointToRotate[2]); 
            }
            pointToRotate[0] = x;
            pointToRotate[1] = y;
            pointToRotate[2] = z;
        }

        private void rotateOnY(double[] pointToRotate)
        {

            double[,] matrix =
                {
                    { 0, 0, 1 },
                    { 0, 1, 0 },
                    {-1, 0, 0 }
                };
            double[,] matrix1 =
                {
                    { 0, 0, -1 },
                    { 0, 1, 0 },
                    { 1, 0, 0 }
                };

            double x, y, z;

            if (checkBox6.Checked)
            {
                x = (matrix[0, 0] * pointToRotate[0]) + (matrix[0, 1] * pointToRotate[1]) + (matrix[0, 2] * pointToRotate[2]);
                y = (matrix[1, 0] * pointToRotate[0]) + (matrix[1, 1] * pointToRotate[1]) + (matrix[1, 2] * pointToRotate[2]);
                z = (matrix[2, 0] * pointToRotate[0]) + (matrix[2, 1] * pointToRotate[1]) + (matrix[2, 2] * pointToRotate[2]);

            }
            else
            {
                x = (matrix1[0, 0] * pointToRotate[0]) + (matrix1[0, 1] * pointToRotate[1]) + (matrix1[0, 2] * pointToRotate[2]);
                y = (matrix1[1, 0] * pointToRotate[0]) + (matrix1[1, 1] * pointToRotate[1]) + (matrix1[1, 2] * pointToRotate[2]);
                z = (matrix1[2, 0] * pointToRotate[0]) + (matrix1[2, 1] * pointToRotate[1]) + (matrix1[2, 2] * pointToRotate[2]);
            }
            pointToRotate[0] = x;
            pointToRotate[1] = y;
            pointToRotate[2] = z;
        }

        private void rotateOnZ(double[] pointToRotate)
        {

            double[,] matrix =
                {
                    { 0, -1, 0 },
                    { 1, 0, 0 },
                    { 0, 0, 1 }
                };

            double[,] matrix1 =
                {
                    { 0, 1, 0 },
                    { -1, 0, 0 },
                    { 0, 0, 1 }
                };

            double x, y, z;

            if (checkBox6.Checked)
            {
                x = (matrix[0, 0] * pointToRotate[0]) + (matrix[0, 1] * pointToRotate[1]) + (matrix[0, 2] * pointToRotate[2]);
                y = (matrix[1, 0] * pointToRotate[0]) + (matrix[1, 1] * pointToRotate[1]) + (matrix[1, 2] * pointToRotate[2]);
                z = (matrix[2, 0] * pointToRotate[0]) + (matrix[2, 1] * pointToRotate[1]) + (matrix[2, 2] * pointToRotate[2]);

            }
            else
            {
                x = (matrix1[0, 0] * pointToRotate[0]) + (matrix1[0, 1] * pointToRotate[1]) + (matrix1[0, 2] * pointToRotate[2]);
                y = (matrix1[1, 0] * pointToRotate[0]) + (matrix1[1, 1] * pointToRotate[1]) + (matrix1[1, 2] * pointToRotate[2]);
                z = (matrix1[2, 0] * pointToRotate[0]) + (matrix1[2, 1] * pointToRotate[1]) + (matrix1[2, 2] * pointToRotate[2]);
            }
            pointToRotate[0] = x;  
            pointToRotate[1] = y;
            pointToRotate[2] = z;
        }

        private void rotateOn(double[] pointToRotate, double rotValue)
        {
            

            double[,] matrixX =
                {
                    { 1, 0, 0 }, // x
                    { 0, Math.Cos(rotValue), -Math.Sin(rotValue) }, // y
                    { 0, Math.Sin(rotValue), Math.Cos(rotValue) }  // z
                };

            double[,] matrixY =
                 {
                    { Math.Cos(rotValue), 0, -Math.Sin(rotValue) }, // x
                    { 0, 1, 0 }, // y
                    { Math.Sin(rotValue), 0, Math.Cos(rotValue) }  // z
                };

            double[,] matrixZ =
                            {
                    { Math.Cos(rotValue), -Math.Sin(rotValue), 0 }, // x
                    { Math.Sin(rotValue), Math.Cos(rotValue), 0 }, // y
                    { 0, 0, 1 }  // z
                };

            double x, y, z;
            if (checkBox3.Checked)
            {
                x = ((matrixX[0, 0] * pointToRotate[0]) + (matrixX[0, 1] * pointToRotate[1]) + (matrixX[0, 2] * pointToRotate[2]));
                y = ((matrixX[1, 0] * pointToRotate[0]) + (matrixX[1, 1] * pointToRotate[1]) + (matrixX[1, 2] * pointToRotate[2]));
                z = ((matrixX[2, 0] * pointToRotate[0]) + (matrixX[2, 1] * pointToRotate[1]) + (matrixX[2, 2] * pointToRotate[2]));
            }
            else if (checkBox4.Checked)
            {
                x = ((matrixY[0, 0] * pointToRotate[0]) + (matrixY[0, 1] * pointToRotate[1]) + (matrixY[0, 2] * pointToRotate[2]));
                y = ((matrixY[1, 0] * pointToRotate[0]) + (matrixY[1, 1] * pointToRotate[1]) + (matrixY[1, 2] * pointToRotate[2]));
                z = ((matrixY[2, 0] * pointToRotate[0]) + (matrixY[2, 1] * pointToRotate[1]) + (matrixY[2, 2] * pointToRotate[2]));
            }
            else
            {
                x = ((matrixZ[0, 0] * pointToRotate[0]) + (matrixZ[0, 1] * pointToRotate[1]) + (matrixZ[0, 2] * pointToRotate[2]));
                y = ((matrixZ[1, 0] * pointToRotate[0]) + (matrixZ[1, 1] * pointToRotate[1]) + (matrixZ[1, 2] * pointToRotate[2]));
                z = ((matrixZ[2, 0] * pointToRotate[0]) + (matrixZ[2, 1] * pointToRotate[1]) + (matrixZ[2, 2] * pointToRotate[2]));
            }
            pointToRotate[0] = x;
            pointToRotate[1] = y;
            pointToRotate[2] = z;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //3-4-5
            //6-9-12
            //7-10-13
            //8-11-14
            //15-16-17
            textBox15.Text = (int.Parse(textBox3.Text) * int.Parse(textBox6.Text) + int.Parse(textBox4.Text) * int.Parse(textBox9.Text)  + int.Parse(textBox5.Text) * int.Parse(textBox12.Text)).ToString();
            textBox16.Text = (int.Parse(textBox3.Text) * int.Parse(textBox7.Text) + int.Parse(textBox4.Text) * int.Parse(textBox10.Text) + int.Parse(textBox5.Text) * int.Parse(textBox13.Text)).ToString();
            textBox17.Text = (int.Parse(textBox3.Text) * int.Parse(textBox8.Text) + int.Parse(textBox4.Text) * int.Parse(textBox11.Text) + int.Parse(textBox5.Text) * int.Parse(textBox14.Text)).ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = (int.Parse(textBox3.Text) * int.Parse(textBox6.Text) + int.Parse(textBox4.Text) * int.Parse(textBox9.Text) + int.Parse(textBox5.Text) * int.Parse(textBox12.Text)).ToString();
            textBox16.Text = (int.Parse(textBox3.Text) * int.Parse(textBox7.Text) + int.Parse(textBox4.Text) * int.Parse(textBox10.Text) + int.Parse(textBox5.Text) * int.Parse(textBox13.Text)).ToString();
            textBox17.Text = (int.Parse(textBox3.Text) * int.Parse(textBox8.Text) + int.Parse(textBox4.Text) * int.Parse(textBox11.Text) + int.Parse(textBox5.Text) * int.Parse(textBox14.Text)).ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = (int.Parse(textBox3.Text) * int.Parse(textBox6.Text) + int.Parse(textBox4.Text) * int.Parse(textBox9.Text) + int.Parse(textBox5.Text) * int.Parse(textBox12.Text)).ToString();
            textBox16.Text = (int.Parse(textBox3.Text) * int.Parse(textBox7.Text) + int.Parse(textBox4.Text) * int.Parse(textBox10.Text) + int.Parse(textBox5.Text) * int.Parse(textBox13.Text)).ToString();
            textBox17.Text = (int.Parse(textBox3.Text) * int.Parse(textBox8.Text) + int.Parse(textBox4.Text) * int.Parse(textBox11.Text) + int.Parse(textBox5.Text) * int.Parse(textBox14.Text)).ToString();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = (int.Parse(textBox3.Text) * int.Parse(textBox6.Text) + int.Parse(textBox4.Text) * int.Parse(textBox9.Text) + int.Parse(textBox5.Text) * int.Parse(textBox12.Text)).ToString();
            textBox16.Text = (int.Parse(textBox3.Text) * int.Parse(textBox7.Text) + int.Parse(textBox4.Text) * int.Parse(textBox10.Text) + int.Parse(textBox5.Text) * int.Parse(textBox13.Text)).ToString();
            textBox17.Text = (int.Parse(textBox3.Text) * int.Parse(textBox8.Text) + int.Parse(textBox4.Text) * int.Parse(textBox11.Text) + int.Parse(textBox5.Text) * int.Parse(textBox14.Text)).ToString();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = (int.Parse(textBox3.Text) * int.Parse(textBox6.Text) + int.Parse(textBox4.Text) * int.Parse(textBox9.Text) + int.Parse(textBox5.Text) * int.Parse(textBox12.Text)).ToString();
            textBox16.Text = (int.Parse(textBox3.Text) * int.Parse(textBox7.Text) + int.Parse(textBox4.Text) * int.Parse(textBox10.Text) + int.Parse(textBox5.Text) * int.Parse(textBox13.Text)).ToString();
            textBox17.Text = (int.Parse(textBox3.Text) * int.Parse(textBox8.Text) + int.Parse(textBox4.Text) * int.Parse(textBox11.Text) + int.Parse(textBox5.Text) * int.Parse(textBox14.Text)).ToString();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = (int.Parse(textBox3.Text) * int.Parse(textBox6.Text) + int.Parse(textBox4.Text) * int.Parse(textBox9.Text) + int.Parse(textBox5.Text) * int.Parse(textBox12.Text)).ToString();
            textBox16.Text = (int.Parse(textBox3.Text) * int.Parse(textBox7.Text) + int.Parse(textBox4.Text) * int.Parse(textBox10.Text) + int.Parse(textBox5.Text) * int.Parse(textBox13.Text)).ToString();
            textBox17.Text = (int.Parse(textBox3.Text) * int.Parse(textBox8.Text) + int.Parse(textBox4.Text) * int.Parse(textBox11.Text) + int.Parse(textBox5.Text) * int.Parse(textBox14.Text)).ToString();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = (int.Parse(textBox3.Text) * int.Parse(textBox6.Text) + int.Parse(textBox4.Text) * int.Parse(textBox9.Text) + int.Parse(textBox5.Text) * int.Parse(textBox12.Text)).ToString();
            textBox16.Text = (int.Parse(textBox3.Text) * int.Parse(textBox7.Text) + int.Parse(textBox4.Text) * int.Parse(textBox10.Text) + int.Parse(textBox5.Text) * int.Parse(textBox13.Text)).ToString();
            textBox17.Text = (int.Parse(textBox3.Text) * int.Parse(textBox8.Text) + int.Parse(textBox4.Text) * int.Parse(textBox11.Text) + int.Parse(textBox5.Text) * int.Parse(textBox14.Text)).ToString();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = (int.Parse(textBox3.Text) * int.Parse(textBox6.Text) + int.Parse(textBox4.Text) * int.Parse(textBox9.Text) + int.Parse(textBox5.Text) * int.Parse(textBox12.Text)).ToString();
            textBox16.Text = (int.Parse(textBox3.Text) * int.Parse(textBox7.Text) + int.Parse(textBox4.Text) * int.Parse(textBox10.Text) + int.Parse(textBox5.Text) * int.Parse(textBox13.Text)).ToString();
            textBox17.Text = (int.Parse(textBox3.Text) * int.Parse(textBox8.Text) + int.Parse(textBox4.Text) * int.Parse(textBox11.Text) + int.Parse(textBox5.Text) * int.Parse(textBox14.Text)).ToString();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = (int.Parse(textBox3.Text) * int.Parse(textBox6.Text) + int.Parse(textBox4.Text) * int.Parse(textBox9.Text) + int.Parse(textBox5.Text) * int.Parse(textBox12.Text)).ToString();
            textBox16.Text = (int.Parse(textBox3.Text) * int.Parse(textBox7.Text) + int.Parse(textBox4.Text) * int.Parse(textBox10.Text) + int.Parse(textBox5.Text) * int.Parse(textBox13.Text)).ToString();
            textBox17.Text = (int.Parse(textBox3.Text) * int.Parse(textBox8.Text) + int.Parse(textBox4.Text) * int.Parse(textBox11.Text) + int.Parse(textBox5.Text) * int.Parse(textBox14.Text)).ToString();
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            changed18 = true;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            changed19 = true;
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            changed20 = true;
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            changed21 = true;
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            changed22 = true;
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            changed23 = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            trackBar4.Value = (int)(camV[0]*100.0);
            trackBar5.Value = (int)(camV[1]*100.0);
            trackBar6.Value = (int)(camV[2]*100.0);
            textBox24.Text = camV[0].ToString();
            textBox25.Text = camV[1].ToString();
            textBox26.Text = camV[2].ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            camV[0] = trackBar4.Value / 100.0;
            if (camV[0] == 0 && camV[1] == 0 && camV[2] == 0)
            {
                camV[0] = 0.1;
            }
            textBox24.Text = (trackBar4.Value / 100.0).ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            camV[1] = trackBar5.Value / 100.0;
            if (camV[0] == 0 && camV[1] == 0 && camV[2] == 0)
            {
                camV[1] = 0.1;
            }
            textBox25.Text = (trackBar5.Value / 100.0).ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            camV[2] = trackBar6.Value / 100.0;
            if (camV[0] == 0 && camV[1] == 0 && camV[2] == 0)
            {
                camV[2] = 0.1;
            }
            textBox26.Text = (trackBar6.Value / 100.0).ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            camera[0] = trackBar7.Value;
            //viewerV[0] = -trackBar7.Value;
            //trackBar10.Value = (int)viewerV[0];
            //textBox21.Text = (trackBar10.Value).ToString();
            textBox18.Text = (trackBar7.Value).ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            camera[1] = trackBar8.Value;
            if (camera[1]>0)
            {

            }
            textBox19.Text = (trackBar8.Value).ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            camera[2] = trackBar9.Value;
            textBox20.Text = (trackBar9.Value).ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            trackBar18.Value = (int)(camOri[0]/* * 100.0*/);
            trackBar19.Value = (int)(camOri[1]/* * 100.0*/);
            trackBar20.Value = (int)(camOri[2]/* * 100.0*/);
            textBox29.Text = camOri[0].ToString();
            textBox30.Text = camOri[1].ToString();
            textBox31.Text = camOri[2].ToString();
        }

        private void trackBar18_Scroll(object sender, EventArgs e)
        {
            camOri[0] = trackBar18.Value;// / 100.0;
            if (camOri[0] == 0 && camOri[1] == 0 && camOri[2] == 0)
            {
                camOri[0] = 0.1;
            }
            textBox29.Text = (trackBar18.Value/* / 100.0*/).ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar19_Scroll(object sender, EventArgs e)
        {
            camOri[1] = trackBar19.Value;// / 100.0;
            if (camOri[0] == 0 && camOri[1] == 0 && camOri[2] == 0)
            {
                camOri[1] = 0.1;
            }
            textBox30.Text = (trackBar19.Value/* / 100.0*/).ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar20_Scroll(object sender, EventArgs e)
        {
            camOri[2] = trackBar20.Value;// / 100.0;
            if (camOri[0] == 0 && camOri[1] == 0 && camOri[2] == 0)
            {
                camOri[2] = 0.1;
            }
            textBox31.Text = (trackBar20.Value/* / 100.0*/).ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar21_MouseDown(object sender, MouseEventArgs e)
        {
            mPosX = MousePosition.X;
            mPosY = MousePosition.Y;
        }

        private void trackBar21_Scroll(object sender, EventArgs e)
        {
            
            
            double translateValue;
            if (trackBar21.Value > 0)
            {
                translateValue = 10.0;
            }
            else
            {
                translateValue = -10.0;
            }
            //rotateOn(camera, translateValue);
            camera[0] = translateValue;
            trackBar21.Value = 0;
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
            Cursor.Position = new Point(mPosX, mPosY);

        }

        private void trackBar22_MouseDown(object sender, MouseEventArgs e)
        {
            mPosX = MousePosition.X;
            mPosY = MousePosition.Y;
        }

        private void trackBar22_Scroll(object sender, EventArgs e)
        {


            double translateValue;
            if (trackBar22.Value > 0)
            {
                translateValue = 10.0;
            }
            else
            {
                translateValue = -10.0;
            }
            //rotateOn(camera, translateValue);
            camera[2] = translateValue;
            trackBar22.Value = 0;
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
            Cursor.Position = new Point(mPosX, mPosY);

        }

        private void trackBar17_Scroll(object sender, EventArgs e)
        {
            viewerV[3] = trackBar17.Value/100.0;
            textBox28.Text = (trackBar17.Value/100.0).ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {

            viewerV[0] = trackBar10.Value;
            //camera[0] = -trackBar10.Value;
            //trackBar7.Value = (int)camera[0];
            //textBox18.Text = (trackBar7.Value).ToString();

            

            textBox21.Text = (trackBar10.Value).ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            viewerV[1] = trackBar11.Value;
            textBox22.Text = (trackBar11.Value).ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            viewerV[2] = trackBar12.Value;
            textBox23.Text = (trackBar12.Value).ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar16_Scroll(object sender, EventArgs e)
        {
            
            if (trackBar16.Value > 0)
            {
                translateZ = 1f;
            }
            else
            {
                translateZ = -1f;
            }
            trackBar16.Value = 0;
            translateOn(point1);
            translateOn(point2);
            translateOn(point3);
            translateOn(point4);
            translateOn(point5);
            translateOn(point6);
            translateOn(point7);
            translateOn(point8);
            updateSquare();
            translateZ = 0;
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar15_Scroll(object sender, EventArgs e)
        {
            if (trackBar15.Value > 0)
            {
                translateX = 2.0;
            }
            else
            {
                translateX = -2.0;
            }
            trackBar15.Value = 0;
            translateOn(point1);
            translateOn(point2);
            translateOn(point3);
            translateOn(point4);
            translateOn(point5);
            translateOn(point6);
            translateOn(point7);
            translateOn(point8);
            updateSquare();
            translateX = 0;
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar14_Scroll(object sender, EventArgs e)
        {
            if (trackBar14.Value > 0)
            {
                translateY = 1f;
            }
            else
            {
                translateY = -1f;
            }
            trackBar14.Value = 0;
            translateOn(point1);
            translateOn(point2);
            translateOn(point3);
            translateOn(point4);
            translateOn(point5);
            translateOn(point6);
            translateOn(point7);
            translateOn(point8);
            updateSquare();
            translateY = 0;
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void textBox39_KeyDown(object sender, KeyEventArgs e)
        {
            textBox36.Text += e.KeyCode.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button7_Click(sender, e);
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            changed28 = true;
        }

        private void trackBar13_Scroll(object sender, EventArgs e)
        {
            scaleFactor = trackBar13.Value / 100.0;
            textBox27.Text = scaleFactor.ToString();
            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);

        }
        private void translateOn(double[] pointToTranslate)
        {
            double[,] translate =
            {
                { 1,0,0,translateX },
                {0,1,0,translateY },
                {0,0,1,translateZ },
                {0,0,0,1 }
            };
            double[] tempMatrix = multiply4x1Matrix(translate, new double[] { pointToTranslate[0], pointToTranslate[1], pointToTranslate[2], 1 });

            pointToTranslate[0] = tempMatrix[0];
            pointToTranslate[1] = tempMatrix[1];
            pointToTranslate[2] = tempMatrix[2];
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = (int.Parse(textBox3.Text) * int.Parse(textBox6.Text) + int.Parse(textBox4.Text) * int.Parse(textBox9.Text) + int.Parse(textBox5.Text) * int.Parse(textBox12.Text)).ToString();
            textBox16.Text = (int.Parse(textBox3.Text) * int.Parse(textBox7.Text) + int.Parse(textBox4.Text) * int.Parse(textBox10.Text) + int.Parse(textBox5.Text) * int.Parse(textBox13.Text)).ToString();
            textBox17.Text = (int.Parse(textBox3.Text) * int.Parse(textBox8.Text) + int.Parse(textBox4.Text) * int.Parse(textBox11.Text) + int.Parse(textBox5.Text) * int.Parse(textBox14.Text)).ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = (int.Parse(textBox3.Text) * int.Parse(textBox6.Text) + int.Parse(textBox4.Text) * int.Parse(textBox9.Text) + int.Parse(textBox5.Text) * int.Parse(textBox12.Text)).ToString();
            textBox16.Text = (int.Parse(textBox3.Text) * int.Parse(textBox7.Text) + int.Parse(textBox4.Text) * int.Parse(textBox10.Text) + int.Parse(textBox5.Text) * int.Parse(textBox13.Text)).ToString();
            textBox17.Text = (int.Parse(textBox3.Text) * int.Parse(textBox8.Text) + int.Parse(textBox4.Text) * int.Parse(textBox11.Text) + int.Parse(textBox5.Text) * int.Parse(textBox14.Text)).ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox15.Text = (int.Parse(textBox3.Text) * int.Parse(textBox6.Text) + int.Parse(textBox4.Text) * int.Parse(textBox9.Text) + int.Parse(textBox5.Text) * int.Parse(textBox12.Text)).ToString();
            textBox16.Text = (int.Parse(textBox3.Text) * int.Parse(textBox7.Text) + int.Parse(textBox4.Text) * int.Parse(textBox10.Text) + int.Parse(textBox5.Text) * int.Parse(textBox13.Text)).ToString();
            textBox17.Text = (int.Parse(textBox3.Text) * int.Parse(textBox8.Text) + int.Parse(textBox4.Text) * int.Parse(textBox11.Text) + int.Parse(textBox5.Text) * int.Parse(textBox14.Text)).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            rotateOnZ(point1);
            rotateOnZ(point2);
            rotateOnZ(point3);
            rotateOnZ(point4);
            rotateOnZ(point5);
            rotateOnZ(point6);
            rotateOnZ(point7);
            rotateOnZ(point8);

            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (changed18)
            {
                camera[0] = int.Parse(textBox18.Text);
            }
            if (changed19)
            {
                camera[1] = int.Parse(textBox19.Text);
            }
            if (changed20)
            {
                camera[2] = int.Parse(textBox20.Text);
            }
            if (changed21)
            {
                viewerV[0] = int.Parse(textBox21.Text);
            }
            if (changed22)
            {
                viewerV[1] = int.Parse(textBox22.Text);
            }
            if (changed23)
            {
                viewerV[2] = int.Parse(textBox23.Text);
            }
            if (changed28)
            {
                viewerV[3] = int.Parse(textBox28.Text);
            }
            changed18 = false;
            changed19 = false;
            changed20 = false;
            changed21 = false;
            changed22 = false;
            changed23 = false;
            changed28 = false;

            textBox18.Text = camera[0].ToString();
            textBox19.Text = camera[1].ToString();
            textBox20.Text = camera[2].ToString();
            textBox21.Text = viewerV[0].ToString();
            textBox22.Text = viewerV[1].ToString();
            textBox23.Text = viewerV[2].ToString();
            textBox28.Text = viewerV[3].ToString();

            trackBar7.Value = (int)camera[0];
            trackBar8.Value = (int)camera[1];
            trackBar9.Value = (int)camera[2];
            trackBar10.Value = (int)viewerV[0];
            trackBar11.Value = (int)viewerV[1];
            trackBar12.Value = (int)viewerV[2];
            trackBar17.Value = (int)viewerV[3] * 100;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rotateOnY(point1);
            rotateOnY(point2);
            rotateOnY(point3);
            rotateOnY(point4);
            rotateOnY(point5);
            rotateOnY(point6);
            rotateOnY(point7);
            rotateOnY(point8);

            updateSquare();
            this.Refresh();
            DrawSquare(myPoints);
        }

        static PointF yAxis2D = new PointF((float)(-Math.Sin(theta) * yAxisD[0] + Math.Cos(theta) * yAxisD[1] + 0) + 250, (float)(-Math.Cos(theta) * Math.Sin(phi) * yAxisD[0] + (-Math.Sin(theta) * Math.Sin(phi)) * yAxisD[1] + Math.Cos(phi) * yAxisD[2]) + 250);



        PointF[] myPoints = {
                point21,
                point22,
                point23,
                point24,
                point25,
                point26,
                point27,
                point28,
                zAxis2U,
                zAxis2D,
                xAxis2U,
                xAxis2D,
                yAxis2U,
                yAxis2D,
                origin2
            };

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            pE.X = e.X;
            pE.Y = e.Y;
            gra = this.CreateGraphics();
            if (checkBox1.Checked)
            {
                gra.DrawLine(new Pen(Color.Blue, penWitdh), pS, pE);
            }
            else if (checkBox2.Checked)
            {
                int rW, rH;
                if (pE.X > pS.X)
                {
                    rW = pE.X - pS.X;
                }
                else
                {
                    rW = pS.X - pE.X;
                    pS.X -= rW;
                }
                if (pE.Y > pS.Y)
                {
                    rH = pE.Y - pS.Y;
                }
                else
                {
                    rH = pS.Y - pE.Y;
                    pS.Y -= rH;
                }

                Rectangle MyRect = new Rectangle(pS.X,pS.Y,rW,rH);
                
                gra.DrawRectangle(new Pen(Color.Blue, penWitdh), MyRect);
            }
            
            gra.Dispose();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            pS.X = e.X;
            pS.Y = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create points that define polygon.
            PointF point1 = new PointF(50.0F, 50.0F);
            PointF point2 = new PointF(123.0F, 25.0F);
            PointF point3 = new PointF(250.0F, 5.0F);
            PointF point4 = new PointF(250.0F, 50.0F);
            PointF point5 = new PointF(325.0F, 120.0F);
            PointF point6 = new PointF(350.0F, 225.0F);
            PointF point7 = new PointF(50.0F, 76.0F);

            PointF[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5,
                 point6,
                 point7
             };

            
            // Draw polygon curve to screen.
            gra = this.CreateGraphics();
            gra.DrawPolygon(blackPen, curvePoints);
            
            gra.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            point1[0] = 50;     point1[1] = 50;     point1[2] = 0;
            point2[0] = 50;     point2[1] = 200;    point2[2] = 0;
            point3[0] = 200;    point3[1] = 200;    point3[2] = 0;
            point4[0] = 200;    point4[1] = 50;     point4[2] = 0;
            point5[0] = 50;     point5[1] = 50;     point5[2] = -150;
            point6[0] = 50;     point6[1] = 200;    point6[2] = -150;
            point7[0] = 200;    point7[1] = 200;    point7[2] = -150;
            point8[0] = 200;    point8[1] = 50;     point8[2] = -150;

            this.Refresh();
            theta = float.Parse(textBox1.Text);
            phi = float.Parse(textBox2.Text);
            updateSquare();


            DrawSquare(myPoints);

            Matrix4f M1 = new Matrix4f(new float[,]{
                {1, 0, 2, 0 },
                {1,-1, 4, 0 },
                {3, 3, 2, 0 },
                {0, 0, 0, 1 }
            });
            Matrix4f M2 = new Matrix4f(new float[,]{
                {7,   -3,  -1, 0 },
                {-5,   2,   1, 0 },
                {-3, 3.0f/2.0f, 1.0f/2.0f, 0 },
                {0,    0,   0, 1 }
            });

            Matrix4f r1 = M1 * M2;
            MessageBox.Show("test");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            theta = trackBar1.Value / 1000.0F;
            textBox1.Text = theta.ToString();
            theta = float.Parse(textBox1.Text);
            phi = float.Parse(textBox2.Text);
            updateSquare();

            this.Refresh();
            DrawSquare(myPoints);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            phi = trackBar2.Value / 1000.0F;
            textBox2.Text = phi.ToString();
            theta = float.Parse(textBox1.Text);
            phi = float.Parse(textBox2.Text);
            updateSquare();

            this.Refresh();
            DrawSquare(myPoints);
        }

        private void DrawSquare(PointF[] points)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            PointF[] topS = {
                points[0],
                points[1],
                points[2],
                points[3]
            };
            PointF[] bottomS = {
                points[4],
                points[5],
                points[6],
                points[7]
            };
            int penWidth = 3;
            int penWidthAxes = 5;
            gra = this.CreateGraphics();

            double[] mynewp = { point1[0], point1[2], point1[1] };
            PointF tryme = new PointF();
            tryme = pointTransfer(mynewp);


            //if (phi > 0)
            //{
            //    if (theta < 0)
            //    {
            //        gra.DrawLine(new Pen(Color.DarkBlue, penWidthAxes), points[14], points[9]);
            //        gra.DrawLine(new Pen(Color.Blue, penWidthAxes), points[8], points[14]);
            //        gra.DrawLine(new Pen(Color.IndianRed, penWidthAxes), points[14], points[11]);
            //        gra.DrawLine(new Pen(Color.Red, penWidthAxes), points[10], points[14]);
            //    }
            //    gra.FillPolygon(new SolidBrush(Color.CadetBlue), topS);

            //    gra.DrawLine(new Pen(Color.Green, penWidthAxes), points[12], points[13]);
            //    gra.DrawLine(new Pen(Color.Yellow, penWidth), points[2], points[6]);
            //    gra.DrawLine(new Pen(Color.Yellow, penWidth), points[3], points[7]);
            //    gra.DrawLine(new Pen(Color.Green, penWidth), points[0], points[4]);
            //    gra.DrawLine(new Pen(Color.Green, penWidth), points[1], points[5]);
            //    gra.FillPolygon(new SolidBrush(Color.OrangeRed), bottomS);
            //    if (theta > 0)
            //    {
            //        gra.DrawLine(new Pen(Color.DarkBlue, penWidthAxes), points[14], points[9]);
            //        gra.DrawLine(new Pen(Color.Blue, penWidthAxes), points[8], points[14]);
            //        gra.DrawLine(new Pen(Color.IndianRed, penWidthAxes), points[14], points[11]);
            //        gra.DrawLine(new Pen(Color.Red, penWidthAxes), points[10], points[14]);
            //    }
            //}
            //else
            //{
            //    if (theta < 0)
            //    {
            //        gra.DrawLine(new Pen(Color.DarkBlue, penWidthAxes), points[14], points[9]);
            //        gra.DrawLine(new Pen(Color.Blue, penWidthAxes), points[8], points[14]);
            //        gra.DrawLine(new Pen(Color.IndianRed, penWidthAxes), points[14], points[11]);
            //        gra.DrawLine(new Pen(Color.Red, penWidthAxes), points[10], points[14]);
            //    }
            //    gra.FillPolygon(new SolidBrush(Color.OrangeRed), bottomS);

            //    gra.DrawLine(new Pen(Color.Yellow, penWidth), points[2], points[6]);
            //    gra.DrawLine(new Pen(Color.Yellow, penWidth), points[3], points[7]);
            //    gra.DrawLine(new Pen(Color.Green, penWidth), points[0], points[4]);
            //    gra.DrawLine(new Pen(Color.Green, penWidth), points[1], points[5]);
            //    gra.FillPolygon(new SolidBrush(Color.CadetBlue), topS);
            //    gra.DrawLine(new Pen(Color.Green, penWidthAxes), points[12], points[13]);
            //    if (theta > 0)
            //    {
            //        gra.DrawLine(new Pen(Color.DarkBlue, penWidthAxes), points[14], points[9]);
            //        gra.DrawLine(new Pen(Color.Blue, penWidthAxes), points[8], points[14]);
            //        gra.DrawLine(new Pen(Color.IndianRed, penWidthAxes), points[14], points[11]);
            //        gra.DrawLine(new Pen(Color.Red, penWidthAxes), points[10], points[14]);
            //    }
            //}
            //gra.DrawLine(new Pen(Color.DarkBlue, penWidthAxes), points[0], tryme);
            //32 - 33 , 34 - 35
            textBox32.Text = points[12].X.ToString();
            textBox33.Text = points[12].Y.ToString();
            textBox34.Text = points[13].X.ToString();
            textBox35.Text = points[13].Y.ToString();

            

            gra.DrawLine(new Pen(Color.Green, penWidthAxes), points[12], points[13]);
            gra.DrawLine(new Pen(Color.DarkBlue, penWidthAxes), points[14], points[9]);
            gra.DrawLine(new Pen(Color.Blue, penWidthAxes), points[8], points[14]);
            gra.DrawLine(new Pen(Color.IndianRed, penWidthAxes), points[14], points[11]);
            gra.DrawLine(new Pen(Color.Red, penWidthAxes), points[10], points[14]);
            /////
            
            gra.DrawLine(new Pen(Color.Black, penWidth), points[0], points[1]);
            gra.DrawLine(new Pen(Color.Black, penWidth), points[1], points[2]);
            gra.DrawLine(new Pen(Color.Black, penWidth), points[2], points[3]);
            gra.DrawLine(new Pen(Color.Black, penWidth), points[3], points[0]);

            gra.DrawLine(new Pen(Color.Black, penWidth), points[0], points[4]);
            gra.DrawLine(new Pen(Color.Black, penWidth), points[1], points[5]);
            gra.DrawLine(new Pen(Color.Black, penWidth), points[2], points[6]);
            gra.DrawLine(new Pen(Color.Black, penWidth), points[3], points[7]);

            gra.DrawLine(new Pen(Color.Black, penWidth), points[4], points[5]);
            gra.DrawLine(new Pen(Color.Black, penWidth), points[5], points[6]);
            gra.DrawLine(new Pen(Color.Black, penWidth), points[6], points[7]);
            gra.DrawLine(new Pen(Color.Black, penWidth), points[7], points[4]);
            
            
            //int fontsize = (int)(10 * scaleFactor);
            //if (fontsize <= 0)
            //{
            //    fontsize = 1;
            //}
            //gra.DrawString("+X", new Font("Arial", fontsize), new SolidBrush(Color.Black), textXXp);
            //gra.DrawString("+Y", new Font("Arial", fontsize), new SolidBrush(Color.Black), textYYp);
            //gra.DrawString("+Z", new Font("Arial", fontsize), new SolidBrush(Color.Black), textZZp);
            //gra.DrawString("-X", new Font("Arial", fontsize), new SolidBrush(Color.Black), textXXm);
            //gra.DrawString("-Y", new Font("Arial", fontsize), new SolidBrush(Color.Black), textYYm);
            //gra.DrawString("-Z", new Font("Arial", fontsize), new SolidBrush(Color.Black), textZZm);
            //gra.DrawLine(new Pen(Color.Red, 5), points[14], viewerF);

            gra.Dispose();
            blackPen.Dispose();
        }
        private PointF pointTransfer(double[] pointT)
        {
            float ar = (float)this.Width / (float)this.Height;
            float nearZ = (float)camOri[0];
            float farZ = (float)camOri[1];

            float FOV = (float)viewerV[3];
            Vector4f cameraPos = new Vector4f(new float[] { (float)viewerV[0], (float)viewerV[1], (float)viewerV[2], 1});
            Vector4f lookPos = new Vector4f(new float[] { (float)camera[0], (float)camera[1], (float)camera[2], 1 });
            Vector4f upPos = new Vector4f(new float[] { 0, 0, -1, 1 });
            float vAngle = (float)camV[0];
            float hAngle = (float)camV[2];
            Vector4f direction = new Vector4f(new float[]
            {
                (float)(Math.Cos(vAngle) * Math.Sin(hAngle)),
                (float)(Math.Sin(vAngle)),
                (float)(Math.Cos(vAngle) * Math.Cos(hAngle)),
                1
            });

            Vector4f right = new Vector4f(new float[]
            {
                (float)(Math.Sin(hAngle - Math.PI/2.0)),
                0,
                (float)(Math.Cos(hAngle - Math.PI/2.0)),
                1
            });
            Vector4f upHead = GetCross(right, direction);

            Matrix4f viewMat = GetView(cameraPos, lookPos + direction, upPos);

            Matrix4f model = new Matrix4f(1.0f);

            Matrix4f projection = GetPerspective(FOV, ar, nearZ, farZ);

            Matrix4f mainMatrix = projection * viewMat * model;

           




            double x = camV[0], y = camV[1], z = camV[2], w = viewerV[3];
            double[,] quaternionMat =
            {
                {1-(y*y)-(z*z),   x*y-z*w,          x*z+y*w,0 },
                {x*y+z*w,         1-(x*x)-(z*z),    y*z-x*w ,0 },
                {x*z-y*w,         y*z+x*w,          1-(x*x)-(y*y),0 },
                { 0, 0,                 0,                     1}
            };

            //double S = 1 / (Math.Tan((viewerV[1] / 2) * (Math.PI / 180)));
            //double[,] fustrum =
            //{
            //    {S,0,0,0 },
            //    {0,S,0,0 },
            //    {0,0,-(viewerV[2]/(viewerV[2]-viewerV[3])),-1 },
            //    {0,0,-((viewerV[2]*viewerV[3])/(viewerV[2]-viewerV[3])),0 }
            //};

            double[,] fustrum =
            {
                {1,          0,         -viewerV[0]/viewerV[2],  0 },
                {0,          1,         -viewerV[1]/viewerV[2],  0 },
                {0,          0,          1,                      0 },
                {0,          0,         -1/viewerV[2],           1 }
            };

            double[,] scaling =
            {
                {scaleFactor, 0,           0,           0 },
                {0,           scaleFactor, 0,           0 },
                {0,           0,           scaleFactor, 0 },
                {0,           0,           0,           1 }
            };
            

            PointF temporaryPF;
            if (checkBox7.Checked)
            {
                temporaryPF = new PointF((float)(-Math.Sin(theta) * pointT[0] + Math.Cos(theta) * pointT[1]) + (this.Width / 2), (float)(-Math.Cos(theta) * Math.Sin(phi) * pointT[0] + (-Math.Sin(theta) * Math.Sin(phi)) * pointT[1] + Math.Cos(phi) * pointT[2]) + (this.Height / 2));
                return temporaryPF;
            }
            else
            {
                //////////////////////
                ////Origin
                ////double[,] tempMat1 = multiply3x3Matrix(pers1, pers2);
                ////double[,] tempMat2 = multiply3x3Matrix(tempMat1, pers3);

                //double[,] tempMatCam = multiplyMats(multiplyMats(camPersX, camPersY), camPersZ);

                //double newPX = pointT[0] - camera[0];
                //double newPY = pointT[1] - camera[1];
                //double newPZ = pointT[2] - camera[2];
                ////double[] pointNewMat = multiply3x1Matrix(tempMat2,new double[] { newPX, newPY, newPZ });


                ////double[,] pointNewMatCam = multiplyMats(tempMatCam, new double[,] { { newPX }, { newPY }, { newPZ }, { 1 }  });
                //double[,] pointNewMatCam = multiplyMats(tempMatCam, new double[,] { { newPX }, { newPY }, { newPZ }, { 1 } });


                //temporaryPF = new PointF();

                ////double[] tempCoord = { pointNewMat[0], pointNewMat[1], pointNewMat[2], 1 };
                ////double[] tempCoord = new double[] { newPX, newPY, newPZ, 1 };
                ////double[] tempMatFustrum = multiply4x1Matrix(fustrum, pointNewMatCam);
                //double[,] tempMatFustrum = multiplyMats(fustrum, pointNewMatCam);
                //temporaryPF.X = (float)(tempMatFustrum[0,0] / (tempMatFustrum[3,0])) + this.Width / 2;
                //temporaryPF.Y = (float)(tempMatFustrum[1,0] / (tempMatFustrum[3,0])) + this.Height / 2;
                ////////////////////////
                float halfTanFOV = (float)Math.Tan((Math.PI * (FOV / 2.0) / 180.0));
                Vector4f result = mainMatrix * (new Vector4f(new float[] { (float)pointT[0], (float)pointT[1], (float)pointT[2], 1.0f }));
                temporaryPF = new PointF();
                temporaryPF.X = (float)(result[0] / (result[2] * halfTanFOV)) + this.Width / 2;
                temporaryPF.Y = (float)(result[1] / (result[2] * halfTanFOV)) + this.Height / 2;

            }
            return temporaryPF;

        }
        private double[,] multiply3x3Matrix(double[,] mat1,double[,] mat2)
        {
            double [,] tempMatResult=
            {
                { (mat1[0,0]*mat2[0,0])+(mat1[0,1]*mat2[1,0])+(mat1[0,2]*mat2[2,0]), (mat1[0,0]*mat2[0,1])+(mat1[0,1]*mat2[1,1])+(mat1[0,2]*mat2[2,1]), (mat1[0,0]*mat2[0,2])+(mat1[0,1]*mat2[1,2])+(mat1[0,2]*mat2[2,2]) },
                { (mat1[1,0]*mat2[0,0])+(mat1[1,1]*mat2[1,0])+(mat1[1,2]*mat2[2,0]), (mat1[1,0]*mat2[0,1])+(mat1[1,1]*mat2[1,1])+(mat1[1,2]*mat2[2,1]), (mat1[1,0]*mat2[0,2])+(mat1[1,1]*mat2[1,2])+(mat1[1,2]*mat2[2,2]) },
                { (mat1[2,0]*mat2[0,0])+(mat1[2,1]*mat2[1,0])+(mat1[2,2]*mat2[2,0]), (mat1[2,0]*mat2[0,1])+(mat1[2,1]*mat2[1,1])+(mat1[2,2]*mat2[2,1]), (mat1[2,0]*mat2[0,2])+(mat1[2,1]*mat2[1,2])+(mat1[2,2]*mat2[2,2]) }
            };
            return tempMatResult;
        }

        private double[] multiply3x1Matrix(double[,] mat1, double[] mat2)
        {
            double[] tempMatResult =
            {
                (mat1[0,0]*mat2[0])+(mat1[0,1]*mat2[1])+(mat1[0,2]*mat2[2]),
                (mat1[1,0]*mat2[0])+(mat1[1,1]*mat2[1])+(mat1[1,2]*mat2[2]),
                (mat1[2,0]*mat2[0])+(mat1[2,1]*mat2[1])+(mat1[2,2]*mat2[2])
            };
            
            return tempMatResult;
        }

        private double[,] multiply4x4Matrix(double[,] mat1, double[,] mat2)
        {
            double[,] tempMatResult =
            {
                { (mat1[0,0]*mat2[0,0])+(mat1[0,1]*mat2[1,0])+(mat1[0,2]*mat2[2,0])+(mat1[0,3]*mat2[3,0]), (mat1[0,0]*mat2[0,1])+(mat1[0,1]*mat2[1,1])+(mat1[0,2]*mat2[2,1])+(mat1[0,3]*mat2[3,1]), (mat1[0,0]*mat2[0,2])+(mat1[0,1]*mat2[1,2])+(mat1[0,2]*mat2[2,2])+(mat1[0,3]*mat2[3,2]), (mat1[0,0]*mat2[0,3])+(mat1[0,1]*mat2[1,3])+(mat1[0,2]*mat2[2,3])+(mat1[0,3]*mat2[3,3]) },
                { (mat1[1,0]*mat2[0,0])+(mat1[1,1]*mat2[1,0])+(mat1[1,2]*mat2[2,0])+(mat1[1,3]*mat2[3,0]), (mat1[1,0]*mat2[0,1])+(mat1[1,1]*mat2[1,1])+(mat1[1,2]*mat2[2,1])+(mat1[1,3]*mat2[3,1]), (mat1[1,0]*mat2[0,2])+(mat1[1,1]*mat2[1,2])+(mat1[1,2]*mat2[2,2])+(mat1[1,3]*mat2[3,2]), (mat1[1,0]*mat2[0,3])+(mat1[1,1]*mat2[1,3])+(mat1[1,2]*mat2[2,3])+(mat1[1,3]*mat2[3,3]) },
                { (mat1[2,0]*mat2[0,0])+(mat1[2,1]*mat2[1,0])+(mat1[2,2]*mat2[2,0])+(mat1[2,3]*mat2[3,0]), (mat1[2,0]*mat2[0,1])+(mat1[2,1]*mat2[1,1])+(mat1[2,2]*mat2[2,1])+(mat1[2,3]*mat2[3,1]), (mat1[2,0]*mat2[0,2])+(mat1[2,1]*mat2[1,2])+(mat1[2,2]*mat2[2,2])+(mat1[2,3]*mat2[3,2]), (mat1[2,0]*mat2[0,3])+(mat1[2,1]*mat2[1,3])+(mat1[2,2]*mat2[2,3])+(mat1[2,3]*mat2[3,3]) },
                { (mat1[3,0]*mat2[0,0])+(mat1[3,1]*mat2[1,0])+(mat1[3,2]*mat2[2,0])+(mat1[3,3]*mat2[3,0]), (mat1[3,0]*mat2[0,1])+(mat1[3,1]*mat2[1,1])+(mat1[3,2]*mat2[2,1])+(mat1[3,3]*mat2[3,1]), (mat1[3,0]*mat2[0,2])+(mat1[3,1]*mat2[1,2])+(mat1[3,2]*mat2[2,2])+(mat1[3,3]*mat2[3,2]), (mat1[3,0]*mat2[0,3])+(mat1[3,1]*mat2[1,3])+(mat1[3,2]*mat2[2,3])+(mat1[3,3]*mat2[3,3]) },
            };
            return tempMatResult;
        }
        private double[] multiply4x1Matrix(double[,] mat1, double[] mat2)
        {
            double[] tempMatResult =
            {
                (mat1[0,0]*mat2[0]) + (mat1[0,1]*mat2[1]) + (mat1[0,2]*mat2[2]) + (mat1[0,3]*mat2[3]),
                (mat1[1,0]*mat2[0]) + (mat1[1,1]*mat2[1]) + (mat1[1,2]*mat2[2]) + (mat1[1,3]*mat2[3]),
                (mat1[2,0]*mat2[0]) + (mat1[2,1]*mat2[1]) + (mat1[2,2]*mat2[2]) + (mat1[2,3]*mat2[3]),
                (mat1[3,0]*mat2[0]) + (mat1[3,1]*mat2[1]) + (mat1[3,2]*mat2[2]) + (mat1[3,3]*mat2[3])
            };
            return tempMatResult;
        }

        private double[] multiply43x1Matrix(double[,] mat1, double[] mat2)
        {
            double[] tempMatResult =
            {
                (mat1[0,0]*mat2[0]) + (mat1[0,1]*mat2[1]) + (mat1[0,2]*mat2[2])+ (mat1[0,3]*mat2[3]),
                (mat1[1,0]*mat2[0]) + (mat1[1,1]*mat2[1]) + (mat1[1,2]*mat2[2])+ (mat1[1,3]*mat2[3]),
                (mat1[2,0]*mat2[0]) + (mat1[2,1]*mat2[1]) + (mat1[2,2]*mat2[2])+ (mat1[2,3]*mat2[3]),
            };
            return tempMatResult;
        }

        private double[,] multiplyMats(double[,] mat1,double[,] mat2)
        {
            if (mat1.GetLength(1) != mat2.GetLength(0))
            {
                MessageBox.Show(
                    "Can't multiple a " + mat1.GetLength(0).ToString() + "x" + mat1.GetLength(1).ToString() + " to a " + mat2.GetLength(0).ToString() + "x" + mat2.GetLength(1).ToString() + "matrix",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error // for Warning  
                    //MessageBoxIcon.Error // for Error 
                    //MessageBoxIcon.Information  // for Information
                    //MessageBoxIcon.Question // for Question
                    );

                Environment.Exit(0);
            }
            double[,] newMat = new double[mat1.GetLength(0), mat2.GetLength(1)];

            for (int i = 0; i < newMat.GetLength(0); i++)//0
            {
                for (int j = 0; j < mat2.GetLength(1); j++)//0
                {
                    for (int k = 0; k < mat2.GetLength(0); k++)//0
                    {
                        newMat[i, j] += mat1[i, k] * mat2[k, j];
                    }
                }
            }

            return newMat;
        }

        private void updateSquare()
        {
            point21 = pointTransfer(point1);
            point22 = pointTransfer(point2);
            point23 = pointTransfer(point3);
            point24 = pointTransfer(point4);
            point25 = pointTransfer(point5);
            point26 = pointTransfer(point6);
            point27 = pointTransfer(point7);
            point28 = pointTransfer(point8);
            zAxis2U = pointTransfer(zAxisU);
            zAxis2D = pointTransfer(zAxisD);
            xAxis2U = pointTransfer(xAxisU);
            xAxis2D = pointTransfer(xAxisD);
            yAxis2U = pointTransfer(yAxisU);
            yAxis2D = pointTransfer(yAxisD);
            origin2 = pointTransfer(origin);

            cameraF = pointTransfer(camera);
            viewerF = pointTransfer(viewerV);

            textXXp = pointTransfer(textXp);
            textYYp = pointTransfer(textYp);
            textZZp = pointTransfer(textZp);
            textXXm = pointTransfer(textXm);
            textYYm = pointTransfer(textYm);
            textZZm = pointTransfer(textZm);

            myPoints[0] = point21;
            myPoints[1] = point22;
            myPoints[2] = point23;
            myPoints[3] = point24;
            myPoints[4] = point25;
            myPoints[5] = point26;
            myPoints[6] = point27;
            myPoints[7] = point28;
            myPoints[8] = zAxis2U;
            myPoints[9] = zAxis2D;
            myPoints[10] = xAxis2U;
            myPoints[11] = xAxis2D;
            myPoints[12] = yAxis2U;
            myPoints[13] = yAxis2D;
            myPoints[14] = origin2;


        }

        private Vector4f GetCross(Vector4f left, Vector4f right)
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

        private Matrix4f GetView(Vector4f eye,Vector4f center,Vector4f up)
        {
            Vector4f f = Normalize(center-eye);
            Vector4f s = Normalize(GetCross(f, up));
            Vector4f u = GetCross(s, f);

            Matrix4f result = new Matrix4f(new float[,]
                {
                    {  s[0], s[1], s[2],-DotMatrix(s,eye) },
                    {  u[0], u[1], u[2],-DotMatrix(u,eye) },
                    { -f[0],-f[1],-f[2], DotMatrix(f,eye) },
                    {  0,             0,             0,             1.0f             }
                });

            return result;
        }

        private Vector4f Normalize(Vector4f inV)
        {
            //Vector4f result = inV * (float)(1.0f / Math.Sqrt(DotMatrix(inV,inV)));
            float wLength = (float)Math.Sqrt(Math.Pow(inV[0],2) + Math.Pow(inV[1], 2) + Math.Pow(inV[2], 2));
            Vector4f result = inV *(1.0f/wLength);
            return result;
        }

        private float DotMatrix(Vector4f left, Vector4f right)
        {
            Vector4f multiResult = left * right;
            float result = multiResult[0] + multiResult[1] + multiResult[2];
            
            return result;
        }

        private Matrix4f GetPerspective(float FOV, float ar, float nearZ, float farZ)
        {
            ar = Math.Abs(ar);
            float halfTanFOV = (float)Math.Atan((Math.PI * FOV * 0.5 / 180.0));
            //float halfTanFOV = (float)Math.Tan(FOV*0.5);
            //float h = (float)(Math.Cos(0.5 * FOV) / Math.Sin(0.5 * FOV));
            Matrix4f result = new Matrix4f(new float[,] {
                { 1.0f/(ar * halfTanFOV), 0,                        0,                                0                                  },
                { 0,                      1.0f / (ar * halfTanFOV), 0,                                0                                  },
                { 0,                      0,                       -(farZ + nearZ) / (farZ - nearZ), (2 * farZ * nearZ) / (farZ - nearZ) },
                { 0,                      0,                       -1.0f,                            0.0f                                }
            });
            return result;
        }

    }


}
