using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floor.FloorDB
{
    class FloorDB
    {
        private PointDB pointDB;
        private SlabPropDB slabPropDB;
        private StripForceDB stripForceDB;
        private GeneralAreaDB generalAreaDB;

        private static FloorDB instance;
        internal PointDB PointDB { get => pointDB; set => pointDB = value; }
        internal SlabPropDB SlabPropDB { get => slabPropDB; set => slabPropDB = value; }
        internal StripForceDB StripForceDB { get => stripForceDB; set => stripForceDB = value; }
        internal GeneralAreaDB GeneralAreaDB { get => generalAreaDB; set => generalAreaDB = value; }
        internal static FloorDB Instance { get { if (instance == null) instance = new FloorDB(); return instance; } set => instance = value; }

        public FloorDB()
        {
            PointDB = new PointDB();
            SlabPropDB = new SlabPropDB();
            StripForceDB = new StripForceDB();
            GeneralAreaDB = new GeneralAreaDB();
        }
        public Model.Floor GetFloor(string text)
        {
            if (text != null)
            {
                Model.Floor floor = new Model.Floor();
                floor.SlabProp = SlabPropDB.GetSlabPropByText(text);
                floor.GeneralArea = generalAreaDB.GetGeneralArea(text);
                floor.StripForces = new ObservableCollection<Model.StripForce>(StripForceDB.GetStripForcesInPoints(floor.GeneralArea.Points));
                floor.SetStripForces();
                return floor;
            }
            return null;
        }

    }
}
