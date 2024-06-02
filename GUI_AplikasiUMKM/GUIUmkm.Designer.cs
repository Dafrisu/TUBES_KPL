namespace GUI_AplikasiUMKM
{
    partial class GUIUmkm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnTipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTipe,
            this.ColumnNama,
            this.ColumnStok});
            this.dataGridView1.Location = new System.Drawing.Point(88, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(427, 304);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnTipe
            // 
            this.ColumnTipe.HeaderText = "Tipe Barang";
            this.ColumnTipe.MinimumWidth = 6;
            this.ColumnTipe.Name = "ColumnTipe";
            this.ColumnTipe.Width = 125;
            // 
            // ColumnNama
            // 
            this.ColumnNama.HeaderText = "Nama Barang";
            this.ColumnNama.MinimumWidth = 6;
            this.ColumnNama.Name = "ColumnNama";
            this.ColumnNama.Width = 125;
            // 
            // ColumnStok
            // 
            this.ColumnStok.HeaderText = "Stok";
            this.ColumnStok.MinimumWidth = 6;
            this.ColumnStok.Name = "ColumnStok";
            this.ColumnStok.Width = 125;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(533, 89);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(533, 119);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(533, 149);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // GUIUmkm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GUIUmkm";
            this.Text = "GUIUmkm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNama;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStok;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
    }
}