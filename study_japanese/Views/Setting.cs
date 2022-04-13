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

namespace study_japanese.Views
{
    public partial class Setting : Form
    {
        private SettingInfoDto setConfig = new SettingInfoDto();
        public bool exitApp = false;

        public Setting()
        {
            setConfig.furigana = true;
            setConfig.means = true;
            setConfig.hanTu = false;
            setConfig.example = false;
            setConfig.mode = SettingInfoDto.enmMode.MOTMAT;
            setConfig.speed = 3;
            setConfig.random = true;
            setConfig.effect = true;
            setConfig.startUp = true;
            InitializeComponent();
            this.textBox1.Text = "5";
        }

        private void furigana_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.furigana = furigana.Checked;
        }

        private void nghia_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.means = nghia.Checked;
        }

        private void hanTu_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.hanTu = hanTu.Checked;
        }

        private void viDu_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.example = viDu.Checked;
        }

        private void mode1Mat_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.mode = SettingInfoDto.enmMode.MOTMAT;
        }

        private void mode2Mat_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.mode = SettingInfoDto.enmMode.HAIMAT;
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
            this.Hide();
            startup(setConfig.startUp);
            setConfig.speed = Convert.ToInt32(this.textBox1.Text);
        }

        private void startup(bool startup)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if(startup)
            {
                reg.SetValue("Wiki Japan", Application.ExecutablePath.ToString());
            }
            else
            {
                reg.DeleteValue("Wiki Japan");
            }    
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
            Int32.TryParse(this.textBox1.Text, out box);
            if(box == 0 && this.textBox1.Text != string.Empty)
            {
                this.textBox1.Text = "1";
            }
            else if(box > 900 && this.textBox1.Text != string.Empty)
            {
                this.textBox1.Text = "900";
            }
        }

        public SettingInfoDto getConfig()
        {
            return this.setConfig;
        }

        private void random_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.random = true;
        }

        private void tuanTu_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.random = false;
        }

        private void effect_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.effect = effect.Checked;
        }

        private void startUp_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.startUp = start_up.Checked;
        }
    }
}
