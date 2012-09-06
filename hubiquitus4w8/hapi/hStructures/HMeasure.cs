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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace hubiquitus4w8.hapi.hStructures
{
    /// <summary>
    /// Version 0.4
    /// Describes a measure payload
    /// </summary>
    class HMeasure : HJsonObj
    {

        private JObject hmeasure = new JObject();

        public HMeasure()
        {
        }

        public HMeasure(JObject jsonObj)
        {
            FromJson(jsonObj);
        }

        /* HJsonObj interface */

        public JObject ToJson()
        {
            return hmeasure;
        }

        public void FromJson(JObject jsonObj)
        {
            if (jsonObj != null)
            {
                this.hmeasure = jsonObj;
            }
            else
            {
                this.hmeasure = new JObject();
            }
        }

        public string GetHType()
        {
            return "hmeasure";
        }


        public override string ToString()
        {
            return hmeasure.ToString();
        }

        /// <summary>
        /// Check are made on : value, unit. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool equals(HMeasure obj)
        {
            if (obj.GetUnit() != this.GetUnit())
                return false;
            if (obj.GetValue() != this.GetValue())
                return false;
            return true;
        }


        public override int GetHashCode()
        {
            return hmeasure.GetHashCode();
        }

        // Getters & Setters 

        /// <summary>
        /// Specifies the unit in which the measure is expressed, should be in lowercase. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public string GetUnit()
        {
            string unit;
            try
            {
                unit = (string)hmeasure["unit"];
            }
            catch (ArgumentNullException)
            {
                unit = null;
            }
            return unit;
        }

        public void SetUnit(string unit)
        {
            try
            {
                if (unit == null)
                {
                    hmeasure.Remove("unit");
                }
                else
                {
                    hmeasure.Add("unit", unit);
                }
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }

        /// <summary>
        /// Specify the value of the measure (ie : 31.2). NULL if undefined
        /// </summary>
        /// <returns></returns>
        public string GetValue()
        {
            string value;
            try
            {
                value = (string)hmeasure["value"];
            }
            catch (ArgumentNullException)
            {
                value = null;
            }
            return value;
        }

        public void SetValue(string value)
        {
            try
            {
                if (value == null)
                {
                    hmeasure.Remove("value");
                }
                else
                {
                    hmeasure.Add("value", value);
                }
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }

    }
}
