using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;

namespace FPBackService
{
    public interface IConfigurationManager
    {
        NameValueCollection AppSettings { get; }
        string ConnectionStrings(string name);
        T GetSection<T>(string sectionName);
        object GetSection(string sectionName);
        string AppSetting(string key);
    }

    public class ConfigurationManagerWrapper : IConfigurationManager
    {


        public string AppSetting(string key)
        {
            return AppSetting(key);
        }

        public NameValueCollection AppSettings
        {
            get
            {
                return ConfigurationManager.AppSettings;
            }
        }


        public string ConnectionStrings(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        [DebuggerStepThrough]
        public T GetSection<T>(string sectionName)
        {
            return (T)ConfigurationManager.GetSection(sectionName);
        }

        [DebuggerStepThrough]
        public object GetSection(string sectionName)
        {
            return ConfigurationManager.GetSection(sectionName);
        }
    }
}