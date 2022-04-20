using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using study_japanese.Models;
using study_japanese.Models.Dto;

namespace study_japanese.Views
{
    public partial class NewWords : Form
    {
        private List<TuVungTableDto> newWords = new List<TuVungTableDto>();
        private TuVungTableDto nextWord = new TuVungTableDto();
        private TuVungTableDto currentWord = new TuVungTableDto();
        private Logo golo =  new Logo();
        private Setting settingMode = new Setting();
        private SettingInfoDto config = new SettingInfoDto();
        private bool firstShow;
        private Random random = new Random();
        private int index = -1;
        private bool front = true;

        public NewWords()
        {
            InitializeComponent();
            this.WindowLocation();
            this.showLogo();
            this.getNewWordFromServer();
            this.config = this.settingMode.getConfig();
            this.timer2.Interval = this.config.speed * 1000;
            this.timer2.Start();
            this.firstShow = true;
            _event();
        }

        private bool getRandomWord(bool rd)
        {
            bool haveWord = true;

            if(newWords.Count > 0)
            {
                this.effect(this.config.effect);
                if (rd)
                {
                    this.index = random.Next(newWords.Count);
                }
                else
                {
                    this.index += 1;
                    if (this.index >= newWords.Count)
                    {
                        this.index = 0;
                    }
                }

                this.nextWord.Id = newWords[index].Id;
                this.nextWord.Furigana = newWords[index].Furigana;
                this.nextWord.HanTu = newWords[index].HanTu;
                this.nextWord.Means = newWords[index].Means;
                this.nextWord.Example = newWords[index].Example;
            }
            else
            {
                haveWord = false;
            }

            return haveWord;
        }

        private void getNewWordFromServer()
        {
            Query query = new Query();
            this.newWords = query.getNewWords();
        }

