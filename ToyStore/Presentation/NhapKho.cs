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
    public partial class NhapKho : Form
    {
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;

        AutoCompleteStringCollection col_source;
        bool masp_avail;
        int tong_sl = 0;
        double tong_giatri = 0;
        DateTime now;
        List<DOCHOI> listDc;
        //BindingList<NHAPKHO> listNk;

        public NhapKho()
        {
            InitializeComponent();
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
            MainMenu mn = new MainMenu();
            mn.Show();
        }

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        private void NhapKho_Load(object sender, EventArgs e)
        {
            tb_Manv.Text = MainMenu.usrId.ToString();
            //listNk = new BindingList<NHAPKHO>();
            //tbl_nk.DataSource = listNk;
            col_source = new AutoCompleteStringCollection();
            DoChoiBus dcBus = new DoChoiBus();
            //listDc = new List<DOCHOI>();
            listDc = dcBus.dsDoChoi();
            foreach (DOCHOI a in listDc)
            {
                col_source.Add(a.MADC.ToString());
            }
            tb_masp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_masp.AutoCompleteCustomSource = col_source;
            tb_masp.AutoCompleteSource = AutoCompleteSource.CustomSource;


            tbl_nk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            now = DateTime.Now;
            tb_NgayNhap.Text = now.ToString("dd - MM - yyyy");
            tb_GioNhap.Text = now.ToString("hh : mm : ss");

            tb_SL.Text = "0";
            tb_TSL.Text = tong_sl.ToString();
            tb_tong_tien.Text = tong_giatri.ToString();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            now = DateTime.Now;
            tb_NgayNhap.Text = now.ToString("dd - MM - yyyy");
            tb_GioNhap.Text = now.ToString("hh : mm : ss");
        }

        private void tb_masp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (!string.IsNullOrEmpty(tb_masp.Text))
                    id = int.Parse(tb_masp.Text);
                else
                    return;

                var li = listDc.Where(i => (i.MADC == id));
                if (li.Count() > 0)
                {
                    masp_avail = true;
                    tb_GiaBan.Text = li.First().GIA.ToString();
                    tb_GiaBan.ReadOnly = masp_avail;
                }
                else
                {
                    masp_avail = false;
                    tb_GiaBan.ReadOnly = masp_avail;
                    tb_GiaBan.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_giam_Click(object sender, EventArgs e)
        {
            moveInt(+1);
        }

        private void bt_tang_Click(object sender, EventArgs e)
        {
            moveInt(-1);
        }

        private void tb_SL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                moveInt(+1);
            else
            if (e.KeyCode == Keys.Down)
                moveInt(-1);
        }

        private void btn_nhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(tb_SL.Text) == 0 || string.IsNullOrEmpty(tb_SL.Text))
                    return;
                if (!masp_avail)
                {
                    DoChoiBus dcBus = new DoChoiBus();
                    DOCHOI dc = new DOCHOI();

                    dc.MADC = int.Parse(tb_masp.Text);
                    dc.SL = 0;
                    dc.GIA = double.Parse(tb_GiaBan.Text);

                    dcBus.AddDoChoi(dc);
                }
                //NHAPKHO nk = new NHAPKHO();
                //nk.MANV = MainMenu.usrId;
                //nk.MADC = int.Parse(tb_masp.Text);
                ////nk.GIONHAP = nk.NGAYNHAP = now;
                //nk.SL = int.Parse(tb_SL.Text);
                //nk.GIA = double.Parse(tb_GiaNhap.Text) * (double)nk.SL;
                //tong_giatri += (double)nk.GIA;
                //tong_sl += (int)nk.SL;

                //listNk.Add(nk);
                refreshDataGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                //NhapKhoBus nkBus = new NhapKhoBus();
                //nkBus.addNhapKho(listNk.ToList());
                //MessageBox.Show("Nhập thành công!!");
                //listNk.Clear();
                refreshDataGrid();
                NhapKho_Load(sender, e);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // addon
        private void refreshDataGrid()
        {
            tb_TSL.Text = tong_sl.ToString();
            tb_tong_tien.Text = tong_giatri.ToString();
            tb_GiaNhap.Clear();
            //tbl_nk.DataSource = listNk;
            tbl_nk.Refresh();
        }

        private void moveInt(int delta)
        {
            try
            {
                int num = int.Parse(tb_SL.Text) + delta;
                num = num < 0 ? 0 : num;
                tb_SL.Text = num.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
