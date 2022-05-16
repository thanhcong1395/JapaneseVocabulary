using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using study_japanese.Models.Dto;
using study_japanese.Views;
using System.IO;
using Npgsql;
using study_japanese.Models;
using System.Windows.Forms;
using System.Drawing;

namespace study_japanese.Models
{
    public static class Query
    {
        public static List<TuVungTableDto> allWords = new List<TuVungTableDto>();

        public static void QueryDB()
        {
            using (NpgsqlConnection conn = GetConnection())
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    // Get data
                    // Define a query
                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM kotoba_notify ORDER BY id ASC", conn);
                    NpgsqlDataReader dr = command.ExecuteReader();
                    // Output rows
                    while (dr.Read())
                    {
                        TuVungTableDto tmp = new TuVungTableDto();
                        tmp.Furigana = dr["furigana"].ToString();
                        tmp.HanTu = dr["hanTu"].ToString();
                        tmp.Means = dr["mean"].ToString();
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

        public static void RemoveAllWords()
        {
            allWords.Clear();
        }
    }
}
