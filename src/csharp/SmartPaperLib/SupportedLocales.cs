using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPaperLib
{
    public class SupportedLocales
    {
        public List<string>? supportedLocales { get; set; }
        public string? defaultLocale { get; set; }
        public string? preferredLocale { get; set; }

        public SupportedLocales(SupportedLocales supportedLocales)
        {
            this.supportedLocales = supportedLocales.supportedLocales != null ? new List<string>(supportedLocales.supportedLocales) : null;
            defaultLocale = supportedLocales.defaultLocale;
            preferredLocale = supportedLocales.preferredLocale;
        }

        public SupportedLocales(List<string>? supportedLocales = null, string? defaultLocale = null, string? preferredLocale = null)
        {
            this.supportedLocales = supportedLocales;
            this.defaultLocale = defaultLocale;
            this.preferredLocale = preferredLocale;
        }

        /*public SupportedLocales(List<string>? supportedLocales = null, string? defaultLocale = null, string? preferredLocale = null)
        {
            this.supportedLocales = supportedLocales ?? ["en_US", "ko_KR"];
            this.defaultLocale = defaultLocale ?? "ko_KR";
            this.preferredLocale = preferredLocale ?? "ko_KR";
        }

        public SupportedLocales FromJson(string json)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            if (data.ContainsKey("supportedLocales"))
            {
                supportedLocales = JsonConvert.DeserializeObject<List<string>>(data["supportedLocales"].ToString());
            }
            defaultLocale = data.ContainsKey("defaultLocale") ? data["defaultLocale"].ToString() : null;
            preferredLocale = data.ContainsKey("preferredLocale") ? data["preferredLocale"].ToString() : null;
            return this;
        }

        public Dictionary<string, object> ToJson()
        {
            var data = new Dictionary<string, object>();
            if (supportedLocales != null) data["supportedLocales"] = supportedLocales;
            if (defaultLocale != null) data["defaultLocale"] = defaultLocale;
            if (preferredLocale != null) data["preferredLocale"] = preferredLocale;
            return data;
        }*/
    }
}
