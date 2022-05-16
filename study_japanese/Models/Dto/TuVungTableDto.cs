using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_japanese.Models.Dto
{
    public class TuVungTableDto
    {
        public int Id { get; set; }
        public string Furigana { get; set; }
        public string HanTu { get; set; }
        public string Means { get; set; }
        public string Example { get; set; }
    }
}
