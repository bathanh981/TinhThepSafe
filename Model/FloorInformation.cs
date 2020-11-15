using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floor.Model
{
    class FloorInformation:ViewModel.BaseViewModel
    {
        private string projectName;
        private string address;
        private string concreteName;
        private string steelName;
        private string loadCase;
        private string humidity;
        private int phi;
        private int s;
        private double a;
        private double bStrip;
        private string engineerName;
        private string slabName;
        public string ProjectName { get => projectName; set { projectName = value; OnPropertyChanged(); } }
        public string Address { get => address; set { address = value; OnPropertyChanged(); } }
        public string ConcreteName { get => concreteName; set { concreteName = value; OnPropertyChanged(); } }
        public string SteelName { get => steelName; set { steelName = value; OnPropertyChanged(); } }
        public string LoadCase { get => loadCase; set { loadCase = value; OnPropertyChanged(); } }
        public string Humidity { get => humidity; set { humidity = value; OnPropertyChanged(); } }
        public int Phi { get => phi;set { phi = value; OnPropertyChanged(); } }
        public int S { get => s;set { s = value; OnPropertyChanged(); } }
        public double A { get => a;set { a = value; OnPropertyChanged(); } }
        public double BStrip { get => bStrip; set { bStrip = value; OnPropertyChanged(); } }
        public string EngineerName { get => engineerName; set { engineerName = value; OnPropertyChanged(); } }

        public string SlabName { get => slabName; set => slabName = value; }

        public FloorInformation()
        {
            ProjectName = "Khu Phức Hợp Dịch Vụ Thương Mại Cao Tâng An Hòa.";
            Address = "Phường An Hải Bắc, Q. Sơn Trà, Tp. Đà Nẵng.";
            ConcreteName = "B25";
            SteelName = "CB240T";
            LoadCase = "Dài hạn";
            Humidity = "RH > 75%";
            Phi = 10;
            S = 200;
            A = 25;
            BStrip = 100;
            EngineerName = "Trần Bá Thanh";
            SlabName = "Sàn Điển Hình";
        }
    }
}
