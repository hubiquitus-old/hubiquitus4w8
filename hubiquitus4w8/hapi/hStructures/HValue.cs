using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubiquitus4w8.hapi.hStructures
{
    /// <summary>
    /// Version v0.5
    /// This structure defines a simple condition value for the available operand
    /// </summary>
    public class HValue : JObject
    {
        private string name;

        public HValue()
            : base()
        { 
        }

        public HValue(JObject jsonObj)
            : base(jsonObj)
        { 
        }

        public HValue(string name, JToken value)
        {
            this.name = name;
            SetValue(value);
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetValue(JToken value)
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

        public JToken GetValue()
        {
            JToken value = null;
            try
            {
                value = this[name];
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the value attribute", e.ToString());
            }
            return value;
        }
    }
}
