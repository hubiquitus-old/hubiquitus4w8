/*
 * Copyright (c) Novedia Group 2012.
 *
 *     This file is part of Hubiquitus.
 *
 *     Hubiquitus is free software: you can redistribute it and/or modify
 *     it under the terms of the GNU General Public License as published by
 *     the Free Software Foundation, either version 3 of the License, or
 *     (at your option) any later version.
 *
 *     Hubiquitus is distributed in the hope that it will be useful,
 *     but WITHOUT ANY WARRANTY; without even the implied warranty of
 *     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *     GNU General Public License for more details.
 *
 *     You should have received a copy of the GNU General Public License
 *     along with Hubiquitus.  If not, see <http://www.gnu.org/licenses/>.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hubiquitus4w8.hapi.hStructures;
using Newtonsoft.Json.Linq;

namespace hubiquitus4w8.hapi.util
{
    class HJsonDictionnary : HJsonObj
    {
        private JObject jsonObj;

        public HJsonDictionnary()
        {
            jsonObj = new JObject();
        }

        public HJsonDictionnary(JObject jsonObj)
        {
            FromJson(jsonObj);
        }

        public object Get(string key)
        {
            object value;
            try
            {
                value = jsonObj[key];
            }
            catch (Exception)
            {
                value = null;
                throw;
            }
            return value;
        }

        public void Add(string key, object value)
        {
            try
            {
                if (value is HJsonObj)
                    jsonObj.Add(key, ((HJsonObj)value).ToJson());
                else if (value is JObject)
                    jsonObj.Add(key, (JObject)value);
                else if (value is JArray)
                    jsonObj.Add(key, (JArray)value);
                else if (value is Boolean)
                    jsonObj.Add(key, (Boolean)value);
                else if (value is int)
                    jsonObj.Add(key, (int)value);
                else if (value is double)
                    jsonObj.Add(key, (double)value);
                else if (value is String)
                    jsonObj.Add(key, (String)value);
                else if (value is DateTime)
                    jsonObj.Add(key, (DateTime)value);
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR in " + this.GetType());
                throw;
            }
        }

        public JObject ToJson()
        {
            return jsonObj;
        }

        public void FromJson(JObject jsonObj)
        {
            if (jsonObj != null)
                this.jsonObj = jsonObj;
            else
                this.jsonObj = new JObject();
        }

        public string GetHType()
        {
            return "hjsondictionnary";
        }

        public bool Equals(HJsonObj obj)
        {
            return jsonObj.Equals(obj);
        }

        public override int GetHashCode()
        {
            return jsonObj.GetHashCode();
        }

        public override string ToString()
        {
            return jsonObj.ToString();
        }
    }
}
