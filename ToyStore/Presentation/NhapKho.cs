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
        public NhapKho()
        {
            InitializeComponent();
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
            this.Close();
            MainMenu mn = new MainMenu();
            mn.Show();
        }
    }
}
