namespace QuanLyQuanAn.Forms
{
    partial class frmNhatKy
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
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            User = new DataGridViewTextBoxColumn();
            Table = new DataGridViewTextBoxColumn();
            Action = new DataGridViewTextBoxColumn();
            OldValue = new DataGridViewTextBoxColumn();
            NewValue = new DataGridViewTextBoxColumn();
            AffectAt = new DataGridViewTextBoxColumn();
            label1 = new Label();
            dtpNgay = new DateTimePicker();
            btnXemTheoNgay = new Button();
            btnHienTatCa = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, User, Table, Action, OldValue, NewValue, AffectAt });
            dataGridView.Location = new Point(0, 44);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(798, 431);
            dataGridView.TabIndex = 0;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // User
            // 
            User.DataPropertyName = "User";
            User.HeaderText = "User";
            User.MinimumWidth = 6;
            User.Name = "User";
            // 
            // Table
            // 
            Table.DataPropertyName = "Table";
            Table.HeaderText = "Table";
            Table.MinimumWidth = 6;
            Table.Name = "Table";
            // 
            // Action
            // 
            Action.DataPropertyName = "Action";
            Action.HeaderText = "Action";
            Action.MinimumWidth = 6;
            Action.Name = "Action";
            // 
            // OldValue
            // 
            OldValue.DataPropertyName = "OldValue";
            OldValue.HeaderText = "OldValue";
            OldValue.MinimumWidth = 6;
            OldValue.Name = "OldValue";
            // 
            // NewValue
            // 
            NewValue.DataPropertyName = "NewValue";
            NewValue.HeaderText = "NewValue";
            NewValue.MinimumWidth = 6;
            NewValue.Name = "NewValue";
            // 
            // AffectAt
            // 
            AffectAt.DataPropertyName = "AffectAt";
            AffectAt.HeaderText = "AffectAt";
            AffectAt.MinimumWidth = 6;
            AffectAt.Name = "AffectAt";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 15);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 1;
            label1.Text = "Ngày:";
            // 
            // dtpNgay
            // 
            dtpNgay.CustomFormat = "dd/MM/yyyy";
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.Location = new Point(128, 12);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(141, 27);
            dtpNgay.TabIndex = 2;
            // 
            // btnXemTheoNgay
            // 
            btnXemTheoNgay.Location = new Point(292, 10);
            btnXemTheoNgay.Name = "btnXemTheoNgay";
            btnXemTheoNgay.Size = new Size(131, 29);
            btnXemTheoNgay.TabIndex = 3;
            btnXemTheoNgay.Text = "Xem theo ngày";
            btnXemTheoNgay.UseVisualStyleBackColor = true;
            btnXemTheoNgay.Click += btnXemTheoNgay_Click;
            // 
            // btnHienTatCa
            // 
            btnHienTatCa.Location = new Point(429, 10);
            btnHienTatCa.Name = "btnHienTatCa";
            btnHienTatCa.Size = new Size(131, 29);
            btnHienTatCa.TabIndex = 4;
            btnHienTatCa.Text = "Hiện tất cả";
            btnHienTatCa.UseVisualStyleBackColor = true;
            btnHienTatCa.Click += btnHienTatCa_Click;
            // 
            // frmNhatKy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnHienTatCa);
            Controls.Add(btnXemTheoNgay);
            Controls.Add(dtpNgay);
            Controls.Add(label1);
            Controls.Add(dataGridView);
            Name = "frmNhatKy";
            Text = "Nhật ký";
            Load += frmNhatKy_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn User;
        private DataGridViewTextBoxColumn Table;
        private DataGridViewTextBoxColumn Action;
        private DataGridViewTextBoxColumn OldValue;
        private DataGridViewTextBoxColumn NewValue;
        private DataGridViewTextBoxColumn AffectAt;
        private Label label1;
        private DateTimePicker dtpNgay;
        private Button btnXemTheoNgay;
        private Button btnHienTatCa;
    }
}