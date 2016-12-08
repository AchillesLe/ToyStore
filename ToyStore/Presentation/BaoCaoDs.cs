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
    public partial class BaoCaoDs : Form
    {
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;
        public BaoCaoDs()
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
            MainMenu mn = new MainMenu();
            mn.Show();
        }

        private void Down_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void back_Click(object sender, EventArgs e)
        {
            // hide this Form
            this.Close();
            //Show MainMenuForm
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
        }
    }
}
