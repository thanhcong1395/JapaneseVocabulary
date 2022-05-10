
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.yes = new System.Windows.Forms.PictureBox();
            this.no = new System.Windows.Forms.PictureBox();
            this.setting = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.downSpeed = new System.Windows.Forms.PictureBox();
            this.upSpeed = new System.Windows.Forms.PictureBox();
            this.repeat = new System.Windows.Forms.PictureBox();
            this.next = new System.Windows.Forms.PictureBox();
            this.previous = new System.Windows.Forms.PictureBox();
            this.play = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.yes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.no)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previous)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.play)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 30);
            this.label3.TabIndex = 39;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 30);
            this.label2.TabIndex = 38;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 30);
            this.label1.TabIndex = 37;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // yes
            // 
            this.yes.Image = ((System.Drawing.Image)(resources.GetObject("yes.Image")));
            this.yes.Location = new System.Drawing.Point(315, 56);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(25, 25);
            this.yes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.yes.TabIndex = 42;
            this.yes.TabStop = false;
            this.yes.Click += new System.EventHandler(this.yes_Click);
            this.yes.MouseLeave += new System.EventHandler(this.yes_leave);
            this.yes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.yes_move);
            // 
            // no
            // 
            this.no.Image = ((System.Drawing.Image)(resources.GetObject("no.Image")));
            this.no.Location = new System.Drawing.Point(315, 84);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(25, 25);
            this.no.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.no.TabIndex = 43;
            this.no.TabStop = false;
            this.no.Click += new System.EventHandler(this.no_Click);
            this.no.MouseLeave += new System.EventHandler(this.no_leave);
            this.no.MouseMove += new System.Windows.Forms.MouseEventHandler(this.no_move);
            // 
            // setting
            // 
            this.setting.Image = ((System.Drawing.Image)(resources.GetObject("setting.Image")));
            this.setting.Location = new System.Drawing.Point(315, 28);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(25, 25);
            this.setting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.setting.TabIndex = 44;
            this.setting.TabStop = false;
            this.setting.Click += new System.EventHandler(this.setting_Click);
            this.setting.MouseLeave += new System.EventHandler(this.setting_leave);
            this.setting.MouseMove += new System.Windows.Forms.MouseEventHandler(this.setting_move);
            // 
            // close
            // 
            this.close.Image = ((System.Drawing.Image)(resources.GetObject("close.Image")));
            this.close.Location = new System.Drawing.Point(315, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(25, 25);
            this.close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.close.TabIndex = 45;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.downSpeed);
            this.panel1.Controls.Add(this.upSpeed);
            this.panel1.Controls.Add(this.repeat);
            this.panel1.Controls.Add(this.next);
            this.panel1.Controls.Add(this.previous);
            this.panel1.Controls.Add(this.play);
            this.panel1.Location = new System.Drawing.Point(5, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 30);
            this.panel1.TabIndex = 46;
            this.panel1.Visible = false;
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_leave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_move);
            // 
            // downSpeed
            // 
            this.downSpeed.Image = ((System.Drawing.Image)(resources.GetObject("downSpeed.Image")));
            this.downSpeed.Location = new System.Drawing.Point(217, 3);
            this.downSpeed.Name = "downSpeed";
            this.downSpeed.Size = new System.Drawing.Size(25, 25);
            this.downSpeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.downSpeed.TabIndex = 52;
            this.downSpeed.TabStop = false;
            this.downSpeed.Click += new System.EventHandler(this.DownSpeed_Click);
            // 
            // upSpeed
            // 
            this.upSpeed.Image = ((System.Drawing.Image)(resources.GetObject("upSpeed.Image")));
            this.upSpeed.Location = new System.Drawing.Point(186, 3);
            this.upSpeed.Name = "upSpeed";
            this.upSpeed.Size = new System.Drawing.Size(25, 25);
            this.upSpeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.upSpeed.TabIndex = 51;
            this.upSpeed.TabStop = false;
            this.upSpeed.Click += new System.EventHandler(this.upSpeed_Click);
            // 
            // repeat
            // 
            this.repeat.Image = ((System.Drawing.Image)(resources.GetObject("repeat.Image")));
            this.repeat.Location = new System.Drawing.Point(155, 3);
            this.repeat.Name = "repeat";
            this.repeat.Size = new System.Drawing.Size(25, 25);
            this.repeat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.repeat.TabIndex = 50;
            this.repeat.TabStop = false;
            this.repeat.Click += new System.EventHandler(this.repeat_Click);
            // 
            // next
            // 
            this.next.Image = ((System.Drawing.Image)(resources.GetObject("next.Image")));
            this.next.Location = new System.Drawing.Point(124, 3);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(25, 25);
            this.next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.next.TabIndex = 49;
            this.next.TabStop = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // previous
            // 
            this.previous.Image = ((System.Drawing.Image)(resources.GetObject("previous.Image")));
            this.previous.Location = new System.Drawing.Point(93, 3);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(25, 25);
            this.previous.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previous.TabIndex = 48;
            this.previous.TabStop = false;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // play
            // 
            this.play.Image = ((System.Drawing.Image)(resources.GetObject("play.Image")));
            this.play.Location = new System.Drawing.Point(62, 3);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(25, 25);
            this.play.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.play.TabIndex = 47;
            this.play.TabStop = false;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // NewWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(340, 120);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.setting);
            this.Controls.Add(this.no);
            this.Controls.Add(this.yes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewWords";
            this.Text = "Wiki Japan";
            this.TopMost = true;
            this.MouseLeave += new System.EventHandler(this.NewWords_leave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewWords_move);
            ((System.ComponentModel.ISupportInitialize)(this.yes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.no)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.downSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previous)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.play)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox yes;
        private System.Windows.Forms.PictureBox no;
        private System.Windows.Forms.PictureBox setting;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox downSpeed;
        private System.Windows.Forms.PictureBox upSpeed;
        private System.Windows.Forms.PictureBox repeat;
        private System.Windows.Forms.PictureBox next;
        private System.Windows.Forms.PictureBox previous;
        private System.Windows.Forms.PictureBox play;
    }
}