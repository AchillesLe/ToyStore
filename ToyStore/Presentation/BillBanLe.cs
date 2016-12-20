using Bus;
using Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentation
{
    public partial class BillBanLe : Form
    {
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;

        private int so_sp = 0;
        private double tien_tong = 0.0;
        private double tien_du = 0.0;
        private bool luu_status = false;

        AutoCompleteStringCollection col_source;
        HOADON Hd;
        BindingList<DOCHOI> listDC;

        public BillBanLe()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        private void setDefaultValue()
        {
            tb_NnHd.Text = Hd.NGAYHD.ToString("dd - MM - yyyy");
            tb_GioHd.Text = Hd.NGAYHD.ToString("hh : mm : ss");
            tb_slSP.Text = "1";
            cb_masp.Text = "";

            col_source = new AutoCompleteStringCollection();
            DoChoiBus dcBus = new DoChoiBus();
            List<DOCHOI> data = dcBus.dsDoChoi();
            foreach (DOCHOI a in data)
            {
                col_source.Add(a.MADC.ToString());
            }
            cb_masp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_masp.AutoCompleteCustomSource = col_source;
            cb_masp.AutoCompleteSource = AutoCompleteSource.CustomSource;

            tb_Sl.Text = so_sp.ToString();
            tb_tong_tien.Text = tien_tong.ToString();
            tb_khach_tra.Text = tien_tong.ToString();
            tb_tien_du.Text = tien_du.ToString();

            tbl_sp.Refresh();
        }

        private void BillBanLe_Load(object sender, EventArgs e)
        {
            //Start "Add Hoa don"
            HoaDonBus hdBus = new HoaDonBus();
            Hd = new HOADON();
            Hd.MANV = MainMenu.usrId;
            Hd.NGAYHD = DateTime.Now;
            hdBus.AddHoaDon(Hd);
            //End "Add Hoa Don"
            luu_status = false;

            txt_mahd.Text = Hd.MAHD.ToString();
            txt_Manv.Text = MainMenu.usrId.ToString();

            listDC = new BindingList<DOCHOI>();

            tbl_sp.DataSource = listDC;
            tbl_sp.Columns[3].Visible = false;
            tbl_sp.Columns[4].Visible = false;

            tbl_sp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            
            setDefaultValue();
        }

        private void bt_Nhap_Click(object sender, EventArgs e)
        {
            try
            {
                DoChoiBus dcBus = new DoChoiBus();

                DOCHOI dc = new DOCHOI();

                dc = dcBus.DochoiById(int.Parse(cb_masp.Text));

                dc.SL = int.Parse(tb_slSP.Text);
                dc.GIA = ((double)dc.GIA * (double)dc.SL);

                bool c = true;
                foreach (DOCHOI i in listDC)
                {
                    if (dc.MADC == i.MADC)
                    {
                        i.SL += dc.SL;
                        i.GIA += dc.GIA;
                        c = false;
                        break;
                    }
                }

                if (c)
                    listDC.Add(dc);

                so_sp += (int)dc.SL;
                tien_tong += ((double)dc.GIA);

                setDefaultValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (!luu_status)
            {
                btn_huy_Click(sender, e);
                return;
            }

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
            //hide BillBanLe Form
            this.Close();
            ////Show MainMenuForm
            //MainMenu MainMenu = new MainMenu();
            //MainMenu.Show();
        }

        private void show()
        {
            LoginAcounts lg = new LoginAcounts();

        }

        private void bt_tang_Click(object sender, EventArgs e)
        {
            int num;
            num = int.Parse(tb_slSP.Text);
            num++;
            tb_slSP.Text = num.ToString();
        }

        private void bt_giam_Click(object sender, EventArgs e)
        {
            int num;
            num = int.Parse(tb_slSP.Text);
            if (num != 0)
            {
                num--;
                tb_slSP.Text = num.ToString();
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            if (luu_status)
            {
                var confirmResult =
                    MessageBox.Show("Hóa đơn đã được lưu, không thể hủy!!\n Bạn có muốn thoát hay không?",
                                      "WARNING!!",
                                      MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                    goto endhuy;
                else
                    return;
            }
            else
                goto huy;

            huy:
            var confirm =
                     MessageBox.Show("Hóa chưa được lưu!!\n Bạn có muốn HỦY hay không?",
                                       "WARNING!!",
                                       MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No)
                return;
            HoaDonBus hdBus = new HoaDonBus();
            hdBus.delete(Hd.MAHD);

        endhuy:
            this.Close();
        }

        private void tb_slSP_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                int num;
                num = int.Parse(tb_slSP.Text);
                num++;
                tb_slSP.Text = num.ToString();
            }
            else if (e.KeyCode == Keys.Down)
            {
                int num;
                num = int.Parse(tb_slSP.Text);
                if (num != 0)
                {
                    num--;
                    tb_slSP.Text = num.ToString();
                }
            }
        }

        private void tinh_tien_du(object sender, EventArgs e)
        {
            try
            {
                double khtra = double.Parse(tb_khach_tra.Text);
                tien_du = khtra - tien_tong;
                tb_tien_du.Text = tien_du.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tb_khach_tra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tinh_tien_du(sender, e);
            }
        }

        private void bt_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(tbl_sp.SelectedRows[0].Cells[0].Value.ToString());
                var itemToRemove = listDC.Where(x => x.MADC == id).ToList();
                foreach (var item in itemToRemove)
                {
                    listDC.Remove(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_In_Click(object sender, EventArgs e)
        {
            if (luu_status)
            {
                MessageBox.Show("Chưa làm phần này !");
            }
            else
                MessageBox.Show("Bạn chưa lưu!");
        }

        private void bt_excel_Click(object sender, EventArgs e)
        {
            if (luu_status)
            {
                Presentation.toolTip1.ExportToExcel exp = new Presentation.toolTip1.ExportToExcel();
                string name;
                name = Hd.MAHD.ToString() + "_" + Hd.NGAYHD.ToString("yyyy-MM-dd");
                exp.ExportToExcelFromDatagridview(tbl_sp, name);
            }
            else
                MessageBox.Show("Bạn chưa lưu!");
        }

        private void bt_Luu_Click(object sender, EventArgs e)
        {
            if (!luu_status)
            {
                try
                {
                    if (!(listDC.Count > 0)) return;

                    HoaDonBus hdBus = new HoaDonBus();
                    Hd.TRIGIA = tien_tong;
                    hdBus.edit(Hd);
                    
                    CTHDBus ctBus = new CTHDBus();
                    DoChoiBus dcBus = new DoChoiBus();
                    CTHD ct = new CTHD();
                    //*/
                    foreach (DOCHOI it in listDC)
                    {
                        ct.MADC = it.MADC;
                        ct.MAHD = Hd.MAHD;
                        ct.SL = it.SL;
                        ct.GIA = it.GIA;
                        ctBus.addCTHD(ct);
                    }//*/

                    dcBus.reduceDCs(listDC.ToList<DOCHOI>());

                    luu_status = true;

                    MessageBox.Show("Lưu thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.ToString());
                }
            }
            else
                MessageBox.Show("Dữ liệu đã lưu, Bạn không có quyền sửa!");
        }

        private void bt_moi_Click(object sender, EventArgs e)
        {
            listDC.Clear();
            tbl_sp.Refresh();
            so_sp = 0;
            tien_du = 0;
            tien_tong = 0;
            if (luu_status)
                BillBanLe_Load(sender, e);
            else
                setDefaultValue();
        }
    }
}
