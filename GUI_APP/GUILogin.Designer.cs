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
            label1.Location = new Point(194, 34);
            label1.Name = "label1";
            label1.Size = new Size(588, 68);
            label1.TabIndex = 0;
            label1.Text = "WELCOME TO MYUMKM";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 9.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(399, 123);
            label2.Name = "label2";
            label2.Size = new Size(122, 49);
            label2.TabIndex = 1;
            label2.Text = "LOGIN";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(111, 217);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(100, 25);
            labelUsername.TabIndex = 2;
            labelUsername.Text = "Username :";
            // 
            // labelPass
            // 
            labelPass.AutoSize = true;
            labelPass.Location = new Point(116, 277);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(96, 25);
            labelPass.TabIndex = 3;
            labelPass.Text = "Password :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioPembeli);
            groupBox1.Controls.Add(radioUMKM);
            groupBox1.Location = new Point(216, 336);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 70);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // radioPembeli
            // 
            radioPembeli.AutoSize = true;
            radioPembeli.Location = new Point(167, 23);
            radioPembeli.Name = "radioPembeli";
            radioPembeli.Size = new Size(99, 29);
            radioPembeli.TabIndex = 1;
            radioPembeli.TabStop = true;
            radioPembeli.Text = "Pembeli";
            radioPembeli.UseVisualStyleBackColor = true;
            radioPembeli.CheckedChanged += radioPembeli_CheckedChanged;
            // 
            // radioUMKM
            // 
            radioUMKM.AutoSize = true;
            radioUMKM.Location = new Point(25, 24);
            radioUMKM.Name = "radioUMKM";
            radioUMKM.Size = new Size(91, 29);
            radioUMKM.TabIndex = 0;
            radioUMKM.TabStop = true;
            radioUMKM.Text = "UMKM";
            radioUMKM.UseVisualStyleBackColor = true;
            radioUMKM.CheckedChanged += radioUMKM_CheckedChanged;
            // 
            // fieldUser
            // 
            fieldUser.Location = new Point(216, 220);
            fieldUser.Name = "fieldUser";
            fieldUser.Size = new Size(470, 31);
            fieldUser.TabIndex = 5;
            // 
            // FieldPass
            // 
            FieldPass.Location = new Point(216, 277);
            FieldPass.Name = "FieldPass";
            FieldPass.Size = new Size(470, 31);
            FieldPass.TabIndex = 5;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(409, 437);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(112, 34);
            buttonLogin.TabIndex = 6;
            buttonLogin.Text = "LOGIN";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 562);
            Controls.Add(buttonLogin);
            Controls.Add(FieldPass);
            Controls.Add(fieldUser);
            Controls.Add(groupBox1);
            Controls.Add(labelPass);
            Controls.Add(labelUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
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
