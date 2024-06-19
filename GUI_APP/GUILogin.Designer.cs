namespace GUI_APP
{
    partial class GUILogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            labelUsername = new Label();
            labelPass = new Label();
            groupBox1 = new GroupBox();
            radioPembeli = new RadioButton();
            radioUMKM = new RadioButton();
            fieldUser = new TextBox();
            FieldPass = new TextBox();
            buttonLogin = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sans Serif Collection", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(155, 27);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(492, 59);
            label1.TabIndex = 0;
            label1.Text = "WELCOME TO MYUMKM";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 9.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(319, 98);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(110, 42);
            label2.TabIndex = 1;
            label2.Text = "LOGIN";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(89, 174);
            labelUsername.Margin = new Padding(2, 0, 2, 0);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(82, 20);
            labelUsername.TabIndex = 2;
            labelUsername.Text = "Username :";
            // 
            // labelPass
            // 
            labelPass.AutoSize = true;
            labelPass.Location = new Point(93, 222);
            labelPass.Margin = new Padding(2, 0, 2, 0);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(77, 20);
            labelPass.TabIndex = 3;
            labelPass.Text = "Password :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioPembeli);
            groupBox1.Controls.Add(radioUMKM);
            groupBox1.Location = new Point(173, 269);
            groupBox1.Margin = new Padding(2, 2, 2, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 2, 2, 2);
            groupBox1.Size = new Size(240, 56);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // radioPembeli
            // 
            radioPembeli.AutoSize = true;
            radioPembeli.Location = new Point(134, 18);
            radioPembeli.Margin = new Padding(2, 2, 2, 2);
            radioPembeli.Name = "radioPembeli";
            radioPembeli.Size = new Size(83, 24);
            radioPembeli.TabIndex = 1;
            radioPembeli.TabStop = true;
            radioPembeli.Text = "Pembeli";
            radioPembeli.UseVisualStyleBackColor = true;
            radioPembeli.CheckedChanged += radioPembeli_CheckedChanged;
            // 
            // radioUMKM
            // 
            radioUMKM.AutoSize = true;
            radioUMKM.Location = new Point(20, 19);
            radioUMKM.Margin = new Padding(2, 2, 2, 2);
            radioUMKM.Name = "radioUMKM";
            radioUMKM.Size = new Size(75, 24);
            radioUMKM.TabIndex = 0;
            radioUMKM.TabStop = true;
            radioUMKM.Text = "UMKM";
            radioUMKM.UseVisualStyleBackColor = true;
            radioUMKM.CheckedChanged += radioUMKM_CheckedChanged;
            // 
            // fieldUser
            // 
            fieldUser.Location = new Point(173, 176);
            fieldUser.Margin = new Padding(2, 2, 2, 2);
            fieldUser.Name = "fieldUser";
            fieldUser.Size = new Size(377, 27);
            fieldUser.TabIndex = 5;
            // 
            // FieldPass
            // 
            FieldPass.Location = new Point(173, 222);
            FieldPass.Margin = new Padding(2, 2, 2, 2);
            FieldPass.Name = "FieldPass";
            FieldPass.Size = new Size(377, 27);
            FieldPass.TabIndex = 5;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(327, 350);
            buttonLogin.Margin = new Padding(2, 2, 2, 2);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(90, 27);
            buttonLogin.TabIndex = 6;
            buttonLogin.Text = "LOGIN";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // GUILogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 450);
            Controls.Add(buttonLogin);
            Controls.Add(FieldPass);
            Controls.Add(fieldUser);
            Controls.Add(groupBox1);
            Controls.Add(labelPass);
            Controls.Add(labelUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "GUILogin";
            Text = "Form1";
            Load += GUILogin_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label labelUsername;
        private Label labelPass;
        private GroupBox groupBox1;
        private RadioButton radioUMKM;
        private RadioButton radioPembeli;
        private TextBox fieldUser;
        private TextBox FieldPass;
        private Button buttonLogin;
    }
}
