using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubiquitus4w8.hapi.hStructures
{
    public class HCondition : JObject
    {

        public HCondition()
            : base()
        { 
        }

        public HCondition(JObject jsobObj)
            : base(jsobObj)
        { 
        }

        public void SetEqValue(HValue value)
        {
            try
            {
                if (value == null)
                    this.Remove("eq");
                else
                    this["eq"] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the eq value attribute", e.ToString());
            }
        }

        public HValue GetEqValue()
        {
            HValue value = null;
            try
            {
                value = new HValue(JObject.Parse(this["eq"].ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the eq value attribute", e.ToString());
            }
            return value;
        }

        public void SetNeValue(HValue value)
        {
            try
            {
                if (value == null)
                    this.Remove("ne");
                else
                    this["ne"] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the ne value attribute", e.ToString());
            }
        }

        public HValue GetNeValue()
        {
            HValue value = null;
            try
            {
                value = new HValue(JObject.Parse(this["ne"].ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the ne value attribute", e.ToString());
            }
            return value;
        }

        public void SetGtValue(HValue value)
        {
            try
            {
                if (value == null)
                    this.Remove("gt");
                else
                    this["gt"] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the gt value attribute", e.ToString());
            }
        }

        public HValue GetGtValue()
        {
            HValue value = null;
            try
            {
                value = new HValue(JObject.Parse(this["gt"].ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the gt value attribute", e.ToString());
            }
            return value;
        }

        public void SetGteValue(HValue value)
        {
            try
            {
                if (value == null)
                    this.Remove("gte");
                else
                    this["gte"] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the gte value attribute", e.ToString());
            }
        }

        public HValue GetGteValue()
        {
            HValue value = null;
            try
            {
                value = new HValue(JObject.Parse(this["gte"].ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the gte value attribute", e.ToString());
            }
            return value;
        }

        public void SetLtValue(HValue value)
        {
            try
            {
                if (value == null)
                    this.Remove("lt");
                else
                    this["lt"] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the lt value attribute", e.ToString());
            }
        }

        public HValue GetLtValue()
        {
            HValue value = null;
            try
            {
                value = new HValue(JObject.Parse(this["lt"].ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the lt value attribute", e.ToString());
            }
            return value;
        }

        public void SetLteValue(HValue value)
        {
            try
            {
                if (value == null)
                    this.Remove("lte");
                else
                    this["lte"] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the lte value attribute", e.ToString());
            }
        }

        public HValue GetLteValue()
        {
            HValue value = null;
            try
            {
                value = new HValue(JObject.Parse(this["lte"].ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the lte value attribute", e.ToString());
            }
            return value;
        }

        public void SetInValue(HArrayOfValue value)
        {
            try
            {
                if (value == null)
                    this.Remove("in");
                else
                    this["in"] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the in value attribute", e.ToString());
            }
        }

        public HArrayOfValue GetInValue()
        {
            HArrayOfValue value = null;
            try
            {
                value = new HArrayOfValue(JObject.Parse(this["in"].ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the in value attribute", e.ToString());
            }
            return value;
        }

        public void SetNinValue(HArrayOfValue value)
        {
            try
            {
                if (value == null)
                    this.Remove("nin");
                else
                    this["nin"] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the nin value attribute", e.ToString());
            }
        }

        public HArrayOfValue GetNinValue()
        {
            HArrayOfValue value = null;
            try
            {
                value = new HArrayOfValue(JObject.Parse(this["nin"].ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the nin value attribute", e.ToString());
            }
            return value;
        }

        public void SetAndValue(JArray value)
        {
            try
            {
                if (value == null)
                    this.Remove("and");
                else
                    this["and"] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the and value attribute", e.ToString());
            }
        }

        public JArray GetAndValue()
        {
            JArray value = null;
            try
            {
                value = this["and"].ToObject<JArray>();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the and value attribute", e.ToString());
            }
            return value;
        }

        public void SetOrValue(JArray value)
        {
            try
            {
                if (value == null)
                    this.Remove("or");
                else
                    this["or"] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the or value attribute", e.ToString());
            }
        }

        public JArray GetOrValue()
        {
            JArray value = null;
            try
            {
                value = this["or"].ToObject<JArray>();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the or value attribute", e.ToString());
            }
            return value;
        }

        public void SetNorValue(JArray value)
        {
            try
            {
                if (value == null)
                    this.Remove("nor");
                else
                    this["nor"] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the nor value attribute", e.ToString());
            }
        }

        public JArray GetNorValue()
        {
            JArray value = null;
            try
            {
                value = this["nor"].ToObject<JArray>();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the nor value attribute", e.ToString());
            }
            return value;
        }

        public void SetNotValue(HCondition value)
        {
            try
            {
                if (value == null)
                    this.Remove("not");
                else
                    this["not"] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the not value attribute", e.ToString());
            }
        }

        public HCondition GetNotValue()
        {
            HCondition value = null;
            try
            {
                value = new HCondition(JObject.Parse(this["not"].ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the not value attribute", e.ToString());
            }
            return value;
        }
    }
}
