namespace GUI_AplikasiUMKM
{
    partial class GUILogin
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
            this.LabelLogin = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.ButtonRegister = new System.Windows.Forms.Button();
            this.radioPembeli = new System.Windows.Forms.RadioButton();
            this.radioUMKM = new System.Windows.Forms.RadioButton();
            this.labelTypeUser = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelLogin
            // 
            this.LabelLogin.AutoSize = true;
            this.LabelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.LabelLogin.Location = new System.Drawing.Point(339, 96);
            this.LabelLogin.Name = "LabelLogin";
            this.LabelLogin.Size = new System.Drawing.Size(101, 39);
            this.LabelLogin.TabIndex = 0;
            this.LabelLogin.Text = "Login";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.labelWelcome.Location = new System.Drawing.Point(170, 21);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(450, 48);
            this.labelWelcome.TabIndex = 1;
            this.labelWelcome.Text = "Welcome To MyUMKM";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(106, 178);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(70, 16);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Username";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(109, 218);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(67, 16);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(182, 175);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(426, 22);
            this.textBoxUsername.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(183, 218);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(425, 22);
            this.textBoxPassword.TabIndex = 5;
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.Location = new System.Drawing.Point(433, 363);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(75, 26);
            this.ButtonLogin.TabIndex = 6;
            this.ButtonLogin.Text = "Login";
            this.ButtonLogin.UseVisualStyleBackColor = true;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // ButtonRegister
            // 
            this.ButtonRegister.Location = new System.Drawing.Point(272, 365);
            this.ButtonRegister.Name = "ButtonRegister";
            this.ButtonRegister.Size = new System.Drawing.Size(75, 24);
            this.ButtonRegister.TabIndex = 7;
            this.ButtonRegister.Text = "Register";
            this.ButtonRegister.UseVisualStyleBackColor = true;
            // 
            // radioPembeli
            // 
            this.radioPembeli.AutoSize = true;
            this.radioPembeli.Location = new System.Drawing.Point(6, 33);
            this.radioPembeli.Name = "radioPembeli";
            this.radioPembeli.Size = new System.Drawing.Size(78, 20);
            this.radioPembeli.TabIndex = 8;
            this.radioPembeli.TabStop = true;
            this.radioPembeli.Text = "Pembeli";
            this.radioPembeli.UseVisualStyleBackColor = true;
            this.radioPembeli.CheckedChanged += new System.EventHandler(this.radioPembeli_CheckedChanged);
            // 
            // radioUMKM
            // 
            this.radioUMKM.AutoSize = true;
            this.radioUMKM.Location = new System.Drawing.Point(126, 33);
            this.radioUMKM.Name = "radioUMKM";
            this.radioUMKM.Size = new System.Drawing.Size(68, 20);
            this.radioUMKM.TabIndex = 9;
            this.radioUMKM.TabStop = true;
            this.radioUMKM.Text = "UMKM";
            this.radioUMKM.UseVisualStyleBackColor = true;
            this.radioUMKM.CheckedChanged += new System.EventHandler(this.radioUMKM_CheckedChanged);
            // 
            // labelTypeUser
            // 
            this.labelTypeUser.AutoSize = true;
            this.labelTypeUser.Location = new System.Drawing.Point(112, 293);
            this.labelTypeUser.Name = "labelTypeUser";
            this.labelTypeUser.Size = new System.Drawing.Size(64, 16);
            this.labelTypeUser.TabIndex = 10;
            this.labelTypeUser.Text = "TipeUser";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioPembeli);
            this.groupBox1.Controls.Add(this.radioUMKM);
            this.groupBox1.Location = new System.Drawing.Point(183, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 78);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelTypeUser);
            this.Controls.Add(this.ButtonRegister);
            this.Controls.Add(this.ButtonLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.LabelLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelLogin;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.Button ButtonRegister;
        private System.Windows.Forms.RadioButton radioPembeli;
        private System.Windows.Forms.RadioButton radioUMKM;
        private System.Windows.Forms.Label labelTypeUser;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

