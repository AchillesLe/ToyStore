namespace Presentation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label mANVLabel;
            System.Windows.Forms.Label tENDCLabel;
            System.Windows.Forms.Label sLLabel;
            System.Windows.Forms.Label nUOCSXLabel;
            System.Windows.Forms.Label lOAILabel;
            System.Windows.Forms.Label gIALabel;
            this.tbl_nhanvien = new System.Windows.Forms.DataGridView();
            this.tble_khachhang = new System.Windows.Forms.DataGridView();
            this.tbl_Dochoi = new System.Windows.Forms.DataGridView();
            this.dOCHOIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toyStoreDataSet = new Presentation.ToyStoreDataSet();
            this.mANVTextBox = new System.Windows.Forms.TextBox();
            this.nHANVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SearchManv = new System.Windows.Forms.Button();
            this.ten = new System.Windows.Forms.TextBox();
            this.ncsx = new System.Windows.Forms.TextBox();
            this.bt_add = new System.Windows.Forms.Button();
            this.dOCHOITableAdapter = new Presentation.ToyStoreDataSetTableAdapters.DOCHOITableAdapter();
            this.tableAdapterManager = new Presentation.ToyStoreDataSetTableAdapters.TableAdapterManager();
            this.nHANVIENTableAdapter = new Presentation.ToyStoreDataSetTableAdapters.NHANVIENTableAdapter();
            this.lOAITextBox = new System.Windows.Forms.TextBox();
            this.gIATextBox = new System.Windows.Forms.TextBox();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_edit = new System.Windows.Forms.Button();
            this.sl = new System.Windows.Forms.TextBox();
            mANVLabel = new System.Windows.Forms.Label();
            tENDCLabel = new System.Windows.Forms.Label();
            sLLabel = new System.Windows.Forms.Label();
            nUOCSXLabel = new System.Windows.Forms.Label();
            lOAILabel = new System.Windows.Forms.Label();
            gIALabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_nhanvien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tble_khachhang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Dochoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCHOIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toyStoreDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Location = new System.Drawing.Point(31, 194);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(41, 14);
            mANVLabel.TabIndex = 7;
            mANVLabel.Text = "MANV:";
            // 
            // tENDCLabel
            // 
            tENDCLabel.AutoSize = true;
            tENDCLabel.Location = new System.Drawing.Point(728, 242);
            tENDCLabel.Name = "tENDCLabel";
            tENDCLabel.Size = new System.Drawing.Size(43, 14);
            tENDCLabel.TabIndex = 10;
            tENDCLabel.Text = "TENDC:";
            // 
            // sLLabel
            // 
            sLLabel.AutoSize = true;
            sLLabel.Location = new System.Drawing.Point(748, 268);
            sLLabel.Name = "sLLabel";
            sLLabel.Size = new System.Drawing.Size(23, 14);
            sLLabel.TabIndex = 11;
            sLLabel.Text = "SL:";
            // 
            // nUOCSXLabel
            // 
            nUOCSXLabel.AutoSize = true;
            nUOCSXLabel.Location = new System.Drawing.Point(718, 294);
            nUOCSXLabel.Name = "nUOCSXLabel";
            nUOCSXLabel.Size = new System.Drawing.Size(53, 14);
            nUOCSXLabel.TabIndex = 13;
            nUOCSXLabel.Text = "NUOCSX:";
            // 
            // lOAILabel
            // 
            lOAILabel.AutoSize = true;
            lOAILabel.Location = new System.Drawing.Point(737, 216);
            lOAILabel.Name = "lOAILabel";
            lOAILabel.Size = new System.Drawing.Size(34, 14);
            lOAILabel.TabIndex = 15;
            lOAILabel.Text = "LOAI:";
            // 
            // gIALabel
            // 
            gIALabel.AutoSize = true;
            gIALabel.Location = new System.Drawing.Point(743, 190);
            gIALabel.Name = "gIALabel";
            gIALabel.Size = new System.Drawing.Size(28, 14);
            gIALabel.TabIndex = 16;
            gIALabel.Text = "GIA:";
            // 
            // tbl_nhanvien
            // 
            this.tbl_nhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_nhanvien.Location = new System.Drawing.Point(34, 28);
            this.tbl_nhanvien.Name = "tbl_nhanvien";
            this.tbl_nhanvien.ReadOnly = true;
            this.tbl_nhanvien.Size = new System.Drawing.Size(410, 150);
            this.tbl_nhanvien.TabIndex = 0;
            // 
            // tble_khachhang
            // 
            this.tble_khachhang.AllowUserToAddRows = false;
            this.tble_khachhang.AllowUserToDeleteRows = false;
            this.tble_khachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tble_khachhang.Location = new System.Drawing.Point(471, 28);
            this.tble_khachhang.Name = "tble_khachhang";
            this.tble_khachhang.ReadOnly = true;
            this.tble_khachhang.Size = new System.Drawing.Size(451, 150);
            this.tble_khachhang.TabIndex = 1;
            // 
            // tbl_Dochoi
            // 
            this.tbl_Dochoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_Dochoi.Location = new System.Drawing.Point(251, 191);
            this.tbl_Dochoi.Name = "tbl_Dochoi";
            this.tbl_Dochoi.Size = new System.Drawing.Size(410, 150);
            this.tbl_Dochoi.TabIndex = 2;
            this.tbl_Dochoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cell_edit);
            // 
            // dOCHOIBindingSource
            // 
            this.dOCHOIBindingSource.DataMember = "DOCHOI";
            this.dOCHOIBindingSource.DataSource = this.toyStoreDataSet;
            // 
            // toyStoreDataSet
            // 
            this.toyStoreDataSet.DataSetName = "ToyStoreDataSet";
            this.toyStoreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mANVTextBox
            // 
            this.mANVTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.nHANVIENBindingSource, "MANV", true));
            this.mANVTextBox.Location = new System.Drawing.Point(78, 191);
            this.mANVTextBox.Name = "mANVTextBox";
            this.mANVTextBox.Size = new System.Drawing.Size(100, 20);
            this.mANVTextBox.TabIndex = 8;
            // 
            // nHANVIENBindingSource
            // 
            this.nHANVIENBindingSource.DataMember = "NHANVIEN";
            this.nHANVIENBindingSource.DataSource = this.toyStoreDataSet;
            // 
            // SearchManv
            // 
            this.SearchManv.Location = new System.Drawing.Point(78, 228);
            this.SearchManv.Name = "SearchManv";
            this.SearchManv.Size = new System.Drawing.Size(75, 23);
            this.SearchManv.TabIndex = 9;
            this.SearchManv.Text = "Search";
            this.SearchManv.UseVisualStyleBackColor = true;
            this.SearchManv.Click += new System.EventHandler(this.SearchManv_Click);
            // 
            // ten
            // 
            this.ten.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dOCHOIBindingSource, "TENDC", true));
            this.ten.Location = new System.Drawing.Point(777, 239);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(100, 20);
            this.ten.TabIndex = 11;
            // 
            // ncsx
            // 
            this.ncsx.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dOCHOIBindingSource, "NUOCSX", true));
            this.ncsx.Location = new System.Drawing.Point(777, 291);
            this.ncsx.Name = "ncsx";
            this.ncsx.Size = new System.Drawing.Size(100, 20);
            this.ncsx.TabIndex = 14;
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(777, 325);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 15;
            this.bt_add.Text = "Add";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // dOCHOITableAdapter
            // 
            this.dOCHOITableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BAOCAOTableAdapter = null;
            this.tableAdapterManager.CTHDTableAdapter = null;
            this.tableAdapterManager.DOCHOITableAdapter = this.dOCHOITableAdapter;
            this.tableAdapterManager.HOADONTableAdapter = null;
            this.tableAdapterManager.KHACHHANGTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.QUATableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Presentation.ToyStoreDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // nHANVIENTableAdapter
            // 
            this.nHANVIENTableAdapter.ClearBeforeFill = true;
            // 
            // lOAITextBox
            // 
            this.lOAITextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dOCHOIBindingSource, "LOAI", true));
            this.lOAITextBox.Location = new System.Drawing.Point(777, 213);
            this.lOAITextBox.Name = "lOAITextBox";
            this.lOAITextBox.Size = new System.Drawing.Size(100, 20);
            this.lOAITextBox.TabIndex = 16;
            // 
            // gIATextBox
            // 
            this.gIATextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dOCHOIBindingSource, "GIA", true));
            this.gIATextBox.Location = new System.Drawing.Point(777, 187);
            this.gIATextBox.Name = "gIATextBox";
            this.gIATextBox.Size = new System.Drawing.Size(100, 20);
            this.gIATextBox.TabIndex = 17;
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(78, 261);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 18;
            this.bt_delete.Text = "delete";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_edit
            // 
            this.bt_edit.Location = new System.Drawing.Point(78, 294);
            this.bt_edit.Name = "bt_edit";
            this.bt_edit.Size = new System.Drawing.Size(75, 23);
            this.bt_edit.TabIndex = 19;
            this.bt_edit.Text = "Edit";
            this.bt_edit.UseVisualStyleBackColor = true;
            this.bt_edit.Click += new System.EventHandler(this.bt_edit_Click);
            // 
            // sl
            // 
            this.sl.Location = new System.Drawing.Point(778, 265);
            this.sl.Name = "sl";
            this.sl.Size = new System.Drawing.Size(100, 20);
            this.sl.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 361);
            this.Controls.Add(this.sl);
            this.Controls.Add(this.bt_edit);
            this.Controls.Add(this.bt_delete);
            this.Controls.Add(gIALabel);
            this.Controls.Add(this.gIATextBox);
            this.Controls.Add(lOAILabel);
            this.Controls.Add(this.lOAITextBox);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(nUOCSXLabel);
            this.Controls.Add(this.ncsx);
            this.Controls.Add(sLLabel);
            this.Controls.Add(tENDCLabel);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.SearchManv);
            this.Controls.Add(mANVLabel);
            this.Controls.Add(this.mANVTextBox);
            this.Controls.Add(this.tbl_Dochoi);
            this.Controls.Add(this.tble_khachhang);
            this.Controls.Add(this.tbl_nhanvien);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_nhanvien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tble_khachhang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Dochoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCHOIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toyStoreDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tbl_nhanvien;
        private System.Windows.Forms.DataGridView tble_khachhang;
        private System.Windows.Forms.DataGridView tbl_Dochoi;
        private ToyStoreDataSet toyStoreDataSet;
        private System.Windows.Forms.BindingSource dOCHOIBindingSource;
        private ToyStoreDataSetTableAdapters.DOCHOITableAdapter dOCHOITableAdapter;
        private ToyStoreDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource nHANVIENBindingSource;
        private ToyStoreDataSetTableAdapters.NHANVIENTableAdapter nHANVIENTableAdapter;
        private System.Windows.Forms.TextBox mANVTextBox;
        private System.Windows.Forms.Button SearchManv;
        private System.Windows.Forms.TextBox ten;
        private System.Windows.Forms.TextBox ncsx;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.TextBox lOAITextBox;
        private System.Windows.Forms.TextBox gIATextBox;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_edit;
        private System.Windows.Forms.TextBox sl;
    }
}

