using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floor.Model
{
    class GeneralArea
    {
        private string text;
        private int numberPoint;

        private List<Point> points;

        public string Text { get => text; set => text = value; }
        public int NumberPoint { get => numberPoint; set => numberPoint = value; }
        public List<Point> Points { get => points; set => points = value; }

        public GeneralArea(string text, int numberPoint, List<Point> points)
        {
            Text = text;
            NumberPoint = numberPoint;
            Points = points;
        }

        public GeneralArea()
        {
            Points = new List<Point>();
        }

    }
}
