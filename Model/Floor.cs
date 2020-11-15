using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floor.Model
{
    class Floor:ViewModel.BaseViewModel
    {
        private SlabProp slabProp;
        private ObservableCollection<StripForce> stripForces;
        private GeneralArea generalArea;
        private List<StripForce>[] stripForcesXY;
        public SlabProp SlabProp { get => slabProp; set { slabProp = value; OnPropertyChanged(); } }
        public ObservableCollection<StripForce> StripForces { get => stripForces; set { stripForces = value; OnPropertyChanged(); } }
        public GeneralArea GeneralArea { get => generalArea; set { generalArea = value; OnPropertyChanged(); } }
        public List<StripForce>[] StripForcesXY { get => stripForcesXY; set { stripForcesXY = value; OnPropertyChanged(); } }

        public void SetStripForces()
        {
            StripForcesXY[0] = (StripForces.Where(p => p.Text.Contains("A") && p.M3 < 0).GroupBy(p => p.Text).Select(g => g.OrderByDescending(i => i.M3).First())).ToList();
            StripForcesXY[1] = (StripForces.Where(p => p.Text.Contains("A") && p.M3 > 0).GroupBy(p => p.Text).Select(g => g.OrderByDescending(i => i.M3).First())).ToList();
            StripForcesXY[2] = (StripForces.Where(p => p.Text.Contains("B") && p.M3 < 0).GroupBy(p => p.Text).Select(g => g.OrderByDescending(i => i.M3).First())).ToList();
            StripForcesXY[3] = (StripForces.Where(p => p.Text.Contains("B") && p.M3 > 0).GroupBy(p => p.Text).Select(g => g.OrderByDescending(i => i.M3).First())).ToList();
        }
        public Floor()
        {
            slabProp = new SlabProp();
            stripForces = new ObservableCollection<StripForce>();
            generalArea = new GeneralArea();
            StripForcesXY = new List<StripForce>[4];
         }
      
    }
}
