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
    public partial class LoginAcounts : Form
    {
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;
        public LoginAcounts()
        {
            InitializeComponent();
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
        private void bt_enter_MouseClick(object sender, MouseEventArgs e)
        {
            //Hide LoginAcountsForm
            Visible = false;
            ShowInTaskbar = false;
            //Show MainMenuForm
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void LoginAcounts_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
