using Floor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floor.FloorDB
{
    class PointDB
    {
        private  List<Point> points;

        internal  List<Point> Points { get => points; set => points = value; }

        public PointDB(List<Point> points)
        {
            Points = points;
        }

        public PointDB()
        {
        }

        public Point GetPoint(string text)
        {
           return Points.First(p => p.Text.Equals(text));
        }

    }
}
