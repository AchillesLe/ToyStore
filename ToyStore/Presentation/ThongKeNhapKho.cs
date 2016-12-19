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
    public partial class ThongKeNhapKho : Form
    {
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;

        bool data_change = false;
        List<PHIEUNHAP> listPN;
        BindingList<CTPHIEUNHAP> listCT;
        List<CTPHIEUNHAP> deleted_item;
        List<CTPHIEUNHAP> changed_item;

        public ThongKeNhapKho()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        private void Down_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThongKeNhapKho_Load(object sender, EventArgs e)
        {
            PhieuNhapBus phieuBus = new PhieuNhapBus();

            listPN = new List<PHIEUNHAP>();
            listCT = new BindingList<CTPHIEUNHAP>();
            deleted_item = new List<CTPHIEUNHAP>();
            changed_item = new List<CTPHIEUNHAP>();

            tbl_DsPhieuNhap.DataSource = phieuBus.dsPhieuNhap();
            tbl_DsPhieuNhap.Refresh();
            tbl_CtPhieuNhap.DataSource = listCT;
            tbl_CtPhieuNhap.Refresh();

            tbl_CtPhieuNhap.Columns[0].Visible = false;
            tbl_CtPhieuNhap.Columns[2].ReadOnly = false;

            dtp_from.Value = DateTime.Parse("01/01/2000");
            dtp_to.Value = DateTime.Now;
            load_DsPhieuNhap_From_To();
        }


        private void dtp__ValueChanged(object sender, EventArgs e)
        {
            load_DsPhieuNhap_From_To();
        }

        private void bt_Xoa_Click(object sender, EventArgs e)
        {
            if (!(tbl_DsPhieuNhap.SelectedRows.Count > 0)) return;
            try
            {
                PhieuNhapBus phBus = new PhieuNhapBus();
                phBus.deletePhieuNhap((int)tbl_DsPhieuNhap.SelectedRows[0].Cells["MAPHIEU"].Value);
                MessageBox.Show("Đã Xóa Phiếu Nhập!!");
                load_DsPhieuNhap_From_To();
                data_change = false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_Sua_Click(object sender, EventArgs e)
        {
            if (data_change)
            {
                try
                {
                    CTPhieuNhapBus ctBus = new CTPhieuNhapBus();
                    if (changed_item.Count > 0)
                        foreach (CTPHIEUNHAP it in changed_item)
                        {
                            ctBus.editCTPhieuNhap(it);
                        }
                    if (deleted_item.Count > 0)
                        foreach (CTPHIEUNHAP it in deleted_item)
                        {
                            ctBus.deleteCTPhieuNhap(it);
                        }

                    int maphieu = (int)tbl_DsPhieuNhap.SelectedRows[0].Cells["MAPHIEU"].Value;
                    load_CtPhieuNhapByid(maphieu);
                    MessageBox.Show("Sửa thành công!");
                    data_change = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa sửa thông gì!");
            }
        }

        private void bt_moi_Click(object sender, EventArgs e)
        {
            if (!(tbl_DsPhieuNhap.SelectedRows.Count > 0)) return;
            int maphieu = (int)tbl_DsPhieuNhap.SelectedRows[0].Cells["MAPHIEU"].Value;
            load_CtPhieuNhapByid(maphieu);
            data_change = false;
        }
        
        private void bt_XoaNhieu_Click(object sender, EventArgs e)
        {
            if (!(tbl_CtPhieuNhap.SelectedRows.Count > 0)) return;
            CTPHIEUNHAP ct = new CTPHIEUNHAP();
            ct.GIANHAP = (double)tbl_CtPhieuNhap.SelectedRows[0].Cells["GIANHAP"].Value;
            ct.MADC = (int)tbl_CtPhieuNhap.SelectedRows[0].Cells["MADC"].Value;
            ct.MAPHIEU = (int)tbl_CtPhieuNhap.SelectedRows[0].Cells["MAPHIEU"].Value;
            ct.SL = (int)tbl_CtPhieuNhap.SelectedRows[0].Cells["SL"].Value;

            deleted_item.Add(ct);
            listCT.Remove(ct);
            tbl_CtPhieuNhap.Refresh();
            data_change = true;
        }

        private void bt_excel_Click(object sender, EventArgs e)
        {
            Presentation.toolTip1.ExportToExcel exp = new toolTip1.ExportToExcel();
            if (!(tbl_DsPhieuNhap.SelectedRows.Count > 0)) return;
            string fname;
            fname = "phieu_nhap_kho_"+tbl_DsPhieuNhap.SelectedRows[0].Cells["MAPHIEU"].Value.ToString();

            exp.ExportToExcelFromDatagridview(tbl_CtPhieuNhap, fname);
        }

        private void bt_In_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa Có!!");
        }

        private void tbl_DsPhieuNhap_DoubleClick(object sender, EventArgs e)
        {
            if (!(tbl_DsPhieuNhap.SelectedRows.Count > 0)) return;
            int maphieu = (int)tbl_DsPhieuNhap.SelectedRows[0].Cells["MAPHIEU"].Value;
            load_CtPhieuNhapByid(maphieu);
        }

        private void tbl_CtPhieuNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(!(tbl_CtPhieuNhap.SelectedRows.Count > 0)) return;
            CTPHIEUNHAP ct = new CTPHIEUNHAP();
            ct.GIANHAP = (double)tbl_CtPhieuNhap.SelectedRows[0].Cells["GIANHAP"].Value;
            ct.MADC = (int)tbl_CtPhieuNhap.SelectedRows[0].Cells["MADC"].Value;
            ct.MAPHIEU = (int)tbl_CtPhieuNhap.SelectedRows[0].Cells["MAPHIEU"].Value;
            ct.SL = (int)tbl_CtPhieuNhap.SelectedRows[0].Cells["SL"].Value;

            changed_item.Add(ct);
            data_change = true;
        }
        // ADD_ON FUNCTION

        private void load_DsPhieuNhap_From_To()
        {
            PhieuNhapBus phieuBus = new PhieuNhapBus();

            tbl_DsPhieuNhap.DataSource = phieuBus.dsPhieuNhap(dtp_from.Value, dtp_to.Value);
            tbl_DsPhieuNhap.Refresh();
            tbl_DsPhieuNhap.ClearSelection();
            listCT.Clear();
            tbl_CtPhieuNhap.Refresh();
        }

        private void load_CtPhieuNhapByid(int maphieu)
        {
            CTPhieuNhapBus ctPhieuBus = new CTPhieuNhapBus();
            listCT = new BindingList<CTPHIEUNHAP>(ctPhieuBus.dsPhieuNhapByID(maphieu));
            tbl_CtPhieuNhap.DataSource = listCT;
            tbl_CtPhieuNhap.Refresh();
        }
    } 
}
