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
            MOTMAT,
            HAIMAT
        }
        public bool furigana { get; set; }
        public bool means { get; set; }
        public bool hanTu { get; set; }
        public bool example { get; set; }
        public enmMode mode { get; set; }
        public int speed { get; set; }
    }
}
