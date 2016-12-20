using Bus;
using Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class QuanLiKho : Form
    {

        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;

        bool data_change_status = false;
        List<DOCHOI> listDc;
        NhanVienBus nvbs = new NhanVienBus();
        int manv = MainMenu.usrId;
        public QuanLiKho()
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
        }

        private void Down_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThongKeKho_Load(object sender, EventArgs e)
        {
            DoChoiBus dcBus = new DoChoiBus();
            listDc = new List<DOCHOI>();

            listDc = dcBus.dsDoChoi();
            tbl_DsDc.DataSource = listDc;
            tbl_DsDc.Refresh();
            tbl_DsDc.ClearSelection();

            tb_TenDC.Clear();
            tb_Loai.Clear();
            tb_NuocSX.Clear();
            tb_Gia.Clear();
            tb_SL.Clear();
            if(nvbs.NhanVienByID(manv).MACV!="AD")
            {
                btn_Sua.Hide();
                btn_Xoa.Hide();
            }
        }

        private void tbl_DsDc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                tb_MaDC.Text = tbl_DsDc.SelectedRows[0].Cells["MADC"].Value.ToString();

                tb_TenDC.Text = tbl_DsDc.SelectedRows[0].Cells["TENDC"].Value.ToString();

                if (tbl_DsDc.SelectedRows[0].Cells["LOAI"].Value != null)
                    tb_Loai.Text = tbl_DsDc.SelectedRows[0].Cells["LOAI"].Value.ToString();
                if (tbl_DsDc.SelectedRows[0].Cells["NUOCSX"].Value != null)
                    tb_NuocSX.Text = tbl_DsDc.SelectedRows[0].Cells["NUOCSX"].Value.ToString();

                tb_Gia.Text = tbl_DsDc.SelectedRows[0].Cells["GIA"].Value.ToString();
                tb_SL.Text = tbl_DsDc.SelectedRows[0].Cells["SL"].Value.ToString();

                tb_MaDC.ReadOnly = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void tb_MaDC_Click(object sender, EventArgs e)
        {
            tb_MaDC.ReadOnly = false;
            ThongKeKho_Load(sender, e);
        }

        private void btn_Xem_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tb_MaDC.Text))
            {
                try
                {
                    DoChoiBus dcBus = new DoChoiBus();
                    listDc = dcBus.DSDoChoibyID(int.Parse(tb_MaDC.Text));
                    tbl_DsDc.DataSource = listDc; tbl_DsDc.Refresh();
                    tbl_DsDc.ClearSelection();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                ThongKeKho_Load(sender, e);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbl_DsDc.SelectedRows.Count > 0)
                {
                    if (data_change_status)
                    {
                        DoChoiBus dcBus = new DoChoiBus();
                        DOCHOI dc = new DOCHOI();

                        dc.MADC = (int)tbl_DsDc.SelectedRows[0].Cells["MADC"].Value;
                        dc.TENDC = tb_TenDC.Text;
                        if (string.IsNullOrEmpty(tb_Loai.Text))
                            dc.LOAI = tb_Loai.Text;
                        dc.GIA = double.Parse(tb_Gia.Text);
                        if (string.IsNullOrEmpty(tb_NuocSX.Text))
                            dc.NUOCSX = tb_NuocSX.Text;
                        dc.SL = int.Parse(tb_SL.Text);

                        dcBus.editDC(dc);
                        ThongKeKho_Load(sender, e);
                        MessageBox.Show("Đã sửa thành công!!");
                    }
                    else
                        MessageBox.Show("Chưa có thông tin đc thay đổi!!");
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn Hàng để sửa!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {   
                if(tbl_DsDc.SelectedRows.Count > 0)
                {
                    DoChoiBus dcBus = new DoChoiBus();
                    dcBus.deleteDC((int)tbl_DsDc.SelectedRows[0].Cells["MADC"].Value);
                    ThongKeKho_Load(sender, e);
                    MessageBox.Show("Đã xóa!!");
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn Hàng để xóa!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void tb__TextChanged(object sender, EventArgs e)
        {
            data_change_status = true;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            if (tbl_DsDc.SelectedRows.Count > 0)
                tbl_DsDc_SelectionChanged(sender, e);
            else
                this.Close();
            data_change_status = false;
        }

        private void bt_excel_Click(object sender, EventArgs e)
        {
            if (listDc.Count > 0)
            {
                Presentation.toolTip1.ExportToExcel exp = new toolTip1.ExportToExcel();
                exp.ExportToExcelFromDatagridview(tbl_DsDc, "ds_dochoi_" + DateTime.Now.ToString("dd-MM-yyyy"));
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!!");
            }
        }

        private void bt_In_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa có module máy in!!");
        }
    }
}
