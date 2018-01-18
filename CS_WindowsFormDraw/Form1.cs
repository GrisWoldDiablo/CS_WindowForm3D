using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_WindowsFormDraw
{
    public partial class Form1 : Form
    {
        Graphics gra = null;
        private Point pS, pE;
        private int penWitdh = 5;
        static float theta = 0, phi = 0;

        static int[] 
            point1 = { 0, 50, 0 },
            point2 = { 0, 200, 0 },
            point3 = { 200, 200, 0 },
            point4 = { 200, 50, 0 },
            point5 = { 0, 50, -150 },
            point6 = { 0, 200, -150 },
            point7 = { 200, 200, -150 },
            point8 = { 200, 50, -150 },
            zAxisU = { 0, 0, 500 },
            zAxisD = { 0, 0, -500 },
            xAxisU = { 500, 0, 0 },
            xAxisD = { -500, 0, 0 },
            yAxisU = { 0, 500, 0 },
            yAxisD = { 0, -500, 0 },
            origin = { 0, 0, 0 };

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            theta = float.Parse(textBox1.Text);
            trackBar1.Value = (int)(float.Parse(textBox1.Text) * 1000);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            // point1 = { 50, 50, 0 },
            // point2 = { 50, 200, 0 },
            // point3 = { 200, 200, 0 },
            // point4 = { 200, 50, 0 },
            // point5 = { 50, 50, -150 },
            // point6 = { 50, 200, -150 },
            // point7 = { 200, 200, -150 },
            // point8 = { 200, 50, -150 },
            double valueRot;
            if (trackBar3.Value > 0)
            {
                valueRot = 0.1;
            }
            else
            {
                valueRot = -0.1;
            }

            int c1=0, c2=1;
            if (checkBox3.Checked)
            {
                c1 = 1;
                c2 = 2;
            }
            else if (checkBox4.Checked)
            {
                c1 = 0;
                c2 = 2;
            }
            else if (checkBox5.Checked)
            {
                c1 = 0;
                c2 = 1;
            }

            // point1
            point1[c1] = (int)Math.Round((Math.Cos(valueRot) * point1[c1]) - ((Math.Sin(valueRot)) * point1[c2]));
            point1[c2] = (int)Math.Round((Math.Sin(valueRot) * point1[c1]) + (Math.Cos(valueRot) * point1[c2]));
            // point2
            point2[c1] = (int)Math.Round((Math.Cos(valueRot) * point2[c1]) - ((Math.Sin(valueRot)) * point2[c2]));
            point2[c2] = (int)Math.Round((Math.Sin(valueRot) * point2[c1]) + (Math.Cos(valueRot) * point2[c2]));
            // point3
            point3[c1] = (int)Math.Round((Math.Cos(valueRot) * point3[c1]) - ((Math.Sin(valueRot)) * point3[c2]));
            point3[c2] = (int)Math.Round((Math.Sin(valueRot) * point3[c1]) + (Math.Cos(valueRot) * point3[c2]));
            // point4
            point4[c1] = (int)Math.Round((Math.Cos(valueRot) * point4[c1]) - ((Math.Sin(valueRot)) * point4[c2]));
            point4[c2] = (int)Math.Round((Math.Sin(valueRot) * point4[c1]) + (Math.Cos(valueRot) * point4[c2]));
            // point5
            point5[c1] = (int)Math.Round((Math.Cos(valueRot) * point5[c1]) - ((Math.Sin(valueRot)) * point5[c2]));
            point5[c2] = (int)Math.Round((Math.Sin(valueRot) * point5[c1]) + (Math.Cos(valueRot) * point5[c2]));
            // point6
            point6[c1] = (int)Math.Round((Math.Cos(valueRot) * point6[c1]) - ((Math.Sin(valueRot)) * point6[c2]));
            point6[c2] = (int)Math.Round((Math.Sin(valueRot) * point6[c1]) + (Math.Cos(valueRot) * point6[c2]));
            // point7
            point7[c1] = (int)Math.Round((Math.Cos(valueRot) * point7[c1]) - ((Math.Sin(valueRot)) * point7[c2]));
            point7[c2] = (int)Math.Round((Math.Sin(valueRot) * point7[c1]) + (Math.Cos(valueRot) * point7[c2]));
            // point8
            point8[c1] = (int)Math.Round((Math.Cos(valueRot) * point8[c1]) - ((Math.Sin(valueRot)) * point8[c2]));
            point8[c2] = (int)Math.Round((Math.Sin(valueRot) * point8[c1]) + (Math.Cos(valueRot) * point8[c2]));

            trackBar3.Value = 0;
            /*
            var rotateX3D = function(theta) {
                var sin_t = sin(theta);
                var cos_t = cos(theta);

                for (var n = 0; n < nodes.length; n++)
                {
                    var node = nodes[n];
                    var y = node[1];
                    var z = node[2];
                    node[1] = y * cos_t - z * sin_t;
                    node[2] = z * cos_t + y * sin_t;
                }
            };*/

            updateSquare();

            this.Refresh();
            DrawSquare(myPoints);
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
            
            
            
            
            if (phi > 0)
            {
                if (theta < 0)
                {
                    gra.DrawLine(new Pen(Color.DarkBlue, penWidthAxes), points[14], points[9]);
                    gra.DrawLine(new Pen(Color.Blue, penWidthAxes), points[8], points[14]);
                    gra.DrawLine(new Pen(Color.IndianRed, penWidthAxes), points[14], points[11]);
                    gra.DrawLine(new Pen(Color.Red, penWidthAxes), points[10], points[14]);
                }
                gra.FillPolygon(new SolidBrush(Color.CadetBlue), topS);
                
                gra.DrawLine(new Pen(Color.Green, penWidthAxes), points[12], points[13]);
                gra.DrawLine(new Pen(Color.Yellow, penWidth), points[2], points[6]);
                gra.DrawLine(new Pen(Color.Yellow, penWidth), points[3], points[7]);
                gra.DrawLine(new Pen(Color.Green, penWidth), points[0], points[4]);
                gra.DrawLine(new Pen(Color.Green, penWidth), points[1], points[5]);
                gra.FillPolygon(new SolidBrush(Color.OrangeRed), bottomS);
                if (theta > 0)
                {
                    gra.DrawLine(new Pen(Color.DarkBlue, penWidthAxes), points[14], points[9]);
                    gra.DrawLine(new Pen(Color.Blue, penWidthAxes), points[8], points[14]);
                    gra.DrawLine(new Pen(Color.IndianRed, penWidthAxes), points[14], points[11]);
                    gra.DrawLine(new Pen(Color.Red, penWidthAxes), points[10], points[14]);
                }
            }
            else
            {
                if (theta < 0)
                {
                    gra.DrawLine(new Pen(Color.DarkBlue, penWidthAxes), points[14], points[9]);
                    gra.DrawLine(new Pen(Color.Blue, penWidthAxes), points[8], points[14]);
                    gra.DrawLine(new Pen(Color.IndianRed, penWidthAxes), points[14], points[11]);
                    gra.DrawLine(new Pen(Color.Red, penWidthAxes), points[10], points[14]);
                }
                gra.FillPolygon(new SolidBrush(Color.OrangeRed), bottomS);
                
                gra.DrawLine(new Pen(Color.Yellow, penWidth), points[2], points[6]);
                gra.DrawLine(new Pen(Color.Yellow, penWidth), points[3], points[7]);
                gra.DrawLine(new Pen(Color.Green, penWidth), points[0], points[4]);
                gra.DrawLine(new Pen(Color.Green, penWidth), points[1], points[5]);
                gra.FillPolygon(new SolidBrush(Color.CadetBlue), topS);
                gra.DrawLine(new Pen(Color.Green, penWidthAxes), points[12], points[13]);
                if (theta > 0)
                {
                    gra.DrawLine(new Pen(Color.DarkBlue, penWidthAxes), points[14], points[9]);
                    gra.DrawLine(new Pen(Color.Blue, penWidthAxes), points[8], points[14]);
                    gra.DrawLine(new Pen(Color.IndianRed, penWidthAxes), points[14], points[11]);
                    gra.DrawLine(new Pen(Color.Red, penWidthAxes), points[10], points[14]);
                }
            }
            
            
            
            gra.Dispose();
            blackPen.Dispose();
        }
        private PointF pointTransfer(int[] pointT)
        {
            PointF temporaryPF = new PointF((float)(-Math.Sin(theta) * pointT[0] + Math.Cos(theta) * pointT[1]) + (this.Width / 2), (float)(-Math.Cos(theta) * Math.Sin(phi) * pointT[0] + (-Math.Sin(theta) * Math.Sin(phi)) * pointT[1] + Math.Cos(phi) * pointT[2]) + (this.Height / 2));
            return temporaryPF;
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
