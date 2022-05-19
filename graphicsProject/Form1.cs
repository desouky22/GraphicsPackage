namespace graphicsProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e) // CLEAR
        {
            pictureBox1.Image = null;
        }

        public static void DrawLine(double x0, double y0, double xEnd, double yEnd)
        {
            double dx = xEnd - x0, dy = yEnd - y0, steps, k;
            double xIncrement, yIncrement, x = x0, y = y0;

            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);
            xIncrement = (float)(dx) / (float)(steps);
            yIncrement = (float)(dy) / (float)(steps);
            Brush abrush = Brushes.Black;
            Graphics g = Form1.pictureBox1.CreateGraphics();

            g.FillRectangle(abrush, (int)Math.Round((float)x) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (int)Math.Round((float)y), 3, 3);

            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                y += yIncrement;
                g.FillRectangle(abrush, (int)Math.Round((float)x) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (int)Math.Round((float)y), 3, 3);
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e) 
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Aqua);
            g.DrawLine(p, pictureBox1.Size.Width / 2, 0, pictureBox1.Size.Width / 2, pictureBox1.Height);
            g.DrawLine(p, 0, pictureBox1.Size.Height / 2, pictureBox1.Size.Width, pictureBox1.Size.Height / 2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float x0 = int.Parse(textBox2.Text);
            float y0 = int.Parse(textBox1.Text);
            float xEnd = int.Parse(textBox3.Text);
            float yEnd = int.Parse(textBox4.Text);
            DrawLine(x0, y0, xEnd, yEnd);
        }

        public static void lineBres(int x0, int y0, int xEnd, int yEnd)
        {

            int dx = Math.Abs(xEnd - x0), dy = Math.Abs(yEnd - y0);
            int x, y, p = 2 * dy - dx;
            int twoDy = 2 * dy, twoDyMinusDx = 2 * (dy - dx);


            if (x0 > xEnd)
            {
                x = xEnd; y = yEnd; xEnd = x0;
            }
            else
            {
                x = x0; y = y0;
            }
            Brush abrush = Brushes.Black;
            Graphics g = Form1.pictureBox1.CreateGraphics();
            g.FillRectangle(abrush, x + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - y, 3, 3);


            while (x < xEnd)
            {
                x++;
                if (p < 0)
                    p += twoDy;
                else
                {
                    y++;
                    p += twoDyMinusDx;
                }
                g.FillRectangle(abrush, x + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - y, 3, 3);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int x0 = int.Parse(textBox8.Text);
            int y0 = int.Parse(textBox9.Text);
            int xEnd = int.Parse(textBox10.Text);
            int yEnd = int.Parse(textBox11.Text);
            lineBres(x0, y0, xEnd, yEnd);
        }
        public static void circlePlotPoints(float xCenter, float yCenter, float x, float y)
        {
            Brush abrush = Brushes.Black;
            Graphics g = Form1.pictureBox1.CreateGraphics();
            g.FillRectangle(abrush, (float)Math.Round((float)xCenter + x) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (float)Math.Round((float)yCenter + y), 3, 3);
            g.FillRectangle(abrush, (float)Math.Round((float)xCenter - x) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (float)Math.Round((float)yCenter + y), 3, 3);
            g.FillRectangle(abrush, (float)Math.Round((float)xCenter + x) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (float)Math.Round((float)yCenter - y), 3, 3);
            g.FillRectangle(abrush, (float)Math.Round((float)xCenter - x) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (float)Math.Round((float)yCenter - y ), 3, 3);
            g.FillRectangle(abrush, (float)Math.Round((float)xCenter + y) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (float)Math.Round((float)yCenter + x), 3, 3);
            g.FillRectangle(abrush, (float)Math.Round((float)xCenter - y) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (float)Math.Round((float)yCenter + x ), 3, 3);
            g.FillRectangle(abrush, (float)Math.Round((float)xCenter + y) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (float)Math.Round((float)yCenter - x ), 3, 3);
            g.FillRectangle(abrush, (float)Math.Round((float)xCenter - y) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (float)Math.Round((float)yCenter - x), 3, 3);
        }   

        public static void circleMidpoint(float xc, float yc, float r)
        {

            float x = 0, y = r;

            float d = 3 - 2 * r;

               /* Plot first set of points */
            circlePlotPoints(xc, yc, x, y);

            while (y >= x)
            {
                

                x++;

              
                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                    d = d + 4 * x + 6;
                circlePlotPoints(xc, yc, x, y);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float xCenter = int.Parse(textBox5.Text);
            float ycenter = int.Parse(textBox6.Text);
            float reduis = int.Parse(textBox7.Text);
            circleMidpoint( xCenter, ycenter , reduis);
        }

        void ellipsePlotPoints(int xCenter, int yCenter, int x, int y)
        {
            Brush abrush = Brushes.Black;
            Graphics g = Form1.pictureBox1.CreateGraphics();
            g.FillRectangle(abrush, (float) Math.Round((float)xCenter + x) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (float) Math.Round((float)yCenter + y), 3, 3);
            g.FillRectangle(abrush, (float) Math.Round((float)xCenter - x) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (float) Math.Round((float)yCenter + y), 3, 3);
            g.FillRectangle(abrush, (float) Math.Round((float)xCenter + x) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (float) Math.Round((float)yCenter - y), 3, 3);
            g.FillRectangle(abrush, (float) Math.Round((float)xCenter - x) + (pictureBox1.Width / 2), (pictureBox1.Height / 2) - (float) Math.Round((float)yCenter - y), 3, 3);
        }

        void ellipseMidpoint(int xCenter, int yCenter, int Rx, int Ry)
        {
            int Rx2 = Rx * Rx;
            int Ry2 = Ry * Ry;
            int twoRx2 = 2 * Rx2;
            int twoRy2 = 2 * Ry2;
            int p;
            int x = 0;
            int y = Ry;
            int px = 0;
            int py = twoRx2 * y;
            //void ellipsePlotPoints(int, int, int, int);
            /* Plot the initial point in each quadrant. */
            ellipsePlotPoints(xCenter, yCenter, x, y);
            /* Region 1 */
            p = (int)Math.Round(Ry2 - (Rx2 * Ry) + (0.25 * Rx2));
            while (px < py)
            {
                x++;
                px += twoRy2;
                if (p < 0)
                    p += Ry2 + px;
                else
                {
                    y--;
                    py -= twoRx2;
                    p += Ry2 + px - py;
                }
                ellipsePlotPoints(xCenter, yCenter, x, y);
            }
            /* Region 2 */
            p = (int)Math.Round(Ry2 * (x + 0.5) * (x + 0.5) + Rx2 * (y - 1) * (y - 1) - Rx2 * Ry2);
            while (y > 0)
            {
                y--;
                py -= twoRx2;
                if (p > 0)
                    p += Rx2 - py;
                else
                {
                    x++;
                    px += twoRy2;
                    p += Rx2 - py + px;
                }
                ellipsePlotPoints(xCenter, yCenter, x, y);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int xCenter = int.Parse(textBox12.Text);
            int YCenter = int.Parse(textBox13.Text);
            int Rx = int.Parse(textBox14.Text);
            int Ry = int.Parse(textBox15.Text);
            ellipseMidpoint(xCenter, YCenter, Rx, Ry);
        }

        public static bool IsValidTriangle(int x1, int y1, int x2,
                           int y2, int x3, int y3)
        {
            int a = x1 * (y2 - y3)
                  + x2 * (y3 - y1)
                  + x3 * (y1 - y2);

            if (a == 0)
                return false;
            else
                return true;
        }
        private void button6_Click(object sender, EventArgs e)
        {


            int numberOfPoints = 0;
            // point 1
            if (textBox16.Text == null) return;
            int x1 = int.Parse(textBox16.Text);
            if (textBox17.Text == null) return;
            int y1 = int.Parse(textBox17.Text);
            numberOfPoints++;


            // point 2
            if (textBox18.Text == null) return;
            int x2 = int.Parse(textBox18.Text);
            if (textBox19.Text == null) return;
            int y2 = int.Parse(textBox19.Text);
            numberOfPoints++;

            int x3 = -1000, y3 = -1000;
            // point 3
            if (textBox22.Text != "") 
                x3 = int.Parse(textBox22.Text);
            if (textBox23.Text != "") 
                y3 = int.Parse(textBox23.Text);
            if(x3 != -1000 && y3 != -1000)
                numberOfPoints++;

            //point 4
            int x4 = -1000, y4 = -1000;
            if (textBox20.Text != "")
                x4 = int.Parse(textBox20.Text);
            if (textBox21.Text != "")
                y4 = int.Parse(textBox21.Text);

            if (x4 != -1000 && y4 != -1000)
                numberOfPoints++;


            if (numberOfPoints <= 1 || numberOfPoints > 4) return;
            if (numberOfPoints == 2)
            {

                Pen blackPen = new Pen(Color.Black, 3);


                Point p1 = new Point(Convert.ToInt32(x1)+ (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (y1));
                Point p2 = new Point(Convert.ToInt32(x2)+ (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (y2));
                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);


                DrawLine(x1, y1, x2, y2);
            }else if(numberOfPoints == 3 && IsValidTriangle(x1, y1, x2, y2, x3, y3))
            {
                DrawLine(x1, y1, x2, y2);
                DrawLine(x2, y2, x3, y3);
                DrawLine(x3, y3, x1, y1);
            }
            else if(numberOfPoints == 4)
            {
                DrawLine(x1, y1, x2, y2);
                DrawLine(x2, y2, x3, y3);
                DrawLine(x3, y3, x4, y4);
                DrawLine(x4, y4, x1, y1);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // translation
            int numberOfPoints = 0;
            // point 1
            if (textBox16.Text == null) return;
            int x1 = int.Parse(textBox16.Text);
            if (textBox17.Text == null) return;
            int y1 = int.Parse(textBox17.Text);
            numberOfPoints++;


            // point 2
            if (textBox18.Text == null) return;
            int x2 = int.Parse(textBox18.Text);
            if (textBox19.Text == null) return;
            int y2 = int.Parse(textBox19.Text);
            numberOfPoints++;

            int x3 = -1000, y3 = -1000;
            // point 3
            if (textBox22.Text != "")
                x3 = int.Parse(textBox22.Text);
            if (textBox23.Text != "")
                y3 = int.Parse(textBox23.Text);
            if (x3 != -1000 && y3 != -1000)
                numberOfPoints++;

            //point 4
            int x4 = -1000, y4 = -1000;
            if (textBox20.Text != "")
                x4 = int.Parse(textBox20.Text);
            if (textBox21.Text != "")
                y4 = int.Parse(textBox21.Text);

            if (x4 != -1000 && y4 != -1000)
                numberOfPoints++;

            int tx = Convert.ToInt32(textBox24.Text);
            int ty = Convert.ToInt32(textBox25.Text);


            if (numberOfPoints <= 1 || numberOfPoints > 4) return;
            if (numberOfPoints == 2)
            {
                DrawLine(x1+tx, y1+ty, x2+tx, y2+ty);
            }
            else if (numberOfPoints == 3 && IsValidTriangle(x1, y1, x2, y2, x3, y3))
            {
                x1 += tx;
                x2 += tx;
                x3 += tx;
                y1 += ty;
                y2 += ty;
                y3 += ty;
                DrawLine(x1, y1, x2, y2);
                DrawLine(x2, y2, x3, y3);
                DrawLine(x3, y3, x1, y1);
            }
            else if (numberOfPoints == 4)
            {
                x1 += tx;
                x2 += tx;
                x3 += tx;
                x4 += tx;
                y1 += ty;
                y2 += ty;
                y3 += ty;
                y4 += ty;
                DrawLine(x1, y1, x2, y2);
                DrawLine(x2, y2, x3, y3);
                DrawLine(x3, y3, x4, y4);
                DrawLine(x4, y4, x1, y1);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int numberOfPoints = 0;
            // point 1
            if (textBox16.Text == null) return;
            int x1 = int.Parse(textBox16.Text);
            if (textBox17.Text == null) return;
            int y1 = int.Parse(textBox17.Text);
            numberOfPoints++;


            // point 2
            if (textBox18.Text == null) return;
            int x2 = int.Parse(textBox18.Text);
            if (textBox19.Text == null) return;
            int y2 = int.Parse(textBox19.Text);
            numberOfPoints++;

            int x3 = -1000, y3 = -1000;
            // point 3
            if (textBox22.Text != "")
                x3 = int.Parse(textBox22.Text);
            if (textBox23.Text != "")
                y3 = int.Parse(textBox23.Text);
            if (x3 != -1000 && y3 != -1000)
                numberOfPoints++;

            //point 4
            int x4 = -1000, y4 = -1000;
            if (textBox20.Text != "")
                x4 = int.Parse(textBox20.Text);
            if (textBox21.Text != "")
                y4 = int.Parse(textBox21.Text);

            if (x4 != -1000 && y4 != -1000)
                numberOfPoints++;

            double angle = double.Parse(textBox26.Text);
            float sin = (float)Math.Sin((angle * (Math.PI)) / 180);
            float cos = (float)Math.Cos((angle * (Math.PI)) / 180);

            Pen blackPen = new Pen(Color.Black, 3);


            if (numberOfPoints <= 1 || numberOfPoints > 4) return;
            if (numberOfPoints == 2)
            {
                Point point1 = new Point(Convert.ToInt32((x1 * cos) - (y1 * sin) + (pictureBox1.Size.Width / 2)), Convert.ToInt32((pictureBox1.Size.Height / 2) - ((x1 * sin) + (y1 * cos))));
                Point point2 = new Point(Convert.ToInt32((x2 * cos) - (y2 * sin) + (pictureBox1.Size.Width / 2)), Convert.ToInt32((pictureBox1.Size.Height / 2) - ((x2 * sin) + (y2 * cos))));
                pictureBox1.CreateGraphics().DrawLine(blackPen, point1, point2);
            }
            else if (numberOfPoints == 3 && IsValidTriangle(x1, y1, x2, y2, x3, y3))
            {
                Console.WriteLine((x2 * cos) - (y2 * sin) + (pictureBox1.Size.Width / 2));
                Console.WriteLine(Convert.ToInt32((pictureBox1.Size.Height / 2) - ((x2 * sin) + (y2 * cos))));
                Point point2 = new Point(Convert.ToInt32((x2 * cos) - (y2 * sin) + (pictureBox1.Size.Width / 2)),Convert.ToInt32((pictureBox1.Size.Height / 2) - ((x2 * sin) + (y2 * cos))));
                Point point1 = new Point(Convert.ToInt32((x1 * cos) - (y1 * sin) + (pictureBox1.Size.Width / 2)),Convert.ToInt32((pictureBox1.Size.Height / 2) - ((x1 * sin) + (y1 * cos))));
                Point point3 = new Point(Convert.ToInt32((x3 * cos) - (y3 * sin) + (pictureBox1.Size.Width / 2)),Convert.ToInt32((pictureBox1.Size.Height / 2) - ((x3 * sin) + (y3 * cos))));
                pictureBox1.CreateGraphics().DrawLine(blackPen, point1, point2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, point2, point3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, point1, point3);
            }
            else if (numberOfPoints == 4)
            {

                Point p1 = new Point(Convert.ToInt32((x1 * cos) - (y1 * sin)) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (Convert.ToInt32((x1 * sin) + (y1 * cos))));
                Point p2 = new Point(Convert.ToInt32((x2 * cos) - (y2 * sin)) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (Convert.ToInt32((x2 * sin) + (y2 * cos))));
                Point p3 = new Point(Convert.ToInt32((x3 * cos) - (y3 * sin)) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (Convert.ToInt32((x3 * sin) + (y3 * cos))));
                Point p4 = new Point(Convert.ToInt32((x4 * cos) - (y4 * sin)) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (Convert.ToInt32((x4 * sin) + (y4 * cos))));
                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p2, p3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p3, p4);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p4, p1);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int numberOfPoints = 0;
            // point 1
            if (textBox16.Text == null) return;
            int x1 = int.Parse(textBox16.Text);
            if (textBox17.Text == null) return;
            int y1 = int.Parse(textBox17.Text);
            numberOfPoints++;


            // point 2
            if (textBox18.Text == null) return;
            int x2 = int.Parse(textBox18.Text);
            if (textBox19.Text == null) return;
            int y2 = int.Parse(textBox19.Text);
            numberOfPoints++;

            int x3 = -1000, y3 = -1000;
            // point 3
            if (textBox22.Text != "")
                x3 = int.Parse(textBox22.Text);
            if (textBox23.Text != "")
                y3 = int.Parse(textBox23.Text);
            if (x3 != -1000 && y3 != -1000)
                numberOfPoints++;

            //point 4
            int x4 = -1000, y4 = -1000;
            if (textBox20.Text != "")
                x4 = int.Parse(textBox20.Text);
            if (textBox21.Text != "")
                y4 = int.Parse(textBox21.Text);

            if (x4 != -1000 && y4 != -1000)
                numberOfPoints++;

            int ShX = int.Parse(textBox27.Text);


            Pen blackPen = new Pen(Color.Black, 3);


            if (numberOfPoints <= 1 || numberOfPoints > 4) return;
            if (numberOfPoints == 2)
            {
                Point p1 = new Point((x1 + (ShX * y1)) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y1);
                Point p2 = new Point((x2 + (ShX * y2)) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);

            }
            else if (numberOfPoints == 3 && IsValidTriangle(x1, y1, x2, y2, x3, y3))
            {
                Point p1 = new Point((x1 + (ShX * y1)) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y1);
                Point p2 = new Point((x2 + (ShX * y2)) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y2);
                Point p3 = new Point((x3 + (ShX * y3)) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p2, p3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p3, p1);
            }
            else if (numberOfPoints == 4)
            {
                Point p1 = new Point((x1 + (ShX * y1)) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y1);
                Point p2 = new Point((x2 + (ShX * y2)) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y2);
                Point p3 = new Point((x3 + (ShX * y3)) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y3);
                Point p4 = new Point((x4 + (ShX * y4)) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y4);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p2, p3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p3, p4);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p4, p1);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int numberOfPoints = 0;
            // point 1
            if (textBox16.Text == null) return;
            int x1 = int.Parse(textBox16.Text);
            if (textBox17.Text == null) return;
            int y1 = int.Parse(textBox17.Text);
            numberOfPoints++;


            // point 2
            if (textBox18.Text == null) return;
            int x2 = int.Parse(textBox18.Text);
            if (textBox19.Text == null) return;
            int y2 = int.Parse(textBox19.Text);
            numberOfPoints++;

            int x3 = -1000, y3 = -1000;
            // point 3
            if (textBox22.Text != "")
                x3 = int.Parse(textBox22.Text);
            if (textBox23.Text != "")
                y3 = int.Parse(textBox23.Text);
            if (x3 != -1000 && y3 != -1000)
                numberOfPoints++;

            //point 4
            int x4 = -1000, y4 = -1000;
            if (textBox20.Text != "")
                x4 = int.Parse(textBox20.Text);
            if (textBox21.Text != "")
                y4 = int.Parse(textBox21.Text);

            if (x4 != -1000 && y4 != -1000)
                numberOfPoints++;

            int ShY = Convert.ToInt32(textBox28.Text);


            Pen blackPen = new Pen(Color.Black, 3);


            if (numberOfPoints <= 1 || numberOfPoints > 4) return;
            if (numberOfPoints == 2)
            {
                Point p1 = new Point(x1 + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - ((ShY * x1) + y1));
                Point p2 = new Point(x2 + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - ((ShY * x2) + y2));
              
                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);

            }
            else if (numberOfPoints == 3 && IsValidTriangle(x1, y1, x2, y2, x3, y3))
            {
                Point p1 = new Point(x1 + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - ((ShY * x1) + y1));
                Point p2 = new Point(x2 + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - ((ShY * x2) + y2));
                Point p3 = new Point(x3 + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - ((ShY * x3) + y3));



                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p2, p3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p3, p1);
            }
            else if (numberOfPoints == 4)
            {
                Point p1 = new Point(x1 + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - ((ShY * x1) + y1));
                Point p2 = new Point(x2 + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - ((ShY * x2) + y2));
                Point p3 = new Point(x3 + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - ((ShY * x3) + y3));
                Point p4 = new Point(x4 + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - ((ShY * x4) + y4));



                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p2, p3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p3, p4);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p4, p1);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int numberOfPoints = 0;
            // point 1
            if (textBox16.Text == null) return;
            int x1 = int.Parse(textBox16.Text);
            if (textBox17.Text == null) return;
            int y1 = int.Parse(textBox17.Text);
            numberOfPoints++;


            // point 2
            if (textBox18.Text == null) return;
            int x2 = int.Parse(textBox18.Text);
            if (textBox19.Text == null) return;
            int y2 = int.Parse(textBox19.Text);
            numberOfPoints++;

            int x3 = -1000, y3 = -1000;
            // point 3
            if (textBox22.Text != "")
                x3 = int.Parse(textBox22.Text);
            if (textBox23.Text != "")
                y3 = int.Parse(textBox23.Text);
            if (x3 != -1000 && y3 != -1000)
                numberOfPoints++;

            //point 4
            int x4 = -1000, y4 = -1000;
            if (textBox20.Text != "")
                x4 = int.Parse(textBox20.Text);
            if (textBox21.Text != "")
                y4 = int.Parse(textBox21.Text);

            if (x4 != -1000 && y4 != -1000)
                numberOfPoints++;

            int SX = Convert.ToInt32(textBox24.Text);
            int SY = Convert.ToInt32(textBox25.Text);
            Pen blackPen = new Pen(Color.Black, 3);


            if (numberOfPoints <= 1 || numberOfPoints > 4) return;
            if (numberOfPoints == 2)
            {
                Point p1 = new Point((x1 * SX) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (y1 * SY));
                Point p2 = new Point((x2 * SX) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (y2 * SY));

                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
            }
            else if (numberOfPoints == 3 && IsValidTriangle(x1, y1, x2, y2, x3, y3))
            {
                Point p1 = new Point((x1 * SX) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (y1 * SY));
                Point p2 = new Point((x2 * SX) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (y2 * SY));
                Point p3 = new Point((x3 * SX) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (y3 * SY));

                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p2, p3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p3, p1);
            }
            else if (numberOfPoints == 4)
            {
                Point p1 = new Point((x1 * SX) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (y1 * SY));
                Point p2 = new Point((x2 * SX) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (y2 * SY));
                Point p3 = new Point((x3 * SX) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (y3 * SY));
                Point p4 = new Point((x4 * SX) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (y4 * SY));

                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p2, p3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p3, p4);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p4, p1);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int numberOfPoints = 0;
            // point 1
            if (textBox16.Text == null) return;
            int x1 = int.Parse(textBox16.Text);
            if (textBox17.Text == null) return;
            int y1 = int.Parse(textBox17.Text);
            numberOfPoints++;


            // point 2
            if (textBox18.Text == null) return;
            int x2 = int.Parse(textBox18.Text);
            if (textBox19.Text == null) return;
            int y2 = int.Parse(textBox19.Text);
            numberOfPoints++;

            int x3 = -1000, y3 = -1000;
            // point 3
            if (textBox22.Text != "")
                x3 = int.Parse(textBox22.Text);
            if (textBox23.Text != "")
                y3 = int.Parse(textBox23.Text);
            if (x3 != -1000 && y3 != -1000)
                numberOfPoints++;

            //point 4
            int x4 = -1000, y4 = -1000;
            if (textBox20.Text != "")
                x4 = int.Parse(textBox20.Text);
            if (textBox21.Text != "")
                y4 = int.Parse(textBox21.Text);

            if (x4 != -1000 && y4 != -1000)
                numberOfPoints++;

           
            Pen blackPen = new Pen(Color.Black, 3);


            if (numberOfPoints <= 1 || numberOfPoints > 4) return;
            if (numberOfPoints == 2)
            {
                Point p1 = new Point((-1 * x1) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y1);
                Point p2 = new Point((-1 * x2) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y2);

                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
            }
            else if (numberOfPoints == 3 && IsValidTriangle(x1, y1, x2, y2, x3, y3))
            {
                Point p1 = new Point((-1 * x1) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y1);
                Point p2 = new Point((-1 * x2) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y2);
                Point p3 = new Point((-1 * x3) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y3);

                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p2, p3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p3, p1);
            }
            else if (numberOfPoints == 4)
            {
                Point p1 = new Point((-1 * x1) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y1);
                Point p2 = new Point((-1 * x2) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y2);
                Point p3 = new Point((-1 * x3) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y3);
                Point p4 = new Point((-1 * x4) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y4);

                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p2, p3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p3, p4);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p4, p1);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int numberOfPoints = 0;
            // point 1
            if (textBox16.Text == null) return;
            int x1 = int.Parse(textBox16.Text);
            if (textBox17.Text == null) return;
            int y1 = int.Parse(textBox17.Text);
            numberOfPoints++;


            // point 2
            if (textBox18.Text == null) return;
            int x2 = int.Parse(textBox18.Text);
            if (textBox19.Text == null) return;
            int y2 = int.Parse(textBox19.Text);
            numberOfPoints++;

            int x3 = -1000, y3 = -1000;
            // point 3
            if (textBox22.Text != "")
                x3 = int.Parse(textBox22.Text);
            if (textBox23.Text != "")
                y3 = int.Parse(textBox23.Text);
            if (x3 != -1000 && y3 != -1000)
                numberOfPoints++;

            //point 4
            int x4 = -1000, y4 = -1000;
            if (textBox20.Text != "")
                x4 = int.Parse(textBox20.Text);
            if (textBox21.Text != "")
                y4 = int.Parse(textBox21.Text);

            if (x4 != -1000 && y4 != -1000)
                numberOfPoints++;

            
            Pen blackPen = new Pen(Color.Black, 3);


            if (numberOfPoints <= 1 || numberOfPoints > 4) return;
            if (numberOfPoints == 2)
            {
                Point p1 = new Point(( x1) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y1));
                Point p2 = new Point(( x2) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y2));


                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
               

            }
            else if (numberOfPoints == 3 && IsValidTriangle(x1, y1, x2, y2, x3, y3))
            {
                Point p1 = new Point(( x1) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y1));
                Point p2 = new Point(( x2) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y2));
                Point p3 = new Point(( x3) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y3));

                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p2, p3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p3, p1);

            }
            else if (numberOfPoints == 4)
            {
                Point p1 = new Point(( x1) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y1));
                Point p2 = new Point(( x2) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y2));
                Point p3 = new Point(( x3) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y3));
                Point p4 = new Point(( x4) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y4));

                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p2, p3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p3, p4);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p4, p1);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int numberOfPoints = 0;
            // point 1
            if (textBox16.Text == null) return;
            int x1 = int.Parse(textBox16.Text);
            if (textBox17.Text == null) return;
            int y1 = int.Parse(textBox17.Text);
            numberOfPoints++;


            // point 2
            if (textBox18.Text == null) return;
            int x2 = int.Parse(textBox18.Text);
            if (textBox19.Text == null) return;
            int y2 = int.Parse(textBox19.Text);
            numberOfPoints++;

            int x3 = -1000, y3 = -1000;
            // point 3
            if (textBox22.Text != "")
                x3 = int.Parse(textBox22.Text);
            if (textBox23.Text != "")
                y3 = int.Parse(textBox23.Text);
            if (x3 != -1000 && y3 != -1000)
                numberOfPoints++;

            //point 4
            int x4 = -1000, y4 = -1000;
            if (textBox20.Text != "")
                x4 = int.Parse(textBox20.Text);
            if (textBox21.Text != "")
                y4 = int.Parse(textBox21.Text);

            if (x4 != -1000 && y4 != -1000)
                numberOfPoints++;


            Pen blackPen = new Pen(Color.Black, 3);


            if (numberOfPoints <= 1 || numberOfPoints > 4) return;
            if (numberOfPoints == 2)
            {
                Point p1 = new Point((-1 * x1) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y1));
                Point p2 = new Point((-1 * x2) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y2));


                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);


            }
            else if (numberOfPoints == 3 && IsValidTriangle(x1, y1, x2, y2, x3, y3))
            {
                Point p1 = new Point((-1 * x1) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y1));
                Point p2 = new Point((-1 * x2) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y2));
                Point p3 = new Point((-1 * x3) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y3));

                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p2, p3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p3, p1);

            }
            else if (numberOfPoints == 4)
            {
                Point p1 = new Point((-1 * x1) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y1));
                Point p2 = new Point((-1 * x2) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y2));
                Point p3 = new Point((-1 * x3) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y3));
                Point p4 = new Point((-1 * x4) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (-1 * y4));

                pictureBox1.CreateGraphics().DrawLine(blackPen, p1, p2);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p2, p3);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p3, p4);
                pictureBox1.CreateGraphics().DrawLine(blackPen, p4, p1);
            }
        }
    }
}
