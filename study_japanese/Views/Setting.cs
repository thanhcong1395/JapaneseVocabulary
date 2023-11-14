using study_japanese.Models;
using study_japanese.Models.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace study_japanese.Views
{
    public partial class Setting : Form
    {
        public bool exitApp = false;

        public Setting()
        {
            InitializeComponent();
            this.ShowSettingFile();
        }

        public void ShowSettingFile()
        {
            Set.ReadSettingFile();
            // hien thi
            this.textBox1.Text = Set.settingConfig.Speed.ToString();
            this.textBox2.Text = Set.settingConfig.HiddenTime.ToString();
            this.furigana.Checked = Set.settingConfig.Furigana;
            this.furigana.CheckState = (Set.settingConfig.Furigana) ? CheckState.Checked : CheckState.Unchecked;
            this.nghia.Checked = Set.settingConfig.Means;
            this.nghia.CheckState = (Set.settingConfig.Means) ? CheckState.Checked : CheckState.Unchecked;
            this.hanTu.Checked = Set.settingConfig.HanTu;
            this.hanTu.CheckState = (Set.settingConfig.HanTu) ? CheckState.Checked : CheckState.Unchecked;
            this.viDu.Checked = Set.settingConfig.Example;
            this.viDu.CheckState = (Set.settingConfig.Example) ? CheckState.Checked : CheckState.Unchecked;
            this.start_up.Checked = Set.settingConfig.StartUp;
            this.start_up.CheckState = (Set.settingConfig.StartUp) ? CheckState.Checked : CheckState.Unchecked; ;
            this.effect.Checked = Set.settingConfig.Effect;
            this.effect.CheckState = (Set.settingConfig.Effect) ? CheckState.Checked : CheckState.Unchecked;
            if (Set.settingConfig.Mode == (int)SettingInfoDto.enmMode.MOTMAT)
            {
                this.mode1Mat.Checked = true;
                this.mode2Mat.Checked = false;
            }
            else
            {
                this.mode2Mat.Checked = true;
                this.mode1Mat.Checked = false;
            }
            if (Set.settingConfig.Random)
            {
                this.radioButton3.Checked = true;
                this.radioButton4.Checked = false;
            }
            else
            {
                this.radioButton4.Checked = true;
                this.radioButton3.Checked = false;
            }
        }

        private void Startup(bool startup)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            object name = reg.GetValue("Wiki Japan");
            if (startup)
            {
                if (name == null)
                {
                    reg.SetValue("Wiki Japan", Application.ExecutablePath.ToString());
                }
            }
            else
            {
                if (name != null)
                {
                    reg.DeleteValue("Wiki Japan");
                }
            }
        }

        private void furigana_CheckedChanged(object sender, EventArgs e)
        {
            Set.settingConfig.Furigana = furigana.Checked;
        }

        private void nghia_CheckedChanged(object sender, EventArgs e)
        {
            Set.settingConfig.Means = nghia.Checked;
        }

        private void hanTu_CheckedChanged(object sender, EventArgs e)
        {
            Set.settingConfig.HanTu = hanTu.Checked;
        }

        private void viDu_CheckedChanged(object sender, EventArgs e)
        {
            Set.settingConfig.Example = viDu.Checked;
        }

        private void mode1Mat_CheckedChanged(object sender, EventArgs e)
        {
            Set.settingConfig.Mode = SettingInfoDto.enmMode.MOTMAT;
        }

        private void mode2Mat_CheckedChanged(object sender, EventArgs e)
        {
            Set.settingConfig.Mode = SettingInfoDto.enmMode.HAIMAT;
        }

        private void link_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Config.urlWeb);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.exitApp = true;
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Startup(Set.settingConfig.StartUp);
            Set.WriteSettingFile();
            this.Hide();
            //this.Close();
        }

        private void Speed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void SpeedChanged(object sender, EventArgs e)
        {
            int box = 0;
            if (Int32.TryParse(this.textBox1.Text, out box))
            {
                if (box == 0 && this.textBox1.Text != string.Empty)
                {
                    this.textBox1.Text = "1";
                }
                else if (box > 900 && this.textBox1.Text != string.Empty)
                {
                    this.textBox1.Text = "900";
                }
                Set.settingConfig.Speed = Convert.ToInt32(this.textBox1.Text);
            }
        }

        private void random_CheckedChanged(object sender, EventArgs e)
        {
            Set.settingConfig.Random = true;
        }

        private void tuanTu_CheckedChanged(object sender, EventArgs e)
        {
            Set.settingConfig.Random = false;
        }

        private void effect_CheckedChanged(object sender, EventArgs e)
        {
            Set.settingConfig.Effect = effect.Checked;
        }

        private void startUp_CheckedChanged(object sender, EventArgs e)
        {
            Set.settingConfig.StartUp = start_up.Checked;
        }

        private void ok_move(object sender, MouseEventArgs e)
        {
            this.ok.Image = Image.FromFile(@"..\\..\\Image\\icons8_Done_30px.png");
        }

        private void ok_leave(object sender, EventArgs e)
        {
            this.ok.Image = Image.FromFile(@"..\\..\\Image\\icons8_Done_30px_1.png");
        }

        private void exit_leave(object sender, EventArgs e)
        {
            this.exit.Image = Image.FromFile(@"..\\..\\Image\\icons8_multiply_35px_1.png");
        }

        private void exit_move(object sender, MouseEventArgs e)
        {
            this.exit.Image = Image.FromFile(@"..\\..\Image\\icons8_multiply_35px.png");
        }

        private void HideTime(object sender, EventArgs e)
        {
            int box = 0;
            if(Int32.TryParse(this.textBox2.Text, out box))
            {
                if (box == 0 && this.textBox2.Text != string.Empty)
                {
                    this.textBox2.Text = "1";
                }
                else if (box > 900 && this.textBox2.Text != string.Empty)
                {
                    this.textBox2.Text = "900";
                }
                Set.settingConfig.HiddenTime = Convert.ToInt32(this.textBox2.Text);
            }
        }

        private void HideTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
