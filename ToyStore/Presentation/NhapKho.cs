﻿using Bus;
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
        bool locked = false;

        List<DOCHOI> listDc;
        List<DOCHOI> listNewDC;
        BindingList<CTPHIEUNHAP> listCTPN;
        PHIEUNHAP phieu;
        

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
        }

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        private void NhapKho_Load(object sender, EventArgs e)
        {
            listCTPN = new BindingList<CTPHIEUNHAP>();
            phieu = new PHIEUNHAP();
            
            tbl_nk.DataSource = listCTPN;
            tb_Manv.Text = MainMenu.usrId.ToString();

            col_source = new AutoCompleteStringCollection();
            DoChoiBus dcBus = new DoChoiBus();

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

            PhieuNhapBus phBus = new PhieuNhapBus();
            int s = phBus.dsPhieuNhap().Count;
            if (s == 0)
            {
                phieu.MAPHIEU = 1000;
            }
            else
            phieu.MAPHIEU = phBus.dsPhieuNhap().Last().MAPHIEU+1;

            phieu.MANV = MainMenu.usrId;
            phieu.NGAYNHAP = now;
            phieu.TONGGIA = 0;

            tb_MaPhieu.Text = phieu.MAPHIEU.ToString();
            tb_SL.Text = "0";
            tb_TSL.Text = tong_sl.ToString();
            tb_tong_tien.Text = tong_giatri.ToString();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            if (locked) return;
            now = DateTime.Now;
            phieu.NGAYNHAP = now;
            tb_NgayNhap.Text = now.ToString("dd - MM - yyyy");
            tb_masp.Text = "";
            tb_ncsx.Text = "";
            tb_SL.Text = "0";
            tb_tenDC.Text = "";
            tb_loai.Text = "";
            tb_GiaBan.Text = "";
            tb_GiaNhap.Text = "";
        }

         private void tb_masp_TextChanged(object sender, EventArgs e)
        {
            if (locked) return;
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
                    tb_tenDC.Text = li.First().TENDC;
                    tb_GiaBan.Text = li.First().GIA.ToString();
                    tb_loai.Text = li.First().LOAI;
                    tb_ncsx.Text = li.First().NUOCSX;
                    tb_GiaBan.Text = li.First().GIA.ToString();
                    readOnly(true);
                }
                else
                {
                    masp_avail = false;
                    readOnly(false);
                    tb_loai.Clear();
                    tb_ncsx.Clear();
                    tb_tenDC.Clear();
                    tb_GiaBan.Clear();
                }

                var lj = listCTPN.Where(i => (i.MADC == id));
                if (lj.Count() > 0)
                {
                    //if (string.IsNullOrEmpty(tb_GiaNhap.Text))
                    tb_GiaNhap.Text = (lj.First().GIANHAP / lj.First().SL).ToString();
                    tb_GiaNhap.ReadOnly = true;
                }
                else
                {
                    tb_GiaNhap.Text = "";
                    tb_GiaNhap.ReadOnly = false;
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
            if (locked) return;
            try
            {
                if (string.IsNullOrEmpty(tb_masp.Text) ||
                    string.IsNullOrEmpty(tb_tenDC.Text) || 
                    int.Parse(tb_SL.Text) == 0 || 
                    string.IsNullOrEmpty(tb_SL.Text))
                {
                    MessageBox.Show("Thiếu Dữ Liệu!");
                    return;
                }
                CTPHIEUNHAP ct = new CTPHIEUNHAP();
                if (masp_avail==false)
                {
                    DoChoiBus dcBus = new DoChoiBus();
                    DOCHOI dc = new DOCHOI();

                    dc.MADC = int.Parse(tb_masp.Text);
                    dc.SL = int.Parse(tb_SL.Text);//edit dc.SL=0;
                    dc.GIA = double.Parse(tb_GiaBan.Text);
                    dc.LOAI = tb_loai.Text;
                    dc.NUOCSX = tb_ncsx.Text;
                    dc.TENDC = tb_tenDC.Text;
                   // dcBus.AddDoChoi(dc);

                    listDc.Add(dc);

                    ct.MADC = dc.MADC;
                    ct.MAPHIEU = phieu.MAPHIEU;
                    ct.SL = (int)dc.SL;
                    ct.GIANHAP = double.Parse(tb_GiaNhap.Text)*(double)ct.SL;
                    listCTPN.Add(ct);
                }

                else
                {
                    masp_avail = true;
                    var li = listCTPN.Where(i => i.MADC == ct.MADC);
                    if (li.Count() > 0)
                    {
                        li.First().SL += ct.SL;
                        li.First().GIANHAP += ct.GIANHAP;
                    }
                    ct.MADC = int.Parse(tb_masp.Text);
                    ct.MAPHIEU = phieu.MAPHIEU;
                    ct.SL = int.Parse(tb_SL.Text);
                    ct.GIANHAP = double.Parse(tb_GiaNhap.Text)*(double)ct.SL;
                    
                   
                    listCTPN.Add(ct);
                }

                ///<summary>
                ///hậu
                ///</summary>
                //CTPHIEUNHAP ctph = new CTPHIEUNHAP();
                //ctph.MAPHIEU = phieu.MAPHIEU;
                //ctph.MADC = int.Parse(tb_masp.Text);
                //ctph.SL = int.Parse(tb_SL.Text);
                //ctph.GIANHAP = double.Parse(tb_GiaNhap.Text) * (double)ctph.SL;

                //tong_giatri += (double)ctph.GIANHAP;
                //tong_sl += (int)ctph.SL;

                //var li = listCTPN.Where(i => i.MADC == ctph.MADC);
                //if (li.Count() > 0)
                //{
                //    li.First().SL += ctph.SL;
                //    li.First().GIANHAP += ctph.GIANHAP;
                //}
                //else
                //    listCTPN.Add(ctph);
                tong_giatri += (double)ct.GIANHAP;
                tong_sl += (int)ct.SL;
                refresh();

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
            if (listCTPN.Count<1)
                return;
            try
            {
                if (listDc.Count > 0)
                {
                    DoChoiBus dcbus = new DoChoiBus();

                    dcbus.AddDSDoChoi(listDc);
                }
                PhieuNhapBus phBus = new PhieuNhapBus();
                phieu.TONGGIA = double.Parse(tb_tong_tien.Text);
                phBus.AddPhieuNhap(phieu, listCTPN.ToList<CTPHIEUNHAP>());
               
                MessageBox.Show("Nhập thành công!! \n Locked all Changes!");
                this.Dispose();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // addon
        private void refresh()
        {
            tb_TSL.Text = tong_sl.ToString();
            tb_tong_tien.Text = tong_giatri.ToString();
            tb_masp.Clear();
            tb_GiaNhap.Clear();
            tb_GiaBan.Clear();
            tb_loai.Clear();
            tb_tenDC.Clear();
            tb_ncsx.Clear();
            tbl_nk.Refresh();
            tb_SL.Text = "0";
        }
        private void readOnly(bool e)
        {
            tb_ncsx.ReadOnly = e;
            tb_tenDC.ReadOnly = e;
            tb_loai.ReadOnly = e;
            tb_GiaBan.ReadOnly = e;
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

        private void btn_lam_moi_Click(object sender, EventArgs e)
        {
            listCTPN.Clear();

            tong_sl = 0;
            tong_giatri = 0;

            locked = false;
            btn_lam_moi.Visible = false;
            bt_Luu.Visible = true;

            NhapKho_Load(sender, e);
        }

        private void tb_GiaNhap_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_GiaNhap.Text)) return;
            try
            {
                double giaban = double.Parse(tb_GiaNhap.Text) * (1.0 / 0.78);
                tb_GiaBan.Text = giaban.ToString("0.00");
            }
            catch { }
            
        }

        private void bt_excel_Click(object sender, EventArgs e)
        {
            toolTip1.ExportToExcel excel = new toolTip1.ExportToExcel();
            excel.ExportToExcelFromDatagridview(tbl_nk, string.Format("PhieuKho_{0}_{1}",tb_MaPhieu.Text,DateTime.Now.Date));
            MessageBox.Show("Xuất excel thành công !");
        }

        private void bt_Xoa_Click(object sender, EventArgs e)
        {
            int maDC =Int32.Parse( tbl_nk.Rows[tbl_nk.CurrentCell.RowIndex].Cells[2].Value.ToString());
            int index = tbl_nk.CurrentCell.RowIndex;
            if(listDc.Count>0)
            {
                for(int i=0;i<listDc.Count;i++)
                {
                    if (listDc[i].MADC == maDC)
                        listDc.RemoveAt(i);
                }
            }
            if(listCTPN.Count>0)
            {
                listCTPN.RemoveAt(index);
            }
            tong_sl = tong_sl-int.Parse(tbl_nk.Rows[index].Cells[2].Value.ToString());
            tong_giatri = tong_giatri - double.Parse(tbl_nk.Rows[index].Cells[3].Value.ToString());
            tb_TSL.Text = tong_sl.ToString();
            tb_tong_tien.Text = tong_giatri.ToString();
            tbl_nk.Refresh();
        }
    }
}
