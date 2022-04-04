using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using study_japanese.Models.Dto;
using study_japanese.Views;
using System.IO;
using System.Text;
using Npgsql;
using study_japanese.Models;
using System.Windows.Forms;

namespace study_japanese.Models
{
    public class Control
    {
        private List<TuVungTableDto> allWords = new List<TuVungTableDto>();
        private List<TuVungTableDto> newWords = new List<TuVungTableDto>();


        public Control()
        {
            connectionDb();
            getNewWords();
        }

        private void connectionDb()
        {
            using (NpgsqlConnection conn = GetConnection())
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    // Get data
                    // Define a query
                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM Tu_vung ORDER BY id ASC", conn);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    // Output rows
                    while (dr.Read())
                    {
                        TuVungTableDto tmp = new TuVungTableDto();
                        tmp.Furigana = dr["furigana"].ToString();
                        tmp.HanTu = dr["hanTu"].ToString();
                        tmp.Means = dr["means"].ToString();
                        tmp.Example = dr["example"].ToString();
                        tmp.Id = Convert.ToInt32(dr["id"]);
                        allWords.Add(tmp);
                    }
                }
            }
        }

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(Config.sqlConnect);
        }

        private void getNewWords()
        {
            //bool ret = false;
            //int index = 0;
            int id;
            List<int> oldWordsId = new List<int>();

            //// đọc id từ đã học
            string[] oldWordsIdString;
            if(File.Exists((".\\oldwords.txt")))
            {
                oldWordsIdString = File.ReadAllLines(".\\oldwords.txt");
                foreach (var e in oldWordsIdString)
                {
                    if (Int32.TryParse(e, out id))
                    {
                        oldWordsId.Add(id);
                    }
                }
            }

            // so sánh với danh sách từ đã đọc và từ db -> lấy ra từ mới
            foreach(var e in allWords)
            {
                if(!oldWordsId.Contains(e.Id))
                {
                    newWords.Add(e);
                }
            }
        }

        public void showNewWord(SettingInfoDto config)
        {
            switch(config.mode)
            {
                case SettingInfoDto.enmMode.MOTMAT:
                    if (config.furigana == true && config.hanTu == true && config.mean == true && config.example == false)
                     {
                        screen1();
                    }
                    
                    
                    
                    break;
                case SettingInfoDto.enmMode.HAIMAT:
                    break;
            }
        }

        private void screen1()
        {
            //ThreeLine showNewWordForm = (ThreeLine)Application.OpenForms[1];
        }

         
    }
}
