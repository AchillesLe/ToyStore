using Bus;
using Dto;
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

        bool data_change = false;
        List<HOADON> listHd;
        BindingList<CTHD> listCt;
        List<CTHD> changedItem;
        List<CTHD> deletedItem;

        public ChiTietHd()
        {
            InitializeComponent();
        }

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
            // hide this Form
            this.Close();
            //Show MainMenuForm
            MainMenu MainMenu = new MainMenu();
            MainMenu.Show();
        }

        private void ChiTietHd_Load(object sender, EventArgs e)
        {
            listHd = new List<HOADON>();
            listCt = new BindingList<CTHD>();
            changedItem = new List<CTHD>();
            deletedItem = new List<CTHD>();

            tbl_CtHd.DataSource = listCt;
            tbl_CtHd.Columns[4].Visible = false;
            tbl_CtHd.Columns[5].Visible = false;

            tbl_CtHd.Columns[0].ReadOnly = true;
            tbl_CtHd.Columns[1].ReadOnly = true;
            tbl_CtHd.Columns[2].ReadOnly = false;
            tbl_CtHd.Columns[3].ReadOnly = true;

            dtp_from.Value = DateTime.Parse("01/01/2000");
            dtp_to.Value = DateTime.Now;
            load_DsHD_From_To(sender,e);
            
        }

    //add on function

    private void load_DsHD_From_To(object sender, EventArgs e)
        {
            HoaDonBus hdBus = new HoaDonBus();

            tbl_DsHd.DataSource = hdBus.DsHoaDonFromTo(dtp_from.Value,dtp_to.Value);
            tbl_DsHd.Refresh();
        }

        private void tbl_DsHd_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int mahd = (int)tbl_DsHd.SelectedRows[0].Cells[0].Value;

                tb_TongTien.Text = tbl_DsHd.SelectedRows[0].Cells[3].Value.ToString();
                CTHDBus ctBus = new CTHDBus();
                
                listCt = new BindingList<CTHD>( ctBus.DSChiTiet(mahd));
                tbl_CtHd.DataSource = listCt;
                tbl_CtHd.Refresh();

                tbl_CtHd.ClearSelection();

                int sl = 0;
                foreach (CTHD ct in listCt)
                    sl += (int)ct.SL;
                tb_Sl.Text = sl.ToString();
            }catch(Exception ex)
            { }
        }

        private void bt_Xoa_Click(object sender, EventArgs e)
        {
            int mahd = (int)tbl_DsHd.SelectedRows[0].Cells[0].Value;

            HoaDonBus hdBus = new HoaDonBus();
            hdBus.delete(mahd);

            tbl_CtHd.DataSource = null;
            tbl_CtHd.Refresh();

            load_DsHD_From_To(sender, e);
        }

        private void bt_Sua_Click(object sender, EventArgs e)
        {
            if(data_change)
            {
                try
                {
                    CTHDBus ctBus = new CTHDBus();
                    if (changedItem.Count > 0)
                        foreach (CTHD it in changedItem)
                        {
                            ctBus.editCTHD(it);
                        }
                    if (deletedItem.Count > 0)
                        foreach (CTHD it in deletedItem)
                        {
                            ctBus.deleteCTHD(it.MAHD, it.MADC);
                        }
                    MessageBox.Show("Sửa thành công!");
                    data_change = false;
                    tbl_DsHd_DoubleClick(sender, e);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa sửa thông gì!");
            }
        }

        private void tbl_CtHd_CellValueChanged(object sender, EventArgs e)
        {
            CTHD ct = new CTHD();
            DoChoiBus dcBus = new DoChoiBus();

            var row = tbl_CtHd.SelectedRows[0];

            ct.MAHD = (int)row.Cells[0].Value;
            ct.MADC = (int)row.Cells[1].Value;
            ct.SL = (int)row.Cells[2].Value;

            ct.GIA = dcBus.DochoiById(ct.MADC).GIA * ct.SL;
            row.Cells[3].Value = ct.GIA;

            var li = changedItem.Where(i => (i.MAHD == ct.MAHD && i.MADC == ct.MADC));
            if (li.Count() > 0)
            {
                li.First().GIA = ct.GIA;
                li.First().SL = ct.SL;
            }
            else
                changedItem.Add(ct);
            
            data_change = true;
        }

        private void bt_moi_Click(object sender, EventArgs e)
        {
            changedItem.Clear();
            deletedItem.Clear();
            tbl_DsHd_DoubleClick(sender, e);
            data_change = false;
        }

        private void bt_XoaNhieu_Click(object sender, EventArgs e)
        {
            try
            {
                CTHD ct = new CTHD();
                ct.MAHD = (int)tbl_CtHd.SelectedRows[0].Cells[0].Value;
                ct.MADC = (int)tbl_CtHd.SelectedRows[0].Cells[1].Value;
                ct.SL = (int)tbl_CtHd.SelectedRows[0].Cells[2].Value;
                ct.GIA = (double)tbl_CtHd.SelectedRows[0].Cells[3].Value;

                deletedItem.Add(ct);
                var li = listCt.Single(i => (i.MADC == ct.MADC && i.MAHD == ct.MAHD));
                    listCt.Remove(li);
                
                data_change = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_TimNgayHd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tb_maHD.Text))
            {
                load_DsHD_From_To(sender, e);
            }
            else
            try
            {
                HoaDonBus hdBus = new HoaDonBus();

                int id = int.Parse(tb_maHD.Text);
                listHd = hdBus.dsHoaDonById(id);
                tbl_DsHd.DataSource = listHd;
                tbl_DsHd.Refresh();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
