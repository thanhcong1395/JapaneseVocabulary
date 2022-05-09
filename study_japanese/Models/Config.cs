using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_japanese.Models
{
    public static class Config
    {
        public const string sqlConnect = @"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=Web_JP;";
        public const string urlWeb = "https://www.google.com";
        public const string oldWordFile = "..\\..\\oldwords.txt";
        public const string settingFile = "..\\..\\setting.json";
    }
}
