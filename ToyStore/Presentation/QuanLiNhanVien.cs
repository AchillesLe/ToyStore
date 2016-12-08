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
        public QuanLiNhanVien()
        {
            InitializeComponent();
            loadDSNhanVien();
            bt_moi.Hide();
            lb_pass.Hide();
            tb_pass.Hide();
            pic_pass.Hide();

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
        }
       //ok
        private void bt_save_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.MANV = Int32.Parse(txt_manv.Text);
            nv.NGAYSINH =DateTime.Parse( txt_ngaysinh.Text);
            //DateTime d = Convert.ToDateTime(nv.NGAYSINH);
            
            if (rd_nam.Checked == true) nv.PHAI = "Nam";
            else nv.PHAI = "Nu";
            nv.QUEQUAN = txt_DiaChi.Text;
            nv.SDT = txt_NgayLam.Text;
            nv.TENNV = txt_hoten.Text;
            nv.CMT = txt_CMND.Text;
            
            NhanVienBus nvBus = new NhanVienBus();

            if (nvBus.editNV(nv))
                MessageBox.Show("Edit successted !");
            else MessageBox.Show("Edit not successted !");
            loadDSNhanVien();
            txt_CMND.Text = "";
            txt_hoten.Text = "";
            txt_manv.Text = "";
            txt_ngaysinh.Text = "";
            txt_DiaChi.Text = "";
            txt_NgayLam.Text = "";
            rd_nam.Checked = true;

        }

       
        //ok
        private void tbl_NhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_manv.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[0].Value.ToString();
            txt_hoten.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[1].Value.ToString();
            txt_ngaysinh.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[2].Value.ToString();
            DateTime d = Convert.ToDateTime(txt_ngaysinh.Text);
            txt_ngaysinh.Text = d.ToString("MM/dd/yyyy");
            txt_NgayLam.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[3].Value.ToString();
            txt_DiaChi.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[4].Value.ToString();
            string phai=tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[5].Value.ToString();
            if (phai=="Nam")
            {
                rd_nam.Checked = true;
                
            }                
            else rd_nu.Checked = true;
            txt_CMND.Text = tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[6].Value.ToString();
            
        }
        //Thiếu form thêm.(Click vào nút thêm thì sẽ ra form thêm.)
        private void bt_Moi_Click(object sender, EventArgs e)
        {
            //NHANVIEN nv = new NHANVIEN();
            //nv.MANV = -1;
            //nv.NGAYSINH = DateTime.Parse(txt_ngaysinh.Text);
            //if (rd_nam.Checked == true) nv.PHAI = "Nam";
            //else nv.PHAI = "Nu";
            //nv.QUEQUAN = txt_QQ.Text;
            //nv.SDT = txt_SDT.Text;
            //nv.TENNV = txt_hoten.Text;
            //nv.CMT = txt_CMT.Text;

            //NhanVienBus nvBus = new NhanVienBus();

            //if (nvBus.AddNV(nv)>0)
            //    MessageBox.Show("Add successted !");
            //else MessageBox.Show("Add not successted !");
            //loadDSNhanVien();
        }

        //Xóa Ok !
        private void bt_Xoa_Click(object sender, EventArgs e)
        {
            NhanVienBus nvBus = new NhanVienBus();
            int manv =Int32.Parse( tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[0].Value.ToString());
            
            if (DialogResult.Yes== MessageBox.Show("Bạn Muốn xóa nhân viên ?"+tbl_NhanVien.Rows[tbl_NhanVien.CurrentCell.RowIndex].Cells[1].Value.ToString(),"Comfirm",MessageBoxButtons.YesNo))
            {
                if (nvBus.deleteNV(manv)) MessageBox.Show("Delete Successed !");
                else MessageBox.Show("Delete not Successed !");
            }
            loadDSNhanVien();
                
        }

        private void bt_excel_Click(object sender, EventArgs e)
        {
            string s= tbl_NhanVien.Columns[0].HeaderText;
            MessageBox.Show(s);
        }

        private void bt_In_Click(object sender, EventArgs e)
        {
            toolTip1.ExportToExcel excel = new toolTip1.ExportToExcel();
            excel.ExportToExcelFromDatagridview(tbl_NhanVien, "Danh Sách Nhân Viên");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bt_Huy.Show();
            bt_Luu.Show();
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            bt_moi.Show();
            lb_pass.Show();
            tb_pass.Show();
            pic_pass.Show();
            bt_Luu.Hide();
            bt_Sua.Hide();
            bt_Xoa.Hide();
            bt_Huy.Hide(); 
        }
    }
}
