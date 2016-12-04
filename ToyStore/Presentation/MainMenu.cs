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
    public partial class MainMenu : Form
    {

        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;
        public MainMenu()
        {
            InitializeComponent();
            QuanLiBanHang.Size = new Size(645, 491);
            QuanLiBanHang.Location = new Point(202, 26);
            // chỉ hiện panel chính
            {
                QuanLiSanPham.Hide();
                QuanLiKho.Hide();
                BaoCaoDoanhSo.Hide();
                QuanLiNhanVien.Hide();
            }
            QuanLiBanHang.Show();

        }
        //move window without title bar
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

        private void bt_QuanLiSanPham_Click(object sender, EventArgs e)
        {       
            Hide_Visible(QuanLiSanPham);
            Bt_click(bt_QuanLiSanPham);
        }

        private void bt_QuanLiNhanVien_Click(object sender, EventArgs e)
        {
           
            Hide_Visible(QuanLiNhanVien);
            Bt_click(bt_QuanLiNhanVien);
        }
        public void Hide_Visible(Panel pn)
        {
            if(pn==QuanLiKho)
            {
                QuanLiBanHang.Hide();
                QuanLiNhanVien.Hide();
                QuanLiSanPham.Hide();
                BaoCaoDoanhSo.Hide();
                pn.Size = new Size(645, 491);
                pn.Location = new Point(202, 26);
                pn.Show();
            }
            else if(pn==QuanLiSanPham)
            {
                QuanLiBanHang.Hide();
                QuanLiNhanVien.Hide();
                QuanLiKho.Hide();
                BaoCaoDoanhSo.Hide();
                pn.Size = new Size(645, 491);
                pn.Location = new Point(202, 26);
                pn.Show();
            }
            else if(pn==QuanLiNhanVien)
            {
                QuanLiBanHang.Hide();
                QuanLiKho.Hide();
                QuanLiSanPham.Hide();
                BaoCaoDoanhSo.Hide();
                pn.Size = new Size(645, 491);
                pn.Location = new Point(202, 26);
                pn.Show();
            }
            else  if(pn==QuanLiBanHang)
            {
                QuanLiKho.Hide();
                QuanLiNhanVien.Hide();
                QuanLiSanPham.Hide();
                BaoCaoDoanhSo.Hide();
                pn.Size = new Size(645, 491);
                pn.Location = new Point(202, 26);
                pn.Show();
            }
            else if(pn==BaoCaoDoanhSo)
            {
                QuanLiBanHang.Hide();
                QuanLiNhanVien.Hide();
                QuanLiSanPham.Hide();
                QuanLiKho.Hide();
                pn.Size = new Size(645, 491);
                pn.Location = new Point(202, 26);
                pn.Show();
            }
                
        }
        public void Bt_click(Button bt)
        {
            if(bt==bt_QuanLiKho)
            {
                bt_BanHang.BackColor = TransparencyKey; //mau button khi ko nhap vao
                bt_BaoCaoDoanhSo.BackColor = TransparencyKey;
                bt_QuanLiNhanVien.BackColor = TransparencyKey;
                bt_QuanLiSanPham.BackColor = TransparencyKey;
                bt.BackColor = Color.FromArgb(26, 188, 156); //mau button khi nhap vao 
            }
            else if(bt==bt_BanHang)
            {
                bt_QuanLiKho.BackColor = TransparencyKey; //mau button khi ko nhap vao
                bt_BaoCaoDoanhSo.BackColor = TransparencyKey;
                bt_QuanLiNhanVien.BackColor = TransparencyKey;
                bt_QuanLiSanPham.BackColor = TransparencyKey;
                bt.BackColor = Color.FromArgb(26, 188, 156); //mau button khi nhap vao 

            }
            else if (bt == bt_QuanLiNhanVien)
            {
                bt_QuanLiKho.BackColor = TransparencyKey; //mau button khi ko nhap vao
                bt_BaoCaoDoanhSo.BackColor = TransparencyKey;
                bt_BanHang.BackColor = TransparencyKey;
                bt_QuanLiSanPham.BackColor = TransparencyKey;
                bt.BackColor = Color.FromArgb(26, 188, 156); //mau button khi nhap vao 

            }
            else if (bt == bt_BaoCaoDoanhSo)
            {
                bt_QuanLiKho.BackColor = TransparencyKey; //mau button khi ko nhap vao
                bt_BanHang.BackColor = TransparencyKey;
                bt_QuanLiNhanVien.BackColor = TransparencyKey;
                bt_QuanLiSanPham.BackColor = TransparencyKey;
                bt.BackColor = Color.FromArgb(26, 188, 156); //mau button khi nhap vao 

            }
            else if (bt == bt_QuanLiSanPham)
            {
                bt_QuanLiKho.BackColor = TransparencyKey; //mau button khi ko nhap vao
                bt_BaoCaoDoanhSo.BackColor = TransparencyKey;
                bt_QuanLiNhanVien.BackColor = TransparencyKey;
                bt_BanHang.BackColor = TransparencyKey;
                bt.BackColor = Color.FromArgb(26, 188, 156); //mau button khi nhap vao 

            }

        }
    }
}
    


