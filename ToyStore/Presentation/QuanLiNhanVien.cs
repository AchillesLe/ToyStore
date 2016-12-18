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
    public partial class QuanLiNhanVien : Form
    {
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;
        //private static int manv;
        public QuanLiNhanVien()
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


        private void Down_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mn = new MainMenu();
            mn.Show();
        }

        private void back_Click(object sender, EventArgs e)
        {
            // hide QuanLiNv Form
            this.Close();
            //Show MainMenuForm
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
        }

        private void loadDSNhanVien()
        {
            NhanVienBus nvBus = new NhanVienBus();
            tbl_NhanVien.DataSource = nvBus.DSNhanVien();
            for (int i = 0; i < tbl_NhanVien.Columns.Count; i++)
            {
                if (tbl_NhanVien.Columns[i].HeaderText == "CHUCVU" || tbl_NhanVien.Columns[i].HeaderText == "HOADONs" || tbl_NhanVien.Columns[i].HeaderText == "ACCOUNT" || tbl_NhanVien.Columns[i].HeaderText == "NHAPKHOes")
                {
                    tbl_NhanVien.Columns.RemoveAt(i);
                }
            }

        }
        //ok
        private void bt_save_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = new NHANVIEN();
            NhanVienBus nvBus = new NhanVienBus();
            nv.MANV = Int32.Parse(txt_manv.Text);

            if (toolTip1.Validation.check_NgaySinh(DateTime.Parse(txt_ngaysinh.Text)))
            {
                nv.NGAYSINH = DateTime.Parse(txt_ngaysinh.Text);
            }
            else
                MessageBox.Show(" Invalid NgaySinh!");              
            if (rd_nam.Checked == true) nv.PHAI = "Nam";
            else nv.PHAI = "Nu";
            nv.QUEQUAN = txt_DiaChi.Text;
            if(toolTip1.Validation.check_Phone(txt_Sdt.Text))
            {
                nv.SDT = txt_Sdt.Text;
            }
            else
                MessageBox.Show("Invalid Mobile Phone !");
            nv.TENNV = txt_hoten.Text;
            if(toolTip1.Validation.Check_cmt(txt_CMND.Text))
            {
                nv.CMT = txt_CMND.Text;
            }
            else
            {
                MessageBox.Show("Invalid Identification !");
            }        
            nv.NGAYVAOLAM = DateTime.Parse(txt_ngayLam.Text);
            ChucVuBus cvbus = new ChucVuBus();
            nv.MACV = cvbus.GetCVbyName(cb_loaiNV.Text).MACV;
            try
            {
                if (nvBus.editNV(nv))
                    MessageBox.Show("Edit successted !");
                else MessageBox.Show("Edit not successted !");
                loadDSNhanVien();
                resettext();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Edit not successted !");
            }
        }
        //ok
        private void bt_them_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = new NHANVIEN();
            NhanVienBus nvBus = new NhanVienBus();
            ACCOUNT ac = new ACCOUNT();
            AccountBus acBus = new AccountBus();
            if (!string.IsNullOrEmpty(txt_manv.Text))
            {
                nv.MANV = Int32.Parse(txt_manv.Text);
            }
            else nv.MANV = 1;
            if (rd_nam.Checked == true) nv.PHAI = "Nam";
            else nv.PHAI = "Nu";
            if (!string.IsNullOrEmpty(txt_DiaChi.Text))
            {
                nv.QUEQUAN = txt_DiaChi.Text;
            }
            else nv.QUEQUAN = "";
            nv.NGAYVAOLAM = DateTime.Parse(txt_ngayLam.Text);
            ChucVuBus cvbus = new ChucVuBus();
            nv.MACV = cvbus.GetCVbyName(cb_loaiNV.Text).MACV;
            if (!string.IsNullOrEmpty(txt_Sdt.Text))
            {
                nv.SDT = txt_Sdt.Text;
            }
            else
                nv.SDT = "";
            if (!string.IsNullOrEmpty(txt_hoten.Text))
            {
                nv.TENNV = txt_hoten.Text;
            }
            else
                nv.TENNV = "";
            if (!string.IsNullOrEmpty(txt_CMND.Text))
            {
                nv.CMT = txt_CMND.Text;
            }
            else
                nv.CMT = "";
            nv.NGAYSINH = DateTime.Parse(txt_ngayLam.Text);    
            if (!string.IsNullOrEmpty(txt_user.Text))
            {
                ac.ID = nv.MANV;
                ac.USERNAME = txt_user.Text;
                ac.PASS = txt_pass.Text;
                    if (nvBus.add(nv,ac))//nvBus.AddNV(nv)&&acBus.Addac(ac))
                    {
                        MessageBox.Show("Add successted !");
                        resettext();
                        visiable_pass(false);
                        loadDSNhanVien();
                    }
                    else MessageBox.Show("Add not successted !");                    
            }
            else
            {
                    if (nvBus.AddNV(nv))
                    {
                        MessageBox.Show("Add successted !");
                        loadDSNhanVien();
                        resettext();
                        visiable_pass(false);
                    return;
                    }
                    else MessageBox.Show("Add not successted !"); 
            }          
        }
        //ok
        private void tbl_NhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ResetMouseEventArgs();
            ChucVuBus cvbus = new ChucVuBus();
            txt_manv.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[0].Value.ToString();
            txt_hoten.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[1].Value.ToString();
            txt_ngaysinh.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[2].Value.ToString();
            DateTime d = Convert.ToDateTime(txt_ngaysinh.Text);
            txt_ngaysinh.Text = d.ToString("MM/dd/yyyy");
            txt_Sdt.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[3].Value.ToString();
            txt_DiaChi.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[4].Value.ToString();
            string phai = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[5].Value.ToString();
            if (phai == "Nam")
            {
                rd_nam.Checked = true;
            }
            else rd_nu.Checked = true;
            txt_CMND.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[6].Value.ToString();
            txt_ngayLam.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[7].Value.ToString();
            DateTime dm = Convert.ToDateTime(txt_ngayLam.Text);
            txt_ngayLam.Text = dm.ToString("MM/dd/yyyy");
            string tenCV = cvbus.CHUCVUByID(tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[8].Value.ToString()).TENCV;
            cb_loaiNV.ResetText();
            cb_loaiNV.SelectedText = tenCV;

            string macv = cvbus.GetCVbyName(cb_loaiNV.Text).MACV;
            if (macv.Equals("AD") || macv.Equals("NVBH"))
            {
                AccountBus acBus = new AccountBus();
                txt_user.Text = acBus.ACCOUNTByID(Int32.Parse(txt_manv.Text)).USERNAME;
                visiable_user(true);
            }

            Enable();
        }
        // Ok !
        private void bt_Xoa_Click(object sender, EventArgs e)
        {
            NhanVienBus nvBus = new NhanVienBus();
            int manv = Int32.Parse(tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[0].Value.ToString());

            if (DialogResult.Yes == MessageBox.Show("Bạn Muốn xóa nhân viên ?" + tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[1].Value.ToString(), "Comfirm", MessageBoxButtons.YesNo))
            {
                if (nvBus.deleteNV(manv)) MessageBox.Show("Delete Successed !");
                else MessageBox.Show("Delete not Successed !");
            }
            resettext();
            tbl_NhanVien.ClearSelection();
            loadDSNhanVien();

        }
        //ok
        private void bt_excel_Click(object sender, EventArgs e)
        {
            toolTip1.ExportToExcel excel = new toolTip1.ExportToExcel();
            excel.ExportToExcelFromDatagridview(tbl_NhanVien, "Danh Sách Nhân Viên");
        }
        //ok
        private void bt_In_Click(object sender, EventArgs e)
        {
            toolTip1.ExportToExcel excel = new toolTip1.ExportToExcel();
            excel.ExportToExcelFromDatagridview(tbl_NhanVien, "Danh Sách Nhân Viên");
        }
        private void bt_moi_Click(object sender, EventArgs e)
        {         
            resettext();
            Enable();
            cb_loaiNV.Refresh();
            cb_loaiNV.SelectedIndex = 2;
            tbl_NhanVien.ClearSelection();
            NhanVienBus nvBus = new NhanVienBus();
            txt_manv.Text = (nvBus.MaNVNow()+1).ToString();
            txt_manv.Enabled = false;
            DateTime d = Convert.ToDateTime(DateTime.Now);
            txt_ngayLam.Text = d.ToString("MM/dd/yyyy");
            cb_loaiNV.Focus();
            bt_them.Visible = true;
            bt_Luu.Visible = false;
            txt_pass.ReadOnly = true;
            txt_user.ReadOnly = false;
        }
        private void Enable()
        {
            txt_Sdt.ReadOnly = false;
            txt_hoten.ReadOnly = false;
            txt_ngaysinh.ReadOnly = false;
            txt_DiaChi.ReadOnly = false;
            txt_CMND.ReadOnly = false;
            txt_Sdt.ReadOnly = false;
        }
        private void resettext()
        {
            txt_CMND.Text = "";
            txt_hoten.Text = "";
            txt_manv.Text = "";
            txt_ngayLam.Text = "";
            txt_DiaChi.Text = "";
            txt_ngaysinh.Text = "";
            txt_pass.Text = "";
            txt_Sdt.Text = "";
            txt_user.Text = "";
         
            cb_loaiNV.ResetText();
            rd_nam.Checked = true;
            visiable_user(false);
        }
        private void visiable_user(bool check)
        {
            txt_user.Visible = check;
            lb_user.Visible = check;
            pic_user.Visible = check;
        }
        private void visiable_pass(bool check)
        {
            txt_pass.Visible = check;
            lb_pass.Visible = check;
            pic_pass.Visible = check;

        }
        public void loadCbBx()
        {
            ChucVuBus cvBus = new ChucVuBus();
            
            int a = cvBus.DSCHUCVU().Count;
            for (int i = 0; i < a; i++)
            {
                CHUCVU cv = new CHUCVU();
                cv = cvBus.DSCHUCVU()[i];
                cb_loaiNV.Items.Add(cv);
            }
            cb_loaiNV.DisplayMember = "TENCV";
            cb_loaiNV.ValueMember = "MACV";
        }
        private void QuanLiNhanVien_Load(object sender, EventArgs e)
        {
            loadDSNhanVien();
            bt_them.Visible = false;
            loadCbBx();
           // manv = Int32.Parse(tbl_NhanVien.Rows[tbl_NhanVien.RowCount - 1].Cells[0].Value.ToString());
        }

        private void cb_loaiNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_loaiNV.SelectedIndex==0|| cb_loaiNV.SelectedIndex==1)
            {
                visiable_pass(true);
                visiable_user(true);
                txt_pass.ReadOnly = true;
            }
            
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {
            txt_pass.Text = "123456";
            txt_pass.ReadOnly = true;
        }


    }
}
