
namespace study_japanese.Views
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.furigana = new System.Windows.Forms.CheckBox();
            this.nghia = new System.Windows.Forms.CheckBox();
            this.hanTu = new System.Windows.Forms.CheckBox();
            this.viDu = new System.Windows.Forms.CheckBox();
            this.mode1Mat = new System.Windows.Forms.RadioButton();
            this.mode2Mat = new System.Windows.Forms.RadioButton();
            this.link = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(464, 198);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hiển thị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chế độ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(27, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tốc độ";
            // 
            // furigana
            // 
            this.furigana.AutoSize = true;
            this.furigana.Checked = true;
            this.furigana.CheckState = System.Windows.Forms.CheckState.Checked;
            this.furigana.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.furigana.ForeColor = System.Drawing.Color.White;
            this.furigana.Location = new System.Drawing.Point(165, 224);
            this.furigana.Name = "furigana";
            this.furigana.Size = new System.Drawing.Size(112, 26);
            this.furigana.TabIndex = 4;
            this.furigana.Text = "Furigana";
            this.furigana.UseVisualStyleBackColor = true;
            this.furigana.CheckedChanged += new System.EventHandler(this.furigana_CheckedChanged);
            // 
            // nghia
            // 
            this.nghia.AutoSize = true;
            this.nghia.Checked = true;
            this.nghia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nghia.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nghia.ForeColor = System.Drawing.Color.White;
            this.nghia.Location = new System.Drawing.Point(297, 224);
            this.nghia.Name = "nghia";
            this.nghia.Size = new System.Drawing.Size(82, 26);
            this.nghia.TabIndex = 5;
            this.nghia.Text = "Nghĩa";
            this.nghia.UseVisualStyleBackColor = true;
            this.nghia.CheckedChanged += new System.EventHandler(this.nghia_CheckedChanged);
            // 
            // hanTu
            // 
            this.hanTu.AutoSize = true;
            this.hanTu.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hanTu.ForeColor = System.Drawing.Color.White;
            this.hanTu.Location = new System.Drawing.Point(165, 256);
            this.hanTu.Name = "hanTu";
            this.hanTu.Size = new System.Drawing.Size(90, 26);
            this.hanTu.TabIndex = 6;
            this.hanTu.Text = "Hán tự";
            this.hanTu.UseVisualStyleBackColor = true;
            this.hanTu.CheckedChanged += new System.EventHandler(this.hanTu_CheckedChanged);
            // 
            // viDu
            // 
            this.viDu.AutoSize = true;
            this.viDu.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viDu.ForeColor = System.Drawing.Color.White;
            this.viDu.Location = new System.Drawing.Point(297, 256);
            this.viDu.Name = "viDu";
            this.viDu.Size = new System.Drawing.Size(76, 26);
            this.viDu.TabIndex = 7;
            this.viDu.Text = "Ví dụ";
            this.viDu.UseVisualStyleBackColor = true;
            this.viDu.CheckedChanged += new System.EventHandler(this.viDu_CheckedChanged);
            // 
            // mode1Mat
            // 
            this.mode1Mat.AutoSize = true;
            this.mode1Mat.Checked = true;
            this.mode1Mat.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mode1Mat.ForeColor = System.Drawing.Color.White;
            this.mode1Mat.Location = new System.Drawing.Point(165, 295);
            this.mode1Mat.Name = "mode1Mat";
            this.mode1Mat.Size = new System.Drawing.Size(78, 26);
            this.mode1Mat.TabIndex = 8;
            this.mode1Mat.TabStop = true;
            this.mode1Mat.Text = "1 mặt";
            this.mode1Mat.UseVisualStyleBackColor = true;
            this.mode1Mat.CheckedChanged += new System.EventHandler(this.mode1Mat_CheckedChanged);
            // 
            // mode2Mat
            // 
            this.mode2Mat.AutoSize = true;
            this.mode2Mat.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mode2Mat.ForeColor = System.Drawing.Color.White;
            this.mode2Mat.Location = new System.Drawing.Point(297, 295);
            this.mode2Mat.Name = "mode2Mat";
            this.mode2Mat.Size = new System.Drawing.Size(78, 26);
            this.mode2Mat.TabIndex = 9;
            this.mode2Mat.Text = "2 mặt";
            this.mode2Mat.UseVisualStyleBackColor = true;
            this.mode2Mat.CheckedChanged += new System.EventHandler(this.mode2Mat_CheckedChanged);
            // 
            // link
            // 
            this.link.AutoSize = true;
            this.link.BackColor = System.Drawing.Color.Transparent;
            this.link.Cursor = System.Windows.Forms.Cursors.Hand;
            this.link.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.link.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link.ForeColor = System.Drawing.Color.White;
            this.link.Location = new System.Drawing.Point(364, 173);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(88, 16);
            this.link.TabIndex = 10;
            this.link.Text = "link trang web";
            this.link.Click += new System.EventHandler(this.link_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(293, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "thẻ/s";
            // 
            // ok
            // 
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok.ForeColor = System.Drawing.Color.Gray;
            this.ok.Image = ((System.Drawing.Image)(resources.GetObject("ok.Image")));
            this.ok.Location = new System.Drawing.Point(422, 217);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(30, 30);
            this.ok.TabIndex = 12;
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // exit
            // 
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.ForeColor = System.Drawing.Color.Gray;
            this.exit.Image = ((System.Drawing.Image)(resources.GetObject("exit.Image")));
            this.exit.Location = new System.Drawing.Point(422, 268);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(30, 30);
            this.exit.TabIndex = 13;
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(464, 380);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.link);
            this.Controls.Add(this.mode2Mat);
            this.Controls.Add(this.mode1Mat);
            this.Controls.Add(this.viDu);
            this.Controls.Add(this.hanTu);
            this.Controls.Add(this.nghia);
            this.Controls.Add(this.furigana);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Setting";
            this.Text = "Wiki Japan";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox furigana;
        private System.Windows.Forms.CheckBox nghia;
        private System.Windows.Forms.CheckBox hanTu;
        private System.Windows.Forms.CheckBox viDu;
        private System.Windows.Forms.RadioButton mode1Mat;
        private System.Windows.Forms.RadioButton mode2Mat;
        private System.Windows.Forms.Label link;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button exit;
    }
}