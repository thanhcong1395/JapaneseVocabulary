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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace study_japanese.Views
{
    public partial class NewWords : Form
    {
        private enum enmGetNewWord
        {
            NO_GET = 1,
            GOT = 2,
            NO_WORD  = 3
        }

        private readonly Point lineOne = new Point(6, 20);
        private readonly Point lineTwo = new Point(6, 70);
        private readonly Size large = new Size(300, 40);
        private readonly Size medium = new Size(300, 30);
        private readonly Color gray = Color.FromArgb(64, 64, 64);
        private readonly Color red = Color.FromArgb(164, 52, 48);

        private List<TuVungTableDto> newWords = new List<TuVungTableDto>();
        private List<TuVungTableDto> randomList = new List<TuVungTableDto>();
        private TuVungTableDto nextWord = new TuVungTableDto();
        private TuVungTableDto currentWord = new TuVungTableDto();
        private Logo logo;
        private Setting settingScreen = new Setting();
        private Random random = new Random();
        private int index = 0;
        private FlagDto flag = new FlagDto();
        private int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
        private int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
        public NewWords()
        {
            InitializeComponent();
            Task t2 = this.Init();
            this.ShowLogo();
            Task.WaitAll(t2);
            _event();
            this.timer2.Start();
        }

        private async Task Init()
        {
            Task t3 = new Task(
                () =>
                {
                    this.WindowLocation();
                    this.GetNewWordsFromServer();
                    Set.ReadSettingFile();
                    this.flag.FirstFace = true;
                    this.flag.PlayButton = true;
                    this.flag.RepeatButton = false;
                    this.flag.CheckedNewWord = false;
                    this.timer2.Interval = Set.settingConfig.Speed * 1000;
                }
            );
            t3.Start();
            await t3;
        }

        private void GetNewWordsFromServer()
        {
            string[] oldWordId;
            List<int> oldWordIdList = new List<int>();
            int result = 0;

            Query.QueryDB();
            if(File.Exists(Config.oldWordFile))
            {
                oldWordId = File.ReadAllLines(Config.oldWordFile);
                foreach (var e in oldWordId)
                {
                    if(Int32.TryParse(e, out result))
                    {
                        if(!oldWordIdList.Contains(result))
                        {
                            oldWordIdList.Append(result);
                        }
                    }
                }
                foreach (var e in Query.allWords)
                {
                    if(!oldWordIdList.Contains(e.Id))
                    {
                        this.newWords.Add(e);
                    }
                }
                
            }
            else
            {
                foreach (var e in Query.allWords)
                {
                    this.newWords.Add(e);
                }
            }
            Query.RemoveAllWords();

            // tao ramdom list tu moi
            int i = 0;
            int id = 0;
            List<int> randId = new List<int>();
            while(i < this.newWords.Count)
            {
                id = random.Next(this.newWords.Count);
                if(!randId.Contains(id))
                {
                    randId.Add(id);
                    this.randomList.Add(this.newWords[id]);
                    ++i;
                }
            }
        }

        private void WindowLocation()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(this.screenWidth - this.Width, this.screenHeight - this.Height);
        }

        private void ShowLogo()
        {
            this.Hide();
            this.logo = new Logo();
            this.logo.ShowDialog();
        }

        private void effect(bool show)
        {
            if(Set.settingConfig.Effect)
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
            switch (Set.settingConfig.Mode)
            {
                case SettingInfoDto.enmMode.MOTMAT:
                    if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == true && Set.settingConfig.Means == true && Set.settingConfig.Example == false)
                    {
                        // 1st face three lines, no 2nd face
                        this.threeLinesScreen(this.nextWord.HanTu, this.nextWord.Furigana, this.nextWord.Means);
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == true && Set.settingConfig.Means == false && Set.settingConfig.Example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.HanTu, this.lineTwo, this.lineOne);
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == false && Set.settingConfig.Means == true && Set.settingConfig.Example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.Means, this.lineOne, this.lineTwo);
                        return;
                    }
                    else if (Set.settingConfig.Furigana == false && Set.settingConfig.HanTu == true && Set.settingConfig.Means == true && Set.settingConfig.Example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.twoLinesScreen(this.nextWord.HanTu, this.nextWord.Means, this.lineOne, this.lineTwo);
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == false && Set.settingConfig.Means == false && Set.settingConfig.Example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.oneLineScreen(this.nextWord.Furigana);
                        return;
                    }
                    else if (Set.settingConfig.Furigana == false && Set.settingConfig.HanTu == true && Set.settingConfig.Means == false && Set.settingConfig.Example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.oneLineScreen(this.nextWord.HanTu);
                        return;
                    }
                    else if (Set.settingConfig.Furigana == false && Set.settingConfig.HanTu == false && Set.settingConfig.Means == true && Set.settingConfig.Example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.oneLineScreen(this.nextWord.Means);
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == true && Set.settingConfig.Means == true && Set.settingConfig.Example == true)
                    {
                        // 1st face three lines, 2nd face one line
                        if (this.flag.FirstFace)
                        {
                            this.threeLinesScreen(this.nextWord.HanTu, this.nextWord.Furigana, this.nextWord.Means);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == true && Set.settingConfig.Means == false && Set.settingConfig.Example == true)
                    {
                        // 1st face 2 lines, 2nd face 1 line
                        if (this.flag.FirstFace)
                        {
                            this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.HanTu, this.lineTwo, this.lineOne);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == false && Set.settingConfig.Means == true && Set.settingConfig.Example == true)
                    {
                        // 1st face 2 lines, 2nd face 1 line
                        if (this.flag.FirstFace)
                        {
                            this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.Means, this.lineOne, this.lineTwo);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == false && Set.settingConfig.HanTu == true && Set.settingConfig.Means == true && Set.settingConfig.Example == true)
                    {
                        // 1st face 2 lines, 2nd face 1 line
                        if (this.flag.FirstFace)
                        {
                            this.twoLinesScreen(this.nextWord.HanTu, this.nextWord.Means, this.lineOne, this.lineTwo);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == false && Set.settingConfig.Means == false && Set.settingConfig.Example == true)
                    {
                        // 1st face two lines, no 2nd face
                        this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.Example, this.lineOne, this.lineTwo);
                        return;
                    }
                    else if (Set.settingConfig.Furigana == false && Set.settingConfig.HanTu == true && Set.settingConfig.Means == false && Set.settingConfig.Example == true)
                    {
                        // 1st face two lines, no 2nd face
                        this.twoLinesScreen(this.nextWord.HanTu, this.nextWord.Means, this.lineOne, this.lineTwo);
                        return;
                    }
                    else if (Set.settingConfig.Furigana == false && Set.settingConfig.HanTu == false && Set.settingConfig.Means == true && Set.settingConfig.Example == true)
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
                    if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == true && Set.settingConfig.Means == true && Set.settingConfig.Example == false)
                    {
                        // 1st face 2 lines, 2nd face 1 line
                        if (this.flag.FirstFace)
                        {
                            this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.HanTu, this.lineTwo, this.lineOne);
                        }
                        else
                        {
                            this.oneLineScreen(this.nextWord.Means);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == true && Set.settingConfig.Means == false && Set.settingConfig.Example == false)
                    {
                        // 1st face 1 lines, 2nd face 1 line
                        if (this.flag.FirstFace)
                        {
                            this.oneLineScreen(this.nextWord.Furigana);
                        }
                        else
                        {
                            this.oneLineScreen(this.nextWord.HanTu);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == false && Set.settingConfig.Means == true && Set.settingConfig.Example == false)
                    {
                        // 1st face 1 lines, 2nd face 1 line
                        if (this.flag.FirstFace)
                        {
                            this.oneLineScreen(this.nextWord.Furigana);
                        }
                        else
                        {
                            this.oneLineScreen(this.nextWord.Means);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == false && Set.settingConfig.HanTu == true && Set.settingConfig.Means == true && Set.settingConfig.Example == false)
                    {
                        // 1st face 1 lines, 2nd face 1 line
                        if (this.flag.FirstFace)
                        {
                            this.oneLineScreen(this.nextWord.HanTu);
                        }
                        else
                        {
                            this.oneLineScreen(this.nextWord.Means);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == false && Set.settingConfig.Means == false && Set.settingConfig.Example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.oneLineScreen(this.nextWord.Furigana);
                        return;
                    }
                    else if (Set.settingConfig.Furigana == false && Set.settingConfig.HanTu == true && Set.settingConfig.Means == false && Set.settingConfig.Example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.oneLineScreen(this.nextWord.HanTu);
                        return;
                    }
                    else if (Set.settingConfig.Furigana == false && Set.settingConfig.HanTu == false && Set.settingConfig.Means == true && Set.settingConfig.Example == false)
                    {
                        // 1st face two lines, no 2nd face
                        this.oneLineScreen(this.nextWord.Means);
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == true && Set.settingConfig.Means == true && Set.settingConfig.Example == true)
                    {
                        // 1st face 2 lines, 2nd face 2 line
                        if (this.flag.FirstFace)
                        {
                            this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.HanTu, this.lineTwo, this.lineOne);
                        }
                        else
                        {
                            this.twoLinesScreen(this.nextWord.Means, this.nextWord.Example, this.lineOne, this.lineTwo);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == true && Set.settingConfig.Means == false && Set.settingConfig.Example == true)
                    {
                        // 1st face 2 lines, 2nd face 1 line
                        if (this.flag.FirstFace)
                        {
                            this.twoLinesScreen(this.nextWord.Furigana, this.nextWord.HanTu, this.lineTwo, this.lineOne);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == false && Set.settingConfig.Means == true && Set.settingConfig.Example == true)
                    {
                        // 1st face 1 lines, 2nd face 2 line
                        if (this.flag.FirstFace)
                        {
                            this.oneLineScreen(this.nextWord.Furigana);
                        }
                        else
                        {
                            this.twoLinesScreen(this.nextWord.Means, this.nextWord.Example, this.lineOne, this.lineTwo);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == false && Set.settingConfig.HanTu == true && Set.settingConfig.Means == true && Set.settingConfig.Example == true)
                    {
                        // 1st face 1 lines, 2nd face 2 line
                        if (this.flag.FirstFace)
                        {
                            this.oneLineScreen(this.nextWord.HanTu);
                        }
                        else
                        {
                            this.twoLinesScreen(this.nextWord.Means, this.nextWord.Example, this.lineOne, this.lineTwo);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == true && Set.settingConfig.HanTu == false && Set.settingConfig.Means == false && Set.settingConfig.Example == true)
                    {
                        // 1st face 1 lines, 2nd face 1 line
                        if (this.flag.FirstFace)
                        {
                            this.oneLineScreen(this.nextWord.Furigana);
                            this.flag.FirstFace = false;
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == false && Set.settingConfig.HanTu == true && Set.settingConfig.Means == false && Set.settingConfig.Example == true)
                    {
                        // 1st face 1 lines, 2nd face 2 line
                        if (this.flag.FirstFace)
                        {
                            this.oneLineScreen(this.nextWord.HanTu);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else if (Set.settingConfig.Furigana == false && Set.settingConfig.HanTu == false && Set.settingConfig.Means == true && Set.settingConfig.Example == true)
                    {
                        // 1st face 1 lines, 2nd face 2 line
                        if (this.flag.FirstFace)
                        {
                            this.oneLineScreen(this.nextWord.Means);
                        }
                        else
                        {
                            this.exampleScreen(this.nextWord.Example);
                        }
                        this.flag.FirstFace = !this.flag.FirstFace;
                        return;
                    }
                    else
                    {
                        this.noneScreen();
                    }
                    break;
            }
        }

        private enmGetNewWord getWord(bool rd)
        {
            enmGetNewWord ret;

            if (!this.flag.FirstFace)
            {
                ret = enmGetNewWord.NO_GET;
                goto EXIT;
            }
            if(this.flag.CheckedNewWord)
            {
                goto GET_NEW_WORD;
            }
            if(this.flag.RepeatButton)
            {
                ret = enmGetNewWord.NO_GET;
                goto EXIT;
            }

            GET_NEW_WORD:
            if (this.newWords.Count > 0)
            {
                ++this.index;
                if (this.index >= this.newWords.Count)
                {
                    this.index = 0;
                }
                else if (this.index < 0)
                {
                    this.index = this.newWords.Count - 1;
                }
                if (rd)
                {
                    this.nextWord.Id = this.randomList[this.index].Id;
                    this.nextWord.Furigana = this.randomList[this.index].Furigana;
                    this.nextWord.HanTu = this.randomList[this.index].HanTu;
                    this.nextWord.Means = this.randomList[this.index].Means;
                    this.nextWord.Example = this.randomList[this.index].Example;
                }
                else
                {
                    this.nextWord.Id = this.newWords[this.index].Id;
                    this.nextWord.Furigana = this.newWords[this.index].Furigana;
                    this.nextWord.HanTu = this.newWords[this.index].HanTu;
                    this.nextWord.Means = this.newWords[this.index].Means;
                    this.nextWord.Example = this.newWords[this.index].Example;
                }
                ret = enmGetNewWord.GOT;
            }
            else
            {
                ret = enmGetNewWord.NO_WORD;
            }

            EXIT:
            return ret;
        }

        private void _event()
        {
            enmGetNewWord ret;

            this.currentWord = this.nextWord;
            ret = this.getWord(Set.settingConfig.Random);
            if(ret == enmGetNewWord.NO_WORD)
            {
                this.NoWordScreen();
            }
            else
            {
                this.showWord();
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
            this.label2.ForeColor = this.red;
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
            this.label2.ForeColor = this.gray;
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
            this.label2.ForeColor = this.red;
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
            this.label2.ForeColor = this.gray;
            this.label2.Location = location2;
            this.label2.Size = this.medium;
            this.label1.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = this.red;
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
            this.label1.ForeColor = this.gray;
            this.label1.Location = new Point(6, 9);
            this.label1.Size = this.medium;
            this.label2.Font = new Font("UD Digi Kyokasho NK-R", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = this.red;
            this.label2.Location = new Point(6, 42);
            this.label2.Size = this.large;
            this.label3.Font = new Font("UD Digi Kyokasho NK-R", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = this.gray;
            this.label3.Location = new Point(6, 79);
            this.label3.Size = this.medium;
            this.label1.Visible = true;
            this.label2.Visible = true;
            this.label3.Visible = true;
            this.label1.Text = line1;
            this.label2.Text = line2;
            this.label3.Text = line3;
        }

        private void updateSpeed(int speed)
        {
            SettingInfoDto update = new SettingInfoDto();

            if (File.Exists(Config.settingFile))
            {
                JObject data = JObject.Parse(File.ReadAllText(Config.settingFile));
                update.Furigana = (bool)data["Furigana"];
                update.Means = (bool)data["Means"];
                update.HanTu = (bool)data["HanTu"];
                update.Example = (bool)data["Example"];
                update.Mode = ((int)data["Mode"] == (int)SettingInfoDto.enmMode.MOTMAT) ? SettingInfoDto.enmMode.MOTMAT : SettingInfoDto.enmMode.HAIMAT;
                update.Speed = (int)data["Speed"];
                update.Random = (bool)data["Random"];
                update.Effect = (bool)data["Effect"];
                update.StartUp = (bool)data["StartUp"];

                update.Speed = speed;
                string JsonResult = JsonConvert.SerializeObject(update);
                byte[] vs = Encoding.UTF8.GetBytes(JsonResult);
                FileStream fs = new FileStream(Config.settingFile, FileMode.Create);
                fs.Write(vs, 0, JsonResult.Length);
                fs.Close();
            }
        }

        /* event */
        private void setting_Click(object sender, EventArgs e)
        {
            this.timer2.Stop();
            this.Hide();
            //this.settingScreen = new Setting();
            this.settingScreen.Show();

            if (this.settingScreen.exitApp)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                this.timer2.Interval = Set.settingConfig.Speed * 1000;
                if (!this.flag.PlayButton)
                {
                    this.timer2.Stop();
                }
                else
                {
                    this.timer2.Start();
                }
                this._event();
                this.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            //this.logo.Close();
            this.logo.Dispose();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this._event();
        }

        private void yes_Click(object sender, EventArgs e)
        {
            this.flag.CheckedNewWord = true;
            this.flag.FirstFace = true;
            this.timer2.Stop();
            this.newWords.Remove(this.currentWord);
            this.randomList.Remove(this.currentWord);
            string[] id = new string[1];
            id[0] = this.currentWord.Id.ToString();
            File.AppendAllLines(Config.oldWordFile, id);
            this._event();
            if (!this.flag.PlayButton)
            {
                this.timer2.Stop();
            }
            else
            {
                this.timer2.Start();
            }
            this.flag.CheckedNewWord = false;
        }

        private void no_Click(object sender, EventArgs e)
        {
            this.flag.CheckedNewWord = true;
            this.flag.FirstFace = true;
            this.timer2.Stop();
            this._event();
            if (!this.flag.PlayButton)
            {
                this.timer2.Stop();
            }
            else
            {
                this.timer2.Start();
            }
            this.flag.CheckedNewWord = false;
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
            this.Close();
            Application.Exit();
        }

        private void play_Click(object sender, EventArgs e)
        {
            this.flag.PlayButton = !this.flag.PlayButton;
            if (!this.flag.PlayButton)
            {
                this.play.Image = Image.FromFile(@"..\\..\\Image\\icons8_play_30px.png");
                this.timer2.Stop();
            }
            else
            {
                this.play.Image = Image.FromFile(@"..\\..\\Image\\icons8_pause_30px.png");
                this.timer2.Start();
            }
        }

        private void previous_Click(object sender, EventArgs e)
        {
            this.flag.CheckedNewWord = true;
            this.flag.FirstFace = true;
            this.timer2.Stop();
            this.index -= 2;
            this._event();
            if (!this.flag.PlayButton)
            {
                this.timer2.Stop();
            }
            else
            {
                this.timer2.Start();
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            this.flag.CheckedNewWord = true;
            this.flag.FirstFace = true;
            this.timer2.Stop();
            this._event();
            if (!this.flag.PlayButton)
            {
                this.timer2.Stop();
            }
            else
            {
                this.timer2.Start();
            }
        }

        private void repeat_Click(object sender, EventArgs e)
        {
            this.flag.RepeatButton = !this.flag.RepeatButton;
            if (this.flag.RepeatButton)
            {
                this.repeat.Image = Image.FromFile(@"..\\..\\Image\\icons8_shuffle_20px.png");
            }
            else
            {
                this.repeat.Image = Image.FromFile(@"..\\..\\Image\\icons8_rotate_20px.png");
            }
        }

        private void upSpeed_Click(object sender, EventArgs e)
        {
            if (++Set.settingConfig.Speed > 900)
            {
                Set.settingConfig.Speed = 900;
            }
            this.timer2.Interval = Set.settingConfig.Speed*1000;
            this.updateSpeed(Set.settingConfig.Speed);
        }

        private void DownSpeed_Click(object sender, EventArgs e)
        {
            if (--Set.settingConfig.Speed <= 0)
            {
                Set.settingConfig.Speed = 1;
            }
            this.timer2.Interval = Set.settingConfig.Speed * 1000;
            this.updateSpeed(Set.settingConfig.Speed);
        }

        private void NewWord_Load(object sender, EventArgs e)
        {
            this.timer3.Interval = 100;
            this.timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int cursorX = Cursor.Position.X;
            int cursorY = Cursor.Position.Y;
            if(((this.screenWidth - this.panel1.Width) <= cursorX) && ((this.screenHeight - this.panel1.Height) <= cursorY))
            {
                this.panel1.Visible = true;
            }
            else
            {
                this.panel1.Visible = false;
            }
        }
    }
}
