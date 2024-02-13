namespace JsonParser
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
            this.fileBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnParsing = new System.Windows.Forms.Button();
            this.Btn_Check_File_Create = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileBtn
            // 
            this.fileBtn.Location = new System.Drawing.Point(20, 32);
            this.fileBtn.Name = "fileBtn";
            this.fileBtn.Size = new System.Drawing.Size(125, 23);
            this.fileBtn.TabIndex = 0;
            this.fileBtn.Text = "json파일 선택";
            this.fileBtn.UseVisualStyleBackColor = true;
            this.fileBtn.Click += new System.EventHandler(this.fileClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnParsing
            // 
            this.btnParsing.Location = new System.Drawing.Point(151, 32);
            this.btnParsing.Name = "btnParsing";
            this.btnParsing.Size = new System.Drawing.Size(125, 23);
            this.btnParsing.TabIndex = 1;
            this.btnParsing.Text = "파싱시작";
            this.btnParsing.UseVisualStyleBackColor = true;
            this.btnParsing.Click += new System.EventHandler(this.btnParsing_Click);
            // 
            // Btn_Check_File_Create
            // 
            this.Btn_Check_File_Create.Location = new System.Drawing.Point(20, 30);
            this.Btn_Check_File_Create.Name = "Btn_Check_File_Create";
            this.Btn_Check_File_Create.Size = new System.Drawing.Size(125, 23);
            this.Btn_Check_File_Create.TabIndex = 2;
            this.Btn_Check_File_Create.Text = "Check 파일만들기";
            this.Btn_Check_File_Create.UseVisualStyleBackColor = true;
            this.Btn_Check_File_Create.Click += new System.EventHandler(this.Btn_Check_File_Create_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fileBtn);
            this.groupBox1.Controls.Add(this.btnParsing);
            this.groupBox1.Location = new System.Drawing.Point(25, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 133);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Json 파싱하기";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_Check_File_Create);
            this.groupBox2.Location = new System.Drawing.Point(25, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 135);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Check 파일만들기";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button fileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnParsing;
        private System.Windows.Forms.Button Btn_Check_File_Create;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

