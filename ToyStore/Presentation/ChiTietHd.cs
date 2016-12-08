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
    public partial class ChiTietHd : Form
    {
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;
        public ChiTietHd()
        {
            InitializeComponent();
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
            // hide this Form
            this.Close();
            //Show MainMenuForm
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
        }
        
        private void rd_MaHd_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rd_NgayHd_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
