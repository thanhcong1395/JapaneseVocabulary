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
using study_japanese.Models;

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
            setConfig.speed = 5;
            InitializeComponent();
        }

        private void furigana_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.furigana = furigana.Checked;
        }

        private void nghia_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.means = furigana.Checked;
        }

        private void hanTu_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.hanTu = hanTu.Checked;
        }

        private void viDu_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.means = viDu.Checked;
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
            ctrl.showNewWord(setConfig);
        }
    }
}
