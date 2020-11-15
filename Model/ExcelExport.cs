using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Floor.Model
{
    class ExcelExport
    {
        public ExcelExport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public void ExportFloor(ObservableCollection<Floor> floors,FloorInformation floorInformation, string pathTemplate, string fileSave)
        {

            using (ExcelPackage p = new ExcelPackage())
            {
                using (FileStream stream = new FileStream(pathTemplate, FileMode.Open, FileAccess.ReadWrite))
                {
                    p.Load(stream);
                }
                p.Workbook.Properties.Author = "Bá Thanh";
                p.Workbook.Properties.Title = "Thiết kế sàn ";
                ExcelWorksheet ws0 = p.Workbook.Worksheets[0];
                ws0.Cells["H4"].Value = floorInformation.ConcreteName.ToString();
                ws0.Cells["H11"].Value = floorInformation.SteelName.ToString();
                ExcelWorksheet ws1 = p.Workbook.Worksheets[1];
                ws1.Cells["H1"].Value = floorInformation.SlabName;
                ws1.Cells["B4"].Value = floorInformation.ProjectName;
                ws1.Cells["B5"].Value = floorInformation.Address;
                ws1.Cells["K8"].Value = floorInformation.LoadCase.ToString();
                ws1.Cells["K9"].Value = floorInformation.Humidity.ToString();
                ws1.Cells["Q3"].Value = DateTime.Today;
                for (int i = 0; i < 4; i++)
                {
                    int r = 18;
                    ExcelWorksheet ws = p.Workbook.Worksheets[i + 1];
                    foreach (Floor floor in floors)
                    {
                        if (floor == null || floor.SlabProp.Area==null) continue;
                        List<StripForce> strips = floor.StripForcesXY[i];

                        foreach (StripForce strip in strips)
                        {
                            int c = 1;
                            ws.Cells[r, c++].Value = floor.SlabProp.Name+"("+ floor.SlabProp.Area+")";
                            ws.Cells[r, c++].Value = strip.Text;
                            ws.Cells[r, c].Style.Numberformat.Format = "0.00";
                            ws.Cells[r, c++].Value = strip.Station;
                            ws.Cells[r, c++].Value = strip.OutputCase;
                            ws.Cells[r, c].Style.Numberformat.Format = "0.00";
                            ws.Cells[r, c++].Value = strip.M3;
                            ws.Cells[r, c++].Value = strip.Width * 100;
                            ws.Cells[r, c++].Value = floor.SlabProp.Thickness * 100;
                            ws.Cells[r, c++].Value = (float)floorInformation.A/10;
                            ws.Cells[r, c].Style.Numberformat.Format = "0.000";
                            ws.Cells[r, c++].Formula = "=(ABS(E" + r + ")*10^4)/($L$10*$E$8*F" + r + "*(G" + r + "-H" + r + ")^2)";
                            ws.Cells[r, c].Style.Numberformat.Format = "0.000";
                            ws.Cells[r, c++].Formula = "=IF(I" + r + "<=$L$14,0.5*(1+SQRT(1-2*I" + r + ")),\"\")";
                            ws.Cells[r, c].Style.Numberformat.Format = "0.000";
                            ws.Cells[r, c++].Formula = "=IF(J" + r + "=\"\",\"\",(ABS(E" + r + ")*10^4)/($E$11*J" + r + "*(G" + r + "-H" + r + ")))";
                            ws.Cells[r, c].Style.Numberformat.Format = Char.ConvertFromUtf32(248).ToString() + "#";
                            ws.Cells[r, c++].Value = floorInformation.Phi;
                            ws.Cells[r, c].Style.Numberformat.Format = "a#";
                            ws.Cells[r, c++].Value = floorInformation.S;
                            ws.Cells[r, c++].Value = "+";
                            ws.Cells[r, c].Style.Numberformat.Format = Char.ConvertFromUtf32(248).ToString() + "#";
                            ws.Cells[r, c++].Value = 0;
                            ws.Cells[r, c].Style.Numberformat.Format = "a#";
                            ws.Cells[r, c++].Value = floorInformation.S;
                            ws.Cells[r, c].Style.Numberformat.Format = "0.000";
                            ws.Cells[r, c++].Formula = "=IF(P" + r + "=\"\",((F" + r + "*10/M" + r + ")*(0.25*PI()*(L" + r + "/10)^2)),((F" + r + "*10/M" + r + ")*(0.25*PI()*(L" + r + "/10)^2))+((F" + r + "*10/P" + r + ")*(0.25*PI()*(O" + r + "/10)^2)))";
                            ws.Cells[r, c++].Formula = "=IF(Q" + r + ">=K" + r + ",\"OK\",\"NOT OK\")";
                            r++;

                        }
                      //  ws.Cells[r - strips.Count, 1, r-1, 1].Merge = true;
                    }
                    ExcelRange range = ws.Cells[18, 1, r - 1, 18];
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                }
                Byte[] bin = p.GetAsByteArray();
                File.WriteAllBytes(fileSave, bin);
            }

        }
    }
}
