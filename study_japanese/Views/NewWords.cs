using System;
using System.Collections.Generic;
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
        private readonly Point lineOne = new Point(6, 20);
        private readonly Point lineTwo = new Point(6, 70);
        private readonly Size large = new Size(300, 40);
        private readonly Size medium = new Size(300, 30);

        private List<TuVungTableDto> newWords = new List<TuVungTableDto>();
        private TuVungTableDto nextWord = new TuVungTableDto();
        private TuVungTableDto currentWord = new TuVungTableDto();
        private Logo logo =  new Logo();
        private Setting settingprintMode = new Setting();
        private SettingInfoDto config = new SettingInfoDto();
        private Random random = new Random();
        private int index = -1;
        private bool firstFace = true;

        public NewWords()
        {
            InitializeComponent();
            this.showLogo();
            this.WindowLocation();
            this.getNewWordFromServer();
            this.config = this.settingprintMode.getConfig();
            this.timer2.Interval = this.config.speed * 1000;
            this.timer2.Start();
            _event();
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

        

        private void showLogo()
        {
            this.Hide();
            this.logo.ShowDialog();
        }

        private void effect(bool show)
        {
            if(this.config.effect)
            {
                switch(show)
                {
                    case true:
                        while (this.Opacity < 1)
                        {
                            this.Opacity += 0.02;
                            Thread.Sleep(1);
                        }
                        break;
                    case false:
                        while (this.Opacity > 0)
                        {
                            this.Opacity -= 0.02;
                            Thread.Sleep(1);
                        }
                        break;
                }
            }
            else
            {
                this.Opacity = 1;
            }
        }

        private void showWord()
        {
            switch (this.config.mode)
            {
                case SettingInfoDto.enmMode.MOTMAT:
                    if (this.config.furigana == true && this.config.hanTu == true && this.config.means == true && this.config.example == false)
                    {
                        // 1st face three lines, no 2nd face
                        this.threeLinesScreen(this.nextWord.HanTu, this.nextWord.Furigana, this.nextWord.Means);
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == true && this.config.means == false && this.config.example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.HanTu, this.lineTwo, this.lineOne);
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == true && this.config.example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.Means, this.lineOne, this.lineTwo);
                        return;
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == true && this.config.example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.twoLinesScreen(this.nextWord.HanTu, this.nextWord.Means, this.lineOne, this.lineTwo);
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == false && this.config.example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.oneLineScreen(this.nextWord.Furigana);
                        return;
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == false && this.config.example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.oneLineScreen(this.nextWord.HanTu);
                        return;
                    }
                    else if (this.config.furigana == false && this.config.hanTu == false && this.config.means == true && this.config.example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.oneLineScreen(this.nextWord.Means);
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == true && this.config.means == true && this.config.example == true)
                    {
                        // 1st face three lines, 2nd face one line
                        if (this.firstFace)
                        {
                            this.threeLinesScreen(this.nextWord.HanTu, this.nextWord.Furigana, this.nextWord.Means);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == true && this.config.means == false && this.config.example == true)
                    {
                        // 1st face 2 lines, 2nd face 1 line
                        if (this.firstFace)
                        {
                            this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.HanTu, this.lineTwo, this.lineOne);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == true && this.config.example == true)
                    {
                        // 1st face 2 lines, 2nd face 1 line
                        if (this.firstFace)
                        {
                            this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.Means, this.lineOne, this.lineTwo);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == true && this.config.example == true)
                    {
                        // 1st face 2 lines, 2nd face 1 line
                        if (this.firstFace)
                        {
                            this.twoLinesScreen(this.nextWord.HanTu, this.nextWord.Means, this.lineOne, this.lineTwo);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == false && this.config.example == true)
                    {
                        // 1st face two lines, no 2nd face
                        this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.Example, this.lineOne, this.lineTwo);
                        return;
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == false && this.config.example == true)
                    {
                        // 1st face two lines, no 2nd face
                        this.twoLinesScreen(this.nextWord.HanTu, this.nextWord.Means, this.lineOne, this.lineTwo);
                        return;
                    }
                    else if (this.config.furigana == false && this.config.hanTu == false && this.config.means == true && this.config.example == true)
                    {
                        // 1st face two lines, no 2nd face
                        this.twoLinesScreen(this.nextWord.HanTu, this.nextWord.Means, this.lineOne, this.lineTwo);
                        return;
                    }
                    else
                    {
                        this.noneScreen();
                    }
                    break;
                case SettingInfoDto.enmMode.HAIMAT:
                    if (this.config.furigana == true && this.config.hanTu == true && this.config.means == true && this.config.example == false)
                    {
                        // 1st face 2 lines, 2nd face 1 line
                        if (this.firstFace)
                        {
                            this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.HanTu, this.lineTwo, this.lineOne);
                        }
                        else
                        {
                            this.oneLineScreen(this.nextWord.Means);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == true && this.config.means == false && this.config.example == false)
                    {
                        // 1st face 1 lines, 2nd face 1 line
                        if (this.firstFace)
                        {
                            this.oneLineScreen(this.nextWord.Furigana);
                        }
                        else
                        {
                            this.oneLineScreen(this.nextWord.HanTu);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == true && this.config.example == false)
                    {
                        // 1st face 1 lines, 2nd face 1 line
                        if (this.firstFace)
                        {
                            this.oneLineScreen(this.nextWord.Furigana);
                        }
                        else
                        {
                            this.oneLineScreen(this.nextWord.Means);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == true && this.config.example == false)
                    {
                        // 1st face 1 lines, 2nd face 1 line
                        if (this.firstFace)
                        {
                            this.oneLineScreen(this.nextWord.HanTu);
                        }
                        else
                        {
                            this.oneLineScreen(this.nextWord.Means);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == false && this.config.example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.oneLineScreen(this.nextWord.Furigana);
                        return;
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == false && this.config.example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.oneLineScreen(this.nextWord.HanTu);
                        return;
                    }
                    else if (this.config.furigana == false && this.config.hanTu == false && this.config.means == true && this.config.example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.oneLineScreen(this.nextWord.Means);
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == true && this.config.means == true && this.config.example == true)
                    {
                        // 1st face 2 lines, 2nd face 2 line
                        if (this.firstFace)
                        {
                            this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.HanTu, this.lineTwo, this.lineOne);
                        }
                        else
                        {
                            this.twoLinesScreen(this.nextWord.Means, this.nextWord.Example, this.lineOne, this.lineTwo);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == true && this.config.means == false && this.config.example == true)
                    {
                        // 1st face 2 lines, 2nd face 1 line
                        if (this.firstFace)
                        {
                            this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.HanTu, this.lineTwo, this.lineOne);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == true && this.config.example == true)
                    {
                        // 1st face 1 lines, 2nd face 2 line
                        if (this.firstFace)
                        {
                            this.oneLineScreen(this.nextWord.Furigana);
                        }
                        else
                        {
                            this.twoLinesScreen(this.nextWord.Means, this.nextWord.Example, this.lineOne, this.lineTwo);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == true && this.config.example == true)
                    {
                        // 1st face 1 lines, 2nd face 2 line
                        if (this.firstFace)
                        {
                            this.oneLineScreen(this.nextWord.HanTu);
                        }
                        else
                        {
                            this.twoLinesScreen(this.nextWord.Means, this.nextWord.Example, this.lineOne, this.lineTwo);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == true && this.config.hanTu == false && this.config.means == false && this.config.example == true)
                    {
                        // 1st face 1 lines, 2nd face 1 line
                        if (this.firstFace)
                        {
                            this.oneLineScreen(this.nextWord.Furigana);
                            this.firstFace = false;
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == false && this.config.hanTu == true && this.config.means == false && this.config.example == true)
                    {
                        // 1st face 1 lines, 2nd face 2 line
                        if (this.firstFace)
                        {
                            this.oneLineScreen(this.nextWord.HanTu);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else if (this.config.furigana == false && this.config.hanTu == false && this.config.means == true && this.config.example == true)
                    {
                        // 1st face 1 lines, 2nd face 2 line
                        if (this.firstFace)
                        {
                            this.oneLineScreen(this.nextWord.Means);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.firstFace = !this.firstFace;
                        return;
                    }
                    else
                    {
                        this.noneScreen();
                    }
                    break;
            }
        }

        private bool getWord(bool rd)
        {
            bool haveWord = true;

            if (this.newWords.Count > 0)
            {
                if (rd)
                {
                    this.index = random.Next(newWords.Count);
                }
                else
                {
                    if (++this.index == this.newWords.Count)
                    {
                        this.index = 0;
                    }
                }
                this.nextWord.Id = newWords[this.index].Id;
                this.nextWord.Furigana = newWords[this.index].Furigana;
                this.nextWord.HanTu = newWords[this.index].HanTu;
                this.nextWord.Means = newWords[this.index].Means;
                this.nextWord.Example = newWords[this.index].Example;
            }
            else
            {
                haveWord = false;
            }

            return haveWord;
        }


        private void _event()
        {
            if (this.getWord(this.config.random))
            {
                this.showWord();
            }
            else
            {
                this.NoWordScreen();
            }
        }

        /* screen */
        private void noneScreen()
        {
            this.label1.Text = string.Empty;
            this.label2.Text = string.Empty;
            this.label3.Text = string.Empty;
        }
        private void NoWordScreen()
        {
            this.label2.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = Color.Red;
            this.label2.Location = new Point(6, 42);
            this.label2.Size = this.large;
            this.label1.Visible = false;
            this.label2.Visible = true;
            this.label3.Visible = false;

            this.label1.Text = string.Empty;
            this.label2.Text = "HẾT TỪ MỚI!!!!";
            this.label3.Text = string.Empty;
        }

        private void exampleScreen(string word)
        {
            this.label2.Font = new Font("UD Digi Kyokasho NK-R", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Size = this.medium;
            this.label2.Location = new Point(6, 42);
            this.label1.Visible = false;
            this.label2.Visible = true;
            this.label3.Visible = false;

            this.label1.Text = string.Empty;
            this.label2.Text = word;
            this.label3.Text = string.Empty;
        }

        private void oneLineScreen(string word)
        {
            this.label2.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = Color.Red;
            this.label2.Size = this.large;
            this.label2.Location = new Point(6, 42);
            this.label1.Visible = false;
            this.label2.Visible = true;
            this.label3.Visible = false;

            this.label1.Text = string.Empty;
            this.label2.Text = word;
            this.label3.Text = string.Empty;
        }

        private void twoLinesScreen(string redLine, string BrownLine, Point location1, Point location2)
        {
            this.label2.Font = new Font("UD Digi Kyokasho NK-R", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = location2;
            this.label2.Size = this.medium;
            this.label1.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = Color.Red;
            this.label1.Location = location1;
            this.label1.Size = this.large;
            this.label1.Visible = true;
            this.label2.Visible = true;
            this.label3.Visible = false;

            this.label1.Text = redLine;
            this.label2.Text = BrownLine;
            this.label3.Text = string.Empty;
        }

        private void threeLinesScreen(string line1, string line2, string line3)
        {
            this.label1.Font = new Font("UD Digi Kyokasho NK-R", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new Point(6, 9);
            this.label1.Size = this.medium;
            this.label2.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = Color.Red;
            this.label2.Location = new Point(6, 42);
            this.label2.Size = this.large;
            this.label3.Font = new Font("UD Digi Kyokasho NK-R", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new Point(6, 79);
            this.label3.Size = this.medium;
            this.label1.Visible = true;
            this.label2.Visible = true;
            this.label3.Visible = true;
            this.label1.Text = line1;
            this.label2.Text = line2;
            this.label3.Text = line3;
        }

        /* event */
        private void setting_Click(object sender, EventArgs e)
        {
            this.timer2.Stop();
            this.Hide();
            this.settingprintMode.ShowDialog();

            if (this.settingprintMode.exitApp)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                this.config = this.settingprintMode.getConfig();
                this.timer2.Interval = this.config.speed * 1000;
                this.timer2.Start();
                this._event();
                this.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.logo.Close();
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

        private void close_Click(object sender, EventArgs e)
        {
            this.settingprintMode.Close();
            this.Close();
            Application.Exit();
        }

    }
}
