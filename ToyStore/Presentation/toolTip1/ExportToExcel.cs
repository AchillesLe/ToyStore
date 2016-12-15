using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using excel=Microsoft.Office.Interop.Excel;
using System.IO;

namespace Presentation.toolTip1
{
    public class ExportToExcel
    {
        public void ExportToExcelFromDatagridview(System.Windows.Forms.DataGridView dgv, string fileName)
        {
            SaveFileDialog sfdSave = new SaveFileDialog();
            sfdSave.Filter = "Excel file(*.xls)|*.xls";
            sfdSave.FileName = fileName;
            sfdSave.Title = "Save to Excel file";

            if (sfdSave.ShowDialog() == DialogResult.OK)
            {
                FileInfo f = new FileInfo(sfdSave.FileName);
                if (f.Exists) f.Delete();

                excel.Application exapp = new excel.Application();
                excel.Workbook exbook = exapp.Workbooks.Add(excel.XlWBATemplate.xlWBATWorksheet);
                excel.Worksheet exSheet = (excel.Worksheet)exbook.Worksheets[1];
                excel.Range cellrange;

                exSheet.Name = fileName;

                //List<string> field = new List<string>();
                //field.Add("MANV"); field.Add("TENNV"); field.Add("NGAYSINH");
                //field.Add("SDT"); field.Add("QUEQUAN"); field.Add("PHAI"); field.Add("CMT");
                cellrange = exSheet.Range[exSheet.Cells[1, 1], exSheet.Cells[dgv.Rows.Count + 1, dgv.Columns.Count]];
                cellrange.NumberFormat = "@";

                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    exSheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                }

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.ColumnCount; j++)
                    {
                        try
                        {
                            exSheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[dgv.Columns[j].HeaderText].Value.ToString();
                        }
                        catch(Exception ex)
                        {

                        }
                        
                    }
                }

                cellrange.EntireColumn.AutoFit();
                exapp.Visible = true;

                exbook.SaveAs(sfdSave.FileName,
                    excel.XlFileFormat.xlWorkbookNormal,
                    null, null, false, false,
                    excel.XlSaveAsAccessMode.xlExclusive,
                    false, false, false, false, false);

                exbook.Close();
                exapp.Quit();
            }
        }

        public void ExportToExcelFromDatagridviewAuto(System.Windows.Forms.DataGridView dgv, string fileName)
        {
            SaveFileDialog sfdSave = new SaveFileDialog();
            sfdSave.Filter = "Excel file(*.xls)|*.xls";
            sfdSave.FileName = fileName;
            sfdSave.Title = "Save to Excel file";

            if (true)
            {
                FileInfo f = new FileInfo(sfdSave.FileName);
                if (f.Exists) f.Delete();

                excel.Application exapp = new excel.Application();
                excel.Workbook exbook = exapp.Workbooks.Add(excel.XlWBATemplate.xlWBATWorksheet);
                excel.Worksheet exSheet = (excel.Worksheet)exbook.Worksheets[1];
                excel.Range cellrange;

                exSheet.Name = fileName;

                //List<string> field = new List<string>();
                //field.Add("MANV"); field.Add("TENNV"); field.Add("NGAYSINH");
                //field.Add("SDT"); field.Add("QUEQUAN"); field.Add("PHAI"); field.Add("CMT");
                cellrange = exSheet.Range[exSheet.Cells[1, 1], exSheet.Cells[dgv.Rows.Count + 1, dgv.Columns.Count]];
                cellrange.NumberFormat = "@";

                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    exSheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                }

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.ColumnCount; j++)
                    {
                        try
                        {
                            exSheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[dgv.Columns[j].HeaderText].Value.ToString();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                cellrange.EntireColumn.AutoFit();
                exapp.Visible = true;

                exbook.SaveAs(sfdSave.FileName,
                    excel.XlFileFormat.xlWorkbookNormal,
                    null, null, false, false,
                    excel.XlSaveAsAccessMode.xlExclusive,
                    false, false, false, false, false);

                exbook.Close();
                exapp.Quit();
            }
        }
    }
}
