using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dto;
using Bus;

namespace Presentation
{
    public partial class MainMenu : Form
    {
        int click = 0;
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;
        public static string UserName = String.Empty;
        public static int usrId = -1;
        NhanVienBus nvbus = new NhanVienBus();
        AccountBus ac = new AccountBus();
        public MainMenu()
        {
            InitializeComponent();    
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            QuanLiBanHang.Size = new Size(645, 491);
            QuanLiBanHang.Location = new Point(202, 26);
            bt_BanHang.BackColor = Color.FromArgb(26, 188, 156); //mau button khi nhap vao 
            // chỉ hiện panel chính
            {
                QuanLiKho.Hide();
                BaoCaoDoanhSo.Hide();
                QuanLiNhanVien.Hide();
                pn_DangXuat.Hide();
                pn_ThongBao.Hide();
            }
            QuanLiBanHang.Show();
            bt_Account.Text = UserName;
            ThongTinNv.UserName_infor = bt_Account.Text;
            int ma = ac.ACCOUNTByName(UserName).ID;
            if(nvbus.NhanVienByID(ma).MACV=="NVBH")
            {
                bt_QuanLiNhanVien.Hide();
            }
        }
        public void Hide_Visible(Panel pn)
        {
            if (pn == QuanLiKho)
            {
                QuanLiBanHang.Hide();
                QuanLiNhanVien.Hide();
                BaoCaoDoanhSo.Hide();
                pn.Size = new Size(645, 491);
                pn.Location = new Point(202, 26);
                pn.Show();
            }

            else if (pn == QuanLiNhanVien)
            {
                QuanLiBanHang.Hide();
                QuanLiKho.Hide();
                BaoCaoDoanhSo.Hide();
                pn.Size = new Size(645, 491);
                pn.Location = new Point(202, 26);
                pn.Show();
            }
            else if (pn == QuanLiBanHang)
            {
                QuanLiKho.Hide();
                QuanLiNhanVien.Hide();
                BaoCaoDoanhSo.Hide();
                pn.Size = new Size(645, 491);
                pn.Location = new Point(202, 26);
                pn.Show();
            }
            else if (pn == BaoCaoDoanhSo)
            {
                QuanLiBanHang.Hide();
                QuanLiNhanVien.Hide();
                QuanLiKho.Hide();
                pn.Size = new Size(645, 491);
                pn.Location = new Point(202, 26);
                pn.Show();
            }

        }
        public void Bt_click(Button bt)
        {
            if (bt == bt_QuanLiKho)
            {
                bt_BanHang.BackColor = TransparencyKey; //mau button khi ko nhap vao
                bt_BaoCaoDoanhSo.BackColor = TransparencyKey;
                bt_QuanLiNhanVien.BackColor = TransparencyKey;
                bt.BackColor = Color.FromArgb(26, 188, 156); //mau button khi nhap vao 
            }
            else if (bt == bt_BanHang)
            {
                bt_QuanLiKho.BackColor = TransparencyKey; //mau button khi ko nhap vao
                bt_BaoCaoDoanhSo.BackColor = TransparencyKey;
                bt_QuanLiNhanVien.BackColor = TransparencyKey;
                bt.BackColor = Color.FromArgb(26, 188, 156); //mau button khi nhap vao 

            }
            else if (bt == bt_QuanLiNhanVien)
            {
                bt_QuanLiKho.BackColor = TransparencyKey; //mau button khi ko nhap vao
                bt_BaoCaoDoanhSo.BackColor = TransparencyKey;
                bt_BanHang.BackColor = TransparencyKey;
                bt.BackColor = Color.FromArgb(26, 188, 156); //mau button khi nhap vao 

            }
            else if (bt == bt_BaoCaoDoanhSo)
            {
                bt_QuanLiKho.BackColor = TransparencyKey; //mau button khi ko nhap vao
                bt_BanHang.BackColor = TransparencyKey;
                bt_QuanLiNhanVien.BackColor = TransparencyKey;
                bt.BackColor = Color.FromArgb(26, 188, 156); //mau button khi nhap vao 

            }


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
            Application.Exit();
        }
        private void Down_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void bt_QuanLiKho_Click(object sender, EventArgs e)
        {           
            Hide_Visible(QuanLiKho);
            Bt_click(bt_QuanLiKho);

        }
        private void bt_BanHang_Click_(object sender, EventArgs e)
        {            
            Hide_Visible(QuanLiBanHang);
            Bt_click(bt_BanHang);
        }
        private void bt_BaoCaoDoanhSo_Click(object sender, EventArgs e)
        {           
            Hide_Visible(BaoCaoDoanhSo);
            Bt_click(bt_BaoCaoDoanhSo);
        }
        private void bt_QuanLiNhanVien_Click(object sender, EventArgs e)
        {
           
            Hide_Visible(QuanLiNhanVien);
            Bt_click(bt_QuanLiNhanVien);
        }

