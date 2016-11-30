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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'toyStoreDataSet.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.toyStoreDataSet.NHANVIEN);
            // TODO: This line of code loads data into the 'toyStoreDataSet.DOCHOI' table. You can move, or remove it, as needed.
            this.dOCHOITableAdapter.Fill(this.toyStoreDataSet.DOCHOI);
            load_dochoi();
            load_NV();
            load_kh();
        }
        public void load_dochoi()
        {
            DoChoiBus dochoibus = new DoChoiBus();
            tbl_Dochoi.DataSource = dochoibus.dsDoChoi();
            //tbl_Dochoi.Columns[7].Visible = false;
            //tbl_Dochoi.Columns[8].Visible = false;

        }
        public void load_NV()
        {
            NhanVienBus nvbus = new NhanVienBus();
            tbl_nhanvien.DataSource = nvbus.DSNhanVien();
           // tbl_nhanvien.Columns[7].Visible = false;
        }
        public void load_kh()
        {
            KhachHangBus khBus = new KhachHangBus();
            tble_khachhang.DataSource = khBus.DSkhachhang();
            
        }

        private void dOCHOIBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dOCHOIBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.toyStoreDataSet);

        }


        private void SearchManv_Click(object sender, EventArgs e)
        {
            NhanVienBus nvBus = new NhanVienBus();
            int id = Int32.Parse(mANVTextBox.Text);
            List<NHANVIEN> listNv = new List<NHANVIEN>();
            listNv.Add(nvBus.NhanVienByID(id));
            tbl_nhanvien.DataSource = listNv;
                MessageBox.Show("" + id);
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            DOCHOI dc = new DOCHOI();
            dc.NUOCSX = ncsx.Text;
            dc.SL = Int32.Parse(sl.Text);
            dc.TENDC = ten.Text;
            dc.GIA = float.Parse(gIATextBox.Text);
            dc.LOAI = lOAITextBox.Text;

            DoChoiBus dcBus = new DoChoiBus();
            
            if(dcBus.AddDoChoi(dc)>0)
            {
                MessageBox.Show("Add suscess !");
                load_dochoi();
            }
            else MessageBox.Show("Add not suscess !");
            ncsx.Text = "";
            sl.Text = "";
            ten.Text = "";
            lOAITextBox.Text = "";
            gIATextBox.Text = "";

        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            DoChoiBus dcBus = new DoChoiBus();
            int vt = tbl_Dochoi.CurrentCell.RowIndex;
            int id = (int)tbl_Dochoi.Rows[vt].Cells[0].Value;
            //string ten = tbl_Dochoi.Rows[vt].Cells[1].Value.ToString();
            //MessageBox.Show("Do you want to delelte {0}",ten);
            if (dcBus.deleteDC(id))
                MessageBox.Show("Delete Success!");
            else MessageBox.Show("Delete not Success !");
            load_dochoi();
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            DoChoiBus dcBus = new DoChoiBus();
            DOCHOI dc = new DOCHOI();
            //ten.Text = tbl_Dochoi.Rows[tbl_Dochoi.CurrentCell.RowIndex].Cells[1].Value.ToString();
            //sl.Text = tbl_Dochoi.Rows[tbl_Dochoi.CurrentCell.RowIndex].Cells[2].Value.ToString();
            //ncsx.Text = tbl_Dochoi.Rows[tbl_Dochoi.CurrentCell.RowIndex].Cells[3].Value.ToString();
            //lOAITextBox.Text = tbl_Dochoi.Rows[tbl_Dochoi.CurrentCell.RowIndex].Cells[4].Value.ToString();
            //gIATextBox.Text = tbl_Dochoi.Rows[tbl_Dochoi.CurrentCell.RowIndex].Cells[5].Value.ToString();
            dc.MADC = (int)tbl_Dochoi.Rows[tbl_Dochoi.CurrentCell.RowIndex].Cells[0].Value;
            dc.TENDC = ten.Text;
            dc.GIA = double.Parse(gIATextBox.Text);
            dc.SL =Int32.Parse( sl.Text);
            dc.LOAI = lOAITextBox.Text;
            dc.NUOCSX = ncsx.Text;

            if (dcBus.editDC(dc))
                MessageBox.Show("edit success !");
            else MessageBox.Show("edit not success !");
            load_dochoi();
        }

        private void cell_edit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ten.Text = tbl_Dochoi.Rows[tbl_Dochoi.CurrentCell.RowIndex].Cells[1].Value.ToString();
                sl.Text = tbl_Dochoi.Rows[tbl_Dochoi.CurrentCell.RowIndex].Cells[2].Value.ToString();
                ncsx.Text = tbl_Dochoi.Rows[tbl_Dochoi.CurrentCell.RowIndex].Cells[3].Value.ToString();
                lOAITextBox.Text = tbl_Dochoi.Rows[tbl_Dochoi.CurrentCell.RowIndex].Cells[4].Value.ToString();
                gIATextBox.Text = tbl_Dochoi.Rows[tbl_Dochoi.CurrentCell.RowIndex].Cells[5].Value.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
