
namespace study_japanese.Views
{
    partial class NewWords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewWords));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.yes = new System.Windows.Forms.PictureBox();
            this.no = new System.Windows.Forms.PictureBox();
            this.setting = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.yes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.no)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setting)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(76, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(300, 60);
            this.label5.TabIndex = 41;
            this.label5.Text = "label5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(76, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 60);
            this.label4.TabIndex = 40;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(76, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 60);
            this.label3.TabIndex = 39;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(76, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 60);
            this.label2.TabIndex = 38;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(76, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 60);
            this.label1.TabIndex = 37;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // back
            // 
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.ForeColor = System.Drawing.Color.Silver;
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.Location = new System.Drawing.Point(411, -2);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(30, 30);
            this.back.TabIndex = 36;
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8_Done_30px.png");
            this.imageList1.Images.SetKeyName(1, "icons8_Done_30px_1.png");
            this.imageList1.Images.SetKeyName(2, "icons8_multiply_35px.png");
            this.imageList1.Images.SetKeyName(3, "icons8_multiply_35px_1.png");
            // 
            // yes
            // 
            this.yes.Image = ((System.Drawing.Image)(resources.GetObject("yes.Image")));
            this.yes.Location = new System.Drawing.Point(12, 47);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(30, 30);
            this.yes.TabIndex = 42;
            this.yes.TabStop = false;
            this.yes.Click += new System.EventHandler(this.yes_Click);
            this.yes.MouseLeave += new System.EventHandler(this.yes_leave);
            this.yes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.yes_move);
            // 
            // no
            // 
            this.no.Image = ((System.Drawing.Image)(resources.GetObject("no.Image")));
            this.no.Location = new System.Drawing.Point(12, 85);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(30, 30);
            this.no.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.no.TabIndex = 43;
            this.no.TabStop = false;
            this.no.Click += new System.EventHandler(this.no_Click);
            this.no.MouseLeave += new System.EventHandler(this.no_leave);
            this.no.MouseMove += new System.Windows.Forms.MouseEventHandler(this.no_move);
            // 
            // setting
            // 
            this.setting.Image = ((System.Drawing.Image)(resources.GetObject("setting.Image")));
            this.setting.Location = new System.Drawing.Point(12, 12);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(30, 30);
            this.setting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.setting.TabIndex = 44;
            this.setting.TabStop = false;
            this.setting.Click += new System.EventHandler(this.setting_Click);
            this.setting.MouseLeave += new System.EventHandler(this.setting_leave);
            this.setting.MouseMove += new System.Windows.Forms.MouseEventHandler(this.setting_move);
            // 
            // NewWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(440, 220);
            this.Controls.Add(this.setting);
            this.Controls.Add(this.no);
            this.Controls.Add(this.yes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.back);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewWords";
            this.Text = "Wiki Japan";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.yes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.no)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox yes;
        private System.Windows.Forms.PictureBox no;
        private System.Windows.Forms.PictureBox setting;
    }
}