using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus;
using Dto;

namespace Presentation
{
    public partial class BaoCaoDs : Form
    {
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;
        public static DateTime ngaychon;
        public BaoCaoDs()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mn = new MainMenu();
            mn.Show();
        }

        private void Down_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void back_Click(object sender, EventArgs e)
        {
            // hide this Form
            this.Close();
            //Show MainMenuForm
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
        }

        private void cb_XemNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_XemNgay.Checked)
            {
                lb_TuNgay.Enabled = false;
                txt_tuNgay.Enabled = false;
                txt_denNgay.Enabled = false;
                lb_DenNgay.Enabled = false;
                txt_chonNgay.Visible = true;
            }
                   
        }
        BaoCaoBus bcbus = new BaoCaoBus();
        private void bt_TimNgayHd_Click(object sender, EventArgs e)
        {
            float doanhthu = 0;
            DateTime dayfrom = txt_tuNgay.Value;
            DateTime dayto = txt_denNgay.Value;
            tbl_DsBc.Refresh();
            if (checkbox_XemNgay.Checked)
            {
                tbl_DsBc.DataSource = bcbus.dsBAOCAO(dayto);
            }
            else
            {
                tbl_DsBc.DataSource = bcbus.dsBAOCAO(dayfrom, dayto);
            }

            for (int i = 0; i < tbl_DsBc.RowCount; i++)
            {
                doanhthu += float.Parse(tbl_DsBc.Rows[i].Cells[3].Value.ToString());
            }

        }

        private void BaoCaoDs_Load(object sender, EventArgs e)
        {
            lb_chonngay.Hide();
            txt_chonNgay.Hide();
            int m = DateTime.Now.Month;
            int y = DateTime.Now.Year;
            tbl_DsBc.DataSource = bcbus.dsBAOCAO(DateTime.Parse(string.Format("{0}/1/{1}",m,y)), DateTime.Now);
            txt_tuNgay.Value = DateTime.Parse(string.Format("{0}/1/{1}", m, y));
            txt_denNgay.Value = DateTime.Now;
        }

        private void bt_excel_Click(object sender, EventArgs e)
        {
            toolTip1.ExportToExcel export = new toolTip1.ExportToExcel();
            export.ExportToExcelFromDatagridview(tbl_DsBc,"BaoCaoDoanhSo");
            MessageBox.Show("Export to excel Successed !");
        }
        private void tbl_DsBc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ngaychon = (DateTime)tbl_DsBc.Rows[tbl_DsBc.CurrentCell.RowIndex].Cells[2].Value;
            ChiTietHd cthd = new ChiTietHd();
            cthd.ShowDialog();
        }
    }
}
