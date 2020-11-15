using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floor.Model
{
    class Point
    {
        private string text;
        private double x, y;

        public string Text { get => text; set => text = value; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public Point(string test, double x, double y)
        {
            this.Text = test;
            this.X = x;
            this.Y = y;
        }

        public Point()
        {
        }

       

    }
}
