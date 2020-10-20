using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_task3_
{
    class Segment
    {
        public static void drawMyCircle(Graphics g, int diameter)
        {
            Brush brush = new SolidBrush(Color.Blue);
            g.FillEllipse(brush, 0, 0, diameter, diameter);
        }

        public static void drawMySegment(Graphics g, int height, int radius)
        {
            int diameter = radius * 2;
            drawMyCircle(g, diameter);
            Brush brush = new SolidBrush(Color.WhiteSmoke);
            
            Rectangle rectangle = new Rectangle(0, height, diameter, diameter);

            g.FillRectangle(brush, rectangle);
        }
    }
}
