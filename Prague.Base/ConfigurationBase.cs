using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague.Base
{
    public class ConfigurationBase<T>
    {
        private static string GetFullPropertyName(System.Reflection.PropertyInfo pInfo)
        {
            var childType = typeof(T);
            return string.Format("{0}.{1}.{2}", childType.Namespace, childType.Name, pInfo.Name);
        }

        public static void SaveConfiguration()
        {
            foreach (var property in typeof(T).GetProperties())
            {
                SetConfigParameter(GetFullPropertyName(property), property.GetValue(null).ToString());
            }
        }

        public static void ReadConfiguration()
        {
            foreach (var property in typeof(T).GetProperties())
            {
                property.SetValue(null, GetConfigParameter(GetFullPropertyName(property)));
            }
        }

        public static string GetConfigParameter(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }

        public static void SetConfigParameter(string key, string val)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(key))
                configuration.AppSettings.Settings.Add(key, "");

            configuration.AppSettings.Settings[key].Value = val;
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}
