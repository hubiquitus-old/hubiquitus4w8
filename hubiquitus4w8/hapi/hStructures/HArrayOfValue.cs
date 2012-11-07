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
                Console.WriteLine("{0} : Can not update the value attribute", e.ToString());
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
                Console.WriteLine("{0} : Can not fetch the value attribute", e.ToString());
            }
            return value;
        }
    }
}
