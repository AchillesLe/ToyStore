using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus;
using Dto;
namespace Presentation
{
   
    public partial class ThongTinNv : Form
    {
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;
        public static string UserName_infor;
        
        public ThongTinNv()
        {
            InitializeComponent();
            txt_newpass.Visible = false;
            txt_pass.Visible = false;
            txt_comfirmpass.Visible = false;
            bt_Huy.Visible = false;
            bt_Luu.Visible = false;
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
        }

        private void ThongTinNv_Load(object sender, EventArgs e)
        {
            int id;
            string name = UserName_infor;
            AccountBus acbus = new AccountBus();
            ACCOUNT ac = new ACCOUNT();
            ac= acbus.ACCOUNTByName(name);
            id = ac.ID;
            NhanVienBus nvbus = new NhanVienBus();               
            NHANVIEN nv = new NHANVIEN();
            nv = nvbus.NhanVienByID(id);
            txt_manv.Text = nv.MANV.ToString();
            if (nv.PHAI == "Nam")
            {
                rd_nam.Checked = true;
                rd_nu.Enabled = false;
            }
            else
            {
                rd_nu.Checked = true;
                rd_nam.Enabled = false;
            }

            txt_CMND.Text = nv.CMT;
            txt_DiaChi.Text = nv.QUEQUAN;
            txt_hoten.Text = nv.TENNV;
            txt_NgayLam.Text = nv.NGAYVAOLAM.ToString();
            DateTime d = Convert.ToDateTime(txt_NgayLam.Text);
            txt_NgayLam.Text = d.ToString("MM/dd/yyyy");
            txt_ngaysinh.Text = nv.NGAYSINH.ToString();
            DateTime dm = Convert.ToDateTime(txt_ngaysinh.Text);
            txt_ngaysinh.Text = dm.ToString("MM/dd/yyyy");
            txt_Sdt.Text = nv.SDT;
            txt_user.Text = ac.USERNAME;
            txt_pass.Text = ac.PASS;
            txt_newpass.Visible = false;
            txt_pass.Visible = false;
            txt_comfirmpass.Visible = false;
            bt_Huy.Visible = false;
            bt_Luu.Visible = false; 
            
        }

        private void bt_Sua_Click(object sender, EventArgs e)
        {
            bt_Luu.Show();
            bt_Huy.Show();
            ACCOUNT ac = new ACCOUNT();
            AccountBus acBus = new AccountBus();
            try
            {
                ac.ID = Int32.Parse(txt_manv.Text);
                ac.USERNAME = txt_user.Text;
                if ( !txt_comfirmpass.Text.Equals(txt_newpass.Text))
                {
                    MessageBox.Show("Invalid Pass !");
                    return;
                }
                    ac.PASS = txt_comfirmpass.Text;
                if(acBus.editac(ac))
                {
                    MessageBox.Show("Update Successed Password !");
                }
                else
                {
                    MessageBox.Show("Update not Successed Password !");
                    return;
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("Invalid Pass!");
            }
           
        }
    }
}
