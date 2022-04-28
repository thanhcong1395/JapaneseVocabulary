using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_japanese.Models
{
    public static class Config
    {
        public static readonly string sqlConnect = @"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=Web_JP;";
        public static readonly string urlWeb = "https://www.google.com";
        public static readonly string oldWordFile = "..\\..\\oldwords.txt";
        public static readonly string settingFile = "..\\..\\setting.json";
    }
}