        private void bt_HoaDon_Click(object sender, EventArgs e)
        {          
            BillBanLe BillBanLe = new BillBanLe();
            BillBanLe.ShowDialog();
        }
        private void bt_out_Click(object sender, EventArgs e)
        {
            LoginAcounts lg = new LoginAcounts();
            lg.Show();
            this.Close();
        }
        private void bt_XemNv_Click(object sender, EventArgs e)
        {
            QuanLiNhanVien QuanLiNv = new QuanLiNhanVien();
            QuanLiNv.Show();
        }
        private void bt_Account_Click(object sender, EventArgs e)
        {
            click++;
            if (click % 2 != 0) //click chuot thu 1
                pn_DangXuat.Show();
            else //click chuot lan nua
                pn_DangXuat.Hide();
        }
        private void bt_DangXuat_Click(object sender, EventArgs e)
        {
            ////hiện thông báo
            pn_DangXuat.Hide();
            pn_ThongBao.Show();
            pn_ThongBao.BringToFront();
            pn_ThongBao.Location = new Point(380, 163);
           
            {
                pn_menu.Enabled = false;
                QuanLiBanHang.Enabled = false;
                QuanLiKho.Enabled = false;
                QuanLiNhanVien.Enabled = false;
                BaoCaoDoanhSo.Enabled = false;
            }
        }
        private void bt_DongY_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginAcounts logic = new LoginAcounts();
            logic.Show();
        }
        private void bt_huy_Click(object sender, EventArgs e)
        {
            pn_ThongBao.Hide();
            pn_ThongBao.SendToBack();
            //mở lại các chức năng khác
            {
                pn_menu.Enabled = true;
                QuanLiBanHang.Enabled = true;
                QuanLiKho.Enabled = true;
                QuanLiNhanVien.Enabled = true;
                BaoCaoDoanhSo.Enabled = true;
            }
        }
        private void bt_XemThongTin_Click(object sender, EventArgs e)
        {
            ThongTinNv ThongTinNv = new ThongTinNv();
            ThongTinNv.Show();
            pn_DangXuat.Hide();

        }
        private void bt_ThemNv_Click(object sender, EventArgs e)
        {
            QuanLiNhanVien QuanLiNv = new QuanLiNhanVien();
            QuanLiNv.ShowDialog();
        }
        private void bt_CtHd_Click(object sender, EventArgs e)
        {
            ChiTietHd Cthd = new ChiTietHd();
            Cthd.ShowDialog();
            
        }
        private void bt_XemNgay_Click(object sender, EventArgs e)
        {
            BaoCaoDs Bcds = new BaoCaoDs();
            Bcds.ShowDialog();
            
        }
        private void bt_CtSp_Click(object sender, EventArgs e)
        {
            QuanLiKho TKK = new QuanLiKho();
            TKK.ShowDialog();
            
        }
        private void bt_CtKho_Click(object sender, EventArgs e)
        {
            NhapKho TKK = new NhapKho();
            TKK.ShowDialog();
           
        }

        private void pn_DangXuat_MouseLeave(object sender, EventArgs e)
        {
            pn_DangXuat.Hide();
        }

        private void pn_DangXuat_Leave(object sender, EventArgs e)
        {
            pn_DangXuat.Hide();
        }

        private void btn_ThongKeKho_Click(object sender, EventArgs e)
        {
            ThongKeNhapKho TKNK = new ThongKeNhapKho();
            TKNK.ShowDialog();
        }
    }
}
    


