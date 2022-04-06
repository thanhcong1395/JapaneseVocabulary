using study_japanese.Models;
using study_japanese.Models.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using study_japanese;
namespace study_japanese.Views
{
    public partial class ThreeLine : Form
    {
        List<TuVungTableDto> newWords = new List<TuVungTableDto>();
        Random random = new Random();
        TuVungTableDto currentWord = new TuVungTableDto();
        SettingInfoDto config;
        private bool firstShow;

        public ThreeLine(SettingInfoDto config, List<TuVungTableDto> newWords)
        {
            InitializeComponent();
            this.firstShow = true;
            this.config = config;
            this.timer1.Interval = this.config.speed * 1000;
            this.timer1.Start();
            this.newWords = newWords;
            this.getRandomWord();
            this.showWord();
        }

        private void ThreeLine_Load(object sender, EventArgs e)
        {

        }

        private void yes_Click(object sender, EventArgs e)
        {
            string[] id = new string[1];
            id[0] = currentWord.Id.ToString();
            _event();
            File.AppendAllLines(Config.oldWordFile, id);
        }

        private void no_Click(object sender, EventArgs e)
        {
            _event();
        }

        private void setting_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.Close();
        }

        private void getRandomWord()
        {
            int index = random.Next(newWords.Count);
            
            this.currentWord.Id = newWords[index].Id;
            this.currentWord.Furigana = newWords[index].Furigana;
            this.currentWord.HanTu = newWords[index].HanTu;
            this.currentWord.Means = newWords[index].Means;
            this.currentWord.Example = newWords[index].Example;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _event();
        }

        private void _event ()
        {
            timer1.Interval = this.config.speed * 1000;
            if (this.firstShow == true)
            {
                this.getRandomWord();
            }
            this.showWord();
        }

        public void showWord()
        {
            switch (this.config.mode)
            {
                case SettingInfoDto.enmMode.MOTMAT:
                    if (this.config.furigana == true && this.config.hanTu == true && this.config.means == true && this.config.example == false)
                    {
                        this.screen1();
                    }
                    else if (this.config.furigana == true && this.config.hanTu == true && this.config.means == false && this.config.example == false)
                    {
                        this.screen2();
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == true && this.config.example == false)
                    {
                        this.screen3();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == true && this.config.example == false)
                    {
                        this.screen4();
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == false && this.config.example == false)
                    {
                        this.screen5();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == false && this.config.example == false)
                    {
                        this.screen6();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == false && this.config.means == true && this.config.example == false)
                    {
                        this.screen7();
                    }
                    else if(this.config.furigana == true && this.config.hanTu == true && this.config.means == true && this.config.example == true)
                    {
                        this.screen8();
                    }
                    else if (this.config.furigana == true && this.config.hanTu == true && this.config.means == false && this.config.example == true)
                    {
                        this.screen9();
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == true && this.config.example == true)
                    {
                        this.screen10();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == true && this.config.example == true)
                    {
                        this.screen11();
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == false && this.config.example == true)
                    {
                        this.screen12();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == false && this.config.example == true)
                    {
                        this.screen13();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == false && this.config.means == true && this.config.example == true)
                    {
                        this.screen14();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == false && this.config.means == false && this.config.example == false)
                    {
                        this.screen1();
                    }
                    else
                    {
                        this.screen1();
                    }
                    break;
                case SettingInfoDto.enmMode.HAIMAT:
                    if (this.config.furigana == true && this.config.hanTu == true && this.config.means == true && this.config.example == false)
                    {
                        this.screen15();
                    }
                    else if (this.config.furigana == true && this.config.hanTu == true && this.config.means == false && this.config.example == false)
                    {
                        this.screen16();
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == true && this.config.example == false)
                    {
                        this.screen17();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == true && this.config.example == false)
                    {
                        this.screen18();
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == false && this.config.example == false)
                    {
                        this.screen5();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == false && this.config.example == false)
                    {
                        this.screen6();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == false && this.config.means == true && this.config.example == false)
                    {
                        this.screen7();
                    }
                    else if(this.config.furigana == true && this.config.hanTu == true && this.config.means == true && this.config.example == true)
                    {
                        this.screen19();
                    }
                    else if (this.config.furigana == true && this.config.hanTu == true && this.config.means == false && this.config.example == true)
                    {
                        this.screen9();
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == true && this.config.example == true)
                    {
                        this.screen10();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == true && this.config.example == true)
                    {
                        this.screen11();
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == false && this.config.example == true)
                    {
                        this.screen12();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == false && this.config.example == true)
                    {
                        this.screen13();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == false && this.config.means == true && this.config.example == true)
                    {
                        this.screen14();
                    }
                    else if (this.config.furigana == false && this.config.hanTu == false && this.config.means == false && this.config.example == false)
                    {
                        this.screen1();
                    }
                    else
                    {
                        this.screen1();
                    }
                    break;
            }
        }

