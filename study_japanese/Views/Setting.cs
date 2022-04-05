﻿using study_japanese.Models;
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

namespace study_japanese.Views
{
    public partial class Setting : Form
    {
        SettingInfoDto setConfig = new SettingInfoDto();
        Models.Control ctrl = new Models.Control();


        public Setting()
        {
            setConfig.furigana = true;
            setConfig.means = true;
            setConfig.hanTu = false;
            setConfig.example = false;
            setConfig.mode = SettingInfoDto.enmMode.MOTMAT;
            setConfig.speed = 3;
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
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Hide();
            setConfig.speed = Convert.ToInt32(this.textBox1.Text);
            ctrl.getNewWords();
            ctrl.showNewWord(setConfig);
        }

        public SettingInfoDto settingInfo()
        {
            return setConfig;
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
    }
}
