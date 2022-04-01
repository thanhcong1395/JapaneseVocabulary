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

        public Setting()
        {
            setConfig.furigana = true;
            setConfig.mean = true;
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
            setConfig.mean = furigana.Checked;
        }

        private void hanTu_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.hanTu = hanTu.Checked;
        }

        private void viDu_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.mean = viDu.Checked;
        }

        private void mode1Mat_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.mode = SettingInfoDto.enmMode.MOTMAT;
        }

        private void mode2Mat_CheckedChanged(object sender, EventArgs e)
        {
            setConfig.mode = SettingInfoDto.enmMode.HAIMAT;
        }
    }
}
