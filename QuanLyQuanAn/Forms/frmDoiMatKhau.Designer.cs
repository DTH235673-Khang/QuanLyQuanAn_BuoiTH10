namespace QuanLyQuanAn.Forms
{
    partial class frmDoiMatKhau
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
            btnHuyBo = new Button();
            btnXacNhan = new Button();
            txtTenDangNhap = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            txtMatKhauMoi = new TextBox();
            label4 = new Label();
            txtXacNhanMatKhau = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(307, 237);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(94, 29);
            btnHuyBo.TabIndex = 15;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Location = new Point(160, 237);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(94, 29);
            btnXacNhan.TabIndex = 14;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(162, 88);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(241, 27);
            txtTenDangNhap.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 65);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 10;
            label2.Text = "Tên đăng nhập:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(162, 9);
            label1.Name = "label1";
            label1.Size = new Size(226, 38);
            label1.TabIndex = 9;
            label1.Text = "ĐỔI MẬT KHẨU";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.log_in;
            pictureBox1.Location = new Point(12, 82);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(133, 137);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(162, 139);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '*';
            txtMatKhauMoi.Size = new Size(241, 27);
            txtMatKhauMoi.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(162, 116);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 16;
            label4.Text = "Mật khẩu mới:";
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.Location = new Point(162, 192);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.PasswordChar = '*';
            txtXacNhanMatKhau.Size = new Size(241, 27);
            txtXacNhanMatKhau.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(162, 169);
            label5.Name = "label5";
            label5.Size = new Size(137, 20);
            label5.TabIndex = 18;
            label5.Text = "Xác nhận mật khẩu:";
            // 
            // frmDoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 278);
            Controls.Add(txtXacNhanMatKhau);
            Controls.Add(label5);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(label4);
            Controls.Add(btnHuyBo);
            Controls.Add(btnXacNhan);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDoiMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đổi mật khẩu";
            Load += frmDoiMatKhau_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHuyBo;
        private Button btnXacNhan;
        public TextBox txtTenDangNhap;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        public TextBox txtMatKhauMoi;
        private Label label4;
        public TextBox txtXacNhanMatKhau;
        private Label label5;
    }
}