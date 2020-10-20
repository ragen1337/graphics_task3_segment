using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics_task3_
{
    public partial class Form1 : Form
    {
        Point p1, p2;
        bool ClickFlag = false;

        Point drawingPoint1 = new Point(0, 0);
        Point drawingPoint2 = new Point(150, 150);

        int radius = 0;
        int height = 0;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
            ClickFlag = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ClickFlag)
            {
                p2 = e.Location;

                int deltaX = p2.X - p1.X;
                int deltaY = p2.Y - p1.Y;

                Point OldPoint = pictureBox1.Location;
                Point NewPoint = new Point(OldPoint.X + deltaX, OldPoint.Y + deltaY);
                pictureBox1.Location = NewPoint;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            clearPictureBox(g);

            pictureBox1.Width += 20;
            pictureBox1.Height += 20;

            numericUpDown1.Maximum += 10;
            numericUpDown2.Maximum += 10;

            height += 10;
            radius += 10;

            numericUpDown1.Text = "" + radius;
            numericUpDown2.Text = "" + height;

            Segment.drawMySegment(g, height, radius);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Width > 30 && pictureBox1.Height > 30)
            {
                Graphics g = pictureBox1.CreateGraphics();

                clearPictureBox(g);

                pictureBox1.Width -= 20;
                pictureBox1.Height -= 20;

                numericUpDown1.Maximum -= 10;
                numericUpDown2.Maximum -= 10;

                height -= 10;
                radius -= 10;

                numericUpDown1.Text = "" + radius;
                numericUpDown2.Text = "" + height;

                Segment.drawMySegment(g, height, radius);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            clearPictureBox(g);

            radius = int.Parse(numericUpDown1.Text);
            height = int.Parse(numericUpDown2.Text);

            Segment.drawMySegment(g, height, radius);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (ClickFlag)
            {
                ClickFlag = false;
            } 
        }

        private void clearPictureBox(Graphics g)
        {
            Brush brush = new SolidBrush(Color.WhiteSmoke);
            Rectangle rectangle = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
            g.FillRectangle(brush, rectangle);
        }
    }
}
