using Floor.Model;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Floor.FloorDB;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Floor.ViewModel
{
    class FloorViewModel:BaseViewModel
    {
        private ObservableCollection<Model.Floor> floors;
        public string pathTemplate = "Thepsan5574-2018.xlsx";
        private FloorInformation floorInformation;
        public ICommand ImportExcel { get; set; }
        public ICommand ExportExcel { get; set; }
        public ObservableCollection<Model.Floor> Floors { get => floors; set { floors = value; OnPropertyChanged(); } }
        public FloorInformation FloorInformation { get => floorInformation; set { floorInformation = value; OnPropertyChanged(); } }
        public FloorViewModel()
        {
            FloorDB.FloorDB.Instance = new FloorDB.FloorDB();
            Floors = new ObservableCollection<Model.Floor>();
            FloorInformation = new FloorInformation();
            ImportExcel = new RelayCommand<object>((p) => { return true; }, (p) => { ImportDataFromExcel(); });
            ExportExcel = new RelayCommand<object>((p) => { return true; }, (p) => { ExportFloor(); });
        }


        public void ImportDataFromExcel()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Excelmport excel = new Excelmport(openFile.FileName);
                    FloorDB.FloorDB.Instance.StripForceDB = excel.GetForceFloorToFile();
                    FloorDB.FloorDB.Instance.PointDB = excel.GetPoint();
                    FloorDB.FloorDB.Instance.GeneralAreaDB = excel.GetGeneralAreas();
                    FloorDB.FloorDB.Instance.SlabPropDB = excel.GetSlabPropDB();
                    if(FloorDB.FloorDB.Instance.StripForceDB.StripForces.Count==0 || 
                        FloorDB.FloorDB.Instance.PointDB.Points.Count==0 || 
                        FloorDB.FloorDB.Instance.GeneralAreaDB.GeneralAreas.Count==0 ||
                        FloorDB.FloorDB.Instance.SlabPropDB.SlabProps.Count == 0)
                    {
                        throw new Exception("Có bảng không có dữ liệu");
                    }
                    RunFloor();
                    MessageBox.Show("Nhập file thành công", "Thông báo");
                }
                catch(Exception)
                {
                    MessageBox.Show("Có lỗi khi Import file. Hãy kiểm tra lại!", "Thông báo");
                }
            }
        }
        public void RunFloor()
        {
            FloorDB.FloorDB.Instance.GeneralAreaDB.GeneralAreas.ForEach(p =>
            {
                if (p != null)
                    Floors.Add(FloorDB.FloorDB.Instance.GetFloor(p.Text));
            });
        }
        public void ExportFloor()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            string filePath = "";
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = dialog.FileName;
            }
            if (string.IsNullOrEmpty(filePath))
            {
                System.Windows.Forms.MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }
            else
            {
                try
                {
                    Model.ExcelExport export = new ExcelExport();

                    export.ExportFloor(Floors,FloorInformation, pathTemplate, filePath);
                    MessageBox.Show("Xuất file thành công", "Thông báo");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Có lỗi khi Export file. Hãy kiểm tra lại!", "Thông báo");
                }

            }
          
        }
    }
}
