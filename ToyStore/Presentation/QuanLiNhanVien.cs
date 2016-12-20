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
        }

        private void back_Click(object sender, EventArgs e)
        {
            // hide QuanLiNv Form
            this.Close();
        }

        private void loadDSNhanVien()
        {
            NhanVienBus nvBus = new NhanVienBus();
            tbl_NhanVien.DataSource = nvBus.DSNhanVien();
            //for (int i = 0; i < tbl_NhanVien.Columns.Count; i++)
            //{
            //    //if ((tbl_NhanVien.Columns[i].HeaderText == "CHUCVU" && tbl_NhanVien.Columns[8].Visible == true) ||
            //    //    (tbl_NhanVien.Columns[i].HeaderText == "HOADONs" && tbl_NhanVien.Columns[9].Visible == true) ||
            //    //    (tbl_NhanVien.Columns[i].HeaderText == "ACCOUNT" && tbl_NhanVien.Columns[10].Visible == true) ||
            //    //    (tbl_NhanVien.Columns[i].HeaderText == "NHAPKHOes" && tbl_NhanVien.Columns[11].Visible == true))
            //    //{
            //    //    tbl_NhanVien.Columns.RemoveAt(i);
            //    //}

            //}

        }
        //ok
        private void bt_save_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = new NHANVIEN();
            NhanVienBus nvBus = new NhanVienBus();
            nv.MANV = Int32.Parse(txt_manv.Text);
            nv.NGAYSINH = txt_ngaysinh.Value;             
            if (rd_nam.Checked == true) nv.PHAI = "Nam";
            else nv.PHAI = "Nu";
            if(!string.IsNullOrEmpty(txt_DiaChi.Text))
            {
                nv.QUEQUAN = txt_DiaChi.Text;
            }
            
            if(!string.IsNullOrEmpty(txt_Sdt.Text))
            {
                nv.SDT = txt_Sdt.Text;
            }
            nv.TENNV = txt_hoten.Text;
            if(!String.IsNullOrEmpty(txt_CMND.Text))
            {
                nv.CMT = txt_CMND.Text;
            }   
            nv.NGAYVAOLAM = txt_ngayLam.Value;
            ChucVuBus cvbus = new ChucVuBus();
            nv.MACV = cvbus.GetCVbyName(cb_loaiNV.Text).MACV;
            try
            {
                if (!string.IsNullOrEmpty(nv.CMT) && !string.IsNullOrEmpty(nv.QUEQUAN) && !string.IsNullOrEmpty(nv.SDT) && !string.IsNullOrEmpty(nv.TENNV))
                {
                    if (nvBus.editNV(nv))
                    {
                        MessageBox.Show("Edit successted !");
                        loadDSNhanVien();                     
                    }
                       
                    else
                        MessageBox.Show("Edit not successted !");
                    resettext();
                }
                else
                {
                    MessageBox.Show("Điền đầy đủ thông tin trước khi cập nhật nhân viên !");
                }
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
            if (rd_nam.Checked == true) nv.PHAI = "Nam";
            else nv.PHAI = "Nu";
            if (!string.IsNullOrEmpty(txt_DiaChi.Text))
            {
                nv.QUEQUAN = txt_DiaChi.Text;
            }
            
            nv.NGAYVAOLAM = txt_ngayLam.Value;
            ChucVuBus cvbus = new ChucVuBus();
            nv.MACV = cvbus.GetCVbyName(cb_loaiNV.Text).MACV;
            if (!string.IsNullOrEmpty(txt_Sdt.Text))
            {
                nv.SDT = txt_Sdt.Text;
            }
            if (!string.IsNullOrEmpty(txt_hoten.Text))
            {
                nv.TENNV = txt_hoten.Text;
            }

            if (!string.IsNullOrEmpty(txt_CMND.Text))
            {
                nv.CMT = txt_CMND.Text;
            }
            nv.NGAYSINH = txt_ngaysinh.Value;   
            if (!string.IsNullOrEmpty(txt_user.Text))
            {
                ac.ID = nv.MANV;
                ac.USERNAME = txt_user.Text;
                ac.PASS = txt_pass.Text;
                if(!string.IsNullOrEmpty(nv.CMT)&& !string.IsNullOrEmpty(nv.QUEQUAN)&& !string.IsNullOrEmpty(nv.SDT)&& !string.IsNullOrEmpty(nv.TENNV))
                {
                    if (nvBus.add(nv, ac))
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
                    MessageBox.Show("Điền đầy đủ thông tin trước khi thêm nhân viên !");
                    return;
                }           
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
            bt_them.Visible = false;
            ChucVuBus cvbus = new ChucVuBus();
            txt_manv.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[0].Value.ToString();//!=null? tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[0].Value.ToString():"";
            txt_hoten.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[1].Value.ToString();// != null ? tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[1].Value.ToString() : "";           
            txt_Sdt.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[2].Value.ToString();//!= null ? tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[2].Value.ToString() : "";
            txt_DiaChi.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[3].Value.ToString();//!= null ? tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[3].Value.ToString() : "";
            string phai = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[4].Value.ToString();// != null ? tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[4].Value.ToString() : "";
            if (phai == "Nam")
            {
                rd_nam.Checked = true;
            }
            else rd_nu.Checked = true;
            txt_CMND.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[5].Value.ToString();// != null ? tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[5].Value.ToString() : "123456789";
            txt_ngaysinh.Value = (DateTime)(tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[6].Value);// != null ? (DateTime)(tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[6].Value) : DateTime.Parse("12/31/1998");
            txt_ngayLam.Value = (DateTime)(tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[7].Value);// != null ? (DateTime)(tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[7].Value) : DateTime.Now;
            string tenCV = cvbus.CHUCVUByID(tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[8].Value.ToString()).TENCV;//!= null ? cvbus.CHUCVUByID(tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[8].Value.ToString()).TENCV : "NVTV";
            cb_loaiNV.ResetText();
            cb_loaiNV.SelectedText = tenCV;

            string macv = cvbus.GetCVbyName(cb_loaiNV.Text).MACV;
            if (macv.Equals("AD") || macv.Equals("NVBH"))
            {
                AccountBus acBus = new AccountBus();
                txt_user.Text = acBus.ACCOUNTByID(Int32.Parse(txt_manv.Text)).USERNAME;
                visiable_user(true);
                visiable_pass(false);
            }
            Enable(true);
        }
        // Ok !
        private void bt_Xoa_Click(object sender, EventArgs e)
        {
            NhanVienBus nvBus = new NhanVienBus();
            int manv = Int32.Parse(tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[0].Value.ToString());
            if(manv!=3114100)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn Muốn xóa nhân viên ?" + tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[1].Value.ToString(), "Comfirm", MessageBoxButtons.YesNo))
                {
                    if (nvBus.deleteNV(manv))
                        MessageBox.Show("Delete Successed !");
                    else
                    {
                        MessageBox.Show("Delete not Successed !");
                        return;
                    }
                }
                resettext();
                tbl_NhanVien.ClearSelection();
                loadDSNhanVien();
            }
            else
            {
                MessageBox.Show("Không thể xoá chính bạn !");
                return;
            }
           
           
           
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
            Enable(true);
            cb_loaiNV.Refresh();
            cb_loaiNV.SelectedIndex = 2;
            tbl_NhanVien.ClearSelection();
            NhanVienBus nvBus = new NhanVienBus();
            txt_manv.Text = (nvBus.MaNVNow()+1).ToString();
            txt_manv.Enabled = false;
            txt_ngayLam.Value = DateTime.Now;
            txt_ngaysinh.Value = DateTime.Parse("12/31/1996");
            cb_loaiNV.Focus();
            bt_them.Visible = true;
            bt_Luu.Visible = false;
            txt_pass.ReadOnly = true;
            txt_user.ReadOnly = false;
            visiable_user(false);
            visiable_pass(false);

        }
        private void Enable(bool en)
        {
            txt_Sdt.Enabled = en;
            txt_hoten.Enabled = en;
            txt_DiaChi.Enabled = en;
            txt_CMND.Enabled = en;
            txt_Sdt.Enabled = en;
            txt_ngaysinh.Enabled = en;
            Gb_GioiTinh.Enabled = en;
            cb_loaiNV.Enabled = en;
        }
        private void resettext()
        {
            txt_CMND.Text = "";
            txt_hoten.Text = "";
            txt_manv.Text = "";
            txt_ngayLam.Value = DateTime.Now ;
            txt_DiaChi.Text = "";
            txt_ngaysinh.Value = DateTime.Parse("12/31/1998");
            txt_pass.Text ="";
            txt_Sdt.Text = "";
            txt_user.Text = ""; 
            cb_loaiNV.ResetText();
            rd_nam.Checked = true;

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
            Enable(false);
        }

        private void cb_loaiNV_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if(cb_loaiNV.SelectedIndex==0|| cb_loaiNV.SelectedIndex==1)
            {
                visiable_pass(true);
                visiable_user(true);
                txt_pass.Text = "";
            }
            else
            {
                visiable_pass(false);
                visiable_user(false);
                txt_pass.Text = "";
            }
            
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {
            txt_pass.Text = "123456";
            txt_pass.ReadOnly = true;
        }

        private void txt_CMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txt_hoten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&! char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        AccountBus acbus = new AccountBus();
        private void txt_user_Leave(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txt_user.Text))
            {
                if (acbus.ACCOUNTByName(txt_user.Text).ID>0)
                {
                    MessageBox.Show("Tên user đã tồn tại");
                    txt_user.Text = "";
                }
            }
            
        }

        private void txt_CMND_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txt_CMND.Text))
            {
                if(txt_CMND.Text.Length!=9)
                {
                    MessageBox.Show("Sai định dạng số chứng minh thư !");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập số chứng minh thư !");
            }
        }

        private void txt_hoten_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_hoten.Text))
            {
                MessageBox.Show("Hãy nhập số họ tên !");
            }
               
        }

        private void txt_ngaysinh_ValueChanged(object sender, EventArgs e)
        {
            if ((txt_ngayLam.Value.Year - txt_ngaysinh.Value.Year) < 18)
            {
                MessageBox.Show("Nhân viên phải trên 18 tuổi !");
                txt_ngaysinh.Value = DateTime.Parse("12/31/1998");
            }
        }

        private void txt_Sdt_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Sdt.Text))
            {
                if (txt_Sdt.Text.Length != 10 && txt_Sdt.Text.Length != 11)
                {
                    MessageBox.Show("Sai định dạng số điện thoại ! ");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập số điện thoại !");
                txt_Sdt.Focus();
            }
        }
    }
}