        private void WindowLocation()
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x - this.Width, y - this.Height);
        }

        private void setting_Click(object sender, EventArgs e)
        {
            this.timer2.Stop();
            this.Hide();
            this.settingMode.ShowDialog();
            
            if (this.settingMode.exitApp)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                this.config = this.settingMode.getConfig();
                this.timer2.Interval = this.config.speed * 1000;
                this.timer2.Start();
                this.Show();
            }
        }

        private void showLogo()
        {
            this.Hide();
            this.golo.ShowDialog();
        }

        private void effect(bool ef)
        {
            if(ef)
            {
                this.front = !this.front;
                this.BackColor = (this.front) ? Color.Silver : Color.LightGray;
            }
        }

        private void _event()
        {
            bool haveWord = true;

            timer2.Interval = this.config.speed * 1000;
            if (this.firstShow == true)
            {
                haveWord = this.getRandomWord(this.config.random);
            }
            if(haveWord)
            {
                this.showWord();
            }
            else
            {
                noneScreen();
            }
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
                    else if (this.config.furigana == true && this.config.hanTu == true && this.config.means == true && this.config.example == true)
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
                    else if (this.config.furigana == true && this.config.hanTu == true && this.config.means == true && this.config.example == true)
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
            this.currentWord = this.nextWord;
        }

        private void noneScreen()
        {
            this.label3.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = Color.Red;
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = true;
            this.label4.Visible = false;
            this.label5.Visible = false;

            label1.Text = string.Empty;
            label2.Text = string.Empty;
            label3.Text = "HẾT TỪ MỚI!!!!";
            label4.Text = string.Empty;
            label5.Text = string.Empty;
        }


        private void screen1()
        {
            this.label1.Font = new Font("UD Digi Kyokasho NK-R", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new Font("UD Digi Kyokasho NK-R", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = Color.Red;
            this.label5.Font = new Font("UD Digi Kyokasho NK-R", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Visible = true;
            this.label2.Visible = false;
            this.label3.Visible = true;
            this.label4.Visible = false;
            this.label5.Visible = true;

            label1.Text = this.nextWord.Furigana;
            label2.Text = string.Empty;
            label3.Text = this.nextWord.HanTu;
            label4.Text = string.Empty;
            label5.Text = this.nextWord.Means;
        }

        private void screen2()
        {
            this.label2.Font = new Font("UD Digi Kyokasho NK-R", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = Color.Red;
            this.label1.Visible = false;
            this.label2.Visible = true;
            this.label3.Visible = false;
            this.label4.Visible = true;
            this.label5.Visible = false;

            label1.Text = string.Empty;
            label2.Text = this.nextWord.Furigana;
            label3.Text = string.Empty;
            label4.Text = this.nextWord.HanTu;
            label5.Text = string.Empty;
        }
        private void screen3()
        {
            this.label2.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = Color.Red;
            this.label4.Font = new Font("UD Digi Kyokasho NK-R", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Visible = false;
            this.label2.Visible = true;
            this.label3.Visible = false;
            this.label4.Visible = true;
            this.label5.Visible = false;

            label1.Text = string.Empty;
            label2.Text = this.nextWord.Furigana;
            label3.Text = string.Empty;
            label4.Text = this.nextWord.Means;
            label5.Text = string.Empty;
        }

        private void screen4()
        {
            this.label4.Font = new Font("UD Digi Kyokasho NK-R", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = Color.Red;
            this.label1.Visible = false;
            this.label2.Visible = true;
            this.label3.Visible = false;
            this.label4.Visible = true;
            this.label5.Visible = false;

            label1.Text = string.Empty;
            label2.Text = this.nextWord.HanTu;
            label3.Text = string.Empty;
            label4.Text = this.nextWord.Means;
            label5.Text = string.Empty;
        }

        private void screen5()
        {
            this.label3.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = Color.Red;
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = true;
            this.label4.Visible = false;
            this.label5.Visible = false;

            label1.Text = string.Empty;
            label2.Text = string.Empty;
            label3.Text = this.nextWord.Furigana;
            label4.Text = string.Empty;
            label5.Text = string.Empty;
        }

        private void screen6()
        {
            this.label3.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = Color.Red;
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = true;
            this.label4.Visible = false;
            this.label5.Visible = false;

            label1.Text = string.Empty;
            label2.Text = string.Empty;
            label3.Text = this.nextWord.HanTu;
            label4.Text = string.Empty;
            label5.Text = string.Empty;
        }

        private void screen7()
        {
            this.label3.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = Color.Red;
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = true;
            this.label4.Visible = false;
            this.label5.Visible = false;

            label1.Text = string.Empty;
            label2.Text = string.Empty;
            label3.Text = this.nextWord.Means;
            label4.Text = string.Empty;
            label5.Text = string.Empty;
        }

        private void screenExample()
        {
            this.label3.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = Color.Red;
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = true;
            this.label4.Visible = false;
            this.label5.Visible = false;

            label1.Text = string.Empty;
            label2.Text = string.Empty;
            label3.Text = this.nextWord.Example;
            label4.Text = string.Empty;
            label5.Text = string.Empty;
        }

        private void screen8()
        {
            if (this.firstShow)
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
            this.label4.Font = new Font("UD Digi Kyokasho NK-R", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = Color.Red;
            this.label1.Visible = false;
            this.label2.Visible = true;
            this.label3.Visible = false;
            this.label4.Visible = true;
            this.label5.Visible = false;

            label1.Text = string.Empty;
            label2.Text = this.nextWord.Means;
            label3.Text = string.Empty;
            label4.Text = this.nextWord.Example;
            label5.Text = string.Empty;
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

        // event
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.golo.Close();
            this.timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           this._event();
        }

        private void yes_Click(object sender, EventArgs e)
        {
            string[] id = new string[1];
            if(this.newWords.Contains(this.currentWord))
            {
                this.newWords.RemoveAt(this.currentWord.Id);
                id[0] = this.currentWord.Id.ToString();
                File.AppendAllLines(Config.oldWordFile, id);
            }
            this._event();
        }

        private void no_Click(object sender, EventArgs e)
        {
            this._event();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.settingMode.Close();
            this.Close();
            Application.Exit();
        }

        private void yes_move(object sender, MouseEventArgs e)
        {
            this.yes.Image = Image.FromFile(@"..\\..\\Image\\icons8_Done_30px.png");
        }

        private void yes_leave(object sender, EventArgs e)
        {
            this.yes.Image = Image.FromFile(@"..\\..\\Image\\icons8_Done_30px_1.png");
        }

        private void no_move(object sender, MouseEventArgs e)
        {
            this.no.Image = Image.FromFile(@"..\\..\\Image\\icons8_multiply_35px.png");
        }

        private void no_leave(object sender, EventArgs e)
        {
            this.no.Image = Image.FromFile(@"..\\..\\Image\\icons8_multiply_35px_1.png");
        }

        private void setting_leave(object sender, EventArgs e)
        {
            this.setting.Image = Image.FromFile(@"..\\..\\Image\\icons8_settings_30px.png");
        }

        private void setting_move(object sender, MouseEventArgs e)
        {
            this.setting.Image = Image.FromFile(@"..\\..\\Image\\icons8_settings_30px_2.png");
        }
    }
}
