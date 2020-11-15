using Floor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floor.FloorDB
{
    class GeneralAreaDB
    {
        private List<GeneralArea> generalAreas;

        internal List<GeneralArea> GeneralAreas { get => generalAreas; set => generalAreas = value; }

        public GeneralAreaDB(List<GeneralArea> generalAreas)
        {
            GeneralAreas = generalAreas;
        }

        public GeneralAreaDB()
        {
            GeneralAreas = new List<GeneralArea>();
        }
        public GeneralArea GetGeneralArea(string text)
        {
            GeneralArea generalArea = null;
            generalAreas.ForEach(p =>
            {
                if (p.Text.Equals(text)) generalArea = p;
            });
            return generalArea;
        }
    }
}
