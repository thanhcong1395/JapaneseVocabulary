using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using study_japanese.Models.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_japanese.Models
{
    public static class Set
    {
        public static SettingInfoDto settingConfig = new SettingInfoDto();

        public static void SetDefualtConfig()
        {
            settingConfig.Furigana = true;
            settingConfig.Means = true;
            settingConfig.HanTu = false;
            settingConfig.Example = false;
            settingConfig.Mode = SettingInfoDto.enmMode.MOTMAT;
            settingConfig.Speed = 5;
            settingConfig.Random = true;
            settingConfig.Effect = true;
            settingConfig.StartUp = true;
            settingConfig.HiddenTime = 10;
        }

        public static void WriteSettingFile()
        {
            string JsonResult = JsonConvert.SerializeObject(settingConfig);
            byte[] vs = Encoding.UTF8.GetBytes(JsonResult);
            FileStream fs = new FileStream(Config.settingFile, FileMode.Create);
            fs.Write(vs, 0, JsonResult.Length);
            fs.Close();
        }

        public static void ReadSettingFile()
        {
            if (File.Exists(Config.settingFile))
            {
                JObject data = JObject.Parse(File.ReadAllText(Config.settingFile));
                settingConfig.Furigana = (bool)data["Furigana"];
                settingConfig.Means = (bool)data["Means"];
                settingConfig.HanTu = (bool)data["HanTu"];
                settingConfig.Example = (bool)data["Example"];
                settingConfig.Mode = ((int)data["Mode"] == (int)SettingInfoDto.enmMode.MOTMAT) ? SettingInfoDto.enmMode.MOTMAT : SettingInfoDto.enmMode.HAIMAT;
                settingConfig.Speed = (int)data["Speed"];
                settingConfig.Random = (bool)data["Random"];
                settingConfig.Effect = (bool)data["Effect"];
                settingConfig.StartUp = (bool)data["StartUp"];
                settingConfig.HiddenTime = (int)data["HiddenTime"];
            }
            else
            {
                SetDefualtConfig();
                // ghi file setting.json
                WriteSettingFile();
            }
        }



    }
}
