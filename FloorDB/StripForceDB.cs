using Floor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floor.FloorDB
{
    class StripForceDB
    {
        private List<StripForce> stripForces;

        internal List<StripForce> StripForces { get => stripForces; set => stripForces = value; }

        public StripForceDB(List<StripForce> stripForces)
        {
            StripForces = stripForces;
        }

        public StripForceDB()
        {
        }

        public StripForce GetStripForce(string text)
        {
           return StripForces.First(s => s.Text.Equals(text));
        }
        public List<StripForce> GetStripForcesInPoints(List<Point> points)
        {
            List<StripForce> stripForces = new List<StripForce>();
            StripForces.ForEach(p =>
            {
                if (p.CheckStripInPoints(points)) stripForces.Add(p);
            });

            return stripForces;
        }
    }
}
