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
            // click vao QuanLiKho
            bt_BanHang.BackColor = TransparencyKey ; //mau button khi ko nhap vao
            bt_BaoCaoDoanhSo.BackColor = TransparencyKey;
            bt_QuanLiKho.BackColor = Color.FromArgb(26, 188, 156); //mau button khi nhap vao
            QuanLiBanHang.Visible = false;
            BaoCao.Visible = false;
            QuanLiKho.Show();
            
        }

        private void bt_BanHang_Click_(object sender, EventArgs e)
        {
            bt_QuanLiKho.BackColor = TransparencyKey ; //mau button khi ko nhap vao
            bt_BaoCaoDoanhSo.BackColor = TransparencyKey;
            bt_BanHang.BackColor = Color.FromArgb(26, 188, 156); //mau button khi nhap vao
            QuanLiKho.Visible = false;
            BaoCao.Visible = false;
            QuanLiBanHang.Show();
        }

        private void bt_BaoCaoDoanhSo_Click(object sender, EventArgs e)
        {
            bt_QuanLiKho.BackColor = TransparencyKey; //mau button khi ko nhap vao
            bt_BanHang.BackColor = TransparencyKey;
            bt_BaoCaoDoanhSo.BackColor = Color.FromArgb(26, 188, 156); //mau button khi nhap vao
            QuanLiKho.Visible = false;
            QuanLiBanHang.Visible = false;
            BaoCao.Show();
        }
    }
}
    


