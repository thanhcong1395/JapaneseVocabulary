
namespace study_japanese.Views
{
    partial class ThreeLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThreeLine));
            this.WordHanTu = new System.Windows.Forms.Label();
            this.WordMeans = new System.Windows.Forms.Label();
            this.WordFuri = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.setting = new System.Windows.Forms.Button();
            this.no = new System.Windows.Forms.Button();
            this.yes = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // WordHanTu
            // 
            this.WordHanTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WordHanTu.ForeColor = System.Drawing.Color.Red;
            this.WordHanTu.Location = new System.Drawing.Point(76, 85);
            this.WordHanTu.Name = "WordHanTu";
            this.WordHanTu.Size = new System.Drawing.Size(300, 30);
            this.WordHanTu.TabIndex = 27;
            this.WordHanTu.Text = "label2";
            this.WordHanTu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WordMeans
            // 
            this.WordMeans.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WordMeans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WordMeans.Location = new System.Drawing.Point(54, 153);
            this.WordMeans.Name = "WordMeans";
            this.WordMeans.Size = new System.Drawing.Size(350, 24);
            this.WordMeans.TabIndex = 26;
            this.WordMeans.Text = "label3";
            this.WordMeans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WordFuri
            // 
            this.WordFuri.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WordFuri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WordFuri.Location = new System.Drawing.Point(77, 49);
            this.WordFuri.Name = "WordFuri";
            this.WordFuri.Size = new System.Drawing.Size(300, 24);
            this.WordFuri.TabIndex = 25;
            this.WordFuri.Text = "label1";
            this.WordFuri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // back
            // 
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.ForeColor = System.Drawing.Color.Silver;
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.Location = new System.Drawing.Point(12, 12);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(30, 30);
            this.back.TabIndex = 24;
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // setting
            // 
            this.setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setting.ForeColor = System.Drawing.Color.Silver;
            this.setting.Image = ((System.Drawing.Image)(resources.GetObject("setting.Image")));
            this.setting.Location = new System.Drawing.Point(398, 12);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(30, 30);
            this.setting.TabIndex = 23;
            this.setting.UseVisualStyleBackColor = true;
            this.setting.Click += new System.EventHandler(this.setting_Click);
            // 
            // no
            // 
            this.no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.no.ForeColor = System.Drawing.Color.Silver;
            this.no.Image = ((System.Drawing.Image)(resources.GetObject("no.Image")));
            this.no.Location = new System.Drawing.Point(398, 85);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(30, 30);
            this.no.TabIndex = 22;
            this.no.UseVisualStyleBackColor = true;
            this.no.Click += new System.EventHandler(this.no_Click);
            // 
            // yes
            // 
            this.yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yes.ForeColor = System.Drawing.Color.Silver;
            this.yes.Image = ((System.Drawing.Image)(resources.GetObject("yes.Image")));
            this.yes.Location = new System.Drawing.Point(398, 49);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(30, 30);
            this.yes.TabIndex = 21;
            this.yes.UseVisualStyleBackColor = true;
            this.yes.Click += new System.EventHandler(this.yes_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ThreeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(440, 200);
            this.Controls.Add(this.WordHanTu);
            this.Controls.Add(this.WordMeans);
            this.Controls.Add(this.WordFuri);
            this.Controls.Add(this.back);
            this.Controls.Add(this.setting);
            this.Controls.Add(this.no);
            this.Controls.Add(this.yes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ThreeLine";
            this.Text = "ThreeLine";
            this.Load += new System.EventHandler(this.ThreeLine_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label WordHanTu;
        private System.Windows.Forms.Label WordMeans;
        private System.Windows.Forms.Label WordFuri;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button setting;
        private System.Windows.Forms.Button no;
        private System.Windows.Forms.Button yes;
        private System.Windows.Forms.Timer timer1;
    }
}