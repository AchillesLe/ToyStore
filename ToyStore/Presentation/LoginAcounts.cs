using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bus;


namespace Presentation
{
    public partial class LoginAcounts : Form
    {
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;
        
       
        public LoginAcounts()
        {
            InitializeComponent();
            tb_matKhau.UseSystemPasswordChar = true;
          //  tb_matKhau.PasswordChar = '*';
        }
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }
        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_exit_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();

        }


        private void tb_matKhau_KeyDown(object sender, KeyEventArgs e)
        {
           
                       if (e.KeyCode == Keys.Enter)
                        bt_enter_Click(null, null);
        }

        private void bt_enter_Click(object sender, EventArgs e)
        {

            AccountBus acBus = new AccountBus();
            string username =(tb_TenDangNhap.Text);
            string pass = tb_matKhau.Text;
           
            if (acBus.checkac(username, pass)==true)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
        
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.Hãy kiểm tra và nhập lại!");
                tb_matKhau.Text = "";
                
            }

        }

        public void getUsername()
        {
            AccountBus acBus = new AccountBus();
            
        }
    }
}
