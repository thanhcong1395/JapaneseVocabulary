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
    public partial class ThreeLine : Form
    {
        List<TuVungTableDto> newWords = new List<TuVungTableDto>();
        Random random = new Random();
        public ThreeLine(int speed, List<TuVungTableDto> newWords)
        {
            InitializeComponent();
            this.timer1.Interval = speed*1000;
            this.timer1.Start();
            this.newWords = newWords;
            getRandomWord();
        }

        private void ThreeLine_Load(object sender, EventArgs e)
        {

        }

        public void showWord(TuVungTableDto word)
        {
            WordFuri.Text = word.Furigana;
            WordHanTu.Text = word.HanTu;
            WordMeans.Text = word.Means;
        }

        private void yes_Click(object sender, EventArgs e)
        {

        }

        private void no_Click(object sender, EventArgs e)
        {

        }

        private void setting_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
        }

        private void getRandomWord()
        {
            int index = random.Next(newWords.Count);
            TuVungTableDto currentWord = new TuVungTableDto();
            currentWord.Id = newWords[index].Id;
            currentWord.Furigana = newWords[index].Furigana;
            currentWord.HanTu = newWords[index].HanTu;
            currentWord.Means = newWords[index].Means;
            currentWord.Example = newWords[index].Example;

            WordFuri.Text = currentWord.Furigana;
            WordHanTu.Text = currentWord.HanTu;
            WordMeans.Text = currentWord.Means;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getRandomWord();
        }
    }
}
