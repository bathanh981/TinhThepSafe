using Floor.FloorDB;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Floor.Model
{
    class Excelmport
    {
        private ExcelPackage package;

        public Excelmport(string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            this.package = new ExcelPackage(new FileInfo(path));
        }

        public StripForceDB GetForceFloorToFile()
        {
            List<StripForce> stripForces = new List<StripForce>();
            ExcelWorksheet ws = package.Workbook.Worksheets["Strip Forces"];
            for (int i = ws.Dimension.Start.Row + 3; i <= ws.Dimension.End.Row; i++)
            {
                StripForce stripForce = new StripForce();
                try
                {
                    int j = 1;
                    stripForce.Text = ws.Cells[i, j++].Value.ToString();
                    stripForce.Station = Double.Parse(ws.Cells[i, j++].Value.ToString());
                    stripForce.Location = ws.Cells[i, j++].Value.ToString();
                    stripForce.OutputCase = ws.Cells[i, j++].Value.ToString();
                    stripForce.CaseType = ws.Cells[i, j++].Value.ToString();
                    stripForce.P = Double.Parse(ws.Cells[i, j++].Value.ToString());
                    stripForce.V2 = Double.Parse(ws.Cells[i, j++].Value.ToString());
                    stripForce.T = Double.Parse(ws.Cells[i, j++].Value.ToString());
                    stripForce.M3 = Double.Parse(ws.Cells[i, j++].Value.ToString());
                    stripForce.X = Double.Parse(ws.Cells[i, j++].Value.ToString());
                    stripForce.Y = Double.Parse(ws.Cells[i, j++].Value.ToString());
                    stripForce.Width = Double.Parse(ws.Cells[i, j++].Value.ToString());
                    stripForces.Add(stripForce);
                }
                catch (Exception e)
                {

                }

            }
            return new StripForceDB(stripForces);
        }

        public PointDB GetPoint()
        {
            List<Point> listpoint = new List<Point>();
            ExcelWorksheet ws = package.Workbook.Worksheets["Obj Geom - Point Coordinates"];
            for (int i = ws.Dimension.Start.Row + 3; i <= ws.Dimension.End.Row; i++)
            {
                Point point = new Point();
                try
                {
                    int j = 1;
                    point.Text = ws.Cells[i, j++].Value.ToString();
                    point.X = Double.Parse(ws.Cells[i, j++].Value.ToString());
                    point.Y = Double.Parse(ws.Cells[i, j++].Value.ToString());
                    listpoint.Add(point);
                }
                catch (Exception e)
                {

                }

            }
            return new PointDB(listpoint);
        }
        public GeneralAreaDB GetGeneralAreas()
        {
            List<GeneralArea> listGeneralArea = new List<GeneralArea>();

            ExcelWorksheet ws = package.Workbook.Worksheets["Obj Geom - Areas 01 - General"];
            for (int i = ws.Dimension.Start.Row + 3; i <= ws.Dimension.End.Row; i++)
            {
                try
                {
                    GeneralArea generalArea = null;
                    int j = 1;
                    string text = ws.Cells[i, j++].Value.ToString();
                    string numberPointStr = "";
                    try
                    {
                        numberPointStr = ws.Cells[i, j++].Value.ToString();
                    }
                    catch (Exception e)
                    {

                    }
                    listGeneralArea.ForEach(p =>
                    {
                        if (p.Text.Equals(text)) generalArea = p;
                    });
                    if (generalArea == null)
                    {
                        generalArea = new GeneralArea();
                        generalArea.Text = text;
                        generalArea.NumberPoint = Int32.Parse(numberPointStr);
                        listGeneralArea.Add(generalArea);
                    }

                    for (int k = 1; k <= 4; k++)
                    {
                        string str = ws.Cells[i, j++].Value.ToString();
                        if (!str.Equals(""))
                        {
                            generalArea.Points.Add(FloorDB.FloorDB.Instance.PointDB.GetPoint(str));
                        }
                    }
                }
                catch (Exception e)
                {

                }

            }
            return new GeneralAreaDB(listGeneralArea);
        }

        public SlabPropDB GetSlabPropDB()
        {
            List<SlabProp> listSlabProp = new List<SlabProp>();

            ExcelWorksheet ws = package.Workbook.Worksheets["Slab Property Assignments"];
            for (int i = ws.Dimension.Start.Row + 3; i <= ws.Dimension.End.Row; i++)
            {
                try
                {
                    int j = 1;
                    string text = ws.Cells[i, j++].Value.ToString();
                    string name = ws.Cells[i, j++].Value.ToString();
                    SlabProp slabProp = new SlabProp()
                    {
                        Name = name,
                        Area = text
                    };
                    listSlabProp.Add(slabProp);
                }
                catch (Exception e)
                {

                }

            }


            ExcelWorksheet ws1 = package.Workbook.Worksheets["Slab Prop 02 - Solid Slabs"];
            for (int i = ws1.Dimension.Start.Row + 3; i <= ws1.Dimension.End.Row; i++)
            {
                try
                {

                    int j = 1;
                    string name = ws1.Cells[i, j++].Value.ToString();
                    j += 2;
                    double thickness = Double.Parse(ws1.Cells[i, j++].Value.ToString());
                    listSlabProp.ForEach(p =>
                    {
                        if (p.Name.Equals(name)) p.Thickness = thickness; ;
                    });
                   
                }
                catch (Exception e)
                {

                }

            }

            return new SlabPropDB(listSlabProp);
        }



    }

}

