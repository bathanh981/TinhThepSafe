using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floor.Model
{
    /// <summary>
    ///
    /// </summary>
    class StripForce
    {
        private double  station, p, v2, t, m3, x, y, width;
        private string text, location, outputCase, caseType;
        public string Text { get => text; set => text = value; }
        public double Station { get => station; set => station = value; }
        public string Location { get => location; set => location = value; }
        public string OutputCase { get => outputCase; set => outputCase = value; }
        public string CaseType { get => caseType; set => caseType = value; }
        public double P { get => p; set => p = value; }
        public double V2 { get => v2; set => v2 = value; }
        public double T { get => t; set => t = value; }
        public double M3 { get => m3; set => m3 = value; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Width { get => width; set => width = value; }

        public StripForce()
        {
        }

        public StripForce(string test, double station, string location, string outputCase, string caseType, double p, double v2, double t, double m3, double x, double y, double width)
        {
            Text = test;
            Station = station;
            Location = location;
            OutputCase = outputCase;
            CaseType = caseType;
            P = p;
            V2 = v2;
            T = t;
            M3 = m3;
            X = x;
            Y = y;
            Width = width;
        }
        public bool CheckStripInPoints(List<Point> points)
        {
            double xmin= points[0].X, xmax = points[0].X, ymin = points[0].Y, ymax = points[0].Y;
            foreach (Point p in points)
            {
                xmin = (xmin < p.X) ? xmin : p.X;
                xmax = (xmax > p.X) ? xmax : p.X;
                ymin = (ymin < p.Y) ? ymin : p.Y;
                ymax = (ymax > p.Y) ? ymax : p.Y;
            }
                return x <= xmax && x >= xmin && y >= ymin && y <= ymax;
        }

        
    }
}
