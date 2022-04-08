
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
            this.setting = new System.Windows.Forms.Button();
            this.no = new System.Windows.Forms.Button();
            this.yes = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(76, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(300, 23);
            this.label5.TabIndex = 41;
            this.label5.Text = "label5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 23);
            this.label4.TabIndex = 40;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 23);
            this.label3.TabIndex = 39;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 23);
            this.label1.TabIndex = 37;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // back
            // 
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.ForeColor = System.Drawing.Color.Silver;
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.Location = new System.Drawing.Point(12, 11);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(30, 30);
            this.back.TabIndex = 36;
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // setting
            // 
            this.setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setting.ForeColor = System.Drawing.Color.Silver;
            this.setting.Image = ((System.Drawing.Image)(resources.GetObject("setting.Image")));
            this.setting.Location = new System.Drawing.Point(398, 11);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(30, 30);
            this.setting.TabIndex = 35;
            this.setting.UseVisualStyleBackColor = true;
            this.setting.Click += new System.EventHandler(this.setting_Click);
            // 
            // no
            // 
            this.no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.no.ForeColor = System.Drawing.Color.Silver;
            this.no.Image = ((System.Drawing.Image)(resources.GetObject("no.Image")));
            this.no.Location = new System.Drawing.Point(398, 84);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(30, 30);
            this.no.TabIndex = 34;
            this.no.UseVisualStyleBackColor = true;
            this.no.Click += new System.EventHandler(this.no_Click);
            // 
            // yes
            // 
            this.yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yes.ForeColor = System.Drawing.Color.Silver;
            this.yes.Image = ((System.Drawing.Image)(resources.GetObject("yes.Image")));
            this.yes.Location = new System.Drawing.Point(398, 48);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(30, 30);
            this.yes.TabIndex = 33;
            this.yes.UseVisualStyleBackColor = true;
            this.yes.Click += new System.EventHandler(this.yes_Click);
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
            // NewWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(440, 220);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.setting);
            this.Controls.Add(this.no);
            this.Controls.Add(this.yes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewWords";
            this.Text = "Wiki Japan";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button setting;
        private System.Windows.Forms.Button no;
        private System.Windows.Forms.Button yes;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}