        private void screen1()
        {
            label1.Text = this.currentWord.Furigana;
            label2.Text = string.Empty;
            label3.Text = this.currentWord.HanTu;
            label4.Text = string.Empty;
            label5.Text = this.currentWord.Means;
        }

        private void screen2()
        {
            label1.Text = string.Empty;
            label2.Text = this.currentWord.Furigana;
            label3.Text = string.Empty;
            label4.Text = this.currentWord.HanTu;
            label5.Text = string.Empty;
        }
        private void screen3()
        {
            label1.Text = string.Empty;
            label2.Text = this.currentWord.Furigana;
            label3.Text = string.Empty;
            label4.Text = this.currentWord.Means;
            label5.Text = string.Empty;
        }

        private void screen4()
        {
            label1.Text = string.Empty;
            label2.Text = this.currentWord.HanTu;
            label3.Text = string.Empty;
            label4.Text = this.currentWord.Means;
            label5.Text = string.Empty;
        }

        private void screen5()
        {
            label1.Text = string.Empty;
            label2.Text = string.Empty;
            label3.Text = this.currentWord.Furigana;
            label4.Text = string.Empty;
            label5.Text = string.Empty;
        }

        private void screen6()
        {
            label1.Text = string.Empty;
            label2.Text = string.Empty;
            label3.Text = this.currentWord.HanTu;
            label4.Text = string.Empty;
            label5.Text = string.Empty;
        }

        private void screen7()
        {
            label1.Text = string.Empty;
            label2.Text = string.Empty;
            label3.Text = this.currentWord.Means;
            label4.Text = string.Empty;
            label5.Text = string.Empty;
        }

        private void screenExample()
        {
            label1.Text = string.Empty;
            label2.Text = string.Empty;
            label3.Text = this.currentWord.Example;
            label4.Text = string.Empty;
            label5.Text = string.Empty;
        }

        private void screen8()
        {
            if(this.firstShow)
            {
                screen1();
            }
            else
            {
                screenExample();
            }
            this.firstShow = !this.firstShow;
        }

        private void screen9()
        {
            if (this.firstShow)
            {
                screen2();
            }
            else
            {
                screenExample();
            }
            this.firstShow = !this.firstShow;
        }

        private void screen10()
        {
            if (this.firstShow)
            {
                screen3();
            }
            else
            {
                screenExample();
            }
            this.firstShow = !this.firstShow;
        }

        private void screen11()
        {
            if (this.firstShow)
            {
                screen4();
            }
            else
            {
                screenExample();
            }
            this.firstShow = !this.firstShow;
        }

        private void screen12()
        {
            if (this.firstShow)
            {
                screen5();
            }
            else
            {
                screenExample();
            }
            this.firstShow = !this.firstShow;
        }

        private void screen13()
        {
            if (this.firstShow)
            {
                screen6();
            }
            else
            {
                screenExample();
            }
            this.firstShow = !this.firstShow;
        }

        private void screen14()
        {
            if (this.firstShow)
            {
                screen7();
            }
            else
            {
                screenExample();
            }
            this.firstShow = !this.firstShow;
        }

        private void screenMeansExample()
        {
            {
                label1.Text = string.Empty;
                label2.Text = this.currentWord.Means;
                label3.Text = string.Empty;
                label4.Text = this.currentWord.Example;
                label5.Text = string.Empty;
            }
        }

        private void screen15()
        {
            if (this.firstShow)
            {
                screen2();
            }
            else
            {
                screen7();
            }
            this.firstShow = !this.firstShow;
        }

        private void screen16()
        {
            if (this.firstShow)
            {
                screen6();
            }
            else
            {
                screen5();
            }
            this.firstShow = !this.firstShow;
        }

        private void screen17()
        {
            if (this.firstShow)
            {
                screen5();
            }
            else
            {
                screen7();
            }
            this.firstShow = !this.firstShow;
        }

        private void screen18()
        {
            if (this.firstShow)
            {
                screen6();
            }
            else
            {
                screen7();
            }
            this.firstShow = !this.firstShow;
        }

        private void screen19()
        {
            if (this.firstShow)
            {
                screen2();
            }
            else
            {
                screenMeansExample();
            }
            this.firstShow = !this.firstShow;
        }


    }
        
}
