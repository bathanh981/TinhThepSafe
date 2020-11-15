using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floor.Model
{
    class SlabProp
    {
        private string area, name;
        private double thickness;

        public string Area { get => area; set => area = value; }
        public string Name { get => name; set => name = value; }
        public double Thickness { get => thickness; set => thickness = value; }

        public SlabProp(string text, string name, double thickness)
        {
            this.Area = text;
            this.Name = name;
            this.Thickness = thickness;
        }

        public SlabProp()
        {
        }

        
    }
}
