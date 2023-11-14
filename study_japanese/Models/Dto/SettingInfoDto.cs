using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_japanese.Models.Dto
{
    public class SettingInfoDto
    {
        public enum enmMode
        {
            MOTMAT = 0,
            HAIMAT = 1
        }

        public bool Furigana { get; set; }
        public bool Means { get; set; }
        public bool HanTu { get; set; }
        public bool Example { get; set; }
        public enmMode Mode { get; set; }
        public int Speed { get; set; }
        public bool Random { get; set; }
        public bool StartUp { get; set; }
        public bool Effect { get; set; }
        public int HiddenTime { get; set; }
    }
}
