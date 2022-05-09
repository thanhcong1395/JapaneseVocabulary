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
        private SettingInfoDto setConfig = new SettingInfoDto();
        public bool exitApp = false;

        public Setting()
        {
            InitializeComponent();
            this.readSettingFile();
            
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
            this.startup(setConfig.startUp);
            setConfig.speed = Convert.ToInt32(this.textBox1.Text);
            this.writeSettingFile();
        }

        private void startup(bool startup)
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

        private void readSettingFile()
        {
            if (File.Exists(Config.settingFile))
            {
                JObject data = JObject.Parse(File.ReadAllText(Config.settingFile));
                setConfig.furigana = (bool)data["furigana"];
                setConfig.means = (bool)data["means"];
                setConfig.hanTu = (bool)data["hanTu"];
                setConfig.example = (bool)data["example"];
                setConfig.mode = ((int)data["mode"] == (int)SettingInfoDto.enmMode.MOTMAT) ? SettingInfoDto.enmMode.MOTMAT : SettingInfoDto.enmMode.HAIMAT;
                setConfig.speed = (int)data["speed"];
                setConfig.random = (bool)data["random"];
                setConfig.effect = (bool)data["effect"];
                setConfig.startUp = (bool)data["startUp"];
            }
            else
            {
                setConfig.furigana = true;
                setConfig.means = true;
                setConfig.hanTu = false;
                setConfig.example = false;
                setConfig.mode = SettingInfoDto.enmMode.MOTMAT;
                setConfig.speed = 5;
                setConfig.random = true;
                setConfig.effect = true;
                setConfig.startUp = true;

                // ghi file setting.json
                this.writeSettingFile();
            }

            // hien thi
            this.textBox1.Text = setConfig.speed.ToString();
            this.furigana.Checked = setConfig.furigana;
            this.furigana.CheckState = (setConfig.furigana) ? CheckState.Checked : CheckState.Unchecked;
            this.nghia.Checked = setConfig.means;
            this.nghia.CheckState = (setConfig.means) ? CheckState.Checked : CheckState.Unchecked;
            this.hanTu.Checked = setConfig.hanTu;
            this.hanTu.CheckState = (setConfig.hanTu) ? CheckState.Checked : CheckState.Unchecked;
            this.viDu.Checked = setConfig.example;
            this.viDu.CheckState = (setConfig.example) ? CheckState.Checked : CheckState.Unchecked;
            this.start_up.Checked = setConfig.startUp;
            this.start_up.CheckState = (setConfig.startUp) ? CheckState.Checked : CheckState.Unchecked; ;
            this.effect.Checked = setConfig.effect;
            this.effect.CheckState = (setConfig.effect) ? CheckState.Checked : CheckState.Unchecked;
            if (setConfig.mode == (int)SettingInfoDto.enmMode.MOTMAT)
            {
                this.mode1Mat.Checked = true;
                this.mode2Mat.Checked = false;
            }
            else
            {
                this.mode2Mat.Checked = true;
                this.mode1Mat.Checked = false;
            }
            if (setConfig.random)
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

        private void writeSettingFile()
        {
            string JsonResult = JsonConvert.SerializeObject(setConfig);
            byte[] vs = Encoding.UTF8.GetBytes(JsonResult);
            FileStream fs = new FileStream(Config.settingFile, FileMode.Create);
            fs.Write(vs, 0, JsonResult.Length);
            fs.Close();
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

    }
}
