using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubiquitus4w8.hapi.hStructures
{
    public class HArrayOfValue : JObject
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HArrayOfValue));
        private string name;

        public HArrayOfValue()
            : base()
        { 
        }

        public HArrayOfValue(JObject jsonObj)
            : base(jsonObj)
        { 
        }

        public HArrayOfValue(string name, JArray value)
            : base()
        {
            this.name = name;
            SetValue(value);
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetValue(JArray value)
        {
            try
            {
                this[name] = value;
            }
            catch (Exception e)
            {
                log.Error("Can not update the value attribute : ", e);
            }
        }

        public JArray GetValue()
        {
            JArray value = null;
            try
            {
                value = this[name].ToObject<JArray>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the value attribute : ", e);
            }
            return value;
        }
    }
}
